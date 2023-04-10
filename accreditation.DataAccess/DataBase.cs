using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Mooho.Base.Common;
using Mooho.Base.DataAccess;
using Mooho.Base.IDataAccess;
using accreditation.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;

namespace accreditation.DataAccess
{
    /// <summary>
    /// 数据访问基类
    /// </summary>
    public class DataBase : Mooho.Base.DataAccess.DataBase
    {
        /// <summary>
        /// 获取数据上下文
        /// </summary>
        protected override Entities Context
        {
            get
            {
                if (CallContext<IEntities>.GetData("Entities") == null)
                {
                    CallContext<IEntities>.SetData("Entities", this.EntityFactory.CreateEntities());
                }

                return (Entities)CallContext<IEntities>.GetData("Entities");
            }
        }

        /// <summary>
        /// 初始化动态代理
        /// </summary>
        public override void InitDynamicProxy()
        {
            DynamicProxy.Init<Entities>();
        }
    }
}
