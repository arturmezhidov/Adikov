using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adikov.Controllers
{
    public class ProductController : LayoutController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}