using Autofac;
using Autofac.Extras.DynamicProxy;
using Mooho.Base.API;
using System;
using System.Reflection;

namespace accreditation.Test
{
    /// <summary>
    /// IoC配置
    /// </summary>
    public class IoCConfig
    {
        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="builder">构造器</param>
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<BusinessInterceptor>();
            builder.RegisterType<DataAccessInterceptor>();

            builder.RegisterAssemblyTypes(Assembly.Load("Mooho.Base.DataAccess"))
                .PropertiesAutowired()
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(DataAccessInterceptor));
            builder.RegisterAssemblyTypes(Assembly.Load("accreditation.DataAccess"))
                .PropertiesAutowired()
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(DataAccessInterceptor));
            builder.RegisterAssemblyTypes(Assembly.Load("Mooho.Base.Business"))
                .PropertiesAutowired()
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(BusinessInterceptor));
            builder.RegisterAssemblyTypes(Assembly.Load("accreditation.Business"))
                .PropertiesAutowired()
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(DataAccessInterceptor));
        }

        /// <summary>
        /// 创建容器
        /// </summary>
        /// <returns>容器</returns>
        public static IContainer BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            ConfigureContainer(builder);
            IContainer container = builder.Build();

            return container;
        }
    }
}
