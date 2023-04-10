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
	/// 培养计划业务逻辑
	/// </summary>
	public class CultivationProjectBusiness : BusinessBase, ICultivationProjectBusiness
	{
        /// <summary>
		/// 获取或设置培养计划数据访问
		/// </summary>
		public ICultivationProjectDataAccess CultivationProjectDataAccess { get; set; }

        /// <summary>
		/// 新增培养计划
		/// </summary>
		/// <param name="cultivationProject">培养计划</param>
		/// <return>培养计划</return>
		public virtual CultivationProject AddCultivationProject(CultivationProject cultivationProject)
		{
			CultivationProject entity = this.CultivationProjectDataAccess.AddCultivationProject(cultivationProject);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, cultivationProject.TableData);

			return entity;
		}

		/// <summary>
		/// 修改培养计划
		/// </summary>
		/// <param name="cultivationProject">培养计划</param>
		/// <return>培养计划</return>
		public virtual CultivationProject UpdateCultivationProject(CultivationProject cultivationProject)
		{
			CultivationProject entity = this.CultivationProjectDataAccess.UpdateCultivationProject(cultivationProject);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, cultivationProject.TableData);

			return entity;
		}

		/// <summary>
		/// 删除培养计划
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveCultivationProject(long id)
		{
			CultivationProject entity = this.CultivationProjectDataAccess.GetCultivationProject(id);

			this.CultivationProjectDataAccess.RemoveCultivationProject(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取培养计划
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>培养计划</returns>
		public virtual CultivationProject GetCultivationProject(long id)
		{
			return this.CultivationProjectDataAccess.GetCultivationProject(id);
		}

		/// <summary>
		/// 获取培养计划
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>培养计划</returns>
		public virtual CultivationProject GetCultivationProjectOrDefault(long id, CultivationProject defaultEntity = null)
		{
			return this.CultivationProjectDataAccess.GetCultivationProjectOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取培养计划
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>培养计划</returns>
		public virtual CultivationProject GetCultivationProject(Expression<Func<CultivationProject, bool>> predicate)
		{
			return this.CultivationProjectDataAccess.GetCultivationProject(predicate);
		}

		/// <summary>
		/// 根据条件获取培养计划
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>培养计划</returns>
		public virtual CultivationProject GetCultivationProjectOrDefault(Expression<Func<CultivationProject, bool>> predicate, CultivationProject defaultEntity = null)
		{
			return this.CultivationProjectDataAccess.GetCultivationProjectOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询培养计划
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>培养计划集合</returns>
		public virtual List<CultivationProject> QueryCultivationProject(Expression<Func<CultivationProject, bool>> predicate, Pages pages = null)
		{
			return this.CultivationProjectDataAccess.QueryCultivationProject(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询培养计划
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>培养计划集合</returns>
        public virtual List<CultivationProject> QueryCultivationProject(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<CultivationProject>();

            return this.CultivationProjectDataAccess.QueryCultivationProject(predicate.Expand(), this.GetPredicate(typeof(CultivationProject), filter), pages);
        }
	}
}
