using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common
{
    public class MonitorLog
    {
        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public DateTime ExecuteStartTime { get; set; }

        public DateTime ExecuteEndTime { get; set; }

        /// <summary>
        /// Form表单数据
        /// </summary>
        public NameValueCollection FormCollections { get; set; }

        /// <summary>
        /// URL参数
        /// </summary>
        public NameValueCollection QueryCollections { get; set; }  

        /// <summary>
        /// 监控类型
        /// </summary>
        public enum MonitorType
        {
            Action = 1,
            View = 2
        }

        /// <summary>
        /// 获取日志监控信息
        /// </summary>
        /// <param name="mType"></param>
        /// <returns></returns>
        public string GetLogInfo(MonitorType mType = MonitorType.Action)
        {
            string actionView = "Action执行时间监控";
            string name = "Action";
            if (mType == MonitorType.View)
            {
                actionView = "View视图生成时间监控";
                name = "View";
            }

            string msg = @"
            {0}
            ControllerName：{1}Controller,
            {8}Name：{2}
            开始时间：{3}
            结束时间：{4}
            总 耗 时：{5}秒
            Form表单：{6}
            URL参数：{7}
                        ";
            return string.Format(msg,
                actionView,
                ControllerName,
                ActionName,
                ExecuteStartTime,
                ExecuteEndTime,
                (ExecuteEndTime - ExecuteStartTime).TotalSeconds,
                GetCollections(FormCollections),
                GetCollections(QueryCollections),
                name);
        }

        /// <summary>
        /// 获取POST或GET参数
        /// </summary>
        /// <param name="collections"></param>
        /// <returns></returns>
        private string GetCollections(NameValueCollection collections)
        {
            string parameters = string.Empty;
            if (collections != null)
            {
                foreach (string key in collections.Keys)
                {
                    parameters += string.Format("{0}={1}&", key, collections[key]);
                }
            }

            return parameters.TrimEnd('&');
        }
    }
}
