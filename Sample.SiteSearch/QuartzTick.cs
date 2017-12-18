using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Sample.SiteSearch
{
    public class QuartzTick
    {
        public static void StartJob()
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            //获取一个计划者
            IScheduler scheduler = factory.GetScheduler();

            IJobDetail job = JobBuilder.Create<>();
        }
    }
}
