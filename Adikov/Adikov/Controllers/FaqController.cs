using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adikov.Domain.Commands.Faq;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Faq;
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

        public ActionResult Requests()
        {
            FindFaqRequestsQueryResult result = Query.For<FindFaqRequestsQueryResult>().With(new EmptyCriterion());

            RequestsViewModel vm = new RequestsViewModel
            {
                Requests = result.Requests
            };

            return View(vm);
        }

        public ActionResult OpenRequest(int id)
        {
            Command.Execute(new OpenFaqRequestCommand
            {
                Id = id
            });

            return RedirectToAction("Requests");
        }

        public ActionResult DeclineRequest(int id)
        {
            Command.Execute(new DeclineFaqRequestCommand
            {
                Id = id
            });

            return RedirectToAction("Requests");
        }

        public ActionResult DeleteRequest(int id)
        {
            Command.Execute(new DeleteFaqRequestCommand
            {
                Id = id
            });

            return RedirectToAction("Requests");
        }
    }
}