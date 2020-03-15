using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Blog
{
    public class GetBlogByIdQueryResult
    {
        public Models.Blog Blog { get; set; }
        
        public bool IsFound { get; set; }
    }

    public class GetBlogByIdQuery : Query<IdCriterion, GetBlogByIdQueryResult>
    {
        protected override GetBlogByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            Models.Blog item = DataContext.Blogs.Find(criterion.Id);

            GetBlogByIdQueryResult result = new GetBlogByIdQueryResult
            {
                Blog = item,
                IsFound = item != null
            };

            return result;
        }
    }
}