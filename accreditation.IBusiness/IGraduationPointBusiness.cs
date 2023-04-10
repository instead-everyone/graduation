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
	/// 毕业指标点业务逻辑接口
	/// </summary>
	public interface IGraduationPointBusiness
	{
        /// <summary>
		/// 新增毕业指标点
		/// </summary>
		/// <param name="graduationPoint">毕业指标点</param>
		/// <return>毕业指标点</return>
		GraduationPoint AddGraduationPoint(GraduationPoint graduationPoint);

		/// <summary>
		/// 修改毕业指标点
		/// </summary>
		/// <param name="graduationPoint">毕业指标点</param>
		/// <return>毕业指标点</return>
		GraduationPoint UpdateGraduationPoint(GraduationPoint graduationPoint);

		/// <summary>
		/// 删除毕业指标点
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveGraduationPoint(long id);

		/// <summary>
		/// 获取毕业指标点
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>毕业指标点</returns>
		GraduationPoint GetGraduationPoint(long id);

		/// <summary>
		/// 获取毕业指标点
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>毕业指标点</returns>
		GraduationPoint GetGraduationPointOrDefault(long id, GraduationPoint defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取毕业指标点
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>毕业指标点</returns>
		GraduationPoint GetGraduationPoint(Expression<Func<GraduationPoint, bool>> predicate);

		/// <summary>
		/// 根据条件获取毕业指标点
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>毕业指标点</returns>
		GraduationPoint GetGraduationPointOrDefault(Expression<Func<GraduationPoint, bool>> predicate, GraduationPoint defaultEntity = null);

		/// <summary>
		/// 根据条件查询毕业指标点
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>毕业指标点集合</returns>
		List<GraduationPoint> QueryGraduationPoint(Expression<Func<GraduationPoint, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询毕业指标点
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>毕业指标点集合</returns>
        List<GraduationPoint> QueryGraduationPoint(JObject filter, out Pages pages);
	}
}
