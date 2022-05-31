namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "FirstName");
            DropColumn("dbo.Jobs", "SecondName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "SecondName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Jobs", "FirstName", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
