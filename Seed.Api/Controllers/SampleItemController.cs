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
    public class SampleItemController : ControllerBase<SampleItemDto>
    {
        public SampleItemController(ISampleItemApplicationService app, ILoggerFactory logger, IWebHostEnvironment env)
            : base(app, logger, env, new ErrorMapCustom())
        {



        }

        [Authorize(Policy = "CanReadAll")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SampleItemFilter filters)
        {
            return await base.Get<SampleItemFilter>(filters, "Seed - SampleItem");
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanReadOne")]
        public async Task<IActionResult> Get(int id, [FromQuery] SampleItemFilter filters)
        {
            if (id.IsSent()) filters.SampleItemId = id;
            return await base.GetOne(filters, "Seed - SampleItem");
        }

        [Authorize(Policy = "CanSave")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SampleItemDtoSpecialized dto)
        {
            return await base.Post(dto, "Seed - SampleItem");
        }

        [Authorize(Policy = "CanEdit")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SampleItemDtoSpecialized dto)
        {
            return await base.Put(dto, "Seed - SampleItem");
        }
        [Authorize(Policy = "CanDelete")]
        [HttpDelete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, SampleItemDtoSpecialized dto)
        {
            if (id.IsSent()) dto.SampleItemId = id;
            return await base.Delete(dto, "Seed - SampleItem");
        }
    }
}
