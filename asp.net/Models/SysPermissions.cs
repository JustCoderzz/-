using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{   public class SysPermissionsConText : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<SysModuleOperate>()
                .HasRequired(o => o.sysModule)
                .WithMany(m => m.sysModuleOperates)
                .HasForeignKey(o => o.ModuleId);
            modelBuilder.Entity<SysModule>()
                .HasMany<SysRole>(c => c.sysRoles)
                .WithMany(s => s.sysModules)
                .Map(cs =>
                {
                    cs.ToTable("SysRight");
                    cs.MapLeftKey("SysModulsRfId");
                    cs.MapRightKey("SysRoleRfmId");
                });
            modelBuilder.Entity<SysRole>()
                .HasMany<SysUser>(s => s.sysUsers)
                .WithMany(c => c.sysRoles)
                .Map(cs =>
                {   
                    cs.ToTable("SysRoleSysUser");
                    cs.MapLeftKey("SysRoleRfuId");
                    cs.MapRightKey("SysUserRfId");
                });
            modelBuilder.Entity<SysUser>().Map(c => c.ToTable("SysUserss"));
        }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysModule> SysModules { get; set; }
        public DbSet<SysModuleOperate> SysModuleOperates { get; set; }
        public DbSet<SysUser> SysUserss { get; set; }
    }
    public class SysModule
    {   [Required]
        public string Id{ get; set; }
        [Required]
        public string Name{ get; set; }

        public string EnglishName { get; set; }
        public string ParentId{ get; set; }
        public string Url{ get; set; }
        public string Iconic{ get; set; }
        public int Sort{ get; set; }
        public string Remark { get; set; }
        public  bool State { get; set; }
        public string CreatePerson { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsLast { get; set; }
        public byte[] Version { get; set; }
        public virtual ICollection<SysModuleOperate> sysModuleOperates { get; set; }
        public virtual ICollection<SysRole> sysRoles { get; set; }
       
    }
    public  class SysModuleOperate
    {   [Required]
        public string Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public string KeyCode { get; set; }
        [Required]
        public string ModuleId{ get; set; }
        [Required]
        public bool IsValid{ get; set; }
        [Required]
        public int Sort{ get; set; } 
        public SysModule sysModule { get; set; }
    }
    public  class SysRole
    {
        public string Id{ get; set; }
        public string Name{ get; set; }

        public string Description{ get; set; }

        public DateTime CreateTime{ get; set; }

        public string CreatePerson{ get; set; }
        public virtual ICollection<SysModule> sysModules { get; set; }
        public virtual ICollection<SysUser> sysUsers { get; set; }
    }
    public class SysUser
    {   
        public string Id{ get; set; }
        [Required]
        public string UserName{ get; set; }
        [Required]
        public string Password{ get; set; }

        public string TrueName{ get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<SysRole> sysRoles { get; set; }

        /*[TrueName] [varchar] (200) NULL,
  [Card] [varchar] (50) NULL,
  [MobileNumber] [varchar] (200) NULL,
  [PhoneNumber] [varchar] (200) NULL,
  [QQ] [varchar] (50) NULL,
  [EmailAddress] [varchar] (200) NULL,
  [OtherContact] [varchar] (200) NULL,
  [Province] [varchar] (200) NULL,
  [City] [varchar] (200) NULL,
  [Village] [varchar] (200) NULL,
  [Address] [varchar] (200) NULL,
  [State] [bit] NULL,
  [CreateTime] [datetime] NULL,
  [CreatePerson] [varchar] (200) NULL,
  [Sex] [varchar] (10) NULL,
  [Birthday] [datetime] NULL,
  [JoinDate] [datetime] NULL,
  [Marital] [varchar] (10) NULL,
  [Political] [varchar] (50) NULL,
  [Nationality] [varchar] (20) NULL,
  [Native] [varchar] (20) NULL,
  [School] [varchar] (50) NULL,
  [Professional] [varchar] (100) NULL,
  [Degree] [varchar] (20) NULL,
  [DepId] [varchar] (50) NOT NULL,

   [PosId] [varchar] (50) NOT NULL,

    [Expertise] [varchar] (3000) NULL,
  [JobState] [varchar] (20) NULL,
  [Photo] [varchar] (200) NULL,
  [Attach] [varchar] (200) NULL,*/

    }

}
