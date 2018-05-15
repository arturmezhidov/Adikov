using System.Collections.Generic;

namespace Adikov.ViewModels.Blog
{
    public class ListViewModel
    {
        public List<Domain.Models.Blog> ActiveBlogs { get; set; }

        public List<Domain.Models.Blog> DeletedBlogs { get; set; }
    }
}