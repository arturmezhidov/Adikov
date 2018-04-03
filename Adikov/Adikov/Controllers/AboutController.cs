using System.Web.Mvc;
using Adikov.Domain.Commands.About;
using Adikov.Domain.Queries.About;
using Adikov.Infrastructura.Commands;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;
using Adikov.Platform.Settings;
using Adikov.Services;
using Adikov.ViewModels.About;

namespace Adikov.Controllers
{
    public class AboutController : LayoutController
    {
        public ActionResult Index()
        {
            GetAboutQueryResults results = Query.For<GetAboutQueryResults>().With(new EmptyCriterion());

            AboutIndexViewModel vm = new AboutIndexViewModel
            {
                Header = ToViewModel(results.HeaderResult),
                Services = ToViewModel(results.ServicesResult),
                About = ToViewModel(results.AboutResult),
                Members = ToViewModel(results.MembersResult),
                Links = ToViewModel(results.LinksResult)
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Header()
        {
            GetAboutHeaderQueryResult result = Query.For<GetAboutHeaderQueryResult>().With(new EmptyCriterion());

            AboutHeaderEditViewModel vm = new AboutHeaderEditViewModel
            {
                Title = result.Header.Title,
                SubTitle = result.Header.SubTitle,
                LinkText = result.Header.LinkText,
                LinkUrl = result.Header.LinkUrl,
                BackgroundImageUrl = result.BackgroundImageUrl
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Header(AboutHeaderEditViewModel vm)
        {
            EditAboutHeaderCommand command = new EditAboutHeaderCommand
            {
                Header = new AboutHeader
                {
                    Title = vm.Title,
                    SubTitle = vm.SubTitle,
                    LinkText = vm.LinkText,
                    LinkUrl = vm.LinkUrl
                }
            };

            if (vm.BackgroundImage != null)
            {
                var result = SaveAs(vm.BackgroundImage, PlatformConfiguration.UploadedSettingsPath);

                if (result != null && result.ResultCode == CommandResultCode.Success)
                {
                    command.File = result.File;
                }
            }

            Command.Execute(command);

            return RedirectToAction("Index");
        }

        protected AboutHeaderViewModel ToViewModel(GetAboutHeaderQueryResult result)
        {
            AboutHeaderViewModel vm = Mapper.Map<AboutHeaderViewModel>(result.Header);
            vm.BackgroundImageUrl = result.BackgroundImageUrl;
            return vm;
        }

        protected AboutServicesViewModel ToViewModel(GetAboutServicesQueryResult result)
        {
            AboutServicesViewModel vm = Mapper.Map<AboutServicesViewModel>(result.Services);
            return vm;
        }

        protected AboutCompanyViewModel ToViewModel(GetAboutCompanyQueryResult result)
        {
            AboutCompanyViewModel vm = Mapper.Map<AboutCompanyViewModel>(result.AboutCompany);
            return vm;
        }

        protected AboutMembersViewModel ToViewModel(GetAboutMembersQueryResult result)
        {
            AboutMembersViewModel vm = Mapper.Map<AboutMembersViewModel>(result);
            return vm;
        }

        protected AboutLinksViewModel ToViewModel(GetAboutLinksQueryResult result)
        {
            AboutLinksViewModel vm = Mapper.Map<AboutLinksViewModel>(result.Links);
            vm.ImageUrl = result.ImageUrl;
            return vm;
        }
    }
}