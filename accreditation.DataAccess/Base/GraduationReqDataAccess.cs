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
    /// 毕业要求数据访问
    /// </summary>
    public partial class GraduationReqDataAccess : DataBase, IGraduationReqDataAccess
    {
        /// <summary>
        /// 新增毕业要求
        /// </summary>
        /// <param name="graduationReq">毕业要求</param>
        /// <return>毕业要求</return>
        public virtual GraduationReq AddGraduationReq(GraduationReq graduationReq)
        {
            GraduationReq entity = this.Create(graduationReq.GetType()) as GraduationReq;
            entity.ID = graduationReq.ID == 0 ? Utility.NewID() : graduationReq.ID;

			Utility.Copy(graduationReq, entity);

            return this.Context.GraduationReqs.Add(entity).Entity;
        }

        /// <summary>
        /// 修改毕业要求
        /// </summary>
        /// <param name="graduationReq">毕业要求</param>
        /// <return>毕业要求</return>
        public virtual GraduationReq UpdateGraduationReq(GraduationReq graduationReq)
        {
            GraduationReq entity = this.Context.GraduationReqs.Find(graduationReq.ID);

			Utility.Copy(graduationReq, entity);

            return entity;
        }

        /// <summary>
        /// 保存毕业要求
        /// </summary>
        /// <param name="graduationReq">毕业要求</param>
        /// <return>毕业要求</return>
        public virtual GraduationReq SaveGraduationReq(GraduationReq graduationReq)
        {
            GraduationReq entity;

            if (graduationReq.ID != 0)
            {
                entity = this.Context.GraduationReqs.Find(graduationReq.ID);
                if (entity != null)
                {
			        Utility.Copy(graduationReq, entity);
                    return entity;
                }
            }

            entity = this.Create(graduationReq.GetType()) as GraduationReq;
            entity.ID = graduationReq.ID == 0 ? Utility.NewID() : graduationReq.ID;

			Utility.Copy(graduationReq, entity);

            return this.Context.GraduationReqs.Add(entity).Entity;
        }

        /// <summary>
        /// 删除毕业要求
        /// </summary>
        /// <param name="graduationReq">毕业要求</param>
        public virtual void RemoveGraduationReq(GraduationReq graduationReq)
        {
            this.Context.GraduationReqs.Remove(graduationReq);
        }

        /// <summary>
        /// 根据条件删除毕业要求
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public virtual void RemoveGraduationReq(Expression<Func<GraduationReq, bool>> predicate)
        {
            List<GraduationReq> graduationReqs = this.QueryGraduationReq(predicate);
            foreach (GraduationReq graduationReq in graduationReqs)
            {
                this.RemoveGraduationReq(graduationReq);
            }
        }

        /// <summary>
        /// 获取毕业要求
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>毕业要求</returns>
        public virtual GraduationReq GetGraduationReq(long id)
        {
            GraduationReq entity = this.Allow(this.Context.GraduationReqs).FirstOrDefault(x => x.ID == id);

            if (entity == null)
            {
                throw new ApplicationException("毕业要求不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 获取毕业要求
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>毕业要求</returns>
        public virtual GraduationReq GetGraduationReqOrDefault(long id, GraduationReq defaultEntity = null)
        {
            return this.Allow(this.Context.GraduationReqs).FirstOrDefault(x => x.ID == id) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取毕业要求
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>毕业要求</returns>
        public virtual GraduationReq GetGraduationReq(Expression<Func<GraduationReq, bool>> predicate)
        {
            GraduationReq entity = this.Allow(this.Context.GraduationReqs).FirstOrDefault(predicate);

            if (entity == null)
            {
                throw new ApplicationException("毕业要求不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 根据条件获取毕业要求
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>毕业要求</returns>
        public virtual GraduationReq GetGraduationReqOrDefault(Expression<Func<GraduationReq, bool>> predicate, GraduationReq defaultEntity = null)
        {
            return this.Allow(this.Context.GraduationReqs).FirstOrDefault(predicate) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取毕业要求数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>毕业要求数量</returns>
        public virtual int CountGraduationReq(Expression<Func<GraduationReq, bool>> predicate)
        {
            return this.Allow(this.Context.GraduationReqs).Where(predicate).Count();
        }

        /// <summary>
        /// 根据条件统计毕业要求
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual int? SumGraduationReq(Expression<Func<GraduationReq, int?>> selecter, Expression<Func<GraduationReq, bool>> predicate)
        {
            return this.Allow(this.Context.GraduationReqs).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件统计毕业要求
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual decimal? SumGraduationReq(Expression<Func<GraduationReq, decimal?>> selecter, Expression<Func<GraduationReq, bool>> predicate)
        {
            return this.Allow(this.Context.GraduationReqs).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件查询毕业要求
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>毕业要求集合</returns>
        public virtual List<GraduationReq> QueryGraduationReq(Expression<Func<GraduationReq, bool>> predicate, Pages pages = null)
        {
            return Utility.SplitPage(this.Allow(this.Context.GraduationReqs).Where(predicate), pages).ToList();
        }

        /// <summary>
        /// 根据条件查询毕业要求
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="dynamicPredicate">动态查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>毕业要求集合</returns>
        public virtual List<GraduationReq> QueryGraduationReq(Expression<Func<GraduationReq, bool>> predicate, LambdaExpression dynamicPredicate, Pages pages = null)
        {
            return this.QueryModel(predicate, dynamicPredicate, pages).Select(x => x as GraduationReq).ToList();
        }
    }
}
