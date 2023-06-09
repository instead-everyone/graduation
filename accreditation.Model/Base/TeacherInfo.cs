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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace accreditation.Model
{
    /// <summary>
    /// 教师信息
    /// </summary>
	[Description("教师信息")]
    [Table("acc_teacher_info")]
    public partial class TeacherInfo : EntityBase
    {
        /// <summary>
        /// 获取或设置教师id编号
        /// </summary>
		[Description("教师id编号")]
        [Key]
        [DataMember]
        [Column("id")]
        public long ID { get; set; }

        /// <summary>
        /// 获取或设置姓名
        /// </summary>
		[Description("姓名")]
        [DataMember]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置账户
        /// </summary>
		[Description("账户")]
        [DataMember]
        [Column("account")]
        public string Account { get; set; }

        /// <summary>
        /// 获取或设置密码
        /// </summary>
		[Description("密码")]
        [DataMember]
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置创建人编号
        /// </summary>
		[Description("创建人编号")]
        [DataMember]
        [Column("create_user_id")]
        public long? CreateUserID { get; set; }

        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
		[Description("创建时间")]
        [DataMember]
        [Column("create_time", TypeName="datetime")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 获取或设置职称
        /// </summary>
		[Description("职称")]
        [DataMember]
        [Column("professional_title")]
        public string ProfessionalTitle { get; set; }

        /// <summary>
        /// 获取或设置更新人编号
        /// </summary>
		[Description("更新人编号")]
        [DataMember]
        [Column("update_user_id")]
        public long? UpdateUserID { get; set; }

        /// <summary>
        /// 获取或设置更新时间
        /// </summary>
		[Description("更新时间")]
        [DataMember]
        [Column("update_time", TypeName="datetime")]
        public DateTime? UpdateTime { get; set; }

    }
}
