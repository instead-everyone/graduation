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
	/// 课程业务逻辑接口
	/// </summary>
	public interface ICourseBusiness
	{
        /// <summary>
		/// 新增课程
		/// </summary>
		/// <param name="course">课程</param>
		/// <return>课程</return>
		Course AddCourse(Course course);

		/// <summary>
		/// 修改课程
		/// </summary>
		/// <param name="course">课程</param>
		/// <return>课程</return>
		Course UpdateCourse(Course course);

		/// <summary>
		/// 删除课程
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveCourse(long id);

		/// <summary>
		/// 获取课程
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>课程</returns>
		Course GetCourse(long id);

		/// <summary>
		/// 获取课程
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>课程</returns>
		Course GetCourseOrDefault(long id, Course defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取课程
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>课程</returns>
		Course GetCourse(Expression<Func<Course, bool>> predicate);

		/// <summary>
		/// 根据条件获取课程
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>课程</returns>
		Course GetCourseOrDefault(Expression<Func<Course, bool>> predicate, Course defaultEntity = null);

		/// <summary>
		/// 根据条件查询课程
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>课程集合</returns>
		List<Course> QueryCourse(Expression<Func<Course, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询课程
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>课程集合</returns>
        List<Course> QueryCourse(JObject filter, out Pages pages);
	}
}
