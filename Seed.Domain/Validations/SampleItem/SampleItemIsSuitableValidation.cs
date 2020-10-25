using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class SampleItemIsSuitableValidation : ValidatorSpecification<SampleItem>
    {
        public SampleItemIsSuitableValidation(ISampleItemRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleItem>(Instance of is suitable,"message for user"));
        }

    }
}
