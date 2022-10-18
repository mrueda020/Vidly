namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationMovie1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rents", "MovieId", "dbo.Movies");
            DropIndex("dbo.Rents", new[] { "CustomerId" });
            DropIndex("dbo.Rents", new[] { "MovieId" });
            RenameColumn(table: "dbo.Rents", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.Rents", name: "MovieId", newName: "Movie_Id");
            AddColumn("dbo.Rents", "Name", c => c.String());
            AlterColumn("dbo.Rents", "Customer_Id", c => c.Int());
            AlterColumn("dbo.Rents", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Rents", "Customer_Id");
            CreateIndex("dbo.Rents", "Movie_Id");
            AddForeignKey("dbo.Rents", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Rents", "Movie_Id", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rents", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "Movie_Id" });
            DropIndex("dbo.Rents", new[] { "Customer_Id" });
            AlterColumn("dbo.Rents", "Movie_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rents", "Customer_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Rents", "Name");
            RenameColumn(table: "dbo.Rents", name: "Movie_Id", newName: "MovieId");
            RenameColumn(table: "dbo.Rents", name: "Customer_Id", newName: "CustomerId");
            CreateIndex("dbo.Rents", "MovieId");
            CreateIndex("dbo.Rents", "CustomerId");
            AddForeignKey("dbo.Rents", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rents", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
