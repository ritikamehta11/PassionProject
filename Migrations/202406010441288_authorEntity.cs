namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Authors");
        }
    }
}
