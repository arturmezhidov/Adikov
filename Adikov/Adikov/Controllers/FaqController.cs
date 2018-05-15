using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Models;
using Adikov.Services;
using Adikov.ViewModels.Faq;
using Adikov.Domain.Queries.Faq;

namespace Adikov.Controllers
{
    public class FaqController : LayoutController
    {
        public ActionResult Index()
        {
            GetFaqQueryResult result = Query.For<GetFaqQueryResult>().Empty();

            IndexViewModel vm = new IndexViewModel
            {
                Categories = result.Categories.Select(ToViewModel)
            };

            return View(vm);
        }

        protected FaqCategoryViewModel ToViewModel(FaqCategory category)
        {
            FaqCategoryViewModel vm = Mapper.Map<FaqCategoryViewModel>(category);
            vm.Items = category.FaqItems.Select(ToViewModel);
            return vm;
        }

        protected FaqItemViewModel ToViewModel(FaqItem item)
        {
            FaqItemViewModel vm = Mapper.Map<FaqItemViewModel>(item);
            return vm;
        }
    }
}