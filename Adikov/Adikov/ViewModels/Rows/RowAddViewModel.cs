using Adikov.Domain.Queries.Products;
using Adikov.ViewModels.Forms;

namespace Adikov.ViewModels.Rows
{
    public class RowAddViewModel
    {
        public FormViewModel Form { get; set; }

        public ProductTable Table { get; set; }
    }
}