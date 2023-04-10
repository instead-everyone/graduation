using Mooho.Base.Common;
using Mooho.Base.IBusiness;
using Mooho.Base.Model;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace accreditation.Service
{
    /// <summary>
    /// 调度服务
    /// </summary>
    public class SchedulerService
    {
        // 调度器
        private IScheduler scheduler;

        // 线程
        private Thread thread;

        public void OnStart()
        {
            //调度器工厂
            ISchedulerFactory factory = new StdSchedulerFactory();

            //创建调度器
            scheduler = factory.GetScheduler().Result;

            // 计划任务
            List<PlanJob> planJobs = Config.Resolve<IPlanJobBusiness>().QueryPlanJob(x => !x.IsDisabled && !string.IsNullOrEmpty(x.Schedule));

            foreach (PlanJob planJob in planJobs)
            {
                Type jobType = Type.GetType(this.GetType().Namespace + ".Jobs." + planJob.Job);

                // 创建任务
                IJobDetail job = JobBuilder.Create(jobType)
                    .WithIdentity("Job" + planJob.ID.ToString())
                    .Build();

                // 创建触发器
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("Trigger" + planJob.ID.ToString())
                    .WithCronSchedule(planJob.Schedule)
                    .Build();

                // 将任务与触发器添加到调度器中
                scheduler.ScheduleJob(job, trigger);
            }

            scheduler.Start();

            // 静态服务线程
            thread = new Thread(new ThreadStart(ExecuteStaticJob));
            thread.Start();
        }

        /// <summary>
        /// 静态服务
        /// </summary>
        public void ExecuteStaticJob()
        {
            // 实时轮询任务
            List<PlanJob> planJobs = Config.Resolve<IPlanJobBusiness>().QueryPlanJob(x => !x.IsDisabled && string.IsNullOrEmpty(x.Schedule));

            while (planJobs.Count > 0)
            {
                foreach (PlanJob planJob in planJobs)
                {
                    Type jobType = Type.GetType(this.GetType().Namespace + "." + planJob.Job);

                    object obj = jobType.Assembly.CreateInstance(jobType.Namespace + "." + jobType.Name);

                    object[] para = { null };
                    jobType.GetMethod("Execute").Invoke(obj, para);
                }

                // 停30秒钟
                Thread.Sleep(30 * 1000);
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void OnStop()
        {
            // 在应用程序关闭时运行的代码
            if (scheduler != null)
            {
                scheduler.Shutdown(true);
            }

            if (thread != null)
            {
                thread.Interrupt();
            }
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void OnPause()
        {
            if (scheduler != null)
            {
                scheduler.PauseAll();
            }
        }

        /// <summary>
        /// 恢复
        /// </summary>
        public void OnContinue()
        {
            if (scheduler != null)
            {
                scheduler.ResumeAll();
            }
        }
    }
}
