namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Email", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
