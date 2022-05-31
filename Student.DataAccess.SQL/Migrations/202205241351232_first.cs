namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StudentName = c.String(nullable: false, maxLength: 30),
                        PropertyId = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 30),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BasketId = c.String(maxLength: 128),
                        DeviceId = c.String(),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.BasketId)
                .Index(t => t.BasketId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DeviceId = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Memory = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperatingSystem = c.String(),
                        ProcessorType = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HardDrive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GraqphicsCard = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VirusProtect = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        YearsOfWarranty = c.Int(nullable: false),
                        DeliveryRequired = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DriverName = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        JobPosition = c.String(),
                        BusinessName = c.String(),
                        Experience = c.Int(nullable: false),
                        University = c.String(),
                        Vaccinated = c.Boolean(nullable: false),
                        ShiftTimes = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Area = c.String(),
                        Address = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        NumBedrooms = c.Int(nullable: false),
                        NumBathrooms = c.Int(nullable: false),
                        NumGarages = c.Int(nullable: false),
                        University = c.String(),
                        Alarm = c.Boolean(nullable: false),
                        Fencing = c.Boolean(nullable: false),
                        Wifi = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderId = c.String(),
                        DeviceId = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        OrderStatus = c.String(),
                        DeliverMethod = c.String(),
                        BasketTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Driver = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        CellNumber = c.Decimal(nullable: false, precision: 18, scale: 2),
                        University = c.String(),
                        Faculty = c.String(),
                        Qualification = c.String(),
                        NumYears = c.Int(nullable: false),
                        Bursary = c.Boolean(nullable: false),
                        EmergencyFirstName = c.String(),
                        Relation = c.String(),
                        EmergencyCellNum = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropTable("dbo.Students");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Listings");
            DropTable("dbo.Jobs");
            DropTable("dbo.Drivers");
            DropTable("dbo.Devices");
            DropTable("dbo.Customers");
            DropTable("dbo.BasketItems");
            DropTable("dbo.Baskets");
            DropTable("dbo.Appointments");
        }
    }
}
