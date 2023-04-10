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
	/// 教学大纲业务逻辑接口
	/// </summary>
	public interface ISyllabuseBusiness
	{
        /// <summary>
		/// 新增教学大纲
		/// </summary>
		/// <param name="syllabuse">教学大纲</param>
		/// <return>教学大纲</return>
		Syllabuse AddSyllabuse(Syllabuse syllabuse);

		/// <summary>
		/// 修改教学大纲
		/// </summary>
		/// <param name="syllabuse">教学大纲</param>
		/// <return>教学大纲</return>
		Syllabuse UpdateSyllabuse(Syllabuse syllabuse);

		/// <summary>
		/// 删除教学大纲
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveSyllabuse(long id);

		/// <summary>
		/// 获取教学大纲
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>教学大纲</returns>
		Syllabuse GetSyllabuse(long id);

		/// <summary>
		/// 获取教学大纲
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教学大纲</returns>
		Syllabuse GetSyllabuseOrDefault(long id, Syllabuse defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取教学大纲
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>教学大纲</returns>
		Syllabuse GetSyllabuse(Expression<Func<Syllabuse, bool>> predicate);

		/// <summary>
		/// 根据条件获取教学大纲
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教学大纲</returns>
		Syllabuse GetSyllabuseOrDefault(Expression<Func<Syllabuse, bool>> predicate, Syllabuse defaultEntity = null);

		/// <summary>
		/// 根据条件查询教学大纲
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>教学大纲集合</returns>
		List<Syllabuse> QuerySyllabuse(Expression<Func<Syllabuse, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询教学大纲
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学大纲集合</returns>
        List<Syllabuse> QuerySyllabuse(JObject filter, out Pages pages);
	}
}
