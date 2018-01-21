namespace Adikov.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public bool IsCategoryDeleted { get; set; }

        public string Table { get; set; }

        public bool IsTableDeleted { get; set; }

        public int TableId { get; set; }

        public bool IsDeleted { get; set; }
    }
}