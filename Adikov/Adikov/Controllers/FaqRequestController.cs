using System.Web.Mvc;
using Adikov.Domain.Commands.FaqRequests;
using Adikov.Domain.Queries.FaqRequests;
using Adikov.Infrastructura.Criterion;
using Adikov.ViewModels.Faq;

namespace Adikov.Controllers
{
    public class FaqRequestController : LayoutController
    {
        public ActionResult Index()
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

            return RedirectToAction("Index");
        }

        public ActionResult DeclineRequest(int id)
        {
            Command.Execute(new DeclineFaqRequestCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        public ActionResult DeleteRequest(int id)
        {
            Command.Execute(new DeleteFaqRequestCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        public ActionResult RecoveryRequest(int id)
        {
            Command.Execute(new RecoveryFaqRequestCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        public ActionResult RemoveRequest(int id)
        {
            Command.Execute(new RemoveFaqRequestCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            Command.Execute(new FaqRequestCommand
            {
                Question = "Creates an array of array values not included in the other given arrays using SameValueZero for equality comparisons. "
            });

            return RedirectToAction("Index");
        }
    }
}