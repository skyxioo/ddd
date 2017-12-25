using System.Web.Mvc;
using Sample.IBLL;
using Sample.WebHelper;

namespace Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService _articleService = OperateHelper.Current._serviceSession.ArticleService;

        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WrapArtList()
        {
            return Json(null);
        }
    }
}