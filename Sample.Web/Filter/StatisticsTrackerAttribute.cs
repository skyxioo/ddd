using System;
using System.Globalization;
using System.Web.Mvc;
using Sample.Common;
using Sample.Web.Helpers;

namespace Sample.Web.Filter
{
    /// <summary>
    /// 日志监控类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class StatisticsTrackerAttribute : ActionFilterAttribute, IExceptionFilter
    {
        private const string _key = "_thisOnActionMonitorKey_";

        #region Action时间监控
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            MonitorLog monitorLog = new MonitorLog();
            monitorLog.ExecuteStartTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.ffff", DateTimeFormatInfo.InvariantInfo));
            monitorLog.ControllerName = filterContext.RouteData.Values["controller"] as string;
            monitorLog.ActionName = filterContext.RouteData.Values["action"] as string;

            //将日志监控对象存入当前Controller的ViewData中
            filterContext.Controller.ViewData[_key] = monitorLog;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            MonitorLog monitorLog = filterContext.Controller.ViewData[_key] as MonitorLog;
            monitorLog.ExecuteEndTime = DateTime.Now;
            monitorLog.FormCollections = filterContext.HttpContext.Request.Form;
            monitorLog.QueryCollections = filterContext.HttpContext.Request.QueryString;

            //Action执行之后记录监控日志
            LogHelper.Monitor(monitorLog.GetLogInfo());
        }
        #endregion


        #region Result时间监控
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            MonitorLog monitorLog = filterContext.Controller.ViewData[_key] as MonitorLog;
            monitorLog.ExecuteStartTime = DateTime.Now;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            MonitorLog monitorLog = filterContext.Controller.ViewData[_key] as MonitorLog;
            monitorLog.ExecuteEndTime = DateTime.Now;
            LogHelper.Monitor(monitorLog.GetLogInfo(MonitorLog.MonitorType.View));
            //执行结束后清除ViewData
            filterContext.Controller.ViewData.Remove(_key);
        }
        #endregion

        #region 异常处理
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string controllerName =
                    string.Format("{0}Controller", filterContext.RouteData.Values["controller"] as string);
                string actionName = filterContext.RouteData.Values["action"] as string;
                string error = string.Format("在执行Controller[{0}]的Action[{1}]时发生异常。", controllerName, actionName);
                LogHelper.Error(error, filterContext.Exception);
            }
        } 
        #endregion
    }
}