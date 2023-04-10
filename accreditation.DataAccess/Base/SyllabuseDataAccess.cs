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
    /// 教学大纲数据访问
    /// </summary>
    public partial class SyllabuseDataAccess : DataBase, ISyllabuseDataAccess
    {
        /// <summary>
        /// 新增教学大纲
        /// </summary>
        /// <param name="syllabuse">教学大纲</param>
        /// <return>教学大纲</return>
        public virtual Syllabuse AddSyllabuse(Syllabuse syllabuse)
        {
            Syllabuse entity = this.Create(syllabuse.GetType()) as Syllabuse;
            entity.ID = syllabuse.ID == 0 ? Utility.NewID() : syllabuse.ID;

			Utility.Copy(syllabuse, entity);

            return this.Context.Syllabuses.Add(entity).Entity;
        }

        /// <summary>
        /// 修改教学大纲
        /// </summary>
        /// <param name="syllabuse">教学大纲</param>
        /// <return>教学大纲</return>
        public virtual Syllabuse UpdateSyllabuse(Syllabuse syllabuse)
        {
            Syllabuse entity = this.Context.Syllabuses.Find(syllabuse.ID);

			Utility.Copy(syllabuse, entity);

            return entity;
        }

        /// <summary>
        /// 保存教学大纲
        /// </summary>
        /// <param name="syllabuse">教学大纲</param>
        /// <return>教学大纲</return>
        public virtual Syllabuse SaveSyllabuse(Syllabuse syllabuse)
        {
            Syllabuse entity;

            if (syllabuse.ID != 0)
            {
                entity = this.Context.Syllabuses.Find(syllabuse.ID);
                if (entity != null)
                {
			        Utility.Copy(syllabuse, entity);
                    return entity;
                }
            }

            entity = this.Create(syllabuse.GetType()) as Syllabuse;
            entity.ID = syllabuse.ID == 0 ? Utility.NewID() : syllabuse.ID;

			Utility.Copy(syllabuse, entity);

            return this.Context.Syllabuses.Add(entity).Entity;
        }

        /// <summary>
        /// 删除教学大纲
        /// </summary>
        /// <param name="syllabuse">教学大纲</param>
        public virtual void RemoveSyllabuse(Syllabuse syllabuse)
        {
            this.Context.Syllabuses.Remove(syllabuse);
        }

        /// <summary>
        /// 根据条件删除教学大纲
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public virtual void RemoveSyllabuse(Expression<Func<Syllabuse, bool>> predicate)
        {
            List<Syllabuse> syllabuses = this.QuerySyllabuse(predicate);
            foreach (Syllabuse syllabuse in syllabuses)
            {
                this.RemoveSyllabuse(syllabuse);
            }
        }

        /// <summary>
        /// 获取教学大纲
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>教学大纲</returns>
        public virtual Syllabuse GetSyllabuse(long id)
        {
            Syllabuse entity = this.Allow(this.Context.Syllabuses).FirstOrDefault(x => x.ID == id);

            if (entity == null)
            {
                throw new ApplicationException("教学大纲不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 获取教学大纲
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>教学大纲</returns>
        public virtual Syllabuse GetSyllabuseOrDefault(long id, Syllabuse defaultEntity = null)
        {
            return this.Allow(this.Context.Syllabuses).FirstOrDefault(x => x.ID == id) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取教学大纲
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>教学大纲</returns>
        public virtual Syllabuse GetSyllabuse(Expression<Func<Syllabuse, bool>> predicate)
        {
            Syllabuse entity = this.Allow(this.Context.Syllabuses).FirstOrDefault(predicate);

            if (entity == null)
            {
                throw new ApplicationException("教学大纲不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 根据条件获取教学大纲
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>教学大纲</returns>
        public virtual Syllabuse GetSyllabuseOrDefault(Expression<Func<Syllabuse, bool>> predicate, Syllabuse defaultEntity = null)
        {
            return this.Allow(this.Context.Syllabuses).FirstOrDefault(predicate) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取教学大纲数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>教学大纲数量</returns>
        public virtual int CountSyllabuse(Expression<Func<Syllabuse, bool>> predicate)
        {
            return this.Allow(this.Context.Syllabuses).Where(predicate).Count();
        }

        /// <summary>
        /// 根据条件统计教学大纲
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual int? SumSyllabuse(Expression<Func<Syllabuse, int?>> selecter, Expression<Func<Syllabuse, bool>> predicate)
        {
            return this.Allow(this.Context.Syllabuses).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件统计教学大纲
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual decimal? SumSyllabuse(Expression<Func<Syllabuse, decimal?>> selecter, Expression<Func<Syllabuse, bool>> predicate)
        {
            return this.Allow(this.Context.Syllabuses).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件查询教学大纲
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学大纲集合</returns>
        public virtual List<Syllabuse> QuerySyllabuse(Expression<Func<Syllabuse, bool>> predicate, Pages pages = null)
        {
            return Utility.SplitPage(this.Allow(this.Context.Syllabuses).Where(predicate), pages).ToList();
        }

        /// <summary>
        /// 根据条件查询教学大纲
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="dynamicPredicate">动态查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学大纲集合</returns>
        public virtual List<Syllabuse> QuerySyllabuse(Expression<Func<Syllabuse, bool>> predicate, LambdaExpression dynamicPredicate, Pages pages = null)
        {
            return this.QueryModel(predicate, dynamicPredicate, pages).Select(x => x as Syllabuse).ToList();
        }
    }
}