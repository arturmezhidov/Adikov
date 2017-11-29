using System.Web.Mvc;
using Adikov.Domain.Commands;
using Adikov.Domain.Criterion;
using Adikov.Domain.Queries;
using Adikov.ViewModels.ProductCategory;

namespace Adikov.Controllers
{
    public class ProductCategoryController : LayoutController
    {
        // GET: Category
        public ActionResult Index()
        {
            var vm = new ProductCategoryIndexViewModel
            {
                ProductCategories = Query.For<FindAllProductCategoryQueryResult>().With(new EmptyCriterion())
            };

            return View(vm);
        }

        public ActionResult Delete(int id)
        {
            Command.Execute(new DeleteProductCategoryCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            Command.Execute(new ClearProductCategoryCommand());

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id)
        {
            Command.Execute(new RecoveryProductCategoryCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult RecoveryAll()
        {
            Command.Execute(new RecoveryAllProductCategoryCommand());

            return RedirectToAction("Index");
        }
    }
}