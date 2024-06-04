namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterColumnName : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Books", "Description", "PublicationYear");

            // Change the column data type
            AlterColumn("dbo.Books", "PublicationYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
