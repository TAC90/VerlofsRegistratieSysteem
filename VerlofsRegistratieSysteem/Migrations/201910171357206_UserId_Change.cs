namespace VerlofsRegistratieSysteem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId_Change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absence",
                c => new
                    {
                        AbsenceId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AbsenceHours = c.Int(nullable: false),
                        Employee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.AbsenceId)
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeID)
                .Index(t => t.Employee_EmployeeID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        EMail = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(),
                        ContractType = c.Int(nullable: false),
                        HoursUsed = c.Int(nullable: false),
                        Schedule_ScheduleId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Schedule", t => t.Schedule_ScheduleId)
                .Index(t => t.Schedule_ScheduleId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Holiday",
                c => new
                    {
                        HolidayId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.HolidayId);
            
            CreateTable(
                "dbo.RoleViewModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Schedule_ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.Absence", "Employee_EmployeeID", "dbo.Employee");
            DropIndex("dbo.Employee", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.Absence", new[] { "Employee_EmployeeID" });
            DropTable("dbo.RoleViewModel");
            DropTable("dbo.Holiday");
            DropTable("dbo.Schedule");
            DropTable("dbo.Employee");
            DropTable("dbo.Absence");
        }
    }
}
