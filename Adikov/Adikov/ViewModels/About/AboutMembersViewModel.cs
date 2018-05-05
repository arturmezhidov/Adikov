using System.Collections.Generic;
using System.Web.Mvc;

namespace Adikov.ViewModels.About
{
    public class AboutMembersViewModel
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Member1Id { get; set; }

        public string Member2Id { get; set; }

        public string Member3Id { get; set; }

        public string Member4Id { get; set; }

        public List<SelectListItem> Members1 { get; set; }

        public List<SelectListItem> Members2 { get; set; }

        public List<SelectListItem> Members3 { get; set; }

        public List<SelectListItem> Members4 { get; set; }
    }
}