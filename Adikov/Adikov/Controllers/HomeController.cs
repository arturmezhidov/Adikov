using System.Web.Mvc;
using Adikov.Domain.Criterion;
using Adikov.Domain.Models;

namespace Adikov.Controllers
{
    public class HomeController : LayoutController
    {
        public ActionResult Index()
        {
            var t = Query.For<Product>().WithAll(new StringSizeCriterion("12"));

            return View(t);
        }
    }
}