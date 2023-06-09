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
    /// 毕业指标点
    /// </summary>
	[Description("毕业指标点")]
    [Table("acc_graduation_point")]
    public partial class GraduationPoint : EntityBase
    {
        /// <summary>
        /// 获取或设置毕业指标点id编号
        /// </summary>
		[Description("毕业指标点id编号")]
        [Key]
        [DataMember]
        [Column("id")]
        public long ID { get; set; }

        /// <summary>
        /// 获取或设置权重
        /// </summary>
		[Description("权重")]
        [DataMember]
        [Column("weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// 获取或设置内容
        /// </summary>
		[Description("内容")]
        [DataMember]
        [Column("content")]
        public string Content { get; set; }

        /// <summary>
        /// 获取或设置完成度
        /// </summary>
		[Description("完成度")]
        [DataMember]
        [Column("completion")]
        public double? Completion { get; set; }

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
