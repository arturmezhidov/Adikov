using System.Web.Mvc;
using Adikov.Domain.Commands.FaqRequests;
using Adikov.Domain.Queries.FaqRequests;
using Adikov.Infrastructura.Criterion;
using Adikov.ViewModels.FaqRequests;

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

        [HttpPost]
        public ActionResult Add(AddFaqRequestViewModel vm)
        {
            if(vm == null || string.IsNullOrWhiteSpace(vm.Question))
            {
                return Json(new
                {
                    message = "Пожалуйста, введите вопрос!",
                    success = false
                });
            }

            try
            {
                Command.Execute(new FaqRequestCommand
                {
                    Question = vm.Question
                });

                return Json(new
                {
                    message = "Мы успешно получили Ваш вопрос!",
                    success = true
                });
            }
            catch
            {
                return Json(new
                {
                    message = "Произошла неизвестная ошибка!",
                    success = false
                });
            }
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
    }
}