namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));

        }

        public override void Down()
        {
        }
    }
}
