using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adikov.Domain.Commands.Blog;
using Adikov.Domain.Queries.Blog;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;
using Adikov.ViewModels.Blog;

namespace Adikov.Controllers
{
    public class BlogController : LayoutController
    {
        [HttpGet]
        public ActionResult Index()
        {
            FindLastBlogsQueryResult result = Query.For<FindLastBlogsQueryResult>().With(new EmptyCriterion());

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
    }
}