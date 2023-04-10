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
    /// 教学大纲控制器
    /// </summary>
    [Route("api/Syllabuse")]
    public class SyllabuseController : AdminControllerBase
    {
        /// <summary>
		/// 获取或设置教学大纲业务逻辑
		/// </summary>
		public ISyllabuseBusiness SyllabuseBusiness { get; set; }

        /// <summary>
        /// 新增教学大纲
        /// </summary>
        /// <param name="syllabuse">教学大纲</param>
        /// <return>教学大纲</return>
        [HttpPost, Route("add")]
        public IActionResult AddSyllabuse(Syllabuse syllabuse)
        {
            Syllabuse result = this.SyllabuseBusiness.AddSyllabuse(syllabuse);

			return this.Ok(result);
        }

        /// <summary>
        /// 修改教学大纲
        /// </summary>
        /// <param name="syllabuse">教学大纲</param>
        /// <return>教学大纲</return>
        [HttpPut, Route("update")]
        public IActionResult UpdateSyllabuse(Syllabuse syllabuse)
        {
            Syllabuse result = this.SyllabuseBusiness.UpdateSyllabuse(syllabuse);

			return this.Ok(result);
        }

        /// <summary>
        /// 删除教学大纲
        /// </summary>
        /// <param name="id">唯一编号</param>
        [HttpDelete, Route("remove")]
        public IActionResult RemoveSyllabuse(long id)
        {
            this.SyllabuseBusiness.RemoveSyllabuse(id);

            return this.Ok();
        }

        /// <summary>
        /// 获取教学大纲
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>教学大纲</returns>
        [HttpGet, Route("get")]
        public IActionResult GetSyllabuse(long id)
        {
            Syllabuse result = this.SyllabuseBusiness.GetSyllabuse(id);

            return this.Ok(result);
        }

        /// <summary>
        /// 根据条件查询教学大纲
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>教学大纲集合</returns>
		[NoLog]
        [HttpPost, Route("query")]
        public IActionResult QuerySyllabuse(JObject filter)
        {
            List<Syllabuse> results = this.SyllabuseBusiness.QuerySyllabuse(filter, out Pages pages);

			return this.GetResponse(results, pages, filter);
        }
    }
}
