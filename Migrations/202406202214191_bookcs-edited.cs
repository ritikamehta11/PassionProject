namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookcsedited : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.Genres", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Books", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.Authors", new[] { "Book_BookId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "Genre_GenreId" });
            DropIndex("dbo.Books", new[] { "Author_AuthorId" });
            DropIndex("dbo.Genres", new[] { "Book_BookId" });
            DropColumn("dbo.Books", "AuthorId");
            DropColumn("dbo.Books", "GenreId");
            RenameColumn(table: "dbo.Books", name: "Author_AuthorId", newName: "AuthorId");
            RenameColumn(table: "dbo.Books", name: "Genre_GenreId", newName: "GenreId");
            
            CreateIndex("dbo.Books", "AuthorId");
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            DropColumn("dbo.Authors", "Book_BookId");
            DropColumn("dbo.Genres", "Book_BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Book_BookId", c => c.Int());
            AddColumn("dbo.Authors", "Book_BookId", c => c.Int());
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
            AlterColumn("dbo.Books", "GenreId", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "GenreId", newName: "Genre_GenreId");
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_AuthorId");
            AddColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Genres", "Book_BookId");
            CreateIndex("dbo.Books", "Author_AuthorId");
            CreateIndex("dbo.Books", "Genre_GenreId");
            CreateIndex("dbo.Books", "GenreId");
            CreateIndex("dbo.Books", "AuthorId");
            CreateIndex("dbo.Authors", "Book_BookId");
            AddForeignKey("dbo.Books", "Genre_GenreId", "dbo.Genres", "GenreId");
            AddForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors", "AuthorId");
            AddForeignKey("dbo.Genres", "Book_BookId", "dbo.Books", "BookId");
            AddForeignKey("dbo.Authors", "Book_BookId", "dbo.Books", "BookId");
        }
    }
}
