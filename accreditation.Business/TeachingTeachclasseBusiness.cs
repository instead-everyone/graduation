using LinqKit;
using Mooho.Base.Common;
using Mooho.Base.IBusiness;
using Mooho.Base.Model;
using accreditation.IBusiness;
using accreditation.IDataAccess;
using accreditation.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace accreditation.Business
{
	/// <summary>
	/// 教学班业务逻辑
	/// </summary>
	public class TeachingTeachclasseBusiness : BusinessBase, ITeachingTeachclasseBusiness
	{
        /// <summary>
		/// 获取或设置教学班数据访问
		/// </summary>
		public ITeachingTeachclasseDataAccess TeachingTeachclasseDataAccess { get; set; }

        /// <summary>
		/// 新增教学班
		/// </summary>
		/// <param name="teachingTeachclasse">教学班</param>
		/// <return>教学班</return>
		public virtual TeachingTeachclasse AddTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse)
		{
			TeachingTeachclasse entity = this.TeachingTeachclasseDataAccess.AddTeachingTeachclasse(teachingTeachclasse);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, teachingTeachclasse.TableData);

			return entity;
		}

		/// <summary>
		/// 修改教学班
		/// </summary>
		/// <param name="teachingTeachclasse">教学班</param>
		/// <return>教学班</return>
		public virtual TeachingTeachclasse UpdateTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse)
		{
			TeachingTeachclasse entity = this.TeachingTeachclasseDataAccess.UpdateTeachingTeachclasse(teachingTeachclasse);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, teachingTeachclasse.TableData);

			return entity;
		}

		/// <summary>
		/// 删除教学班
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveTeachingTeachclasse(long id)
		{
			TeachingTeachclasse entity = this.TeachingTeachclasseDataAccess.GetTeachingTeachclasse(id);

			this.TeachingTeachclasseDataAccess.RemoveTeachingTeachclasse(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取教学班
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>教学班</returns>
		public virtual TeachingTeachclasse GetTeachingTeachclasse(long id)
		{
			return this.TeachingTeachclasseDataAccess.GetTeachingTeachclasse(id);
		}

		/// <summary>
		/// 获取教学班
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教学班</returns>
		public virtual TeachingTeachclasse GetTeachingTeachclasseOrDefault(long id, TeachingTeachclasse defaultEntity = null)
		{
			return this.TeachingTeachclasseDataAccess.GetTeachingTeachclasseOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取教学班
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>教学班</returns>
		public virtual TeachingTeachclasse GetTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate)
		{
			return this.TeachingTeachclasseDataAccess.GetTeachingTeachclasse(predicate);
		}

		/// <summary>
		/// 根据条件获取教学班
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教学班</returns>
		public virtual TeachingTeachclasse GetTeachingTeachclasseOrDefault(Expression<Func<TeachingTeachclasse, bool>> predicate, TeachingTeachclasse defaultEntity = null)
		{
			return this.TeachingTeachclasseDataAccess.GetTeachingTeachclasseOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询教学班
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>教学班集合</returns>
		public virtual List<TeachingTeachclasse> QueryTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate, Pages pages = null)
		{
			return this.TeachingTeachclasseDataAccess.QueryTeachingTeachclasse(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询教学班
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学班集合</returns>
        public virtual List<TeachingTeachclasse> QueryTeachingTeachclasse(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<TeachingTeachclasse>();

            return this.TeachingTeachclasseDataAccess.QueryTeachingTeachclasse(predicate.Expand(), this.GetPredicate(typeof(TeachingTeachclasse), filter), pages);
        }
	}
}
