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
	/// 考核方式业务逻辑
	/// </summary>
	public class AssessMethodBusiness : BusinessBase, IAssessMethodBusiness
	{
        /// <summary>
		/// 获取或设置考核方式数据访问
		/// </summary>
		public IAssessMethodDataAccess AssessMethodDataAccess { get; set; }

        /// <summary>
		/// 新增考核方式
		/// </summary>
		/// <param name="assessMethod">考核方式</param>
		/// <return>考核方式</return>
		public virtual AssessMethod AddAssessMethod(AssessMethod assessMethod)
		{
			AssessMethod entity = this.AssessMethodDataAccess.AddAssessMethod(assessMethod);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, assessMethod.TableData);

			return entity;
		}

		/// <summary>
		/// 修改考核方式
		/// </summary>
		/// <param name="assessMethod">考核方式</param>
		/// <return>考核方式</return>
		public virtual AssessMethod UpdateAssessMethod(AssessMethod assessMethod)
		{
			AssessMethod entity = this.AssessMethodDataAccess.UpdateAssessMethod(assessMethod);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, assessMethod.TableData);

			return entity;
		}

		/// <summary>
		/// 删除考核方式
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveAssessMethod(long id)
		{
			AssessMethod entity = this.AssessMethodDataAccess.GetAssessMethod(id);

			this.AssessMethodDataAccess.RemoveAssessMethod(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取考核方式
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>考核方式</returns>
		public virtual AssessMethod GetAssessMethod(long id)
		{
			return this.AssessMethodDataAccess.GetAssessMethod(id);
		}

		/// <summary>
		/// 获取考核方式
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>考核方式</returns>
		public virtual AssessMethod GetAssessMethodOrDefault(long id, AssessMethod defaultEntity = null)
		{
			return this.AssessMethodDataAccess.GetAssessMethodOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取考核方式
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>考核方式</returns>
		public virtual AssessMethod GetAssessMethod(Expression<Func<AssessMethod, bool>> predicate)
		{
			return this.AssessMethodDataAccess.GetAssessMethod(predicate);
		}

		/// <summary>
		/// 根据条件获取考核方式
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>考核方式</returns>
		public virtual AssessMethod GetAssessMethodOrDefault(Expression<Func<AssessMethod, bool>> predicate, AssessMethod defaultEntity = null)
		{
			return this.AssessMethodDataAccess.GetAssessMethodOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询考核方式
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>考核方式集合</returns>
		public virtual List<AssessMethod> QueryAssessMethod(Expression<Func<AssessMethod, bool>> predicate, Pages pages = null)
		{
			return this.AssessMethodDataAccess.QueryAssessMethod(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询考核方式
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>考核方式集合</returns>
        public virtual List<AssessMethod> QueryAssessMethod(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<AssessMethod>();

            return this.AssessMethodDataAccess.QueryAssessMethod(predicate.Expand(), this.GetPredicate(typeof(AssessMethod), filter), pages);
        }
	}
}
