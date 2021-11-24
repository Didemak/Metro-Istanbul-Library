using LibraryMVC.Tasks.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC.Tasks.Triggers
{
    public class CezaArtirmaDusurme
    {
        public static void Baslat()
        {
            //Zamanlayıcı oluşturuyoruz
            IScheduler zamanlayici = StdSchedulerFactory.GetDefaultScheduler();
            //Zamanlayıcıyı çalıştırıyoruz
            if (!zamanlayici.IsStarted)
                zamanlayici.Start();
            //Tetiklenecek görevi belirtiyoruz
            IJobDetail gorev = JobBuilder.Create<CezaArtirmaDusurmeJob>().Build();
            //Tetikleyici oluşturuyoruz
            ICronTrigger tetikleyici = (ICronTrigger)TriggerBuilder.Create().WithIdentity("CezaArtirmaDusurmeJob", "null").WithCronSchedule("0 0 0 * * ? *").Build();
            //Zamanlayıcıya görevi ve tetikleyiciyi tanıtıyoruz
            zamanlayici.ScheduleJob(gorev, tetikleyici);
        }
    }
}