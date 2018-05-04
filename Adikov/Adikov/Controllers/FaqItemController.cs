using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands.FaqItems;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.FaqCategories;
using Adikov.Domain.Queries.FaqItems;
using Adikov.Domain.Queries.FaqRequests;
using Adikov.Infrastructura.Criterion;
using Adikov.ViewModels.FaqItems;

namespace Adikov.Controllers
{
    public class FaqItemController : LayoutController
    {
        [HttpGet]
        public ActionResult Index()
        {
            GetAllFaqItemsQueryResult result = Query.For<GetAllFaqItemsQueryResult>().Empty();

            IndexViewModel vm = new IndexViewModel
            {
                ActiveItems = result.ActiveItems,
                DeletedItems = result.DeletedItems
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            FindFaqItemByIdQueryResult result = Query.For<FindFaqItemByIdQueryResult>().With(new IdCriterion(id));

            if (!result.IsFounded)
            {
                return RedirectToAction("Index");
            }

            FaqItemDetailsViewModel vm = ToViewModel(result.Item);

            return View(vm);
        }

        [HttpGet]
        public ActionResult Add(int? categoryId, int? requestId)
        {
            AddFaqItemViewModel vm = new AddFaqItemViewModel
            {
                FaqCategoryId = categoryId,
                RequestId = requestId,
                CategorySelectListItems = GetFaqCategoriesList(categoryId)
            };

            if (requestId.HasValue)
            {
                vm.Request = GetFaqRequestDetail(requestId.Value);
                vm.Title = vm.Request?.Question;
            }

            return View(vm);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Add(AddFaqItemViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.CategorySelectListItems = GetFaqCategoriesList(vm.FaqCategoryId);
                return View(vm);
            }

            Command.Execute(new AddFaqItemCommand
            {
                Title = vm.Title,
                ShortContent = vm.ShortContent,
                HtmlContent = vm.HtmlContent,
                FaqCategoryId = vm.FaqCategoryId.Value,
                RequestId = vm.RequestId,
                IsPublished = vm.IsPublished,
                IsHtmlContentDisplay = vm.IsHtmlContentDisplay,
                IsDysplayOnMainScreen = vm.IsDysplayOnMainScreen
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            FindFaqItemByIdQueryResult result = Query.For<FindFaqItemByIdQueryResult>().ById(id);

            if (!result.IsFounded)
            {
                return RedirectToAction("Index");
            }

            FaqItem item = result.Item;

            EditFaqItemViewModel vm = new EditFaqItemViewModel
            {
                Id = id,
                FaqCategoryId = item.FaqCategoryId,
                Title = item.Title,
                ShortContent = item.ShortContent,
                HtmlContent = item.HtmlContent,
                IsDysplayOnMainScreen = item.IsDysplayOnMainScreen,
                IsHtmlContentDisplay = item.IsHtmlContentDisplay,
                IsPublished = item.IsPublished,
                CategorySelectListItems = GetFaqCategoriesList(item.FaqCategoryId)
            };

            return View(vm);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(EditFaqItemViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.CategorySelectListItems = GetFaqCategoriesList(vm.FaqCategoryId);
                return View(vm);
            }

            Command.Execute(new EditFaqItemCommand
            {
                Id = vm.Id,
                Title = vm.Title,
                ShortContent = vm.ShortContent,
                HtmlContent = vm.HtmlContent,
                FaqCategoryId = vm.FaqCategoryId.Value,
                IsPublished = vm.IsPublished,
                IsHtmlContentDisplay = vm.IsHtmlContentDisplay,
                IsDysplayOnMainScreen = vm.IsDysplayOnMainScreen
            });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id, string redirectUrl = null)
        {
            Command.Execute(new DeleteFaqItemCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqItem");
        }

        public ActionResult Clear()
        {
            Command.Execute(new ClearFaqItemCommand());

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id, string redirectUrl = null)
        {
            Command.Execute(new RecoveryFaqItemCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqItem");
        }

        public ActionResult Publish(int id, string redirectUrl = null)
        {
            Command.Execute(new PublishFaqItemCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqItem");
        }

        public ActionResult Unpublish(int id, string redirectUrl = null)
        {
            Command.Execute(new UnpublishFaqItemCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqItem");
        }

        public ActionResult DisplayOnMainScreen(int id, string redirectUrl = null)
        {
            Command.Execute(new DisplayOnMainScreenFaqItemCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqItem");
        }

        public ActionResult HideOnMainScreen(int id, string redirectUrl = null)
        {
            Command.Execute(new HideOnMainScreenFaqItemCommand
            {
                Id = id
            });

            return Redirect(redirectUrl, "/FaqItem");
        }

        protected List<SelectListItem> GetFaqCategoriesList(int? categoryId = null)
        {
            IEnumerable<FaqCategory> categories = Query.For<FindFaqCategoriesQueryResult>().Empty().Categories;

            return categories.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == i.Id
            }).ToList();
        }

        protected FaqRequestDetail GetFaqRequestDetail(int requestId)
        {
            FindFaqRequestByIdQueryResult request = Query.For<FindFaqRequestByIdQueryResult>().ById(requestId);
            return request.RequestDetail;
        }

        protected FaqItemDetailsViewModel ToViewModel(FaqItem item)
        {
            return new FaqItemDetailsViewModel
            {
                Id = item.Id,
                Title = item.Title,
                ShortContent = item.ShortContent,
                HtmlContent = item.HtmlContent,
                IsDeleted = item.IsDeleted,
                IsPublished = item.IsPublished,
                IsDysplayOnMainScreen = item.IsDysplayOnMainScreen,
                IsHtmlContentDisplay = item.IsHtmlContentDisplay,
                FaqCategory = item.FaqCategory
            };
        }
    }
}