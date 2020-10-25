using Common.Domain.Interfaces;
using Seed.Application.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Services;
using Seed.Dto;
using System.Linq;
using System.Collections.Generic;
using Common.Domain.Base;
using Common.Domain.Model;
using AutoMapper;

namespace Seed.Application
{
    public class SampleItemApplicationService : SampleItemApplicationServiceBase
    {

        public SampleItemApplicationService(ISampleItemService service, IUnitOfWork uow, ICache cache, CurrentUser user, IMapper mapper) :
            base(service, uow, cache, user, mapper)
        {
  
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<SampleItem> dataList)
        {
            return base.MapperDomainToResult<SampleItemDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


    }
}
