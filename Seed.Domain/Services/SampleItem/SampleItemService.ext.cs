using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Interfaces.Services;

namespace Seed.Domain.Services
{
    public class SampleItemService : SampleItemServiceBase, ISampleItemService
    {

        public SampleItemService(ISampleItemRepository rep, IValidatorSpecification<SampleItem> validation, IWarningSpecification<SampleItem> warning, ICache cache, CurrentUser user) 
            : base(rep, validation, warning, cache, user)
        {


        }
        
    }
}
