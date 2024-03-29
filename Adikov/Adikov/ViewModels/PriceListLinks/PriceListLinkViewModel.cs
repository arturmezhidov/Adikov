﻿namespace Adikov.ViewModels.PriceListLinks
{
    public class PriceListLinkViewModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string HtmlContent { get; set; }
    }
}