namespace LinkedIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPostImageColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "post_image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "post_image");
        }
    }
}
