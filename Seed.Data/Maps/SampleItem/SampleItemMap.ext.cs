using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class SampleItemMap : SampleItemMapBase
    {
        public SampleItemMap(EntityTypeBuilder<SampleItem> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<SampleItem> type)
        {

        }

    }
}