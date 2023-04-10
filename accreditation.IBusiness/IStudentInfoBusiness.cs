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
	/// 学生信息业务逻辑接口
	/// </summary>
	public interface IStudentInfoBusiness
	{
        /// <summary>
		/// 新增学生信息
		/// </summary>
		/// <param name="studentInfo">学生信息</param>
		/// <return>学生信息</return>
		StudentInfo AddStudentInfo(StudentInfo studentInfo);

		/// <summary>
		/// 修改学生信息
		/// </summary>
		/// <param name="studentInfo">学生信息</param>
		/// <return>学生信息</return>
		StudentInfo UpdateStudentInfo(StudentInfo studentInfo);

		/// <summary>
		/// 删除学生信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		void RemoveStudentInfo(long id);

		/// <summary>
		/// 获取学生信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>学生信息</returns>
		StudentInfo GetStudentInfo(long id);

		/// <summary>
		/// 获取学生信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>学生信息</returns>
		StudentInfo GetStudentInfoOrDefault(long id, StudentInfo defaultEntity = null);
		
		/// <summary>
		/// 根据条件获取学生信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>学生信息</returns>
		StudentInfo GetStudentInfo(Expression<Func<StudentInfo, bool>> predicate);

		/// <summary>
		/// 根据条件获取学生信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>学生信息</returns>
		StudentInfo GetStudentInfoOrDefault(Expression<Func<StudentInfo, bool>> predicate, StudentInfo defaultEntity = null);

		/// <summary>
		/// 根据条件查询学生信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>学生信息集合</returns>
		List<StudentInfo> QueryStudentInfo(Expression<Func<StudentInfo, bool>> predicate, Pages pages = null);

		/// <summary>
        /// 根据条件查询学生信息
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>学生信息集合</returns>
        List<StudentInfo> QueryStudentInfo(JObject filter, out Pages pages);
	}
}
