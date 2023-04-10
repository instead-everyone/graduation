using Microsoft.Extensions.Configuration;
using Mooho.Base.Common;
using Mooho.Base.IBusiness;
using System;
using System.Reflection;
using Topshelf;

namespace accreditation.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Config.Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                Config.Container = IoCConfig.BuildContainer();

                Config.LoadEntityAssembly(Assembly.Load("accreditation.Model"));
                Config.LoadEntityAssembly(Assembly.Load("Mooho.Base.Model"));
                Config.LoadEntityAssembly(Assembly.Load("Mooho.Base.Common"));

                // 系统初始化
                Config.Resolve<ISystemBusiness>().Init();

                // 配置和运行宿主服务
                HostFactory.Run(x =>
                {
                    x.Service<SchedulerService>(s =>
                    {
                        // 指定服务类型。
                        s.ConstructUsing(name => new SchedulerService());

                        s.WhenStarted(tc => tc.OnStart());

                        s.WhenStopped(tc => tc.OnStop());

                        s.WhenPaused(tc => tc.OnStop());

                        s.WhenContinued(tc => tc.OnStop());
                    });

                    // 服务用本地系统账号来运行
                    x.RunAsLocalSystem();

                    // 服务描述信息
                    x.SetDescription("Template服务");
                    // 服务显示名称
                    x.SetDisplayName("Template.Service");
                    // 服务名称
                    x.SetServiceName("Template.Service");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
