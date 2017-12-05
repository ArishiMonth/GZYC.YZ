namespace GZYC.YZ.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_DataPermissions
    {
        public int ID { get; set; }

        public int? FunctionID { get; set; }

        [StringLength(50)]
        public string DataAccessScope { get; set; }

        [StringLength(50)]
        public string OrganizationsListed { get; set; }

        public int? RoleID { get; set; }
    }
}
