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
    /// 教师信息控制器
    /// </summary>
    [Route("api/TeacherInfo")]
    public class TeacherInfoController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置教师信息业务逻辑
		/// </summary>
		public ITeacherInfoBusiness TeacherInfoBusiness { get; set; }

        /// <summary>
        /// 新增教师信息
        /// </summary>
        /// <param name="teacherInfo">教师信息</param>
        /// <return>教师信息</return>
        [HttpPost, Route("add")]
        public IActionResult AddTeacherInfo(TeacherInfo teacherInfo)
        {
            TeacherInfo result = this.TeacherInfoBusiness.AddTeacherInfo(teacherInfo);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="teacherInfo">教师信息</param>
        /// <return>教师信息</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateTeacherInfo(TeacherInfo teacherInfo)
        {
            TeacherInfo result = this.TeacherInfoBusiness.UpdateTeacherInfo(teacherInfo);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除教师信息
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveTeacherInfo(long id)
        {
            this.TeacherInfoBusiness.RemoveTeacherInfo(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取教师信息
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>教师信息</returns>
        [HttpGet, Route("get")]
        public IActionResult GetTeacherInfo(long id)
        {
            TeacherInfo result = this.TeacherInfoBusiness.GetTeacherInfo(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询教师信息
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>教师信息集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryTeacherInfo(JObject filter)
        {
            List<TeacherInfo> results = this.TeacherInfoBusiness.QueryTeacherInfo(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
