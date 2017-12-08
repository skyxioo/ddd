using System.Web.Mvc;
using Sample.Web.Filter;

namespace Sample.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new StatisticsTrackerAttribute());
        }
    }
}