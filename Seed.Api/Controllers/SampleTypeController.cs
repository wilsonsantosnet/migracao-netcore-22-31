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
    public class SampleTypeController : ControllerBase<SampleTypeDto>
    {
        public SampleTypeController(ISampleTypeApplicationService app, ILoggerFactory logger, IWebHostEnvironment env)
            : base(app, logger, env, new ErrorMapCustom())
        {



        }

        [Authorize(Policy = "CanReadAll")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SampleTypeFilter filters)
        {
            return await base.Get<SampleTypeFilter>(filters, "Seed - SampleType");
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanReadOne")]
        public async Task<IActionResult> Get(int id, [FromQuery] SampleTypeFilter filters)
        {
            if (id.IsSent()) filters.SampleTypeId = id;
            return await base.GetOne(filters, "Seed - SampleType");
        }

        [Authorize(Policy = "CanSave")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SampleTypeDtoSpecialized dto)
        {
            return await base.Post(dto, "Seed - SampleType");
        }

        [Authorize(Policy = "CanEdit")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SampleTypeDtoSpecialized dto)
        {
            return await base.Put(dto, "Seed - SampleType");
        }
        [Authorize(Policy = "CanDelete")]
        [HttpDelete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, SampleTypeDtoSpecialized dto)
        {
            if (id.IsSent()) dto.SampleTypeId = id;
            return await base.Delete(dto, "Seed - SampleType");
        }
    }
}
