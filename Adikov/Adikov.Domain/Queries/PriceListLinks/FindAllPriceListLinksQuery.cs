using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.PriceListLinks
{
    public class FindAllPriceListLinksQueryResult
    {
        public List<PriceListLink> ActiveLinks { get; set; }

        public List<PriceListLink> DeletedLinks { get; set; }
    }

    public class FindAllPriceListLinksQuery : Query<EmptyCriterion, FindAllPriceListLinksQueryResult>
    {
        protected override FindAllPriceListLinksQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<PriceListLink> items = DataContext.PriceListLinks.AsNoTracking().ToList();

            FindAllPriceListLinksQueryResult result = new FindAllPriceListLinksQueryResult
            {
                ActiveLinks = items.Where(i => !i.IsDeleted).OrderBy(i => i.OrderNumber).ToList(),
                DeletedLinks = items.Where(i => i.IsDeleted).OrderBy(i => i.OrderNumber).ToList()
            };

            return result;
        }
    }
}