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
	/// 课程业务逻辑
	/// </summary>
	public class CourseBusiness : BusinessBase, ICourseBusiness
	{
        /// <summary>
		/// 获取或设置课程数据访问
		/// </summary>
		public ICourseDataAccess CourseDataAccess { get; set; }

        /// <summary>
		/// 新增课程
		/// </summary>
		/// <param name="course">课程</param>
		/// <return>课程</return>
		public virtual Course AddCourse(Course course)
		{
			Course entity = this.CourseDataAccess.AddCourse(course);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, course.TableData);

			return entity;
		}

		/// <summary>
		/// 修改课程
		/// </summary>
		/// <param name="course">课程</param>
		/// <return>课程</return>
		public virtual Course UpdateCourse(Course course)
		{
			Course entity = this.CourseDataAccess.UpdateCourse(course);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, course.TableData);

			return entity;
		}

		/// <summary>
		/// 删除课程
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveCourse(long id)
		{
			Course entity = this.CourseDataAccess.GetCourse(id);

			this.CourseDataAccess.RemoveCourse(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取课程
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>课程</returns>
		public virtual Course GetCourse(long id)
		{
			return this.CourseDataAccess.GetCourse(id);
		}

		/// <summary>
		/// 获取课程
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>课程</returns>
		public virtual Course GetCourseOrDefault(long id, Course defaultEntity = null)
		{
			return this.CourseDataAccess.GetCourseOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取课程
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>课程</returns>
		public virtual Course GetCourse(Expression<Func<Course, bool>> predicate)
		{
			return this.CourseDataAccess.GetCourse(predicate);
		}

		/// <summary>
		/// 根据条件获取课程
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>课程</returns>
		public virtual Course GetCourseOrDefault(Expression<Func<Course, bool>> predicate, Course defaultEntity = null)
		{
			return this.CourseDataAccess.GetCourseOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询课程
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>课程集合</returns>
		public virtual List<Course> QueryCourse(Expression<Func<Course, bool>> predicate, Pages pages = null)
		{
			return this.CourseDataAccess.QueryCourse(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询课程
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>课程集合</returns>
        public virtual List<Course> QueryCourse(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<Course>();

            return this.CourseDataAccess.QueryCourse(predicate.Expand(), this.GetPredicate(typeof(Course), filter), pages);
        }
	}
}
