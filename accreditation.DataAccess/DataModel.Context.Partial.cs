using Microsoft.EntityFrameworkCore;
using Mooho.Base.Common;
using accreditation.IDataAccess;
using System;

namespace accreditation.DataAccess
{
    /// <summary>
    /// 实体
    /// </summary>
    public partial class Entities : Mooho.Base.DataAccess.Entities
    {
        /// <summary>
        /// 构造实体
        /// </summary>
        /// <param name="options">选项</param>
        public Entities(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// 构造实体
        /// </summary>
        public Entities() : base(Config.IsMysql ? new DbContextOptionsBuilder().UseLazyLoadingProxies().UseMySql(Config.ConnectionString, ServerVersion.AutoDetect(Config.ConnectionString)).Options : new DbContextOptionsBuilder().UseLazyLoadingProxies().UseSqlServer(Config.ConnectionString).Options)
        {
            this.Database.SetCommandTimeout(300);
            //this.Configuration.AutoDetectChangesEnabled = false;
        }

        /// <summary>
        /// 模型设置
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void ModelSetting(ModelBuilder modelBuilder)
        {
        }
    }
}
