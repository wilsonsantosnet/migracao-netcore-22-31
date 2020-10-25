using Common.Domain.Base;
using Common.Domain.CompositeKey;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Filter
{
    public class SampleItemFilterBase : FilterBase
    {

        public virtual int SampleItemId { get; set;} 
        public virtual string Name { get; set;} 
        public virtual int SampleId { get; set;} 


        public override string CompositeKey(CurrentUser user) {
            return CompositeKeyExtensions.MakeCompositeKey(this, $"{user.GetSubjectId<int>()}");
        }

    }
}
