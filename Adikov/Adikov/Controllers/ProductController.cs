using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adikov.ViewModels.Product;
using Adikov.Domain.Queries.ProductAttribute;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Controllers
{
    public class ProductController : LayoutController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add(int categoryId)
        {
            FindActiveProductAttributeQueryResult attributes = Query.For<FindActiveProductAttributeQueryResult>().With(new EmptyCriterion());

            if(attributes.ActiveAttributes.Count == 0)
            {
                // TODO: Redirect to attributes add page.
            }

            ProductAddViewModel vm = new ProductAddViewModel
            {
                CategoryId = categoryId,
                AttributesListItems = attributes.ActiveAttributes
                    .Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(int categoryId, ProductAddViewModel product)
        {
            if (!ModelState.IsValid)
            {
                FindActiveProductAttributeQueryResult attributes = Query.For<FindActiveProductAttributeQueryResult>().With(new EmptyCriterion());

                if (attributes.ActiveAttributes.Count == 0)
                {
                    // TODO: Redirect to attributes add page.
                }

                ProductAddViewModel vm = new ProductAddViewModel
                {
                    CategoryId = categoryId,
                    AttributesListItems = attributes.ActiveAttributes
                        .Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        })
                };

                return View(product);
            }

            return View();
        }
    }
}