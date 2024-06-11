namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removemethods : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Books", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Author_AuthorId" });
            DropIndex("dbo.Books", new[] { "Genre_GenreId" });
            RenameColumn(table: "dbo.Books", name: "Author_AuthorId", newName: "AuthorId");
            RenameColumn(table: "dbo.Books", name: "Genre_GenreId", newName: "GenreId");
            CreateIndex("dbo.Books", "AuthorId");
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            AlterColumn("dbo.Books", "GenreId", c => c.Int());
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "GenreId", newName: "Genre_GenreId");
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_AuthorId");
            CreateIndex("dbo.Books", "Genre_GenreId");
            CreateIndex("dbo.Books", "Author_AuthorId");
            AddForeignKey("dbo.Books", "Genre_GenreId", "dbo.Genres", "GenreId");
            AddForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors", "AuthorId");
        }
    }
}
