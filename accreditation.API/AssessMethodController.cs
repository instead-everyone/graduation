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
    /// 考核方式控制器
    /// </summary>
    [Route("api/AssessMethod")]
    public class AssessMethodController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置考核方式业务逻辑
		/// </summary>
		public IAssessMethodBusiness AssessMethodBusiness { get; set; }

        /// <summary>
        /// 新增考核方式
        /// </summary>
        /// <param name="assessMethod">考核方式</param>
        /// <return>考核方式</return>
        [HttpPost, Route("add")]
        public IActionResult AddAssessMethod(AssessMethod assessMethod)
        {
            AssessMethod result = this.AssessMethodBusiness.AddAssessMethod(assessMethod);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改考核方式
        /// </summary>
        /// <param name="assessMethod">考核方式</param>
        /// <return>考核方式</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateAssessMethod(AssessMethod assessMethod)
        {
            AssessMethod result = this.AssessMethodBusiness.UpdateAssessMethod(assessMethod);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除考核方式
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveAssessMethod(long id)
        {
            this.AssessMethodBusiness.RemoveAssessMethod(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取考核方式
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>考核方式</returns>
        [HttpGet, Route("get")]
        public IActionResult GetAssessMethod(long id)
        {
            AssessMethod result = this.AssessMethodBusiness.GetAssessMethod(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询考核方式
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>考核方式集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryAssessMethod(JObject filter)
        {
            List<AssessMethod> results = this.AssessMethodBusiness.QueryAssessMethod(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
