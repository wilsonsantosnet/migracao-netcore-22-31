using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Common.Validation;
using Microsoft.Extensions.DependencyInjection;
using Seed.Application;
using Seed.Application.Interfaces;
using Seed.Data.Context;
using Seed.Data.Repository;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Interfaces.Services;
using Seed.Domain.Services;
using Seed.Domain.Validations;

namespace Seed.Api
{
    public static partial class ConfigContainerSeed
    {

        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextSeed>>();
            
			services.AddScoped<IValidatorSpecification<Sample>,SampleIsSuitableValidation>();
			services.AddScoped<IWarningSpecification<Sample>, SampleIsSuitableWarning>();
			services.AddScoped<ISampleApplicationService, SampleApplicationService>();
			services.AddScoped<ISampleService, SampleService>();
			services.AddScoped<ISampleRepository, SampleRepository>();

			services.AddScoped<IValidatorSpecification<SampleType>,SampleTypeIsSuitableValidation>();
			services.AddScoped<IWarningSpecification<SampleType>, SampleTypeIsSuitableWarning>();
			services.AddScoped<ISampleTypeApplicationService, SampleTypeApplicationService>();
			services.AddScoped<ISampleTypeService, SampleTypeService>();
			services.AddScoped<ISampleTypeRepository, SampleTypeRepository>();

			services.AddScoped<IValidatorSpecification<SampleItem>,SampleItemIsSuitableValidation>();
			services.AddScoped<IWarningSpecification<SampleItem>, SampleItemIsSuitableWarning>();
			services.AddScoped<ISampleItemApplicationService, SampleItemApplicationService>();
			services.AddScoped<ISampleItemService, SampleItemService>();
			services.AddScoped<ISampleItemRepository, SampleItemRepository>();



            RegisterOtherComponents(services);
        }
    }
}
