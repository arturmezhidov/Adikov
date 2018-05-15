using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.PriceListLinks
{
    public class FindActivePriceListLinksQueryResult
    {
        public List<PriceListLink> Links { get; set; }
    }

    public class FindActivePriceListLinksQuery : Query<EmptyCriterion, FindActivePriceListLinksQueryResult>
    {
        protected override FindActivePriceListLinksQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<PriceListLink> items = DataContext.PriceListLinks
                .AsNoTracking()
                .Where(i => !i.IsDeleted)
                .OrderBy(i => i.OrderNumber)
                .ToList();

            FindActivePriceListLinksQueryResult result = new FindActivePriceListLinksQueryResult
            {
                Links = items
            };

            return result;
        }
    }
}