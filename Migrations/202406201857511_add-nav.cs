namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnav : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            AddColumn("dbo.Authors", "Book_BookId", c => c.Int());
            AddColumn("dbo.Books", "Author_AuthorId", c => c.Int());
            CreateIndex("dbo.Authors", "Book_BookId");
            CreateIndex("dbo.Books", "Author_AuthorId");
            AddForeignKey("dbo.Authors", "Book_BookId", "dbo.Books", "BookId");
            AddForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors", "AuthorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Authors", "Book_BookId", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Author_AuthorId" });
            DropIndex("dbo.Authors", new[] { "Book_BookId" });
            DropColumn("dbo.Books", "Author_AuthorId");
            DropColumn("dbo.Authors", "Book_BookId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
        }
    }
}
