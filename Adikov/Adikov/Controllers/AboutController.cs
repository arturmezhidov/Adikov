using System.Linq;
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

        [HttpGet]
        public ActionResult Services()
        {
            GetAboutServicesQueryResult result = Query.For<GetAboutServicesQueryResult>().With(new EmptyCriterion());

            AboutServicesViewModel vm = ToViewModel(result);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Services(AboutServicesViewModel vm)
        {
            Command.Execute(new EditAboutServicesCommand
            {
                Services = ToModel(vm)
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AboutCompany()
        {
            GetAboutCompanyQueryResult result = Query.For<GetAboutCompanyQueryResult>().With(new EmptyCriterion());

            AboutCompanyViewModel vm = ToViewModel(result);

            return View(vm);
        }

        [HttpPost]
        public ActionResult AboutCompany(AboutCompanyViewModel vm)
        {
            Command.Execute(new EditAboutCompanyCommand
            {
                About = ToModel(vm)
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Members()
        {
            GetAboutMembersQueryResult result = Query.For<GetAboutMembersQueryResult>().With(new EmptyCriterion());
            AboutMembersViewModel vm = ToViewModel(result);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Members(AboutMembersViewModel vm)
        {
            Command.Execute(new EditAboutMembersCommand
            {
                Members = ToModel(vm)
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Links()
        {
            GetAboutLinksQueryResult result = Query.For<GetAboutLinksQueryResult>().With(new EmptyCriterion());
            AboutLinksViewModel vm = ToViewModel(result);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Links(AboutLinksViewModel vm)
        {
            EditAboutLinksCommand command = new EditAboutLinksCommand
            {
                Links = ToModel(vm)
            };

            if (vm.Image != null)
            {
                var result = SaveAs(vm.Image, PlatformConfiguration.UploadedSettingsPath);

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
            vm.Members1 = result.Members.Select(i => new SelectListItem
            {
                Value = i.Id,
                Text = i.FullName,
                Selected = i.Id == result.Member1Id
            }).ToList();
            vm.Members2 = result.Members.Select(i => new SelectListItem
            {
                Value = i.Id,
                Text = i.FullName,
                Selected = i.Id == result.Member2Id
            }).ToList();
            vm.Members3 = result.Members.Select(i => new SelectListItem
            {
                Value = i.Id,
                Text = i.FullName,
                Selected = i.Id == result.Member3Id
            }).ToList();
            vm.Members4 = result.Members.Select(i => new SelectListItem
            {
                Value = i.Id,
                Text = i.FullName,
                Selected = i.Id == result.Member4Id
            }).ToList();
            return vm;
        }

        protected AboutMembersDetailsViewModel ToViewModel(GetAboutMembersDetailsQueryResult result)
        {
            AboutMembersDetailsViewModel vm = Mapper.Map<AboutMembersDetailsViewModel>(result);
            return vm;
        }

        protected AboutLinksViewModel ToViewModel(GetAboutLinksQueryResult result)
        {
            AboutLinksViewModel vm = Mapper.Map<AboutLinksViewModel>(result.Links);
            vm.ImageUrl = result.ImageUrl;
            return vm;
        }

        protected AboutServices ToModel(AboutServicesViewModel vm)
        {
            AboutServices model = Mapper.Map<AboutServices>(vm);
            return model;
        }

        protected AboutCompany ToModel(AboutCompanyViewModel vm)
        {
            AboutCompany model = Mapper.Map<AboutCompany>(vm);
            return model;
        }

        protected AboutMembers ToModel(AboutMembersViewModel vm)
        {
            AboutMembers model = Mapper.Map<AboutMembers>(vm);
            return model;
        }

        protected AboutLinks ToModel(AboutLinksViewModel vm)
        {
            AboutLinks model = Mapper.Map<AboutLinks>(vm);
            return model;
        }
    }
}