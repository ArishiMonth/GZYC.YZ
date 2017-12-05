namespace GZYC.YZ.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Role
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public int SortCode { get; set; }

        public bool? DeleteMark { get; set; }

        public bool? Enabled { get; set; }

        [StringLength(800)]
        public string Description { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Createtime { get; set; }

        [StringLength(50)]
        public string CreateUserID { get; set; }

        [StringLength(50)]
        public string CreateUserName { get; set; }
    }
}
