using Mooho.Base.Common;
using accreditation.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace accreditation.IBusiness
{
	/// <summary>
	/// 课程目标业务逻辑接口
	/// </summary>
	public interface ICourseTargetBusiness
	{
        /// <summary>
		/// 新增课程目标
		/// </summary>
		/// <param name="courseTarget">课程目标</param>
		/// <return>课程目标</return>
		CourseTarget AddCourseTarget(CourseTarget courseTarget);

		/// <summary>
		/// 修改课程目标
		/// </summary>
		/// <param name="courseTarget">课程目标</param>
		/// <return>课程目标</return>
		CourseTarget UpdateCourseTarget(CourseTarget courseTarget);

		/// <summary>
		/// 删除课程目标
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveCourseTarget(long id);

		/// <summary>
		/// 获取课程目标
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>课程目标</returns>
		CourseTarget GetCourseTarget(long id);

		/// <summary>
		/// 获取课程目标
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>课程目标</returns>
		CourseTarget GetCourseTargetOrDefault(long id, CourseTarget defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取课程目标
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>课程目标</returns>
		CourseTarget GetCourseTarget(Expression<Func<CourseTarget, bool>> predicate);

		/// <summary>
		/// 根据条件获取课程目标
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>课程目标</returns>
		CourseTarget GetCourseTargetOrDefault(Expression<Func<CourseTarget, bool>> predicate, CourseTarget defaultEntity = null);

		/// <summary>
		/// 根据条件查询课程目标
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>课程目标集合</returns>
		List<CourseTarget> QueryCourseTarget(Expression<Func<CourseTarget, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询课程目标
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>课程目标集合</returns>
        List<CourseTarget> QueryCourseTarget(JObject filter, out Pages pages);
	}
}
