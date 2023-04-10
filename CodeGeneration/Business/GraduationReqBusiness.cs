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
	/// 毕业要求业务逻辑
	/// </summary>
	public class GraduationReqBusiness : BusinessBase, IGraduationReqBusiness
	{
        /// <summary>
		/// 获取或设置毕业要求数据访问
		/// </summary>
		public IGraduationReqDataAccess GraduationReqDataAccess { get; set; }

        /// <summary>
		/// 新增毕业要求
		/// </summary>
		/// <param name="graduationReq">毕业要求</param>
		/// <return>毕业要求</return>
		public virtual GraduationReq AddGraduationReq(GraduationReq graduationReq)
		{
			GraduationReq entity = this.GraduationReqDataAccess.AddGraduationReq(graduationReq);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, graduationReq.TableData);

			return entity;
		}

		/// <summary>
		/// 修改毕业要求
		/// </summary>
		/// <param name="graduationReq">毕业要求</param>
		/// <return>毕业要求</return>
		public virtual GraduationReq UpdateGraduationReq(GraduationReq graduationReq)
		{
			GraduationReq entity = this.GraduationReqDataAccess.UpdateGraduationReq(graduationReq);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, graduationReq.TableData);

			return entity;
		}

		/// <summary>
		/// 删除毕业要求
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveGraduationReq(long id)
		{
			GraduationReq entity = this.GraduationReqDataAccess.GetGraduationReq(id);

			this.GraduationReqDataAccess.RemoveGraduationReq(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取毕业要求
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>毕业要求</returns>
		public virtual GraduationReq GetGraduationReq(long id)
		{
			return this.GraduationReqDataAccess.GetGraduationReq(id);
		}

		/// <summary>
		/// 获取毕业要求
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>毕业要求</returns>
		public virtual GraduationReq GetGraduationReqOrDefault(long id, GraduationReq defaultEntity = null)
		{
			return this.GraduationReqDataAccess.GetGraduationReqOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取毕业要求
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>毕业要求</returns>
		public virtual GraduationReq GetGraduationReq(Expression<Func<GraduationReq, bool>> predicate)
		{
			return this.GraduationReqDataAccess.GetGraduationReq(predicate);
		}

		/// <summary>
		/// 根据条件获取毕业要求
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>毕业要求</returns>
		public virtual GraduationReq GetGraduationReqOrDefault(Expression<Func<GraduationReq, bool>> predicate, GraduationReq defaultEntity = null)
		{
			return this.GraduationReqDataAccess.GetGraduationReqOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询毕业要求
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>毕业要求集合</returns>
		public virtual List<GraduationReq> QueryGraduationReq(Expression<Func<GraduationReq, bool>> predicate, Pages pages = null)
		{
			return this.GraduationReqDataAccess.QueryGraduationReq(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询毕业要求
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>毕业要求集合</returns>
        public virtual List<GraduationReq> QueryGraduationReq(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<GraduationReq>();

            return this.GraduationReqDataAccess.QueryGraduationReq(predicate.Expand(), this.GetPredicate(typeof(GraduationReq), filter), pages);
        }
	}
}
