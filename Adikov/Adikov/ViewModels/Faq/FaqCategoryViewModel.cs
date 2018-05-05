using System.Collections.Generic;

namespace Adikov.ViewModels.Faq
{
    public class FaqCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<FaqItemViewModel> Items { get; set; }
    }
}