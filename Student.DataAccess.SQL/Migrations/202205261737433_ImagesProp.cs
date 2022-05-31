namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagesProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Image", c => c.String());
            AddColumn("dbo.Listings", "Image", c => c.String());
            AlterColumn("dbo.Appointments", "Address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Street", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Devices", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Devices", "Price", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Devices", "Memory", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Devices", "OperatingSystem", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Devices", "ProcessorType", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Devices", "HardDrive", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Devices", "GraphicsCard", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Drivers", "DriverName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Drivers", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Drivers", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Drivers", "Street", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "SecondName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "JobPosition", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Jobs", "BusinessName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Jobs", "Experience", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "University", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Jobs", "ShiftTimes", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Listings", "Area", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Listings", "Address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Listings", "Price", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Listings", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Listings", "University", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Students", "CellNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "University", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Students", "Faculty", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "Qualification", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "EmergencyFirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Students", "Relation", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Students", "EmergencyCellNum", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "EmergencyCellNum", c => c.String());
            AlterColumn("dbo.Students", "Relation", c => c.String());
            AlterColumn("dbo.Students", "EmergencyFirstName", c => c.String());
            AlterColumn("dbo.Students", "Qualification", c => c.String());
            AlterColumn("dbo.Students", "Faculty", c => c.String());
            AlterColumn("dbo.Students", "University", c => c.String());
            AlterColumn("dbo.Students", "CellNumber", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Listings", "University", c => c.String());
            AlterColumn("dbo.Listings", "Description", c => c.String());
            AlterColumn("dbo.Listings", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Listings", "Address", c => c.String());
            AlterColumn("dbo.Listings", "Area", c => c.String());
            AlterColumn("dbo.Jobs", "ShiftTimes", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "University", c => c.String());
            AlterColumn("dbo.Jobs", "Experience", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "BusinessName", c => c.String());
            AlterColumn("dbo.Jobs", "JobPosition", c => c.String());
            AlterColumn("dbo.Jobs", "Email", c => c.String());
            AlterColumn("dbo.Jobs", "SecondName", c => c.String());
            AlterColumn("dbo.Jobs", "FirstName", c => c.String());
            AlterColumn("dbo.Drivers", "Street", c => c.String());
            AlterColumn("dbo.Drivers", "City", c => c.String());
            AlterColumn("dbo.Drivers", "Email", c => c.String());
            AlterColumn("dbo.Drivers", "DriverName", c => c.String());
            AlterColumn("dbo.Devices", "GraphicsCard", c => c.String());
            AlterColumn("dbo.Devices", "HardDrive", c => c.String());
            AlterColumn("dbo.Devices", "ProcessorType", c => c.String());
            AlterColumn("dbo.Devices", "OperatingSystem", c => c.String());
            AlterColumn("dbo.Devices", "Memory", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Devices", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Devices", "Name", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "Street", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            AlterColumn("dbo.Appointments", "Address", c => c.String(maxLength: 30));
            DropColumn("dbo.Listings", "Image");
            DropColumn("dbo.Jobs", "Image");
        }
    }
}
