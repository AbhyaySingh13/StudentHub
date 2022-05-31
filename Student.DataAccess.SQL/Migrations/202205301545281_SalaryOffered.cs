namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryOffered : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "SalaryOffered", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Devices", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Devices", "Price", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Devices", "Memory", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Devices", "OperatingSystem", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "JobPosition", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "BusinessName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "ShiftTimes", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Listings", "Area", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Listings", "Address", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Listings", "Description", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Listings", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Listings", "Address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Listings", "Area", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "ShiftTimes", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Jobs", "BusinessName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Jobs", "JobPosition", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Devices", "OperatingSystem", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Devices", "Memory", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Devices", "Price", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Devices", "Name", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Jobs", "SalaryOffered");
        }
    }
}
