namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedbook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            AddColumn("dbo.Books", "Genre_GenreId", c => c.Int());
            AddColumn("dbo.Genres", "Book_BookId", c => c.Int());
            CreateIndex("dbo.Books", "Genre_GenreId");
            CreateIndex("dbo.Genres", "Book_BookId");
            AddForeignKey("dbo.Genres", "Book_BookId", "dbo.Books", "BookId");
            AddForeignKey("dbo.Books", "Genre_GenreId", "dbo.Genres", "GenreId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.Genres", "Book_BookId", "dbo.Books");
            DropIndex("dbo.Genres", new[] { "Book_BookId" });
            DropIndex("dbo.Books", new[] { "Genre_GenreId" });
            DropColumn("dbo.Genres", "Book_BookId");
            DropColumn("dbo.Books", "Genre_GenreId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
        }
    }
}
