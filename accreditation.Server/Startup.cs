using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Mooho.Base.API;
using Mooho.Base.Common;
using Mooho.Base.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace accreditation.Server
{
    /// <summary>
    /// 启动
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="configuration">配置</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;

            Config.Configuration = configuration;
        }

        /// <summary>
        /// 服务配置
        /// </summary>
        /// <param name="services">服务</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 解决VUE地址重写
            services.Configure<RewriteOptions>(options =>
            {
                options.Add(new HistoryRewriteRule());
            });

            services.AddControllers(options =>
            {
                // 动态对象处理
                options.InputFormatters.Insert(0, new DynamicJsonInputFormatter());

                // 动作拦截器
                options.Filters.Add(typeof(AppActionFilterAttribute));
            })
            .AddNewtonsoftJson(options =>
            {
                // 把长整型转为字符串，解决jsvascript精度问题
                options.SerializerSettings.Converters.Add(new LongJsonConverter());

                // json不转大小写
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            }); ;

            // jwt认证
            services.AddAuthentication(options =>
            {
                // 认证MiddleWare配置
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    // 这里的key要进行加密，需要引用Microsoft.IdentityModel.Tokens
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.Configuration.GetSection("Jwt:SecurityKey")?.Value ?? "")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });

            // CORS
            services.AddCors(
                option => option.AddPolicy("cors",
                    policy => policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = this.GetType().Assembly.GetName().Name, Version = "v1" });
                c.CustomSchemaIds(x => x.FullName);
            });

            services.AddControllersWithViews()
                .AddControllersAsServices();
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="app">应用</param>
        /// <param name="env">环境</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // IoC容器
            Config.Container = app.ApplicationServices.GetAutofacRoot();

            // 为获取真实客户端IP HttpContext.Request.Headers["X-Forwarded-For"]
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", this.GetType().Assembly.GetName().Name));
            }

            // 解决Vue页面刷新404问题
            RewriteOptions rewriteOption = new RewriteOptions()
                .Add(new HistoryRewriteRule());
            app.UseRewriter(rewriteOption);

            // wwwroot静态文件
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            // Cors
            app.UseCors("cors");

            // jwt认证
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Current.ApplicationServices = app.ApplicationServices;

            Config.LoadEntityAssembly(Assembly.Load("accreditation.Model"));
            Config.LoadEntityAssembly(Assembly.Load("Mooho.Base.Model"));
            Config.LoadEntityAssembly(Assembly.Load("Mooho.Base.Common"));

            // 系统初始化
            Config.Resolve<ISystemBusiness>().Init();

            // 计划任务初始化
            //Config.Resolve<IPlanJobBusiness>().Init();
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="builder">容器构造器</param>
        public void ConfigureContainer(ContainerBuilder builder)
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

            builder.RegisterAssemblyTypes(Assembly.Load("Mooho.Base.API"))
                .PropertiesAutowired();
            builder.RegisterAssemblyTypes(Assembly.Load("accreditation.API"))
                .PropertiesAutowired();

            builder.RegisterType<accreditation.DataAccess.DataBase>()
                .PropertiesAutowired()
                .InstancePerLifetimeScope()
                .As(typeof(Mooho.Base.IDataAccess.IDataBase));
        }
    }
}
