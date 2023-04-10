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
	/// 课程目标业务逻辑
	/// </summary>
	public class CourseTargetBusiness : BusinessBase, ICourseTargetBusiness
	{
        /// <summary>
		/// 获取或设置课程目标数据访问
		/// </summary>
		public ICourseTargetDataAccess CourseTargetDataAccess { get; set; }

        /// <summary>
		/// 新增课程目标
		/// </summary>
		/// <param name="courseTarget">课程目标</param>
		/// <return>课程目标</return>
		public virtual CourseTarget AddCourseTarget(CourseTarget courseTarget)
		{
			CourseTarget entity = this.CourseTargetDataAccess.AddCourseTarget(courseTarget);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, courseTarget.TableData);

			return entity;
		}

		/// <summary>
		/// 修改课程目标
		/// </summary>
		/// <param name="courseTarget">课程目标</param>
		/// <return>课程目标</return>
		public virtual CourseTarget UpdateCourseTarget(CourseTarget courseTarget)
		{
			CourseTarget entity = this.CourseTargetDataAccess.UpdateCourseTarget(courseTarget);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, courseTarget.TableData);

			return entity;
		}

		/// <summary>
		/// 删除课程目标
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveCourseTarget(long id)
		{
			CourseTarget entity = this.CourseTargetDataAccess.GetCourseTarget(id);

			this.CourseTargetDataAccess.RemoveCourseTarget(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取课程目标
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>课程目标</returns>
		public virtual CourseTarget GetCourseTarget(long id)
		{
			return this.CourseTargetDataAccess.GetCourseTarget(id);
		}

		/// <summary>
		/// 获取课程目标
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>课程目标</returns>
		public virtual CourseTarget GetCourseTargetOrDefault(long id, CourseTarget defaultEntity = null)
		{
			return this.CourseTargetDataAccess.GetCourseTargetOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取课程目标
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>课程目标</returns>
		public virtual CourseTarget GetCourseTarget(Expression<Func<CourseTarget, bool>> predicate)
		{
			return this.CourseTargetDataAccess.GetCourseTarget(predicate);
		}

		/// <summary>
		/// 根据条件获取课程目标
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>课程目标</returns>
		public virtual CourseTarget GetCourseTargetOrDefault(Expression<Func<CourseTarget, bool>> predicate, CourseTarget defaultEntity = null)
		{
			return this.CourseTargetDataAccess.GetCourseTargetOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询课程目标
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>课程目标集合</returns>
		public virtual List<CourseTarget> QueryCourseTarget(Expression<Func<CourseTarget, bool>> predicate, Pages pages = null)
		{
			return this.CourseTargetDataAccess.QueryCourseTarget(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询课程目标
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>课程目标集合</returns>
        public virtual List<CourseTarget> QueryCourseTarget(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<CourseTarget>();

            return this.CourseTargetDataAccess.QueryCourseTarget(predicate.Expand(), this.GetPredicate(typeof(CourseTarget), filter), pages);
        }
	}
}
