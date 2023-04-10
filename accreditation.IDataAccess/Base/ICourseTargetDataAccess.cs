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
    /// 课程目标数据访问接口
    /// </summary>
    public partial interface ICourseTargetDataAccess
    {
        /// <summary>
        /// 新增课程目标
        /// </summary>
        /// <param name="courseTarget">课程目标</param>
        /// <return>课程目标</return>
        CourseTarget AddCourseTarget(CourseTarget courseTarget);

        /// <summary>
        /// 修改课程目标
        /// </summary>
        /// <param name="courseTarget">课程目标</param>
        /// <return>课程目标</return>
        CourseTarget UpdateCourseTarget(CourseTarget courseTarget);

        /// <summary>
        /// 保存课程目标
        /// </summary>
        /// <param name="courseTarget">课程目标</param>
        /// <return>课程目标</return>
        CourseTarget SaveCourseTarget(CourseTarget courseTarget);

        /// <summary>
        /// 删除课程目标
        /// </summary>
        /// <param name="courseTarget">课程目标</param>
        void RemoveCourseTarget(CourseTarget courseTarget);

        /// <summary>
        /// 根据条件删除课程目标
        /// </summary>
        /// <param name="predicate">查询条件</param>
        void RemoveCourseTarget(Expression<Func<CourseTarget, bool>> predicate);

        /// <summary>
        /// 获取课程目标
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <returns>课程目标</returns>
        CourseTarget GetCourseTarget(long id);

        /// <summary>
        /// 获取课程目标
        /// </summary>
        /// <param name="id">唯一编号</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>课程目标</returns>
        CourseTarget GetCourseTargetOrDefault(long id, CourseTarget defaultEntity = null);

        /// <summary>
        /// 根据条件获取课程目标
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>课程目标</returns>
        CourseTarget GetCourseTarget(Expression<Func<CourseTarget, bool>> predicate);

        /// <summary>
        /// 根据条件获取课程目标
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="defaultEntity">默认值</param>
        /// <returns>课程目标</returns>
        CourseTarget GetCourseTargetOrDefault(Expression<Func<CourseTarget, bool>> predicate, CourseTarget defaultEntity = null);

        /// <summary>
        /// 根据条件获取课程目标数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>课程目标数量</returns>
        int CountCourseTarget(Expression<Func<CourseTarget, bool>> predicate);

        /// <summary>
        /// 根据条件统计课程目标
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        int? SumCourseTarget(Expression<Func<CourseTarget, int?>> selecter, Expression<Func<CourseTarget, bool>> predicate);

        /// <summary>
        /// 根据条件统计课程目标
        /// </summary>
        /// <param name="selecter">统计字段</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>统计值</returns>
        decimal? SumCourseTarget(Expression<Func<CourseTarget, decimal?>> selecter, Expression<Func<CourseTarget, bool>> predicate);

        /// <summary>
        /// 根据条件查询课程目标
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>课程目标集合</returns>
        List<CourseTarget> QueryCourseTarget(Expression<Func<CourseTarget, bool>> predicate, Pages pages = null);

        /// <summary>
        /// 根据条件查询课程目标
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="dynamicPredicate">动态查询条件</param>
        /// <param name="pages">分页信息</param>
        /// <returns>课程目标集合</returns>
        List<CourseTarget> QueryCourseTarget(Expression<Func<CourseTarget, bool>> predicate, LambdaExpression dynamicPredicate, Pages pages = null);
    }
}
