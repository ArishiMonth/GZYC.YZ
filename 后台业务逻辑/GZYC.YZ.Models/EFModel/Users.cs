namespace GZYC.YZ.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Account { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        public int Status { get; set; }

        public int Sort { get; set; }

        public string Note { get; set; }
    }
}
