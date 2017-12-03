using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adikov.ViewModels.Product;

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
            return View(new ProductAddViewModel
            {
                CategoryId = categoryId
            });
        }

        [HttpPost]
        public ActionResult Add(int categoryId, ProductAddViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            return View();
        }
    }
}