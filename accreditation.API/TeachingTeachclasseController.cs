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
    /// 教学班控制器
    /// </summary>
    [Route("api/TeachingTeachclasse")]
    public class TeachingTeachclasseController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置教学班业务逻辑
		/// </summary>
		public ITeachingTeachclasseBusiness TeachingTeachclasseBusiness { get; set; }

        /// <summary>
        /// 新增教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        /// <return>教学班</return>
        [HttpPost, Route("add")]
        public IActionResult AddTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse)
        {
            TeachingTeachclasse result = this.TeachingTeachclasseBusiness.AddTeachingTeachclasse(teachingTeachclasse);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        /// <return>教学班</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse)
        {
            TeachingTeachclasse result = this.TeachingTeachclasseBusiness.UpdateTeachingTeachclasse(teachingTeachclasse);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除教学班
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveTeachingTeachclasse(long id)
        {
            this.TeachingTeachclasseBusiness.RemoveTeachingTeachclasse(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取教学班
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>教学班</returns>
        [HttpGet, Route("get")]
        public IActionResult GetTeachingTeachclasse(long id)
        {
            TeachingTeachclasse result = this.TeachingTeachclasseBusiness.GetTeachingTeachclasse(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询教学班
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>教学班集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryTeachingTeachclasse(JObject filter)
        {
            List<TeachingTeachclasse> results = this.TeachingTeachclasseBusiness.QueryTeachingTeachclasse(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
