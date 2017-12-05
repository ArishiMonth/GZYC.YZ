namespace GZYC.YZ.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Button
    {
        [Key]
        public int ButtonID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ValidKey { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Createtime { get; set; }

        [StringLength(50)]
        public string CreateUserID { get; set; }

        [StringLength(50)]
        public string CreateUserName { get; set; }

        public bool? DeleteMark { get; set; }
    }
}
