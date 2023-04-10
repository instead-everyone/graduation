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
	/// 培养计划业务逻辑接口
	/// </summary>
	public interface ICultivationProjectBusiness
	{
        /// <summary>
		/// 新增培养计划
		/// </summary>
		/// <param name="cultivationProject">培养计划</param>
		/// <return>培养计划</return>
		CultivationProject AddCultivationProject(CultivationProject cultivationProject);

		/// <summary>
		/// 修改培养计划
		/// </summary>
		/// <param name="cultivationProject">培养计划</param>
		/// <return>培养计划</return>
		CultivationProject UpdateCultivationProject(CultivationProject cultivationProject);

		/// <summary>
		/// 删除培养计划
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveCultivationProject(long id);

		/// <summary>
		/// 获取培养计划
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>培养计划</returns>
		CultivationProject GetCultivationProject(long id);

		/// <summary>
		/// 获取培养计划
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>培养计划</returns>
		CultivationProject GetCultivationProjectOrDefault(long id, CultivationProject defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取培养计划
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>培养计划</returns>
		CultivationProject GetCultivationProject(Expression<Func<CultivationProject, bool>> predicate);

		/// <summary>
		/// 根据条件获取培养计划
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>培养计划</returns>
		CultivationProject GetCultivationProjectOrDefault(Expression<Func<CultivationProject, bool>> predicate, CultivationProject defaultEntity = null);

		/// <summary>
		/// 根据条件查询培养计划
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>培养计划集合</returns>
		List<CultivationProject> QueryCultivationProject(Expression<Func<CultivationProject, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询培养计划
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>培养计划集合</returns>
        List<CultivationProject> QueryCultivationProject(JObject filter, out Pages pages);
	}
}
