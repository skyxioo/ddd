﻿using System.Web.Mvc;

namespace Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return
            View();
        }
    }
}