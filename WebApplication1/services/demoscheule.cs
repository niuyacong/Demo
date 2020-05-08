using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.services
{
    public class demoscheule
    {
        public static void start()
        {
            ISchedulerFactory schedulefactory = new StdSchedulerFactory();//实例化调度器工厂
            IScheduler scheduler = schedulefactory.GetScheduler();//实例化调度器
            scheduler.Start();
            IJobDetail job1 = JobBuilder.Create<quartzdemo>()//创建一个作业
                .WithIdentity("demojob1", "groupa")
                .Build();

            ITrigger trigger1 = TriggerBuilder.Create()//创建一个触发器
                .WithIdentity("demotrigger1", "groupa")
                .StartNow()
                .WithSimpleSchedule(b => b.WithIntervalInSeconds(5)//5秒执行一次
                .RepeatForever())//无限循环执行
                .Build();
 
            scheduler.ScheduleJob(job1, trigger1);//把作业，触发器加入调度器


        }
    }
}