using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Web.Controllers
{
    public class ArchivesController : Controller
    {
        // GET: Archives
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}