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
    /// 考核分解项控制器
    /// </summary>
    [Route("api/AssessFragment")]
    public class AssessFragmentController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置考核分解项业务逻辑
		/// </summary>
		public IAssessFragmentBusiness AssessFragmentBusiness { get; set; }

        /// <summary>
        /// 新增考核分解项
        /// </summary>
        /// <param name="assessFragment">考核分解项</param>
        /// <return>考核分解项</return>
        [HttpPost, Route("add")]
        public IActionResult AddAssessFragment(AssessFragment assessFragment)
        {
            AssessFragment result = this.AssessFragmentBusiness.AddAssessFragment(assessFragment);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改考核分解项
        /// </summary>
        /// <param name="assessFragment">考核分解项</param>
        /// <return>考核分解项</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateAssessFragment(AssessFragment assessFragment)
        {
            AssessFragment result = this.AssessFragmentBusiness.UpdateAssessFragment(assessFragment);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除考核分解项
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveAssessFragment(long id)
        {
            this.AssessFragmentBusiness.RemoveAssessFragment(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取考核分解项
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>考核分解项</returns>
        [HttpGet, Route("get")]
        public IActionResult GetAssessFragment(long id)
        {
            AssessFragment result = this.AssessFragmentBusiness.GetAssessFragment(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询考核分解项
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>考核分解项集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryAssessFragment(JObject filter)
        {
            List<AssessFragment> results = this.AssessFragmentBusiness.QueryAssessFragment(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
