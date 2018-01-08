﻿using System.Web.Mvc;
using System.Linq;
using System.Linq.Expressions;
using Sample.IBLL;
using Sample.WebHelper;
using System.Collections.Generic;
using Sample.Model;
using System;
using Sample.Common;

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

            return Json(null);
        }
    }
}