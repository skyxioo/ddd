using System;
using log4net;

namespace Sample.WebHelper
{
    public class LogHelper
    {
        private static readonly ILog errorLog = LogManager.GetLogger("logerror");
        private static readonly ILog infoLog = LogManager.GetLogger("loginfo");
        private static readonly ILog monitorLog = LogManager.GetLogger("logmonitor");

        public static void Error(string error, Exception ex = null)
        {
            if(ex != null)
                errorLog.Error(error, ex);
            else
            {
                errorLog.Error(error);
            }
        }

        public static void Info(string msg)
        {
            infoLog.Info(msg);
        }

        public static void Monitor(string msg)
        {
            monitorLog.Info(msg);
        }
    }
}