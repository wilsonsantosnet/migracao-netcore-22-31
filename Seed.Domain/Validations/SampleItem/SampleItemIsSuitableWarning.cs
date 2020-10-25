using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class SampleItemIsSuitableWarning : WarningSpecification<SampleItem>
    {
        public SampleItemIsSuitableWarning(ISampleItemRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleItem>(Instance of suitable warning specification,"message for user"));
        }

    }
}
