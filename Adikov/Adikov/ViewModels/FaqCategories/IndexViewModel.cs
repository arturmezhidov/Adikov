using System.Collections.Generic;
using Adikov.Domain.Queries.FaqCategories;

namespace Adikov.ViewModels.FaqCategories
{
    public class IndexViewModel
    {
        public IEnumerable<FaqCategoryDetails> Categories { get; set; }

        public IEnumerable<FaqCategoryDetails> DeletedCategories { get; set; }

        public CategoryViewModel EditingCategory { get; set; }
    }
}