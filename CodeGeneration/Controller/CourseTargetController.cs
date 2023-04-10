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
    /// 课程目标控制器
    /// </summary>
    [Route("api/CourseTarget")]
    public class CourseTargetController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置课程目标业务逻辑
		/// </summary>
		public ICourseTargetBusiness CourseTargetBusiness { get; set; }

        /// <summary>
        /// 新增课程目标
        /// </summary>
        /// <param name="courseTarget">课程目标</param>
        /// <return>课程目标</return>
        [HttpPost, Route("add")]
        public IActionResult AddCourseTarget(CourseTarget courseTarget)
        {
            CourseTarget result = this.CourseTargetBusiness.AddCourseTarget(courseTarget);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改课程目标
        /// </summary>
        /// <param name="courseTarget">课程目标</param>
        /// <return>课程目标</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateCourseTarget(CourseTarget courseTarget)
        {
            CourseTarget result = this.CourseTargetBusiness.UpdateCourseTarget(courseTarget);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除课程目标
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveCourseTarget(long id)
        {
            this.CourseTargetBusiness.RemoveCourseTarget(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取课程目标
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>课程目标</returns>
        [HttpGet, Route("get")]
        public IActionResult GetCourseTarget(long id)
        {
            CourseTarget result = this.CourseTargetBusiness.GetCourseTarget(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询课程目标
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>课程目标集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryCourseTarget(JObject filter)
        {
            List<CourseTarget> results = this.CourseTargetBusiness.QueryCourseTarget(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
