using Sample.IBLL;
using Sample.WebHelper;
using Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Web.Controllers
{
    public class ArchivesController : Controller
    {
        IArticleService _articleService = OperateHelper.Current._serviceSession.ArticleService;

        // GET: Archives
        public ActionResult Index(int id)
        {
            Article article = _articleService.GetEntity(id);

            //获取博文关键词
            string[] keywords = null;
            if(!string.IsNullOrEmpty(article.Keywords))
            {
                keywords = article.Keywords.Split(' ');
            }
            ViewData["keywords"] = keywords;

            return View(article);
        }
    }
}