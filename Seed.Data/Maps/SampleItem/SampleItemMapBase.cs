using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class SampleItemMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<SampleItem> type);

        public SampleItemMapBase(EntityTypeBuilder<SampleItem> type)
        {
            
            type.ToTable("SampleItem");
            type.Property(t => t.SampleItemId).HasColumnName("Id");
           

            type.Property(t => t.Name).HasColumnName("Name").HasColumnType("varchar(150)");
            type.Property(t => t.SampleId).HasColumnName("SampleId");


            type.HasKey(d => new { d.SampleItemId, }); 

			CustomConfig(type);
        }
		
    }
}