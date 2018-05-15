using System.Collections.Generic;
using System.Linq;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Blog
{
    public class FindActiveBlogsQueryResult
    {
        public List<Models.Blog> ActiveBlogs { get; set; }
    }

    public class FindActiveBlogsQuery : Query<EmptyCriterion, FindActiveBlogsQueryResult>
    {
        protected override FindActiveBlogsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<Models.Blog> items = DataContext.Blogs
                .AsNoTracking()
                .Where(i => !i.IsDeleted)
                .OrderBy(i => i.CreatedDate)
                .ToList();

            FindActiveBlogsQueryResult result = new FindActiveBlogsQueryResult
            {
                ActiveBlogs = items
            };

            return result;
        }
    }
}