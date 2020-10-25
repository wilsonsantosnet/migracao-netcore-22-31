using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;

namespace Seed.Domain.Specifications
{
    public class SampleValidationWarningIsSuitableSpecification : ISpecification<Sample>
    {
        private readonly ISampleRepository _rep;
        public SampleValidationWarningIsSuitableSpecification(ISampleRepository rep)
        {
            this._rep = rep;
        }
        public bool IsSatisfiedBy(Sample entity)
        {
            return true;
        }
    }
}
