using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands.ProductCategory;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.ProductCategory;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;
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
                vm.NewProductCategory = new ProductCategoryAddViewModel();
            }
            else
            {
                var editCategory = result.ActiveCategories.FirstOrDefault(i => i.Id == id) ??
                                   result.DeletedCategories.FirstOrDefault(i => i.Id == id);

                if (editCategory == null)
                {
                    return RedirectToAction("Index");
                }

                vm.EditProductCategory = ToEditViewModel(editCategory);
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(ProductCategoryAddViewModel vm)
        {
            var result = SaveAs(vm.Image, PlatformConfiguration.UploadedProductCategoryPath);

            if (result != null)
            {
                Command.Execute(new AddProductCategoryCommand
                {
                    Icon = vm.Icon,
                    Name = vm.Name,
                    Type = vm.Type,
                    FileId = result.File.Id
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ProductCategoryEditViewModel vm)
        {
            var command = new EditProductCategoryCommand
            {
                Id = vm.Id,
                Icon = vm.Icon,
                Name = vm.Name
            };

            if (vm.Image != null)
            {
                var result = SaveAs(vm.Image, PlatformConfiguration.UploadedProductCategoryPath);

                if (result != null)
                {
                    command.FileId = result.File.Id;
                    command.IsFileChanged = true;
                }
            }

            Command.Execute(command);

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
                IsDeleted = category.IsDeleted,
                ImageUrl = GetUrl(category.File.PhysicalName, PlatformConfiguration.UploadedProductCategoryPath)
            };
        }

        protected ProductCategoryEditViewModel ToEditViewModel(ProductCategory category)
        {
            return new ProductCategoryEditViewModel
            {
                Id = category.Id,
                Icon = category.Icon,
                Name = category.Name,
                ImageUrl = GetUrl(category.File.PhysicalName, PlatformConfiguration.UploadedProductCategoryPath)
            };
        }
    }
}