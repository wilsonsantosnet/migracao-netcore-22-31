using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class SampleItemIsConsistentValidation : ValidatorSpecification<SampleItem>
    {
        public SampleItemIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleItem>(Instance of is consistent specification,"message for user"));
        }

    }
}
