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
	/// 考核分解项业务逻辑接口
	/// </summary>
	public interface IAssessFragmentBusiness
	{
        /// <summary>
		/// 新增考核分解项
		/// </summary>
		/// <param name="assessFragment">考核分解项</param>
		/// <return>考核分解项</return>
		AssessFragment AddAssessFragment(AssessFragment assessFragment);

		/// <summary>
		/// 修改考核分解项
		/// </summary>
		/// <param name="assessFragment">考核分解项</param>
		/// <return>考核分解项</return>
		AssessFragment UpdateAssessFragment(AssessFragment assessFragment);

		/// <summary>
		/// 删除考核分解项
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveAssessFragment(long id);

		/// <summary>
		/// 获取考核分解项
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>考核分解项</returns>
		AssessFragment GetAssessFragment(long id);

		/// <summary>
		/// 获取考核分解项
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>考核分解项</returns>
		AssessFragment GetAssessFragmentOrDefault(long id, AssessFragment defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取考核分解项
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>考核分解项</returns>
		AssessFragment GetAssessFragment(Expression<Func<AssessFragment, bool>> predicate);

		/// <summary>
		/// 根据条件获取考核分解项
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>考核分解项</returns>
		AssessFragment GetAssessFragmentOrDefault(Expression<Func<AssessFragment, bool>> predicate, AssessFragment defaultEntity = null);

		/// <summary>
		/// 根据条件查询考核分解项
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>考核分解项集合</returns>
		List<AssessFragment> QueryAssessFragment(Expression<Func<AssessFragment, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询考核分解项
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>考核分解项集合</returns>
        List<AssessFragment> QueryAssessFragment(JObject filter, out Pages pages);
	}
}
