using System.Collections.Generic;

namespace Adikov.ViewModels.PriceListLinks
{
    public class IndexViewModel
    {
        public AddPriceListLinkViewModel AddLink { get; set; }

        public EditPriceListLinkViewModel EditLink { get; set; }

        public List<PriceListLinkViewModel> ActiveLinks { get; set; }

        public List<PriceListLinkViewModel> DeletedLinks { get; set; }
    }
}