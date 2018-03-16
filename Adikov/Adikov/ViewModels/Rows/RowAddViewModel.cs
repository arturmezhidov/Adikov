using Adikov.Domain.Queries.Products;
using Adikov.ViewModels.Forms;

namespace Adikov.ViewModels.Rows
{
    public class RowIndexViewModel
    {
        public bool IsEdittingMode { get; set; }

        public FormViewModel Form { get; set; }

        public ProductTable Table { get; set; }
    }
}