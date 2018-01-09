﻿using System.Web.Mvc;
using System.Linq;
using System.Linq.Expressions;
using Sample.IBLL;
using Sample.WebHelper;
using System.Collections.Generic;
using Sample.Model;
using System;
using Sample.Common;
using Sample.Model.ViewModel;
using Sample.Model.FormatModel;

namespace Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService _articleService = OperateHelper.Current._serviceSession.ArticleService;
        private ICommentService _commentService = OperateHelper.Current._serviceSession.CommentService;

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="id">分类Id</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            return View(id);
        }

        /// <summary>
        /// 首页博文
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WrapArtList(int id)
        {
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int pageSize = Request["pageSize"] == null ? 8 : int.Parse(Request["pageSize"]);

            List<Article> articleList = new List<Article>();
            int totalCount = 0;            

            var whereExp = PredicateBuilder.True<Article>();
            if (id == 0)//取所有博文，对应首页<Home/Index/0>
            {
                whereExp.And(p => p.Status == 1);
                articleList = _articleService.GetPagedListBy(pageIndex, pageSize, whereExp, p => p.SubTime, true, out totalCount);
            }
            else
            {
                whereExp.And(p => p.Status == 1 && p.CategoryId == id);
                articleList = _articleService.GetPagedListBy(pageIndex, pageSize, whereExp, p => p.SubTime, true, out totalCount);
            }

            List<ArticleViewModel> articleViewList = new List<ArticleViewModel>();
            foreach (var item in articleList)
            {
                //获取博文类别名
                string categoryName = item.Category.Name;
                //获取关键词
                string[] keywords = null;
                List<string> keyList = new List<string>();
                if(!string.IsNullOrEmpty(item.Keywords))
                {
                    keywords = item.Keywords.Split(' ');
                    foreach (var word in keywords)
                    {
                        if (!string.IsNullOrEmpty(word))
                            keyList.Add(word);
                    }
                }
                //取前5个非空关键词
                keywords = keyList.Take(5).ToArray();
                //获取评论数
                int commentCount = _commentService.GetListBy(p => p.CmtArtId == item.Id && p.Status == 1).Count();

                //构造视图模型
                ArticleViewModel articleViewModel = new ArticleViewModel {
                    Id = item.Id,
                    Title = item.Title,
                    SubTime = item.SubTime.ToShortDateString(),
                    CategoryName = categoryName,
                    ViewCount = item.ViewCount,
                    CommentCount = commentCount,
                    Digg = item.Digg,
                    Contents = StringUtil.Truncate(item.ContentsRaw, 600),
                    Keywords = keywords
                };
                articleViewList.Add(articleViewModel);
            }

            //构造分页html
            string pagerNavString = PagerHelper.GerneratePagerString(pageIndex, pageSize, totalCount);
            React data = new React
            {
                code = 0,
                data = articleViewList,
                msg = "success",
                gotoUrl = HttpContext.Request.Url.AbsolutePath,
                pagedHtml = pagerNavString
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}