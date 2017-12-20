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
            //生成一个作业
            IJobDetail job = JobBuilder.Create<QuartzJob>()
                .WithIdentity("job1", "group1")
                .Build();

            //指定开始时间，20秒后第一次运行
            DateTimeOffset starTime = DateBuilder.NextGivenSecondDate(null, 20);
            //执行间隔
            TimeSpan ts = TimeSpan.FromSeconds(10);
            //创建触发器
            ITrigger trigger = TriggerBuilder.Create()
                .ForJob(job)
                .StartAt(starTime)
                .WithSimpleSchedule(x => x.WithInterval(ts).RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);
            scheduler.Start();
        }
    }
}
