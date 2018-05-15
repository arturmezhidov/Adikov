using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;

namespace Adikov.Domain.Queries.Blog
{
    public class BlogView
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PreviewContent { get; set; }

        public string HtmlContent { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ImageUrl { get; set; }
    }

    public class FindLastBlogsQueryResult
    {
        public List<BlogView> Blogs { get; set; }
    }

    public class FindLastBlogsQuery : Query<EmptyCriterion, FindLastBlogsQueryResult>
    {
        protected override FindLastBlogsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<BlogView> items = DataContext.Blogs
                .Include(i => i.File)
                .Where(i => !i.IsDeleted && i.IsPublished)
                .OrderByDescending(i => i.CreatedDate)
                .Take(50)
                .AsEnumerable()
                .Select(ToView)
                .ToList();

            FindLastBlogsQueryResult result = new FindLastBlogsQueryResult
            {
                Blogs = items
            };

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