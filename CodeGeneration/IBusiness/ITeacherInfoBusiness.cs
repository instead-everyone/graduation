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
	/// 教师信息业务逻辑接口
	/// </summary>
	public interface ITeacherInfoBusiness
	{
        /// <summary>
		/// 新增教师信息
		/// </summary>
		/// <param name="teacherInfo">教师信息</param>
		/// <return>教师信息</return>
		TeacherInfo AddTeacherInfo(TeacherInfo teacherInfo);

		/// <summary>
		/// 修改教师信息
		/// </summary>
		/// <param name="teacherInfo">教师信息</param>
		/// <return>教师信息</return>
		TeacherInfo UpdateTeacherInfo(TeacherInfo teacherInfo);

		/// <summary>
		/// 删除教师信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveTeacherInfo(long id);

		/// <summary>
		/// 获取教师信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>教师信息</returns>
		TeacherInfo GetTeacherInfo(long id);

		/// <summary>
		/// 获取教师信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教师信息</returns>
		TeacherInfo GetTeacherInfoOrDefault(long id, TeacherInfo defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取教师信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>教师信息</returns>
		TeacherInfo GetTeacherInfo(Expression<Func<TeacherInfo, bool>> predicate);

		/// <summary>
		/// 根据条件获取教师信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教师信息</returns>
		TeacherInfo GetTeacherInfoOrDefault(Expression<Func<TeacherInfo, bool>> predicate, TeacherInfo defaultEntity = null);

		/// <summary>
		/// 根据条件查询教师信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>教师信息集合</returns>
		List<TeacherInfo> QueryTeacherInfo(Expression<Func<TeacherInfo, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询教师信息
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教师信息集合</returns>
        List<TeacherInfo> QueryTeacherInfo(JObject filter, out Pages pages);
	}
}
