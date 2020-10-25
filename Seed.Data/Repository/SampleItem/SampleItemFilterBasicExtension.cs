using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleItemFilterBasicExtension
    {

        public static IQueryable<SampleItem> WithBasicFilters(this IQueryable<SampleItem> queryBase, SampleItemFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.SampleItemId));

            if (filters.SampleItemId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.SampleItemId == filters.SampleItemId);
			}
            if (filters.Name.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Name.Contains(filters.Name));
			}
            if (filters.SampleId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.SampleId == filters.SampleId);
			}


            return queryFilter;
        }

		
    }
}