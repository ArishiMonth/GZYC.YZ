namespace GZYC.YZ.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Permissions
    {
        public int ID { get; set; }

        public int? MenuID { get; set; }

        public int? RoleID { get; set; }
    }
}
