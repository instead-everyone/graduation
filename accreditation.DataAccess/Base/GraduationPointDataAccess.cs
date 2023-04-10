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
    /// 毕业指标点数据访问
    /// </summary>
    public partial class GraduationPointDataAccess : DataBase, IGraduationPointDataAccess
    {
        /// <summary>
        /// 新增毕业指标点
        /// </summary>
        /// <param name="graduationPoint">毕业指标点</param>
        /// <return>毕业指标点</return>
        public virtual GraduationPoint AddGraduationPoint(GraduationPoint graduationPoint)
        {
            GraduationPoint entity = this.Create(graduationPoint.GetType()) as GraduationPoint;
            entity.ID = graduationPoint.ID == 0 ? Utility.NewID() : graduationPoint.ID;

			Utility.Copy(graduationPoint, entity);

            return this.Context.GraduationPoints.Add(entity).Entity;
        }

        /// <summary>
        /// 修改毕业指标点
        /// </summary>
        /// <param name="graduationPoint">毕业指标点</param>
        /// <return>毕业指标点</return>
        public virtual GraduationPoint UpdateGraduationPoint(GraduationPoint graduationPoint)
        {
            GraduationPoint entity = this.Context.GraduationPoints.Find(graduationPoint.ID);

			Utility.Copy(graduationPoint, entity);

            return entity;
        }

        /// <summary>
        /// 保存毕业指标点
        /// </summary>
        /// <param name="graduationPoint">毕业指标点</param>
        /// <return>毕业指标点</return>
        public virtual GraduationPoint SaveGraduationPoint(GraduationPoint graduationPoint)
        {
            GraduationPoint entity;

            if (graduationPoint.ID != 0)
            {
                entity = this.Context.GraduationPoints.Find(graduationPoint.ID);
                if (entity != null)
                {
			        Utility.Copy(graduationPoint, entity);
                    return entity;
                }
            }

            entity = this.Create(graduationPoint.GetType()) as GraduationPoint;
            entity.ID = graduationPoint.ID == 0 ? Utility.NewID() : graduationPoint.ID;

			Utility.Copy(graduationPoint, entity);

            return this.Context.GraduationPoints.Add(entity).Entity;
        }

        /// <summary>
        /// 删除毕业指标点
        /// </summary>
        /// <param name="graduationPoint">毕业指标点</param>
        public virtual void RemoveGraduationPoint(GraduationPoint graduationPoint)
        {
            this.Context.GraduationPoints.Remove(graduationPoint);
        }

        /// <summary>
        /// 根据条件删除毕业指标点
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public virtual void RemoveGraduationPoint(Expression<Func<GraduationPoint, bool>> predicate)
        {
            List<GraduationPoint> graduationPoints = this.QueryGraduationPoint(predicate);
            foreach (GraduationPoint graduationPoint in graduationPoints)
            {
                this.RemoveGraduationPoint(graduationPoint);
            }
        }

        /// <summary>
        /// 获取毕业指标点
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>毕业指标点</returns>
        public virtual GraduationPoint GetGraduationPoint(long id)
        {
            GraduationPoint entity = this.Allow(this.Context.GraduationPoints).FirstOrDefault(x => x.ID == id);

            if (entity == null)
            {
                throw new ApplicationException("毕业指标点不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 获取毕业指标点
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>毕业指标点</returns>
        public virtual GraduationPoint GetGraduationPointOrDefault(long id, GraduationPoint defaultEntity = null)
        {
            return this.Allow(this.Context.GraduationPoints).FirstOrDefault(x => x.ID == id) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取毕业指标点
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>毕业指标点</returns>
        public virtual GraduationPoint GetGraduationPoint(Expression<Func<GraduationPoint, bool>> predicate)
        {
            GraduationPoint entity = this.Allow(this.Context.GraduationPoints).FirstOrDefault(predicate);

            if (entity == null)
            {
                throw new ApplicationException("毕业指标点不存在");
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// 根据条件获取毕业指标点
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>毕业指标点</returns>
        public virtual GraduationPoint GetGraduationPointOrDefault(Expression<Func<GraduationPoint, bool>> predicate, GraduationPoint defaultEntity = null)
        {
            return this.Allow(this.Context.GraduationPoints).FirstOrDefault(predicate) ?? defaultEntity;
        }

        /// <summary>
        /// 根据条件获取毕业指标点数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>毕业指标点数量</returns>
        public virtual int CountGraduationPoint(Expression<Func<GraduationPoint, bool>> predicate)
        {
            return this.Allow(this.Context.GraduationPoints).Where(predicate).Count();
        }

        /// <summary>
        /// 根据条件统计毕业指标点
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual int? SumGraduationPoint(Expression<Func<GraduationPoint, int?>> selecter, Expression<Func<GraduationPoint, bool>> predicate)
        {
            return this.Allow(this.Context.GraduationPoints).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件统计毕业指标点
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        public virtual decimal? SumGraduationPoint(Expression<Func<GraduationPoint, decimal?>> selecter, Expression<Func<GraduationPoint, bool>> predicate)
        {
            return this.Allow(this.Context.GraduationPoints).Where(predicate).Sum(selecter);
        }

        /// <summary>
        /// 根据条件查询毕业指标点
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>毕业指标点集合</returns>
        public virtual List<GraduationPoint> QueryGraduationPoint(Expression<Func<GraduationPoint, bool>> predicate, Pages pages = null)
        {
            return Utility.SplitPage(this.Allow(this.Context.GraduationPoints).Where(predicate), pages).ToList();
        }

        /// <summary>
        /// 根据条件查询毕业指标点
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="dynamicPredicate">动态查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>毕业指标点集合</returns>
        public virtual List<GraduationPoint> QueryGraduationPoint(Expression<Func<GraduationPoint, bool>> predicate, LambdaExpression dynamicPredicate, Pages pages = null)
        {
            return this.QueryModel(predicate, dynamicPredicate, pages).Select(x => x as GraduationPoint).ToList();
        }
    }
}
