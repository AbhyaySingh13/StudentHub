namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDeviceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Name", c => c.String());
            AddColumn("dbo.Devices", "Image", c => c.String());
            AddColumn("dbo.Devices", "GraphicsCard", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Students", "Vaccinated", c => c.Boolean(nullable: false));
            DropColumn("dbo.Devices", "DeviceId");
            DropColumn("dbo.Devices", "GraqphicsCard");
            DropColumn("dbo.Devices", "FirstName");
            DropColumn("dbo.Devices", "LastName");
            DropColumn("dbo.Devices", "DeliveryRequired");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "DeliveryRequired", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "LastName", c => c.String());
            AddColumn("dbo.Devices", "FirstName", c => c.String());
            AddColumn("dbo.Devices", "GraqphicsCard", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Devices", "DeviceId", c => c.String());
            DropColumn("dbo.Students", "Vaccinated");
            DropColumn("dbo.Devices", "GraphicsCard");
            DropColumn("dbo.Devices", "Image");
            DropColumn("dbo.Devices", "Name");
        }
    }
}
