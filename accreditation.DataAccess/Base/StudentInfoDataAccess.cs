//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Mooho.Base.Common;
using accreditation.IDataAccess;
using accreditation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace accreditation.DataAccess
{
    /// <summary>
    /// 学生信息数据访问
    /// </summary>
    public partial class StudentInfoDataAccess : DataBase, IStudentInfoDataAccess
    {
        /// <summary>
        /// 新增学生信息
        /// </summary>
        /// <param name="studentInfo">学生信息</param>
        /// <return>学生信息</return>
        public virtual StudentInfo AddStudentInfo(StudentInfo studentInfo)
        {
            StudentInfo entity = this.Create(studentInfo.GetType()) as StudentInfo;
            entity.ID = studentInfo.ID == 0 ? Utility.NewID() : studentInfo.ID;

			Utility.Copy(studentInfo, entity);

            return this.Context.StudentInfoes.Add(entity).Entity;
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="studentInfo">学生信息</param>
        /// <return>学生信息</return>
        public virtual StudentInfo UpdateStudentInfo(StudentInfo studentInfo)
        {
            StudentInfo entity = this.Context.StudentInfoes.Find(studentInfo.ID);

			Utility.Copy(studentInfo, entity);

            return entity;
        }

        /// <summary>
        /// 保存学生信息
        /// </summary>
        /// <param name="studentInfo">学生信息</param>
        /// <return>学生信息</return>
        public virtual StudentInfo SaveStudentInfo(StudentInfo studentInfo)
        {
            StudentInfo entity;

            if (studentInfo.ID != 0)
            {
                entity = this.Context.StudentInfoes.Find(studentInfo.ID);
                if (entity != null)
                {
			        Utility.Copy(studentInfo, entity);
                    return entity;
                }
            }

            entity = this.Create(studentInfo.GetType()) as StudentInfo;
            entity.ID = studentInfo.ID == 0 ? Utility.NewID() : studentInfo.ID;

			Utility.Copy(studentInfo, entity);

            return this.Context.StudentInfoes.Add(entity).Entity;
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="studentInfo">学生信息</param>
        public virtual void RemoveStudentInfo(StudentInfo studentInfo)
        {
            this.Context.StudentInfoes.Remove(studentInfo);
        }

        /// <summary>
        /// 根据条件删除学生信息
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public virtual void RemoveStudentInfo(Expression<Func<StudentInfo, bool>> predicate)
        {
            List<StudentInfo> studentInfoes = this.QueryStudentInfo(predicate);
            foreach (StudentInfo studentInfo in studentInfoes)
            {
                this.RemoveStudentInfo(studentInfo);
            }
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>学生信息</returns>
        public virtual StudentInfo GetStudentInfo(long id)
        {
            StudentInfo entity = this.Allow(this.Context.StudentInfoes).FirstOrDefault(x => x.ID == id);

            if (entity == null)
            {
                throw new ApplicationException("学生信息不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>学生信息</returns>
        public virtual StudentInfo GetStudentInfoOrDefault(long id, StudentInfo defaultEntity = null)
        {
            return this.Allow(this.Context.StudentInfoes).FirstOrDefault(x => x.ID == id) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取学生信息
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>学生信息</returns>
        public virtual StudentInfo GetStudentInfo(Expression<Func<StudentInfo, bool>> predicate)
        {
            StudentInfo entity = this.Allow(this.Context.StudentInfoes).FirstOrDefault(predicate);

            if (entity == null)
            {
                throw new ApplicationException("学生信息不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 根据条件获取学生信息
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>学生信息</returns>
        public virtual StudentInfo GetStudentInfoOrDefault(Expression<Func<StudentInfo, bool>> predicate, StudentInfo defaultEntity = null)
        {
            return this.Allow(this.Context.StudentInfoes).FirstOrDefault(predicate) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取学生信息数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>学生信息数量</returns>
        public virtual int CountStudentInfo(Expression<Func<StudentInfo, bool>> predicate)
        {
            return this.Allow(this.Context.StudentInfoes).Where(predicate).Count();
        }

        /// <summary>
        /// 根据条件统计学生信息
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual int? SumStudentInfo(Expression<Func<StudentInfo, int?>> selecter, Expression<Func<StudentInfo, bool>> predicate)
        {
            return this.Allow(this.Context.StudentInfoes).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件统计学生信息
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual decimal? SumStudentInfo(Expression<Func<StudentInfo, decimal?>> selecter, Expression<Func<StudentInfo, bool>> predicate)
        {
            return this.Allow(this.Context.StudentInfoes).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件查询学生信息
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>学生信息集合</returns>
        public virtual List<StudentInfo> QueryStudentInfo(Expression<Func<StudentInfo, bool>> predicate, Pages pages = null)
        {
            return Utility.SplitPage(this.Allow(this.Context.StudentInfoes).Where(predicate), pages).ToList();
        }

        /// <summary>
        /// 根据条件查询学生信息
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="dynamicPredicate">动态查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>学生信息集合</returns>
        public virtual List<StudentInfo> QueryStudentInfo(Expression<Func<StudentInfo, bool>> predicate, LambdaExpression dynamicPredicate, Pages pages = null)
        {
            return this.QueryModel(predicate, dynamicPredicate, pages).Select(x => x as StudentInfo).ToList();
        }
    }
}
