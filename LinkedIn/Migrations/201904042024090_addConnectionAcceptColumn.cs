namespace LinkedIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConnectionAcceptColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connections", "accept", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Connections", "accept");
        }
    }
}
