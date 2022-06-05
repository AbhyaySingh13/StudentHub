namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedApplications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        JobId = c.String(),
                        StudentName = c.String(),
                        University = c.String(),
                        Qualification = c.String(),
                        Email = c.String(),
                        Cell = c.String(),
                        CV = c.String(),
                        Image = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Applications");
        }
    }
}
