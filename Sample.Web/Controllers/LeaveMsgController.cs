using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.IBLL;
using Sample.Model;
using Sample.WebHelper;

namespace Sample.Web.Controllers
{
    public class LeaveMsgController : Controller
    {
        ILeaveMsgService _leaveMsgService = OperateHelper.Current._serviceSession.LeaveMsgService;
        IVisitorService _visitorService = OperateHelper.Current._serviceSession.VisitorService;

        // GET: LeaveMsg
        public ActionResult Index()
        {
            //获取留言总数
            ViewBag.lvmCount = _leaveMsgService.GetListBy(p => p.Status == 1 && p.ParentId == 0).Count();

            //获取访客cookie信息
            int visitorId = 0;
            string visitorName = String.Empty;
            string visitorEmail = String.Empty;
            HttpCookie cookie = HttpContext.Request.Cookies["visitorCookie"];
            if(cookie != null)
            {
                if(int.TryParse(cookie.Value, out visitorId))
                {
                    Visitor visitor = _visitorService.GetListBy(v => v.Status == 1 && v.Id == visitorId).FirstOrDefault();
                    if(visitor != null)
                    {
                        visitorName = visitor.VisitorName;
                        visitorEmail = visitor.VisitorEmail;
                    }
                }
            }

            //将这三个参数绑定到留言框上的input标签中
            ViewBag.VisitorId = visitorId;
            ViewBag.VisitorName = visitorName;
            ViewBag.VisitorEmail = visitorEmail;

            return View();
        }
    }
}