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
	/// 教师信息业务逻辑
	/// </summary>
	public class TeacherInfoBusiness : BusinessBase, ITeacherInfoBusiness
	{
        /// <summary>
		/// 获取或设置教师信息数据访问
		/// </summary>
		public ITeacherInfoDataAccess TeacherInfoDataAccess { get; set; }

        /// <summary>
		/// 新增教师信息
		/// </summary>
		/// <param name="teacherInfo">教师信息</param>
		/// <return>教师信息</return>
		public virtual TeacherInfo AddTeacherInfo(TeacherInfo teacherInfo)
		{
			TeacherInfo entity = this.TeacherInfoDataAccess.AddTeacherInfo(teacherInfo);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, teacherInfo.TableData);

			return entity;
		}

		/// <summary>
		/// 修改教师信息
		/// </summary>
		/// <param name="teacherInfo">教师信息</param>
		/// <return>教师信息</return>
		public virtual TeacherInfo UpdateTeacherInfo(TeacherInfo teacherInfo)
		{
			TeacherInfo entity = this.TeacherInfoDataAccess.UpdateTeacherInfo(teacherInfo);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, teacherInfo.TableData);

			return entity;
		}

		/// <summary>
		/// 删除教师信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveTeacherInfo(long id)
		{
			TeacherInfo entity = this.TeacherInfoDataAccess.GetTeacherInfo(id);

			this.TeacherInfoDataAccess.RemoveTeacherInfo(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取教师信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>教师信息</returns>
		public virtual TeacherInfo GetTeacherInfo(long id)
		{
			return this.TeacherInfoDataAccess.GetTeacherInfo(id);
		}

		/// <summary>
		/// 获取教师信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教师信息</returns>
		public virtual TeacherInfo GetTeacherInfoOrDefault(long id, TeacherInfo defaultEntity = null)
		{
			return this.TeacherInfoDataAccess.GetTeacherInfoOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取教师信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>教师信息</returns>
		public virtual TeacherInfo GetTeacherInfo(Expression<Func<TeacherInfo, bool>> predicate)
		{
			return this.TeacherInfoDataAccess.GetTeacherInfo(predicate);
		}

		/// <summary>
		/// 根据条件获取教师信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教师信息</returns>
		public virtual TeacherInfo GetTeacherInfoOrDefault(Expression<Func<TeacherInfo, bool>> predicate, TeacherInfo defaultEntity = null)
		{
			return this.TeacherInfoDataAccess.GetTeacherInfoOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询教师信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>教师信息集合</returns>
		public virtual List<TeacherInfo> QueryTeacherInfo(Expression<Func<TeacherInfo, bool>> predicate, Pages pages = null)
		{
			return this.TeacherInfoDataAccess.QueryTeacherInfo(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询教师信息
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教师信息集合</returns>
        public virtual List<TeacherInfo> QueryTeacherInfo(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<TeacherInfo>();

            return this.TeacherInfoDataAccess.QueryTeacherInfo(predicate.Expand(), this.GetPredicate(typeof(TeacherInfo), filter), pages);
        }
	}
}
