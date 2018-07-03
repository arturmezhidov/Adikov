using Adikov.Domain.Commands.Users;
using Adikov.Domain.Queries.Users;
using Adikov.ViewModels.Users;
using System.Web.Mvc;

namespace Adikov.Controllers
{
    public class UserController : LayoutController
    {
        public ActionResult Index()
        {
            var vm = new UserIndexViewModel
            {
                Users = Query.For<GetAllUsersQueryResult>().Empty().Users
            };
            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var result = Query.For<GetUserByIdQueryResult>().ById(id);

            if (!result.IsFound)
            {
                return RedirectToAction("Index");
            }

            var user = result.User;

            var vm = new UserEditViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                About = user.About,
                Occupation = user.Occupation,
                Interests = user.Interests,
                Website = user.Website
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(UserEditViewModel user)
        {
            Command.Execute(new UpdateUserCommand
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                About = user.About,
                Occupation = user.Occupation,
                Interests = user.Interests,
                Website = user.Website
            });

            return RedirectToAction("Index");
        }

        public ActionResult Admin(string id, bool isAdmin)
        {
            if (isAdmin)
            {
                Command.Execute(new SetAdminUserCommand
                {
                    Id = id
                });
            }
            else
            {
                Command.Execute(new RemoveAdminUserCommand
                {
                    Id = id
                });
            }

            return RedirectToAction("Index");
        }

        public ActionResult Lock(string id, bool isLock)
        {
            if (isLock)
            {
                Command.Execute(new LockUserCommand
                {
                    Id = id
                });
            }
            else
            {
                Command.Execute(new UnlockUserCommand
                {
                    Id = id
                });
            }

            return RedirectToAction("Index");
        }
    }
}