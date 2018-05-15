using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.PriceListLinks
{
    public class GetPriceListLinkByIdQueryResult
    {
        public PriceListLink Link { get; set; }
        
        public bool IsFound { get; set; }
    }

    public class GetPriceListLinkByIdQuery : Query<IdCriterion, GetPriceListLinkByIdQueryResult>
    {
        protected override GetPriceListLinkByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            PriceListLink item = DataContext.PriceListLinks.Find(criterion.Id);

            GetPriceListLinkByIdQueryResult result = new GetPriceListLinkByIdQueryResult
            {
                Link = item,
                IsFound = item != null
            };

            return result;
        }
    }
}