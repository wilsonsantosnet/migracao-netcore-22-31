using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleItemOrderCustomExtension
    {

        public static IQueryable<SampleItem> OrderByDomain(this IQueryable<SampleItem> queryBase, SampleItemFilter filters)
        {
            return queryBase.OrderBy(_ => _.SampleItemId);
        }

    }
}

