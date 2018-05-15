using System.Web.Mvc;
using Adikov.Domain.Commands.Blog;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Blog;
using Adikov.Infrastructura.Commands;
using Adikov.Platform.Configuration;
using Adikov.ViewModels.Blog;

namespace Adikov.Controllers
{
    public class BlogController : LayoutController
    {
        [HttpGet]
        public ActionResult Index()
        {
            FindLastBlogsQueryResult result = Query.For<FindLastBlogsQueryResult>().Empty();

            IndexViewModel vm = new IndexViewModel
            {
                Blogs = result.Blogs
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            GetBlogDetailsByIdQueryResult result = Query.For<GetBlogDetailsByIdQueryResult>().ById(id);

            if (!result.IsFound)
            {
                return RedirectToAction("Index");
            }

            BlogDetailsViewModel vm = new BlogDetailsViewModel
            {
                Blog = result.Blog,
                LastBlogs = result.LastBlogs
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult List()
        {
            FindAllBlogsQueryResult result = Query.For<FindAllBlogsQueryResult>().Empty();

            ListViewModel vm = new ListViewModel
            {
                ActiveBlogs = result.ActiveBlogs,
                DeletedBlogs = result.DeletedBlogs
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(AddBlogViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            if (vm.Image == null)
            {
                ModelState.AddModelError("", "Выберите картинку!");
                return View(vm);
            }

            var result = SaveAs(vm.Image, PlatformConfiguration.UploadedBlogPath);

            AddBlogCommandResult commandResult =  Command.For<AddBlogCommandResult>().Execute(new AddBlogCommand
            {
                Title = vm.Title,
                PreviewContent = vm.PreviewContent,
                HtmlContent = vm.HtmlContent,
                IsPublished = vm.IsPublished,
                FileId = result.File.Id
            });

            return RedirectToAction("Details", new {id = commandResult.Blog.Id});
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GetBlogByIdQueryResult result = Query.For<GetBlogByIdQueryResult>().ById(id);

            if (!result.IsFound)
            {
                return RedirectToAction("Index");
            }

            EditBlogViewModel vm = ToEditViewModel(result.Blog);

            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditBlogViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            EditBlogCommand command = new EditBlogCommand
            {
                Id = vm.Id,
                Title = vm.Title,
                PreviewContent = vm.PreviewContent,
                HtmlContent = vm.HtmlContent,
                IsPublished = vm.IsPublished
            };

            if (vm.Image != null)
            {
                var result = SaveAs(vm.Image, PlatformConfiguration.UploadedBlogPath);

                if (result.ResultCode == CommandResultCode.Success && result.File != null)
                {
                    command.FileId = result.File.Id;
                }
            }

            Command.Execute(command);

            return RedirectToAction("Details", new { id = vm.Id });
        }

        public ActionResult Delete(int id)
        {
            Command.Execute(new DeleteBlogCommand
            {
                Id = id
            });

            return RedirectToAction("List");
        }

        public ActionResult Recovery(int id)
        {
            Command.Execute(new RecoveryBlogCommand
            {
                Id = id
            });

            return RedirectToAction("List");
        }

        public ActionResult Publish(int id)
        {
            Command.Execute(new PublishBlogCommand
            {
                Id = id
            });

            return RedirectToAction("List");
        }

        public ActionResult Unpublish(int id)
        {
            Command.Execute(new UnpublishBlogCommand
            {
                Id = id
            });

            return RedirectToAction("List");
        }

        protected EditBlogViewModel ToEditViewModel(Blog item)
        {
            return new EditBlogViewModel
            {
                Id = item.Id,
                Title = item.Title,
                PreviewContent = item.PreviewContent,
                HtmlContent = item.HtmlContent,
                IsPublished = item.IsPublished
            };
        }
    }
}