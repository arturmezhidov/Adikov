using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adikov.Domain.Commands.FaqItems;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.FaqCategories;
using Adikov.Domain.Queries.FaqRequests;
using Adikov.ViewModels.FaqItems;

namespace Adikov.Controllers
{
    public class FaqItemController : LayoutController
    {
        public ActionResult Index()
        {
            return View();
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
    }
}