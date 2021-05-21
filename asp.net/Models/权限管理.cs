using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class 权限管理上下文:DbContext
    {
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<SystemModule> SystemModules { get; set; }
        public DbSet<SystemModuleOperate> SystemModuleOperates { get; set; }
        public DbSet<SystemUser> SystemUserss { get; set; }
        public DbSet<SystemRoleSysUser> SystemRoleSysUsers { get; set; }
        public DbSet <SystemRight> SystemRights { get; set; }
        public DbSet<SysRightOperate> SysRightOperates { get; set; }
    }
    public class SystemModule
    {   [Key]
        [Required]
        public string ModuleId { get; set; }
        [Required]
        public string text { get; set; }

        public string EnglishName { get; set; }
        
        public string ParentId { get; set; }
        
        public string attributes { get; set; }
        public string Iconic { get; set; }
        public int Sort { get; set; }
        public string Remark { get; set; }
        public string state { get; set; }
        public string CreatePerson { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsLast { get; set; }
        public byte[] Version { get; set; }
        public List<SystemModule> children { get; set; }
       

    }
    public class SystemModuleOperate
    {   [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string KeyCode { get; set; }
        [Required]
        [ForeignKey(nameof(SystemModule))]
        public string ModuleId { get; set; }
        [Required]
        public bool IsValid { get; set; }
        [Required]
        public int Sort { get; set; }
        public  SystemModule SystemModule { get; set; }
        
    }
    public class SystemRight
    {   [Key]
        public string  SystemRightId { get; set; }
        [ForeignKey(nameof(SystemModule))]
        public string  ModuleId { get; set; }
        [ForeignKey(nameof(SystemRole))]
        public string  RoleId { get; set; }
        public bool Rightflag { get; set; }
        public SystemModule SystemModule { get; set; }
        public SystemRole SystemRole { get; set; }
    }
    public class SysRightOperate
    {   [Key]
        public string  Id{ get; set; }
        [ForeignKey(nameof(SystemRight))]
        public string  RightId { get; set; }
        public string  KeyCode { get; set; }
        public bool  IsValid { get; set; }
        public SystemRight SystemRight { get; set; }
    }
    public class SystemRole
    {   [Key]
        public string RoleId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        
        public DateTime CreateTime { get; set; }

        public string CreatePerson { get; set; }
        
    }
    public class SystemRoleSysUser
    {   [Key,Column(Order =0)]
        [ForeignKey(nameof(SystemUser))]
        public string SystenUserId { get; set;}
        public SystemUser SystemUser { get; set; }
        [Key,Column(Order =1)]
        [ForeignKey(nameof(SystemRole))]
        public string SystemRoleId { get; set; }
        public SystemRole SystemRole { get; set; }
    }
    public class SystemUser
    {   [Key]
        public string SystemUserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string TrueName { get; set; }
        public string PhoneNumber { get; set; }
        
    }
    
}
