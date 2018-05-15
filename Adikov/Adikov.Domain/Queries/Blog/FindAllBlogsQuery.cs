using System.Collections.Generic;
using System.Linq;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Blog
{
    public class FindAllBlogsQueryResult
    {
        public List<Models.Blog> ActiveBlogs { get; set; }

        public List<Models.Blog> DeletedBlogs { get; set; }
    }

    public class FindAllBlogsQuery : Query<EmptyCriterion, FindAllBlogsQueryResult>
    {
        protected override FindAllBlogsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<Models.Blog> items = DataContext.Blogs.AsNoTracking().ToList();

            FindAllBlogsQueryResult result = new FindAllBlogsQueryResult
            {
                ActiveBlogs = items.Where(i => !i.IsDeleted).OrderBy(i => i.CreatedDate).ToList(),
                DeletedBlogs = items.Where(i => i.IsDeleted).OrderBy(i => i.CreatedDate).ToList()
            };

            return result;
        }
    }
}