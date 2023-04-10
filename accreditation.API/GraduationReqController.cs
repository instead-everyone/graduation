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
    /// 毕业要求控制器
    /// </summary>
    [Route("api/GraduationReq")]
    public class GraduationReqController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置毕业要求业务逻辑
		/// </summary>
		public IGraduationReqBusiness GraduationReqBusiness { get; set; }

        /// <summary>
        /// 新增毕业要求
        /// </summary>
        /// <param name="graduationReq">毕业要求</param>
        /// <return>毕业要求</return>
        [HttpPost, Route("add")]
        public IActionResult AddGraduationReq(GraduationReq graduationReq)
        {
            GraduationReq result = this.GraduationReqBusiness.AddGraduationReq(graduationReq);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改毕业要求
        /// </summary>
        /// <param name="graduationReq">毕业要求</param>
        /// <return>毕业要求</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateGraduationReq(GraduationReq graduationReq)
        {
            GraduationReq result = this.GraduationReqBusiness.UpdateGraduationReq(graduationReq);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除毕业要求
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveGraduationReq(long id)
        {
            this.GraduationReqBusiness.RemoveGraduationReq(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取毕业要求
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>毕业要求</returns>
        [HttpGet, Route("get")]
        public IActionResult GetGraduationReq(long id)
        {
            GraduationReq result = this.GraduationReqBusiness.GetGraduationReq(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询毕业要求
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>毕业要求集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QueryGraduationReq(JObject filter)
        {
            List<GraduationReq> results = this.GraduationReqBusiness.QueryGraduationReq(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
