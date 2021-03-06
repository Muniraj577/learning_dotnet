namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Description");
        }
    }
}
