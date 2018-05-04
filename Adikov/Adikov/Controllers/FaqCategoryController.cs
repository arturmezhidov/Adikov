using System.Web.Mvc;
using Adikov.Domain.Commands.FaqCategories;
using Adikov.Domain.Queries.FaqCategories;
using Adikov.Infrastructura.Criterion;
using Adikov.ViewModels.FaqCategories;

namespace Adikov.Controllers
{
    public class FaqCategoryController : LayoutController
    {
        public ActionResult Index(int? id)
        {
            FindFaqCategoriesDetailsQueryResult result = Query.For<FindFaqCategoriesDetailsQueryResult>().With(new EmptyCriterion());

            IndexViewModel vm = new IndexViewModel
            {
                Categories = result.Categories,
                DeletedCategories = result.DeletedCategories
            };

            if (id.HasValue)
            {
                FindFaqCategoryByIdQueryResult category = Query.For<FindFaqCategoryByIdQueryResult>().ById(id.Value);

                if (category.IsFoundCategory)
                {
                    vm.EditingCategory = new CategoryViewModel
                    {
                        Id = category.Category.Id,
                        Name = category.Category.Name,
                        IsPublished = category.Category.IsPublished
                    };
                }
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel vm)
        {
            Command.Execute(new AddFaqCategoryCommand
            {
                CategoryName = vm.Name,
                IsPublished = vm.IsPublished
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel vm)
        {
            Command.Execute(new UpdateFaqCategoryCommand
            {
                Id = vm.Id,
                CategoryName = vm.Name,
                IsPublished = vm.IsPublished
            });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id, string redirectUrl = null)
        {
            Command.Execute(new DeleteFaqCategoryCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqCategory");
        }

        public ActionResult Clear()
        {
            Command.Execute(new ClearFaqCategoryCommand());

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id, string redirectUrl = null)
        {
            Command.Execute(new RecoveryFaqCategoryCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqCategory");
        }

        public ActionResult Publish(int id, string redirectUrl = null)
        {
            Command.Execute(new PublishFaqCategoryCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqCategory");
        }

        public ActionResult Unpublish(int id, string redirectUrl = null)
        {
            Command.Execute(new UnpublishFaqCategoryCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqCategory");
        }
    }
}