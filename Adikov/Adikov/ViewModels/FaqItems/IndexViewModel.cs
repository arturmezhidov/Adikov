using System.Collections.Generic;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.FaqItems;

namespace Adikov.ViewModels.FaqItems
{
    public class IndexViewModel
    {
        public IEnumerable<FaqItemCategory> ActiveItems { get; set; }

        public IEnumerable<FaqItem> DeletedItems { get; set; }
    }
}