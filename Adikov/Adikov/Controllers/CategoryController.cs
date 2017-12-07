using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands.Categories;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Categories;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;
using Adikov.ViewModels.Categories;

namespace Adikov.Controllers
{
    public class CategoryController : LayoutController
    {
        public ActionResult Index(int? id)
        {
            var result = Query.For<FindAllCategoryQueryResult>().With(new EmptyCriterion());

            var vm = new CategoryIndexViewModel
            {
                ActiveCategories = result.ActiveCategories.Select(ToViewModel),
                DeletedCategories = result.DeletedCategories.Select(ToViewModel)
            };

            if (id == null)
            {
                vm.NewCategory = new CategoryAddViewModel();
            }
            else
            {
                var editCategory = result.ActiveCategories.FirstOrDefault(i => i.Id == id) ??
                                   result.DeletedCategories.FirstOrDefault(i => i.Id == id);

                if (editCategory == null)
                {
                    return RedirectToAction("Index");
                }

                vm.EditCategory = ToEditViewModel(editCategory);
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(CategoryAddViewModel vm)
        {
            var result = SaveAs(vm.Image, PlatformConfiguration.UploadedProductCategoryPath);

            if (result != null)
            {
                Command.Execute(new AddCategoryCommand
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
        public ActionResult Edit(CategoryEditViewModel vm)
        {
            var command = new EditCategoryCommand
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
            Command.Execute(new DeleteCategoryCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            Command.Execute(new ClearCategoryCommand());

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id)
        {
            Command.Execute(new RecoveryCategoryCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult RecoveryAll()
        {
            Command.Execute(new RecoveryAllCategoryCommand());

            return RedirectToAction("Index");
        }

        protected CategoryViewModel ToViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Icon = category.Icon,
                Name = category.Name,
                Type = category.Type,
                IsDeleted = category.IsDeleted,
                ImageUrl = GetUrl(category.File.PhysicalName, PlatformConfiguration.UploadedProductCategoryPath)
            };
        }

        protected CategoryEditViewModel ToEditViewModel(Category category)
        {
            return new CategoryEditViewModel
            {
                Id = category.Id,
                Icon = category.Icon,
                Name = category.Name,
                ImageUrl = GetUrl(category.File.PhysicalName, PlatformConfiguration.UploadedProductCategoryPath)
            };
        }
    }
}