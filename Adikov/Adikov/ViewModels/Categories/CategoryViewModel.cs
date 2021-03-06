﻿namespace Adikov.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public int ProductCount { get; set; }

        public bool HasProducts { get; set; }
    }
}