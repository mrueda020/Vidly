namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerSubscribed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsCustomerSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsCustomerSubscribedToNewsLetter");
        }
    }
}
