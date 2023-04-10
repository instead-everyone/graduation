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
	/// 考核方式业务逻辑接口
	/// </summary>
	public interface IAssessMethodBusiness
	{
        /// <summary>
		/// 新增考核方式
		/// </summary>
		/// <param name="assessMethod">考核方式</param>
		/// <return>考核方式</return>
		AssessMethod AddAssessMethod(AssessMethod assessMethod);

		/// <summary>
		/// 修改考核方式
		/// </summary>
		/// <param name="assessMethod">考核方式</param>
		/// <return>考核方式</return>
		AssessMethod UpdateAssessMethod(AssessMethod assessMethod);

		/// <summary>
		/// 删除考核方式
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveAssessMethod(long id);

		/// <summary>
		/// 获取考核方式
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>考核方式</returns>
		AssessMethod GetAssessMethod(long id);

		/// <summary>
		/// 获取考核方式
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>考核方式</returns>
		AssessMethod GetAssessMethodOrDefault(long id, AssessMethod defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取考核方式
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>考核方式</returns>
		AssessMethod GetAssessMethod(Expression<Func<AssessMethod, bool>> predicate);

		/// <summary>
		/// 根据条件获取考核方式
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>考核方式</returns>
		AssessMethod GetAssessMethodOrDefault(Expression<Func<AssessMethod, bool>> predicate, AssessMethod defaultEntity = null);

		/// <summary>
		/// 根据条件查询考核方式
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>考核方式集合</returns>
		List<AssessMethod> QueryAssessMethod(Expression<Func<AssessMethod, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询考核方式
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>考核方式集合</returns>
        List<AssessMethod> QueryAssessMethod(JObject filter, out Pages pages);
	}
}
