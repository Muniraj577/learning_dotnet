namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTableChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Description", c => c.String(nullable: false));
        }
    }
}
