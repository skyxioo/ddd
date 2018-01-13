using Sample.IBLL;
using Sample.WebHelper;
using Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.Common;
using Sample.Model.ViewModel;

namespace Sample.Web.Controllers
{
    public class ArchivesController : Controller
    {
        IArticleService _articleService = OperateHelper.Current._serviceSession.ArticleService;
        ICommentService _commentService = OperateHelper.Current._serviceSession.CommentService;

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

            //获取评论数
            var count = _commentService.GetListBy(p => p.Status == 1 && p.CmtArtId == article.CategoryId).Count();
            ViewBag.CmtCount = count;

            //百度分享的分享内容
            ViewBag.Share = StringUtil.Truncate(article.ContentsRaw, 100);//新浪微博只能输入104个字

            //前一篇后一篇处理
            var articles = _articleService.GetListBy(p => p.CategoryId == article.CategoryId && p.Status == 1, p => p.SubTime)
                .Select(p => new ArticlePagedViewModel {
                    Id = p.Id,
                    Title = p.Title
                }).ToList();
            if(articles.Count > 1)
            {
                if (id == articles[0].Id)
                    ViewBag.NextArticle = articles[1];
                else if(id == articles.Last().Id)
                    ViewBag.PreArticle = articles[articles.Count - 2];
                else
                {
                    var index = articles.IndexOf(articles.Find(p => p.Id == id));
                    ViewBag.PreArticle = articles[index - 1];
                    ViewBag.NextArticle = articles[index + 1];
                }
            }

            return View(article);
        }
    }
}