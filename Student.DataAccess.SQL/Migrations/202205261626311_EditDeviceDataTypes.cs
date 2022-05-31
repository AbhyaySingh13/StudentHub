namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDeviceDataTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "ProcessorType", c => c.String());
            AlterColumn("dbo.Devices", "HardDrive", c => c.String());
            AlterColumn("dbo.Devices", "GraphicsCard", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "GraphicsCard", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Devices", "HardDrive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Devices", "ProcessorType", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
