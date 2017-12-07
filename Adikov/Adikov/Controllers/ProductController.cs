using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adikov.Domain.Commands.Products;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Columns;
using Adikov.Infrastructura.Criterion;
using Adikov.ViewModels.Products;

namespace Adikov.Controllers
{
    public class ProductController : LayoutController
    {
        // GET: Product
        public ActionResult Index(int id)
        {
            return View(new ProductIndexViewModel());
        }

        [HttpGet]
        public ActionResult Add(int categoryId)
        {
            FindActiveColumnQueryResult attributes = Query.For<FindActiveColumnQueryResult>().With(new EmptyCriterion());

            if(attributes.ActiveColumns.Count == 0)
            {
                return RedirectToAction("Index", "Column");
            }

            ProductAddViewModel vm = new ProductAddViewModel
            {
                CategoryId = categoryId
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(ProductAddViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Add", new { categoryId = product.CategoryId });
            }

            AddProductCommandResult result = Command.For<AddProductCommandResult>().Execute(new AddProductCommand
            {
                Name = product.Name,
                CategoryId = product.CategoryId
            });

            return RedirectToAction("Index", new { id = result.Product.Id });
        }
    }
}