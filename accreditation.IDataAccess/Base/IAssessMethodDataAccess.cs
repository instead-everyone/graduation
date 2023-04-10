//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Mooho.Base.Common;
using Mooho.Base.Model;
using accreditation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace accreditation.IDataAccess
{
    /// <summary>
    /// 考核方式数据访问接口
    /// </summary>
    public partial interface IAssessMethodDataAccess
    {
        /// <summary>
        /// 新增考核方式
        /// </summary>
        /// <param name="assessMethod">考核方式</param>
        /// <return>考核方式</return>
        AssessMethod AddAssessMethod(AssessMethod assessMethod);

        /// <summary>
        /// 修改考核方式
        /// </summary>
        /// <param name="assessMethod">考核方式</param>
        /// <return>考核方式</return>
        AssessMethod UpdateAssessMethod(AssessMethod assessMethod);

        /// <summary>
        /// 保存考核方式
        /// </summary>
        /// <param name="assessMethod">考核方式</param>
        /// <return>考核方式</return>
        AssessMethod SaveAssessMethod(AssessMethod assessMethod);

        /// <summary>
        /// 删除考核方式
        /// </summary>
        /// <param name="assessMethod">考核方式</param>
        void RemoveAssessMethod(AssessMethod assessMethod);

        /// <summary>
        /// 根据条件删除考核方式
        /// </summary>
        /// <param name="predicate">查询条件</param>
        void RemoveAssessMethod(Expression<Func<AssessMethod, bool>> predicate);

        /// <summary>
        /// 获取考核方式
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>考核方式</returns>
        AssessMethod GetAssessMethod(long id);

        /// <summary>
        /// 获取考核方式
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>考核方式</returns>
        AssessMethod GetAssessMethodOrDefault(long id, AssessMethod defaultEntity = null);

        /// <summary>
        /// 根据条件获取考核方式
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>考核方式</returns>
        AssessMethod GetAssessMethod(Expression<Func<AssessMethod, bool>> predicate);

        /// <summary>
        /// 根据条件获取考核方式
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>考核方式</returns>
        AssessMethod GetAssessMethodOrDefault(Expression<Func<AssessMethod, bool>> predicate, AssessMethod defaultEntity = null);

        /// <summary>
        /// 根据条件获取考核方式数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>考核方式数量</returns>
        int CountAssessMethod(Expression<Func<AssessMethod, bool>> predicate);

        /// <summary>
        /// 根据条件统计考核方式
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        int? SumAssessMethod(Expression<Func<AssessMethod, int?>> selecter, Expression<Func<AssessMethod, bool>> predicate);

        /// <summary>
        /// 根据条件统计考核方式
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        decimal? SumAssessMethod(Expression<Func<AssessMethod, decimal?>> selecter, Expression<Func<AssessMethod, bool>> predicate);

        /// <summary>
        /// 根据条件查询考核方式
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>考核方式集合</returns>
        List<AssessMethod> QueryAssessMethod(Expression<Func<AssessMethod, bool>> predicate, Pages pages = null);

        /// <summary>
        /// 根据条件查询考核方式
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="dynamicPredicate">动态查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>考核方式集合</returns>
        List<AssessMethod> QueryAssessMethod(Expression<Func<AssessMethod, bool>> predicate, LambdaExpression dynamicPredicate, Pages pages = null);
    }
}
