using Adikov.Domain.Commands.Messages;
using Adikov.Domain.Queries.Messages;
using Adikov.Services;
using Adikov.ViewModels.Messages;
using System.Linq;
using System.Web.Mvc;

namespace Adikov.Controllers
{
    public class MessageController : LayoutController
    {
        [HttpGet]
        public ActionResult Index()
        {
            GetMessagesQueryResult result = Query.For<GetMessagesQueryResult>().Empty();
            MessagesViewModel vm = ToViewModel(result);
            return View(vm);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            GetMessageQueryResult result = Query.For<GetMessageQueryResult>().ById(id);

            if (!result.IsFound)
            {
                return RedirectToAction("Index");
            }

            DetailsViewModel vm = new DetailsViewModel
            {
                Message = result.Message
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Read(int id)
        {
            Command.Execute(new ReadMessageCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Command.Execute(new DeleteMessageCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Clear(int id)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult KeepInTouchMessage(MessageViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        message = ModelState.Values.FirstOrDefault()?.Errors?.FirstOrDefault()?.ErrorMessage ?? "Введите корректную информацию!",
                        success = false
                    });
                }

                Command.Execute(new SendMessageCommand
                {
                    Username = vm.Username,
                    Email = vm.Email,
                    Phone = vm.Phone,
                    Content = vm.Content
                });

                return Json(new
                {
                    message = "Сообщение отправлено успешно!",
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

        protected MessagesViewModel ToViewModel(GetMessagesQueryResult model)
        {
            MessagesViewModel vm = Mapper.Map<MessagesViewModel>(model);
            return vm;
        }
    }
}