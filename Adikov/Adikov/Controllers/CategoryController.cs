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
        public ActionResult Index()
        {
            var result = Query.For<FindAllCategoryDetailsQueryResult>().With(new EmptyCriterion());

            var vm = new CategoryIndexViewModel
            {
                ActiveCategories = result.ActiveCategories.Select(ToViewModel),
                DeletedCategories = result.DeletedCategories.Select(ToViewModel)
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CategoryAddViewModel vm)
        {
            var result = SaveAs(vm.Image, PlatformConfiguration.UploadedCategoryPath);

            if (result != null)
            {
                Command.Execute(new AddCategoryCommand
                {
                    Icon = vm.Icon,
                    Name = vm.Name,
                    FileId = result.File.Id
                });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            FindCategoryByIdQueryResult result = Query.For<FindCategoryByIdQueryResult>().ById(id);

            if (result?.Category == null)
            {
                return RedirectToAction("Index");
            }

            CategoryEditViewModel vm = ToEditViewModel(result.Category);

            return View(vm);
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
                var result = SaveAs(vm.Image, PlatformConfiguration.UploadedCategoryPath);

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

        public ActionResult SortUp(int categoryId)
        {
            Command.Execute(new SortUpCategoryCommand
            {
                CategoryId = categoryId
            });

            return RedirectToAction("Index");
        }

        public ActionResult SortDown(int categoryId)
        {
            Command.Execute(new SortDownCategoryCommand
            {
                CategoryId = categoryId
            });

            return RedirectToAction("Index");
        }

        protected CategoryViewModel ToViewModel(CategoryDetails category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Icon = category.Icon,
                Name = category.Name,
                IsDeleted = category.IsDeleted,
                ImageUrl = GetUrl(category.File.PhysicalName, PlatformConfiguration.UploadedCategoryPath),
                ProductCount = category.Products.Count(),
                HasProducts = category.HasProducts
            };
        }

        protected CategoryEditViewModel ToEditViewModel(Category category)
        {
            return new CategoryEditViewModel
            {
                Id = category.Id,
                Icon = category.Icon,
                Name = category.Name,
                ImageUrl = GetUrl(category.File.PhysicalName, PlatformConfiguration.UploadedCategoryPath)
            };
        }
    }
}