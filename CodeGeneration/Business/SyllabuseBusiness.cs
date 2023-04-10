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
	/// 教学大纲业务逻辑
	/// </summary>
	public class SyllabuseBusiness : BusinessBase, ISyllabuseBusiness
	{
        /// <summary>
		/// 获取或设置教学大纲数据访问
		/// </summary>
		public ISyllabuseDataAccess SyllabuseDataAccess { get; set; }

        /// <summary>
		/// 新增教学大纲
		/// </summary>
		/// <param name="syllabuse">教学大纲</param>
		/// <return>教学大纲</return>
		public virtual Syllabuse AddSyllabuse(Syllabuse syllabuse)
		{
			Syllabuse entity = this.SyllabuseDataAccess.AddSyllabuse(syllabuse);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, syllabuse.TableData);

			return entity;
		}

		/// <summary>
		/// 修改教学大纲
		/// </summary>
		/// <param name="syllabuse">教学大纲</param>
		/// <return>教学大纲</return>
		public virtual Syllabuse UpdateSyllabuse(Syllabuse syllabuse)
		{
			Syllabuse entity = this.SyllabuseDataAccess.UpdateSyllabuse(syllabuse);

			this.DataBase.SaveChanges();

			this.SaveTableData(entity.ID, syllabuse.TableData);

			return entity;
		}

		/// <summary>
		/// 删除教学大纲
		/// </summary>
		/// <param name="id">唯一编号</param>
		public virtual void RemoveSyllabuse(long id)
		{
			Syllabuse entity = this.SyllabuseDataAccess.GetSyllabuse(id);

			this.SyllabuseDataAccess.RemoveSyllabuse(entity);

			this.DataBase.SaveChanges();
		}

		/// <summary>
		/// 获取教学大纲
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <returns>教学大纲</returns>
		public virtual Syllabuse GetSyllabuse(long id)
		{
			return this.SyllabuseDataAccess.GetSyllabuse(id);
		}

		/// <summary>
		/// 获取教学大纲
		/// </summary>
		/// <param name="id">唯一编号</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教学大纲</returns>
		public virtual Syllabuse GetSyllabuseOrDefault(long id, Syllabuse defaultEntity = null)
		{
			return this.SyllabuseDataAccess.GetSyllabuseOrDefault(id, defaultEntity);
		}
		
		/// <summary>
		/// 根据条件获取教学大纲
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <returns>教学大纲</returns>
		public virtual Syllabuse GetSyllabuse(Expression<Func<Syllabuse, bool>> predicate)
		{
			return this.SyllabuseDataAccess.GetSyllabuse(predicate);
		}

		/// <summary>
		/// 根据条件获取教学大纲
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="defaultEntity">默认值</param>
		/// <returns>教学大纲</returns>
		public virtual Syllabuse GetSyllabuseOrDefault(Expression<Func<Syllabuse, bool>> predicate, Syllabuse defaultEntity = null)
		{
			return this.SyllabuseDataAccess.GetSyllabuseOrDefault(predicate, defaultEntity);
		}

		/// <summary>
		/// 根据条件查询教学大纲
		/// </summary>
		/// <param name="predicate">查询条件</param>
		/// <param name="pages">分页信息</param>
		/// <returns>教学大纲集合</returns>
		public virtual List<Syllabuse> QuerySyllabuse(Expression<Func<Syllabuse, bool>> predicate, Pages pages = null)
		{
			return this.SyllabuseDataAccess.QuerySyllabuse(predicate, pages);
		}

		/// <summary>
        /// 根据条件查询教学大纲
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学大纲集合</returns>
        public virtual List<Syllabuse> QuerySyllabuse(JObject filter, out Pages pages)
        {
            pages = this.GetPages(filter);

            var predicate = this.CreatePredicate<Syllabuse>();

            return this.SyllabuseDataAccess.QuerySyllabuse(predicate.Expand(), this.GetPredicate(typeof(Syllabuse), filter), pages);
        }
	}
}
