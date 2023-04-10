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
    /// 学生信息控制器
    /// </summary>
    [Route("api/StudentInfo")]
    public class StudentInfoController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置学生信息业务逻辑
		/// </summary>
		public IStudentInfoBusiness StudentInfoBusiness { get; set; }

        /// <summary>
        /// 新增学生信息
        /// </summary>
        /// <param name="studentInfo">学生信息</param>
        /// <return>学生信息</return>
        [HttpPost, Route("add")]
        public IActionResult AddStudentInfo(StudentInfo studentInfo)
        {
            StudentInfo result = this.StudentInfoBusiness.AddStudentInfo(studentInfo);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="studentInfo">学生信息</param>
        /// <return>学生信息</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateStudentInfo(StudentInfo studentInfo)
        {
            StudentInfo result = this.StudentInfoBusiness.UpdateStudentInfo(studentInfo);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveStudentInfo(long id)
        {
            this.StudentInfoBusiness.RemoveStudentInfo(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>学生信息</returns>
        [HttpGet, Route("get")]
        public IActionResult GetStudentInfo(long id)
        {
            StudentInfo result = this.StudentInfoBusiness.GetStudentInfo(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询学生信息
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>学生信息集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryStudentInfo(JObject filter)
        {
            List<StudentInfo> results = this.StudentInfoBusiness.QueryStudentInfo(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
