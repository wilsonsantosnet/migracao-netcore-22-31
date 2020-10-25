using Common.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Seed.Application.Interfaces;
using Seed.Domain.Filter;
using Seed.Dto;
using Seed.CrossCuting;
using System;

namespace Seed.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase<SampleDto>
    {
        public SampleController(ISampleApplicationService app, ILoggerFactory logger, IWebHostEnvironment env)
            : base(app, logger, env, new ErrorMapCustom())
        {



        }

        [Authorize(Policy = "CanReadAll")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SampleFilter filters)
        {
            return await base.Get<SampleFilter>(filters, "Seed - Sample");
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanReadOne")]
        public async Task<IActionResult> Get(int id, [FromQuery] SampleFilter filters)
        {
            if (id.IsSent()) filters.SampleId = id;
            return await base.GetOne(filters, "Seed - Sample");
        }

        [Authorize(Policy = "CanSave")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SampleDtoSpecialized dto)
        {
            return await base.Post(dto, "Seed - Sample");
        }

        [Authorize(Policy = "CanEdit")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SampleDtoSpecialized dto)
        {
            return await base.Put(dto, "Seed - Sample");
        }
        [Authorize(Policy = "CanDelete")]
        [HttpDelete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, SampleDtoSpecialized dto)
        {
            if (id.IsSent()) dto.SampleId = id;
            return await base.Delete(dto, "Seed - Sample");
        }
    }
}
