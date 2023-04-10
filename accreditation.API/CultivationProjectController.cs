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
    /// 培养计划控制器
    /// </summary>
    [Route("api/CultivationProject")]
    public class CultivationProjectController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置培养计划业务逻辑
		/// </summary>
		public ICultivationProjectBusiness CultivationProjectBusiness { get; set; }

        /// <summary>
        /// 新增培养计划
        /// </summary>
        /// <param name="cultivationProject">培养计划</param>
        /// <return>培养计划</return>
        [HttpPost, Route("add")]
        public IActionResult AddCultivationProject(CultivationProject cultivationProject)
        {
            CultivationProject result = this.CultivationProjectBusiness.AddCultivationProject(cultivationProject);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改培养计划
        /// </summary>
        /// <param name="cultivationProject">培养计划</param>
        /// <return>培养计划</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateCultivationProject(CultivationProject cultivationProject)
        {
            CultivationProject result = this.CultivationProjectBusiness.UpdateCultivationProject(cultivationProject);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除培养计划
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveCultivationProject(long id)
        {
            this.CultivationProjectBusiness.RemoveCultivationProject(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取培养计划
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>培养计划</returns>
        [HttpGet, Route("get")]
        public IActionResult GetCultivationProject(long id)
        {
            CultivationProject result = this.CultivationProjectBusiness.GetCultivationProject(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询培养计划
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>培养计划集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryCultivationProject(JObject filter)
        {
            List<CultivationProject> results = this.CultivationProjectBusiness.QueryCultivationProject(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
