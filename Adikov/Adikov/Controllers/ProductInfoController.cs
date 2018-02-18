using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adikov.Controllers
{
    public class ProductInfoController : LayoutController
    {
        // GET: ProductInfo
        public ActionResult Index(int id)
        {
            return View(id);
        }
    }
}