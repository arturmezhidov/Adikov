using System;
using System.Web.Mvc;
using Adikov.Domain.Commands.Profile;
using Adikov.Platform.Configuration;
using Adikov.ViewModels.Profile;

namespace Adikov.Controllers
{
    [Authorize]
    public class ProfileController : LayoutController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Settings(UserProfileViewModel vm)
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Avatar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Avatar(AvatarViewModel vm)
        {
            var path = String.Format(PlatformConfiguration.UploadedUserPathTemplate, UserContext.UserId);
            var result = SaveAs(vm.Image, path);

            if (result != null)
            {
                Command.Execute(new UpdateAvatarCommand
                {
                    FileId = result.File.Id
                });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Security()
        {
            return View();
        }
    }
}