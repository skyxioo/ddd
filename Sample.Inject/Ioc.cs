using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace Sample.Inject
{
    public class Ioc
    {
        private static IApplicationContext SprintContext
        {
            get { return ContextRegistry.GetContext(); }
        }

        public static T GetObject<T>(string objectName) where T : class
        {
            return SprintContext.GetObject<T>(objectName);
        }
    }
}
