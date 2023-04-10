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
    /// ����
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ����
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="configuration">����</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;

            Config.Configuration = configuration;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="services">����</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // ���VUE��ַ��д
            services.Configure<RewriteOptions>(options =>
            {
                options.Add(new HistoryRewriteRule());
            });

            services.AddControllers(options =>
            {
                // ��̬������
                options.InputFormatters.Insert(0, new DynamicJsonInputFormatter());

                // ����������
                options.Filters.Add(typeof(AppActionFilterAttribute));
            })
            .AddNewtonsoftJson(options =>
            {
                // �ѳ�����תΪ�ַ��������jsvascript��������
                options.SerializerSettings.Converters.Add(new LongJsonConverter());

                // json��ת��Сд
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            }); ;

            // jwt��֤
            services.AddAuthentication(options =>
            {
                // ��֤MiddleWare����
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    // �����keyҪ���м��ܣ���Ҫ����Microsoft.IdentityModel.Tokens
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
        /// ����
        /// </summary>
        /// <param name="app">Ӧ��</param>
        /// <param name="env">����</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // IoC����
            Config.Container = app.ApplicationServices.GetAutofacRoot();

            // Ϊ��ȡ��ʵ�ͻ���IP HttpContext.Request.Headers["X-Forwarded-For"]
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

            // ���Vueҳ��ˢ��404����
            RewriteOptions rewriteOption = new RewriteOptions()
                .Add(new HistoryRewriteRule());
            app.UseRewriter(rewriteOption);

            // wwwroot��̬�ļ�
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            // Cors
            app.UseCors("cors");

            // jwt��֤
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

            // ϵͳ��ʼ��
            Config.Resolve<ISystemBusiness>().Init();

            // �ƻ������ʼ��
            //Config.Resolve<IPlanJobBusiness>().Init();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="builder">����������</param>
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
