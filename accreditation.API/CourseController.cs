using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Mooho.Base.Common;
using accreditation.IBusiness;
using accreditation.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace accreditation.API.Admin
{
    /// <summary>
    /// 课程控制器
    /// </summary>
    [Route("api/Course")]
    public class CourseController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置课程业务逻辑
		/// </summary>
		public ICourseBusiness CourseBusiness { get; set; }

        /// <summary>
        /// 新增课程
        /// </summary>
        /// <param name="course">课程</param>
        /// <return>课程</return>
        [HttpPost, Route("add")]
        public IActionResult AddCourse(Course course)
        {
            Course result = this.CourseBusiness.AddCourse(course);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改课程
        /// </summary>
        /// <param name="course">课程</param>
        /// <return>课程</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateCourse(Course course)
        {
            Course result = this.CourseBusiness.UpdateCourse(course);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveCourse(long id)
        {
            this.CourseBusiness.RemoveCourse(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取课程
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>课程</returns>
        [HttpGet, Route("get")]
        public IActionResult GetCourse(long id)
        {
            Course result = this.CourseBusiness.GetCourse(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询课程
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>课程集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryCourse(JObject filter)
        {
            List<Course> results = this.CourseBusiness.QueryCourse(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
