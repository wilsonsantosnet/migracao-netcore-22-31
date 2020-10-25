using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Interfaces.Services;

namespace Seed.Domain.Services
{
    public class SampleTypeService : SampleTypeServiceBase, ISampleTypeService
    {

        public SampleTypeService(ISampleTypeRepository rep, IValidatorSpecification<SampleType> validation, IWarningSpecification<SampleType> warning, ICache cache, CurrentUser user) 
            : base(rep, validation, warning, cache, user)
        {


        }
        
    }
}
