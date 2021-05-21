namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysRightOperates",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RightId = c.String(maxLength: 128),
                        KeyCode = c.String(),
                        IsValid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SystemRights", t => t.RightId)
                .Index(t => t.RightId);
            
            CreateTable(
                "dbo.SystemRights",
                c => new
                    {
                        SystemRightId = c.String(nullable: false, maxLength: 128),
                        ModuleId = c.String(maxLength: 128),
                        RoleId = c.String(maxLength: 128),
                        Rightflag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SystemRightId)
                .ForeignKey("dbo.SystemModules", t => t.ModuleId)
                .ForeignKey("dbo.SystemRoles", t => t.RoleId)
                .Index(t => t.ModuleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SystemModules",
                c => new
                    {
                        ModuleId = c.String(nullable: false, maxLength: 128),
                        text = c.String(nullable: false),
                        EnglishName = c.String(),
                        ParentId = c.String(),
                        attributes = c.String(),
                        Iconic = c.String(),
                        Sort = c.Int(nullable: false),
                        Remark = c.String(),
                        state = c.String(),
                        CreatePerson = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsLast = c.Boolean(nullable: false),
                        Version = c.Binary(),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.SystemRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreatePerson = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.SystemModuleOperates",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        KeyCode = c.String(nullable: false),
                        ModuleId = c.String(nullable: false, maxLength: 128),
                        IsValid = c.Boolean(nullable: false),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SystemModules", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.SystemRoleSysUsers",
                c => new
                    {
                        SystenUserId = c.String(nullable: false, maxLength: 128),
                        SystemRoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SystenUserId, t.SystemRoleId })
                .ForeignKey("dbo.SystemRoles", t => t.SystemRoleId, cascadeDelete: true)
                .ForeignKey("dbo.SystemUsers", t => t.SystenUserId, cascadeDelete: true)
                .Index(t => t.SystenUserId)
                .Index(t => t.SystemRoleId);
            
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        SystemUserId = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        TrueName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.SystemUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemRoleSysUsers", "SystenUserId", "dbo.SystemUsers");
            DropForeignKey("dbo.SystemRoleSysUsers", "SystemRoleId", "dbo.SystemRoles");
            DropForeignKey("dbo.SystemModuleOperates", "ModuleId", "dbo.SystemModules");
            DropForeignKey("dbo.SysRightOperates", "RightId", "dbo.SystemRights");
            DropForeignKey("dbo.SystemRights", "RoleId", "dbo.SystemRoles");
            DropForeignKey("dbo.SystemRights", "ModuleId", "dbo.SystemModules");
            DropIndex("dbo.SystemRoleSysUsers", new[] { "SystemRoleId" });
            DropIndex("dbo.SystemRoleSysUsers", new[] { "SystenUserId" });
            DropIndex("dbo.SystemModuleOperates", new[] { "ModuleId" });
            DropIndex("dbo.SystemRights", new[] { "RoleId" });
            DropIndex("dbo.SystemRights", new[] { "ModuleId" });
            DropIndex("dbo.SysRightOperates", new[] { "RightId" });
            DropTable("dbo.SystemUsers");
            DropTable("dbo.SystemRoleSysUsers");
            DropTable("dbo.SystemModuleOperates");
            DropTable("dbo.SystemRoles");
            DropTable("dbo.SystemModules");
            DropTable("dbo.SystemRights");
            DropTable("dbo.SysRightOperates");
        }
    }
}
