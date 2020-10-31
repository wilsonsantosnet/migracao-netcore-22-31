using AutoMapper;
using Common.API;
using Common.API.Extensions;
using Common.Domain.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Seed.Application.Config;
using Seed.CrossCuting;
using Seed.Data.Context;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace Seed.Api
{
    public class Startup
    {
		private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
			this._env = env;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.WriteIndented = false;
                options.JsonSerializerOptions.AllowTrailingCommas = true;
                options.JsonSerializerOptions.Converters.Add(new StringJsonConverter());
            }); 


            services.AddDbContext<DbContextSeed>(
             options => options.UseSqlServer(
                 Configuration
                    .GetSection("ConfigConnectionString:Default").Value));

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetSection("ConfigCache:Default").Value;
                options.InstanceName = "Seed";
            });

            services.Configure<ConfigSettingsBase>(Configuration.GetSection("ConfigSettings"));
			services.Configure<ConfigStorageConnectionStringBase>(Configuration.GetSection("ConfigStorage"));
            services.AddSingleton<IConfiguration>(Configuration);
			services.AddSingleton(new EnviromentInfo
            {
                RootPath = this._env.ContentRootPath
            });
			services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

			// Config AuthorityEndPoint SSO
			 services.AddAuthentication("Bearer")
			.AddIdentityServerAuthentication(options =>
			{
				options.Authority = Configuration.GetSection("ConfigSettings:AuthorityEndPoint").Value;
				options.RequireHttpsMetadata = false;
				options.ApiName = "ssosa";
			});


            // Add cross-origin resource sharing services Configurations
            var sp = services.BuildServiceProvider();
            var configuration = sp.GetService<IOptions<ConfigSettingsBase>>();
            
            Cors.Enable(services, configuration.Value.ClientAuthorityEndPoint.ToArray());


			services.AddAutoMapper(AutoMapperConfigSeed.RegisterMappings());

            // Add application services.
            ConfigContainerSeed.Config(services);

            // Add framework services.
            //services.AddMvc(options =>
            //{
            //    options.ModelBinderProviders.Insert(0, new DateTimePtBrModelBinderProvider());
            //    options.ModelBinderProviders.Insert(1, new NumberModelBinderProvider());
            //});
                //.AddNewtonsoftJson(); 

            // TODO : MIGRAÇÃO PROBLEMA 02
            //.AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.Converters.Add(new DateTimePtBrConverter());
            //    options.SerializerSettings.Converters.Add(new DecimalPtBrConverter());
            //});

            //Policys
            services.AddAuthorizationPolicy(ProfileCustom.Define);
			// Configurando o serviço do Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1",
            //        new Info
            //        {
            //            Title = "Target.Intranet",
            //            Version = "v1",
            //            Description = "Target.Intranet",

            //        });

            //    var caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
            //    var nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
            //    var caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");
            //    c.IncludeXmlComments(caminhoXmlDoc);

            //    c.AddSecurityDefinition("oauth2", new OAuth2Scheme
            //    {
            //        Type = "oauth2",
            //        Flow = "implicit",
            //        AuthorizationUrl = "http://localhost:4000/connect/authorize",
            //        Scopes = new Dictionary<string, string>
            //        {
            //            { "ssosa", "ssosa" },
            //        }
            //    });
            //    c.OperationFilter<AuthorizeCheckOperationFilter>();
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IOptions<ConfigSettingsBase> configSettingsBase)
        {

			if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            loggerFactory.AddFile(Configuration.GetSection("Logging"));


            var supportedCultures = new[]
            {
                new CultureInfo("pt-BR"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

           
           
            app.UseCors("AllowStackOrigin");
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.AddTokenMiddlewareCustom();
            app.UseEndpoints(_ => _.MapControllers());


            //Ativando middlewares para uso do Swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Target.Intranet");
            //    c.OAuthClientId("swagger-dash");
            //    c.OAuthAppName("swagger Dashboard");

            //});

          
        }

    }
}
