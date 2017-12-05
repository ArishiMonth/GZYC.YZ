namespace GZYC.YZ.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MenuIconic
    {
        [Key]
        public int IconicID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Iconic { get; set; }

        public int? Sort { get; set; }

        [StringLength(800)]
        public string Description { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Createtime { get; set; }

        [StringLength(50)]
        public string CreateUserID { get; set; }

        [StringLength(50)]
        public string CreateUserName { get; set; }

        public bool? DeleteMark { get; set; }
    }
}
