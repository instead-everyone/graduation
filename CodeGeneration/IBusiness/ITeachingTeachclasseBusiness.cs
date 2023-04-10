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
	/// 教学班业务逻辑接口
	/// </summary>
	public interface ITeachingTeachclasseBusiness
	{
        /// <summary>
		/// 新增教学班
		/// </summary>
		/// <param name="teachingTeachclasse">教学班</param>
		/// <return>教学班</return>
		TeachingTeachclasse AddTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse);

		/// <summary>
		/// 修改教学班
		/// </summary>
		/// <param name="teachingTeachclasse">教学班</param>
		/// <return>教学班</return>
		TeachingTeachclasse UpdateTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse);

		/// <summary>
		/// 删除教学班
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveTeachingTeachclasse(long id);

		/// <summary>
		/// 获取教学班
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>教学班</returns>
		TeachingTeachclasse GetTeachingTeachclasse(long id);

		/// <summary>
		/// 获取教学班
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教学班</returns>
		TeachingTeachclasse GetTeachingTeachclasseOrDefault(long id, TeachingTeachclasse defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取教学班
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>教学班</returns>
		TeachingTeachclasse GetTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate);

		/// <summary>
		/// 根据条件获取教学班
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教学班</returns>
		TeachingTeachclasse GetTeachingTeachclasseOrDefault(Expression<Func<TeachingTeachclasse, bool>> predicate, TeachingTeachclasse defaultEntity = null);

		/// <summary>
		/// 根据条件查询教学班
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>教学班集合</returns>
		List<TeachingTeachclasse> QueryTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询教学班
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学班集合</returns>
        List<TeachingTeachclasse> QueryTeachingTeachclasse(JObject filter, out Pages pages);
	}
}
