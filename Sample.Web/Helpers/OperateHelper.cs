using System.Dynamic;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.SessionState;
using Sample.IBLL;
using Sample.Inject;

namespace Sample.Web.Helpers
{
    public class OperateHelper
    {
        public IServiceSession _serviceSession;

        public OperateHelper()
        {
            _serviceSession = Ioc.GetObject<IServiceSession>("ServiceSession");
        }

        public static OperateHelper Current
        {
            get
            {
                OperateHelper operateHelper = CallContext.GetData(typeof(OperateHelper).Name) as OperateHelper;
                if (operateHelper == null)
                {
                    operateHelper = new OperateHelper();
                    CallContext.SetData(typeof(OperateHelper).Name, operateHelper);
                }

                return operateHelper;
            }
        }

        public HttpContext ContextHttp
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public HttpRequest Request
        {
            get { return ContextHttp.Request; }
        }

        public HttpResponse Response
        {
            get { return ContextHttp.Response; }
        }

        public HttpSessionState Session
        {
            get { return ContextHttp.Session; }
        }
    }
}