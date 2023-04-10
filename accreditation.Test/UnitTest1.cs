using LinqKit;
using Microsoft.Extensions.Configuration;
using Mooho.Base.Common;
using Mooho.Base.IBusiness;
using Mooho.Base.IDataAccess;
using accreditation.IBusiness;
using accreditation.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace accreditation.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
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
        }

        [Test]
        public void Test1()
        {

        }
    }
}