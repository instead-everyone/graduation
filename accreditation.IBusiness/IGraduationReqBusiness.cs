using Mooho.Base.Common;
using accreditation.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace accreditation.IBusiness
{
	/// <summary>
	/// 毕业要求业务逻辑接口
	/// </summary>
	public interface IGraduationReqBusiness
	{
        /// <summary>
		/// 新增毕业要求
		/// </summary>
		/// <param name="graduationReq">毕业要求</param>
		/// <return>毕业要求</return>
		GraduationReq AddGraduationReq(GraduationReq graduationReq);

		/// <summary>
		/// 修改毕业要求
		/// </summary>
		/// <param name="graduationReq">毕业要求</param>
		/// <return>毕业要求</return>
		GraduationReq UpdateGraduationReq(GraduationReq graduationReq);

		/// <summary>
		/// 删除毕业要求
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveGraduationReq(long id);

		/// <summary>
		/// 获取毕业要求
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>毕业要求</returns>
		GraduationReq GetGraduationReq(long id);

		/// <summary>
		/// 获取毕业要求
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>毕业要求</returns>
		GraduationReq GetGraduationReqOrDefault(long id, GraduationReq defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取毕业要求
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>毕业要求</returns>
		GraduationReq GetGraduationReq(Expression<Func<GraduationReq, bool>> predicate);

		/// <summary>
		/// 根据条件获取毕业要求
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>毕业要求</returns>
		GraduationReq GetGraduationReqOrDefault(Expression<Func<GraduationReq, bool>> predicate, GraduationReq defaultEntity = null);

		/// <summary>
		/// 根据条件查询毕业要求
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>毕业要求集合</returns>
		List<GraduationReq> QueryGraduationReq(Expression<Func<GraduationReq, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询毕业要求
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>毕业要求集合</returns>
        List<GraduationReq> QueryGraduationReq(JObject filter, out Pages pages);
	}
}
