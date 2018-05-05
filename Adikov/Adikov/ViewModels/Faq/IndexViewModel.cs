using System.Collections.Generic;

namespace Adikov.ViewModels.Faq
{
    public class IndexViewModel
    {
        public IEnumerable<FaqCategoryViewModel> Categories { get; set; }
    }
}