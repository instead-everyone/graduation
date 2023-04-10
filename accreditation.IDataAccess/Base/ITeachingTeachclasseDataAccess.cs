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
    /// 教学班数据访问接口
    /// </summary>
    public partial interface ITeachingTeachclasseDataAccess
    {
        /// <summary>
        /// 新增教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        /// <return>教学班</return>
        TeachingTeachclasse AddTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse);

        /// <summary>
        /// 修改教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        /// <return>教学班</return>
        TeachingTeachclasse UpdateTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse);

        /// <summary>
        /// 保存教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        /// <return>教学班</return>
        TeachingTeachclasse SaveTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse);

        /// <summary>
        /// 删除教学班
        /// </summary>
        /// <param name="teachingTeachclasse">教学班</param>
        void RemoveTeachingTeachclasse(TeachingTeachclasse teachingTeachclasse);

        /// <summary>
        /// 根据条件删除教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        void RemoveTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate);

        /// <summary>
        /// 获取教学班
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>教学班</returns>
        TeachingTeachclasse GetTeachingTeachclasse(long id);

        /// <summary>
        /// 获取教学班
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>教学班</returns>
        TeachingTeachclasse GetTeachingTeachclasseOrDefault(long id, TeachingTeachclasse defaultEntity = null);

        /// <summary>
        /// 根据条件获取教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>教学班</returns>
        TeachingTeachclasse GetTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate);

        /// <summary>
        /// 根据条件获取教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>教学班</returns>
        TeachingTeachclasse GetTeachingTeachclasseOrDefault(Expression<Func<TeachingTeachclasse, bool>> predicate, TeachingTeachclasse defaultEntity = null);

        /// <summary>
        /// 根据条件获取教学班数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>教学班数量</returns>
        int CountTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate);

        /// <summary>
        /// 根据条件统计教学班
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        int? SumTeachingTeachclasse(Expression<Func<TeachingTeachclasse, int?>> selecter, Expression<Func<TeachingTeachclasse, bool>> predicate);

        /// <summary>
        /// 根据条件统计教学班
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        decimal? SumTeachingTeachclasse(Expression<Func<TeachingTeachclasse, decimal?>> selecter, Expression<Func<TeachingTeachclasse, bool>> predicate);

        /// <summary>
        /// 根据条件查询教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学班集合</returns>
        List<TeachingTeachclasse> QueryTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate, Pages pages = null);

        /// <summary>
        /// 根据条件查询教学班
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="dynamicPredicate">动态查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>教学班集合</returns>
        List<TeachingTeachclasse> QueryTeachingTeachclasse(Expression<Func<TeachingTeachclasse, bool>> predicate, LambdaExpression dynamicPredicate, Pages pages = null);
    }
}
