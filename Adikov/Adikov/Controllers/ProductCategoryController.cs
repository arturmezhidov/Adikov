using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands;
using Adikov.Domain.Criterion;
using Adikov.Domain.Models;
using Adikov.Domain.Queries;
using Adikov.ViewModels.ProductCategory;

namespace Adikov.Controllers
{
    public class ProductCategoryController : LayoutController
    {
        public ActionResult Index(int? id)
        {
            var result = Query.For<FindAllProductCategoryQueryResult>().With(new EmptyCriterion());

            var vm = new ProductCategoryIndexViewModel
            {
                ActiveCategories = result.ActiveCategories.Select(ToViewModel),
                DeletedCategories = result.DeletedCategories.Select(ToViewModel)
            };

            if (id == null)
            {
                vm.NewProductCategory = new ProductCategoryViewModel();
            }
            else
            {
                var editCategory = result.ActiveCategories.FirstOrDefault(i => i.Id == id) ??
                                   result.DeletedCategories.FirstOrDefault(i => i.Id == id);

                if (editCategory == null)
                {
                    return RedirectToAction("Index");
                }

                vm.EditProductCategory = ToViewModel(editCategory);
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(ProductCategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Command.Execute(new AddProductCategoryCommand
            {
                Icon = vm.Icon,
                Name = vm.Name,
                Type = vm.Type
            });

            return RedirectToAction("Index");
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

        protected ProductCategoryViewModel ToViewModel(ProductCategory category)
        {
            return new ProductCategoryViewModel
            {
                Id = category.Id,
                Icon = category.Icon,
                Name = category.Name,
                Type = category.Type,
                IsDeleted = category.IsDeleted
            };
        }
    }
}