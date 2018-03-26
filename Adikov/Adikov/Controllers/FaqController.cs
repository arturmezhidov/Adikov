using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;
using Adikov.ViewModels.Faq;

namespace Adikov.Controllers
{
    public class FaqController : LayoutController
    {
        public ActionResult Index()
        {
            //Command.Execute(new FaqRequestCommand
            //{
            //    Question = DateTime.Now + "Duis autem vel eum iriure dolor in hendrerit in vulputate. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut. "
            //});

            return View();
        }
    }
}