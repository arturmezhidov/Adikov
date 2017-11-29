﻿using System.Web.Mvc;
using Adikov.Domain.Criterion;
using Adikov.Domain.Models;

namespace Adikov.Controllers
{
    public class HomeController : LayoutController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}