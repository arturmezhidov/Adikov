using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        [HttpGet]
        public ActionResult Security()
        {
            return View();
        }
    }
}