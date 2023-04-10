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
	/// 毕业指标点业务逻辑
	/// </summary>
	public class GraduationPointBusiness : BusinessBase, IGraduationPointBusiness
	{
        /// <summary>
		/// 获取或设置毕业指标点数据访问
		/// </summary>
		public IGraduationPointDataAccess GraduationPointDataAccess { get; set; }

        /// <summary>
		/// 新增毕业指标点
		/// </summary>
		/// <param name="graduationPoint">毕业指标点</param>
		/// <return>毕业指标点</return>
		public virtual GraduationPoint AddGraduationPoint(GraduationPoint graduationPoint)
		{
			GraduationPoint entity = this.GraduationPointDataAccess.AddGraduationPoint(graduationPoint);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, graduationPoint.TableData);

			return entity;
		}

		/// <summary>
		/// 修改毕业指标点
		/// </summary>
		/// <param name="graduationPoint">毕业指标点</param>
		/// <return>毕业指标点</return>
		public virtual GraduationPoint UpdateGraduationPoint(GraduationPoint graduationPoint)
		{
			GraduationPoint entity = this.GraduationPointDataAccess.UpdateGraduationPoint(graduationPoint);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, graduationPoint.TableData);

			return entity;
		}

		/// <summary>
		/// 删除毕业指标点
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveGraduationPoint(long id)
		{
			GraduationPoint entity = this.GraduationPointDataAccess.GetGraduationPoint(id);

			this.GraduationPointDataAccess.RemoveGraduationPoint(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取毕业指标点
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>毕业指标点</returns>
		public virtual GraduationPoint GetGraduationPoint(long id)
		{
			return this.GraduationPointDataAccess.GetGraduationPoint(id);
		}

		/// <summary>
		/// 获取毕业指标点
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>毕业指标点</returns>
		public virtual GraduationPoint GetGraduationPointOrDefault(long id, GraduationPoint defaultEntity = null)
		{
			return this.GraduationPointDataAccess.GetGraduationPointOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取毕业指标点
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>毕业指标点</returns>
		public virtual GraduationPoint GetGraduationPoint(Expression<Func<GraduationPoint, bool>> predicate)
		{
			return this.GraduationPointDataAccess.GetGraduationPoint(predicate);
		}

		/// <summary>
		/// 根据条件获取毕业指标点
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>毕业指标点</returns>
		public virtual GraduationPoint GetGraduationPointOrDefault(Expression<Func<GraduationPoint, bool>> predicate, GraduationPoint defaultEntity = null)
		{
			return this.GraduationPointDataAccess.GetGraduationPointOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询毕业指标点
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>毕业指标点集合</returns>
		public virtual List<GraduationPoint> QueryGraduationPoint(Expression<Func<GraduationPoint, bool>> predicate, Pages pages = null)
		{
			return this.GraduationPointDataAccess.QueryGraduationPoint(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询毕业指标点
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>毕业指标点集合</returns>
        public virtual List<GraduationPoint> QueryGraduationPoint(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<GraduationPoint>();

            return this.GraduationPointDataAccess.QueryGraduationPoint(predicate.Expand(), this.GetPredicate(typeof(GraduationPoint), filter), pages);
        }
	}
}
