using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Adikov.Domain.Commands.Profile;
using Adikov.Platform.Configuration;
using Adikov.ViewModels.Profile;
using Microsoft.AspNet.Identity.Owin;

namespace Adikov.Controllers
{
    [Authorize]
    public class ProfileController : LayoutController
    {
        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager => _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Settings()
        {
            UserProfileViewModel vm = new UserProfileViewModel
            {
                FirstName = UserContext.FirstName,
                LastName = UserContext.LastName,
                PhoneNumber = UserContext.PhoneNumber,
                Website = UserContext.Website,
                About = UserContext.About,
                Occupation = UserContext.Occupation,
                Interests = UserContext.Interests
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Settings(UserProfileViewModel vm)
        {
            Command.Execute(new UpdateProfileCommand
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                PhoneNumber = vm.PhoneNumber,
                Occupation = vm.Occupation,
                Interests = vm.Interests,
                About = vm.About,
                Website = vm.Website
            });

            await SignInManager.UpdateClaims(UserContext);

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