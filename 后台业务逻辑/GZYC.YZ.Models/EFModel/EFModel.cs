namespace GZYC.YZ.Models.EFModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFModel : DbContext
    {
        public EFModel()
            : base("name=EFModel")
        {
        }

        public virtual DbSet<tb_Log> tb_Log { get; set; }
        public virtual DbSet<tb_Button> tb_Button { get; set; }
        public virtual DbSet<tb_DataPermissions> tb_DataPermissions { get; set; }
        public virtual DbSet<tb_Menu> tb_Menu { get; set; }
        public virtual DbSet<tb_MenuIconic> tb_MenuIconic { get; set; }
        public virtual DbSet<tb_Permissions> tb_Permissions { get; set; }
        public virtual DbSet<tb_Role> tb_Role { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<tb_DataPermissions>()
                .Property(e => e.DataAccessScope)
                .IsUnicode(false);

            modelBuilder.Entity<tb_DataPermissions>()
                .Property(e => e.OrganizationsListed)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
