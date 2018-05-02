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

        public ActionResult Delete(int id)
        {
            Command.Execute(new DeleteFaqCategoryCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            Command.Execute(new ClearFaqCategoryCommand());

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id, bool? isAnswersPage = false)
        {
            Command.Execute(new RecoveryFaqCategoryCommand
            {
                Id = id
            });

            if (isAnswersPage.HasValue && isAnswersPage.Value)
            {
                return RedirectToAction("Index", "FaqItem");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Publish(int id, bool? isAnswersPage = false)
        {
            Command.Execute(new PublishFaqCategoryCommand
            {
                Id = id
            });

            if (isAnswersPage.HasValue && isAnswersPage.Value)
            {
                return RedirectToAction("Index", "FaqItem");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Unpublish(int id)
        {
            Command.Execute(new UnpublishFaqCategoryCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }
    }
}