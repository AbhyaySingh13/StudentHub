namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeenanOcd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DeliveryMethod", c => c.String());
            DropColumn("dbo.Orders", "DeliverMethod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "DeliverMethod", c => c.String());
            DropColumn("dbo.Orders", "DeliveryMethod");
        }
    }
}
