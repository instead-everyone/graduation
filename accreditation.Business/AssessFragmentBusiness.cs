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
	/// 考核分解项业务逻辑
	/// </summary>
	public class AssessFragmentBusiness : BusinessBase, IAssessFragmentBusiness
	{
        /// <summary>
		/// 获取或设置考核分解项数据访问
		/// </summary>
		public IAssessFragmentDataAccess AssessFragmentDataAccess { get; set; }

        /// <summary>
		/// 新增考核分解项
		/// </summary>
		/// <param name="assessFragment">考核分解项</param>
		/// <return>考核分解项</return>
		public virtual AssessFragment AddAssessFragment(AssessFragment assessFragment)
		{
			AssessFragment entity = this.AssessFragmentDataAccess.AddAssessFragment(assessFragment);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, assessFragment.TableData);

			return entity;
		}

		/// <summary>
		/// 修改考核分解项
		/// </summary>
		/// <param name="assessFragment">考核分解项</param>
		/// <return>考核分解项</return>
		public virtual AssessFragment UpdateAssessFragment(AssessFragment assessFragment)
		{
			AssessFragment entity = this.AssessFragmentDataAccess.UpdateAssessFragment(assessFragment);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, assessFragment.TableData);

			return entity;
		}

		/// <summary>
		/// 删除考核分解项
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveAssessFragment(long id)
		{
			AssessFragment entity = this.AssessFragmentDataAccess.GetAssessFragment(id);

			this.AssessFragmentDataAccess.RemoveAssessFragment(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取考核分解项
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>考核分解项</returns>
		public virtual AssessFragment GetAssessFragment(long id)
		{
			return this.AssessFragmentDataAccess.GetAssessFragment(id);
		}

		/// <summary>
		/// 获取考核分解项
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>考核分解项</returns>
		public virtual AssessFragment GetAssessFragmentOrDefault(long id, AssessFragment defaultEntity = null)
		{
			return this.AssessFragmentDataAccess.GetAssessFragmentOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取考核分解项
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>考核分解项</returns>
		public virtual AssessFragment GetAssessFragment(Expression<Func<AssessFragment, bool>> predicate)
		{
			return this.AssessFragmentDataAccess.GetAssessFragment(predicate);
		}

		/// <summary>
		/// 根据条件获取考核分解项
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>考核分解项</returns>
		public virtual AssessFragment GetAssessFragmentOrDefault(Expression<Func<AssessFragment, bool>> predicate, AssessFragment defaultEntity = null)
		{
			return this.AssessFragmentDataAccess.GetAssessFragmentOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询考核分解项
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>考核分解项集合</returns>
		public virtual List<AssessFragment> QueryAssessFragment(Expression<Func<AssessFragment, bool>> predicate, Pages pages = null)
		{
			return this.AssessFragmentDataAccess.QueryAssessFragment(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询考核分解项
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>考核分解项集合</returns>
        public virtual List<AssessFragment> QueryAssessFragment(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<AssessFragment>();

            return this.AssessFragmentDataAccess.QueryAssessFragment(predicate.Expand(), this.GetPredicate(typeof(AssessFragment), filter), pages);
        }
	}
}
