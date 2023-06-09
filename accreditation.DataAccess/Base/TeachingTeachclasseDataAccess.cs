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
    /// 教学班数据访问
    /// </summary>
    public partial class TeachingTeachclasseDataAccess : DataBase, ITeachingTeachclasseDataAccess
    {
        /// <summary>
        /// 新增教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        /// <return>教学班</return>
        public virtual TeachingTeachclasse AddTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse)
        {
            TeachingTeachclasse entity = this.Create(teachingTeachclasse.GetType()) as TeachingTeachclasse;
            entity.ID = teachingTeachclasse.ID == 0 ? Utility.NewID() : teachingTeachclasse.ID;

			Utility.Copy(teachingTeachclasse, entity);

            return this.Context.TeachingTeachclasses.Add(entity).Entity;
        }

        /// <summary>
        /// 修改教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        /// <return>教学班</return>
        public virtual TeachingTeachclasse UpdateTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse)
        {
            TeachingTeachclasse entity = this.Context.TeachingTeachclasses.Find(teachingTeachclasse.ID);

			Utility.Copy(teachingTeachclasse, entity);

            return entity;
        }

        /// <summary>
        /// 保存教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        /// <return>教学班</return>
        public virtual TeachingTeachclasse SaveTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse)
        {
            TeachingTeachclasse entity;

            if (teachingTeachclasse.ID != 0)
            {
                entity = this.Context.TeachingTeachclasses.Find(teachingTeachclasse.ID);
                if (entity != null)
                {
			        Utility.Copy(teachingTeachclasse, entity);
                    return entity;
                }
            }

            entity = this.Create(teachingTeachclasse.GetType()) as TeachingTeachclasse;
            entity.ID = teachingTeachclasse.ID == 0 ? Utility.NewID() : teachingTeachclasse.ID;

			Utility.Copy(teachingTeachclasse, entity);

            return this.Context.TeachingTeachclasses.Add(entity).Entity;
        }

        /// <summary>
        /// 删除教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        public virtual void RemoveTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse)
        {
            this.Context.TeachingTeachclasses.Remove(teachingTeachclasse);
        }

        /// <summary>
        /// 根据条件删除教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public virtual void RemoveTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate)
        {
            List<TeachingTeachclasse> teachingTeachclasses = this.QueryTeachingTeachclasse(predicate);
            foreach (TeachingTeachclasse teachingTeachclasse in teachingTeachclasses)
            {
                this.RemoveTeachingTeachclasse(teachingTeachclasse);
            }
        }

        /// <summary>
        /// 获取教学班
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>教学班</returns>
        public virtual TeachingTeachclasse GetTeachingTeachclasse(long id)
        {
            TeachingTeachclasse entity = this.Allow(this.Context.TeachingTeachclasses).FirstOrDefault(x => x.ID == id);

            if (entity == null)
            {
                throw new ApplicationException("教学班不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 获取教学班
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>教学班</returns>
        public virtual TeachingTeachclasse GetTeachingTeachclasseOrDefault(long id, TeachingTeachclasse defaultEntity = null)
        {
            return this.Allow(this.Context.TeachingTeachclasses).FirstOrDefault(x => x.ID == id) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>教学班</returns>
        public virtual TeachingTeachclasse GetTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate)
        {
            TeachingTeachclasse entity = this.Allow(this.Context.TeachingTeachclasses).FirstOrDefault(predicate);

            if (entity == null)
            {
                throw new ApplicationException("教学班不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 根据条件获取教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>教学班</returns>
        public virtual TeachingTeachclasse GetTeachingTeachclasseOrDefault(Expression<Func<TeachingTeachclasse, bool>> predicate, TeachingTeachclasse defaultEntity = null)
        {
            return this.Allow(this.Context.TeachingTeachclasses).FirstOrDefault(predicate) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取教学班数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>教学班数量</returns>
        public virtual int CountTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate)
        {
            return this.Allow(this.Context.TeachingTeachclasses).Where(predicate).Count();
        }

        /// <summary>
        /// 根据条件统计教学班
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual int? SumTeachingTeachclasse(Expression<Func<TeachingTeachclasse, int?>> selecter, Expression<Func<TeachingTeachclasse, bool>> predicate)
        {
            return this.Allow(this.Context.TeachingTeachclasses).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件统计教学班
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual decimal? SumTeachingTeachclasse(Expression<Func<TeachingTeachclasse, decimal?>> selecter, Expression<Func<TeachingTeachclasse, bool>> predicate)
        {
            return this.Allow(this.Context.TeachingTeachclasses).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件查询教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学班集合</returns>
        public virtual List<TeachingTeachclasse> QueryTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate, Pages pages = null)
        {
            return Utility.SplitPage(this.Allow(this.Context.TeachingTeachclasses).Where(predicate), pages).ToList();
        }

        /// <summary>
        /// 根据条件查询教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="dynamicPredicate">动态查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学班集合</returns>
        public virtual List<TeachingTeachclasse> QueryTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate, LambdaExpression dynamicPredicate, Pages pages = null)
        {
            return this.QueryModel(predicate, dynamicPredicate, pages).Select(x => x as TeachingTeachclasse).ToList();
        }
    }
}
