using System.Collections.Generic;
using Adikov.Domain.Queries.Blog;

namespace Adikov.ViewModels.Blog
{
    public class BlogDetailsViewModel
    {
        public BlogView Blog { get; set; }

        public List<BlogView> LastBlogs { get; set; }
    }
}