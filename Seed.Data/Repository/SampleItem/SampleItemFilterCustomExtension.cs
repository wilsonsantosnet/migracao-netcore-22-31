using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleItemFilterCustomExtension
    {

        public static IQueryable<SampleItem> WithCustomFilters(this IQueryable<SampleItem> queryBase, SampleItemFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<SampleItem> WithLimitTenant(this IQueryable<SampleItem> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

