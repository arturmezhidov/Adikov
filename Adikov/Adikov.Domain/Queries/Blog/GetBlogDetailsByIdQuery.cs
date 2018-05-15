using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;

namespace Adikov.Domain.Queries.Blog
{
    public class GetBlogDetailsByIdQueryResult
    {
        public BlogView Blog { get; set; }

        public List<BlogView> LastBlogs { get; set; }

        public bool IsFound { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class GetBlogDetailsByIdQuery : Query<IdCriterion, GetBlogDetailsByIdQueryResult>
    {
        protected override GetBlogDetailsByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            Models.Blog item = DataContext.Blogs.Find(criterion.Id);

            GetBlogDetailsByIdQueryResult result = new GetBlogDetailsByIdQueryResult();

            if (item != null)
            {
                result.Blog = ToView(item);
                result.IsFound = true;
                result.IsDeleted = item.IsDeleted;

                result.LastBlogs = DataContext.Blogs
                    .Include(i => i.File)
                    .Where(i => !i.IsDeleted && i.IsPublished && i.Id != item.Id)
                    .OrderByDescending(i => i.CreatedDate)
                    .Take(10)
                    .AsEnumerable()
                    .Select(ToView)
                    .ToList();
            }

            return result;
        }

        protected BlogView ToView(Models.Blog blog)
        {
            return new BlogView
            {
                Id = blog.Id,
                Title = blog.Title,
                PreviewContent = blog.PreviewContent,
                HtmlContent = blog.HtmlContent,
                CreatedDate = blog.CreatedDate,
                ImageUrl = GetFileUrl(blog.File, PlatformConfiguration.UploadedBlogPathTemplate)
            };
        }
    }
}