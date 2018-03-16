using System.Web.Mvc;
using Adikov.Domain.Queries.Products;
using Adikov.ViewModels.ProductInfo;

namespace Adikov.Controllers
{
    public class ProductInfoController : LayoutController
    {
        // GET: ProductInfo
        public ActionResult Index(int id)
        {
            GetProductTableByIdQueryResult productTable = Query.For<GetProductTableByIdQueryResult>().ById(id);

            ProductInfoIndexViewModel vm = new ProductInfoIndexViewModel
            {
                Table = productTable.Table
            };

            return View(vm);
        }
    }
}