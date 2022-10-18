namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationMovie2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rents", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rents", new[] { "Customer_Id" });
            DropIndex("dbo.Rents", new[] { "Movie_Id" });
            RenameColumn(table: "dbo.Rents", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Rents", name: "Movie_Id", newName: "MovieId");
            AlterColumn("dbo.Rents", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rents", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rents", "CustomerId");
            CreateIndex("dbo.Rents", "MovieId");
            AddForeignKey("dbo.Rents", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rents", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            DropColumn("dbo.Rents", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "Name", c => c.String());
            DropForeignKey("dbo.Rents", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Rents", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "MovieId" });
            DropIndex("dbo.Rents", new[] { "CustomerId" });
            AlterColumn("dbo.Rents", "MovieId", c => c.Int());
            AlterColumn("dbo.Rents", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Rents", name: "MovieId", newName: "Movie_Id");
            RenameColumn(table: "dbo.Rents", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Rents", "Movie_Id");
            CreateIndex("dbo.Rents", "Customer_Id");
            AddForeignKey("dbo.Rents", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Rents", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
