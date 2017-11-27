using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adikov.Controllers
{
    public class ProductCategoryController : LayoutController
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
    }
}