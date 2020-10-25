using Common.Validation;
using Seed.Domain.Entitys;

namespace Seed.Domain.Specifications
{
    public class SampleValidationConsistentIsConsistentSpecification : ISpecification<Sample>
    {
        public bool IsSatisfiedBy(Sample entity)
        {
           return true;
        }
    }
}
