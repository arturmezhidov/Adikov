﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Adikov.ViewModels.Products
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TableId { get; set; }

        // Read only properties
        public List<SelectListItem> CategorySelectListItems { get; set; }

        public List<SelectListItem> TableSelectListItems { get; set; }
    }
}