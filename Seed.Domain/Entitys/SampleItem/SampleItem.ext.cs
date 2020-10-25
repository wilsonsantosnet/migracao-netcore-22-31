using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class SampleItem : SampleItemBase
    {

        public SampleItem()
        {

        }

		 public SampleItem(int sampleitemid, string name, int sampleid) : base(sampleitemid, name, sampleid) { }


		public class SampleItemFactory : SampleItemFactoryBase
        {
            public SampleItem GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new SampleItemIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
