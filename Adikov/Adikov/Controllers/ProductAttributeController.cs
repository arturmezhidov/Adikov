using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands.ProductAttribute;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.ProductAttribute;
using Adikov.Infrastructura.Criterion;
using Adikov.ViewModels.ProductAttribute;

namespace Adikov.Controllers
{
    public class ProductAttributeController : LayoutController
    {
        public ActionResult Index(int? id)
        {
            var result = Query.For<FindAllProductAttributeQueryResult>().With(new EmptyCriterion());

            var vm = new ProductAttributeIndexViewModel
            {
                ActiveAttributes = result.ActiveAttributes.Select(ToViewModel),
                DeletedAttributes = result.DeletedAttributes.Select(ToViewModel)
            };

            if (id == null)
            {
                vm.NewProductAttribute = new ProductAttributeViewModel();
            }
            else
            {
                var editAttribute = result.ActiveAttributes.FirstOrDefault(i => i.Id == id) ??
                                   result.DeletedAttributes.FirstOrDefault(i => i.Id == id);

                if (editAttribute == null)
                {
                    return RedirectToAction("Index");
                }

                vm.EditProductAttribute = ToViewModel(editAttribute);
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(AddProductAttributeCommand vm)
        {
            Command.Execute(new AddProductAttributeCommand
            {
                Name = vm.Name,
                Type = vm.Type
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ProductAttributeViewModel vm)
        {
            Command.Execute(new EditProductAttributeCommand
            {
                Id = vm.Id ?? 0,
                Name = vm.Name
            });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Command.Execute(new DeleteProductAttributeCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            Command.Execute(new ClearProductAttributeCommand());

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id)
        {
            Command.Execute(new RecoveryProductAttributeCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult RecoveryAll()
        {
            Command.Execute(new RecoveryAllProductAttributeCommand());

            return RedirectToAction("Index");
        }

        protected ProductAttributeViewModel ToViewModel(ProductAttribute category)
        {
            return new ProductAttributeViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Type = category.Type,
                IsDeleted = category.IsDeleted
            };
        }
    }
}