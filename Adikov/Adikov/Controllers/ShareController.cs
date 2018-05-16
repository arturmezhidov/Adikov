using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adikov.Domain.Commands.Shares;
using Adikov.Domain.Models;
using Adikov.Platform.Configuration;
using Adikov.ViewModels.Shares;

namespace Adikov.Controllers
{
    public class ShareController : LayoutController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddShareViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var result = SaveAs(vm.Image, PlatformConfiguration.SharesPath);

            if (result == null)
            {
                return View(vm);
            }

            Command.Execute(new AddShareCommand
            {
                Title = vm.Title,
                Description = vm.Description,
                EndDate = vm.EndDate,
                RibbonColor = vm.RibbonColor,
                RibbonText = vm.RibbonText,
                IsRibbonDisplayed = vm.IsRibbonDisplayed,
                FileId = result.File.Id
            });

            return RedirectToAction("Index");
        }
    }
}