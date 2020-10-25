using Common.API;
using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seed.Application.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using Seed.Dto;
using Seed.CrossCuting;


namespace Seed.Api.Controllers
{
    [Authorize]
    [Route("api/SampleItem/more")]
    public class SampleItemMoreController : ControllerMoreBase<SampleItemDto, SampleItemFilter, SampleItem>
    {
        public SampleItemMoreController(ISampleItemRepository rep, ISampleItemApplicationService app, ILoggerFactory logger, EnviromentInfo env, CurrentUser user, ICache cache) 
            : base(rep, app, logger, env, user, cache, new ExportExcel<dynamic>(), new ErrorMapCustom())
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]SampleItemFilter filters)
        {
            return await base.Get(filters,typeof(SampleItem).Name, "Seed - SampleItem");
        }

        [Authorize(Policy = "CanWrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<SampleItemDtoSpecialized> dtos)
        {
            return await base.Post(dtos,  "Seed - SampleItem");
        }

        [Authorize(Policy = "CanWrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]IEnumerable<SampleItemDtoSpecialized> dtos)
        {
            return await base.Put(dtos, "Seed - SampleItem");
        }

    }
}
