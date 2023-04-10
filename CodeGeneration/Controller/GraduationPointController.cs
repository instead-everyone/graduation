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
    /// 毕业指标点控制器
    /// </summary>
    [Route("api/GraduationPoint")]
    public class GraduationPointController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置毕业指标点业务逻辑
		/// </summary>
		public IGraduationPointBusiness GraduationPointBusiness { get; set; }

        /// <summary>
        /// 新增毕业指标点
        /// </summary>
        /// <param name="graduationPoint">毕业指标点</param>
        /// <return>毕业指标点</return>
        [HttpPost, Route("add")]
        public IActionResult AddGraduationPoint(GraduationPoint graduationPoint)
        {
            GraduationPoint result = this.GraduationPointBusiness.AddGraduationPoint(graduationPoint);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改毕业指标点
        /// </summary>
        /// <param name="graduationPoint">毕业指标点</param>
        /// <return>毕业指标点</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateGraduationPoint(GraduationPoint graduationPoint)
        {
            GraduationPoint result = this.GraduationPointBusiness.UpdateGraduationPoint(graduationPoint);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除毕业指标点
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveGraduationPoint(long id)
        {
            this.GraduationPointBusiness.RemoveGraduationPoint(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取毕业指标点
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>毕业指标点</returns>
        [HttpGet, Route("get")]
        public IActionResult GetGraduationPoint(long id)
        {
            GraduationPoint result = this.GraduationPointBusiness.GetGraduationPoint(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询毕业指标点
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>毕业指标点集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryGraduationPoint(JObject filter)
        {
            List<GraduationPoint> results = this.GraduationPointBusiness.QueryGraduationPoint(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
