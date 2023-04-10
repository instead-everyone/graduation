using LinqKit;
using Mooho.Base.Common;
using Mooho.Base.IBusiness;
using Mooho.Base.Model;
using accreditation.IBusiness;
using accreditation.IDataAccess;
using accreditation.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace accreditation.Business
{
	/// <summary>
	/// 学生信息业务逻辑
	/// </summary>
	public class StudentInfoBusiness : BusinessBase, IStudentInfoBusiness
	{
        /// <summary>
		/// 获取或设置学生信息数据访问
		/// </summary>
		public IStudentInfoDataAccess StudentInfoDataAccess { get; set; }

        /// <summary>
		/// 新增学生信息
		/// </summary>
		/// <param name="studentInfo">学生信息</param>
		/// <return>学生信息</return>
		public virtual StudentInfo AddStudentInfo(StudentInfo studentInfo)
		{
			StudentInfo entity = this.StudentInfoDataAccess.AddStudentInfo(studentInfo);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, studentInfo.TableData);

			return entity;
		}

		/// <summary>
		/// 修改学生信息
		/// </summary>
		/// <param name="studentInfo">学生信息</param>
		/// <return>学生信息</return>
		public virtual StudentInfo UpdateStudentInfo(StudentInfo studentInfo)
		{
			StudentInfo entity = this.StudentInfoDataAccess.UpdateStudentInfo(studentInfo);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, studentInfo.TableData);

			return entity;
		}

		/// <summary>
		/// 删除学生信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveStudentInfo(long id)
		{
			StudentInfo entity = this.StudentInfoDataAccess.GetStudentInfo(id);

			this.StudentInfoDataAccess.RemoveStudentInfo(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取学生信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>学生信息</returns>
		public virtual StudentInfo GetStudentInfo(long id)
		{
			return this.StudentInfoDataAccess.GetStudentInfo(id);
		}

		/// <summary>
		/// 获取学生信息
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>学生信息</returns>
		public virtual StudentInfo GetStudentInfoOrDefault(long id, StudentInfo defaultEntity = null)
		{
			return this.StudentInfoDataAccess.GetStudentInfoOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取学生信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>学生信息</returns>
		public virtual StudentInfo GetStudentInfo(Expression<Func<StudentInfo, bool>> predicate)
		{
			return this.StudentInfoDataAccess.GetStudentInfo(predicate);
		}

		/// <summary>
		/// 根据条件获取学生信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>学生信息</returns>
		public virtual StudentInfo GetStudentInfoOrDefault(Expression<Func<StudentInfo, bool>> predicate, StudentInfo defaultEntity = null)
		{
			return this.StudentInfoDataAccess.GetStudentInfoOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询学生信息
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>学生信息集合</returns>
		public virtual List<StudentInfo> QueryStudentInfo(Expression<Func<StudentInfo, bool>> predicate, Pages pages = null)
		{
			return this.StudentInfoDataAccess.QueryStudentInfo(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询学生信息
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>学生信息集合</returns>
        public virtual List<StudentInfo> QueryStudentInfo(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<StudentInfo>();

            return this.StudentInfoDataAccess.QueryStudentInfo(predicate.Expand(), this.GetPredicate(typeof(StudentInfo), filter), pages);
        }
	}
}
