namespace GZYC.YZ.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Menu
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public int? Type { get; set; }

        public int? ParentID { get; set; }

        public int? IconicID { get; set; }

        public int? ButtonID { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        public int Sort { get; set; }

        [StringLength(800)]
        public string Description { get; set; }

        public bool? DeleteMark { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Createtime { get; set; }

        [StringLength(50)]
        public string CreateUserID { get; set; }

        [StringLength(50)]
        public string CreateUserName { get; set; }

        public int? IsDataPermissions { get; set; }

        public bool? OperateLogEnabled { get; set; }
    }
}
