namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "categories_DataGroupField", c => c.String());
            AddColumn("dbo.Posts", "categories_DataTextField", c => c.String());
            AddColumn("dbo.Posts", "categories_DataValueField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "categories_DataValueField");
            DropColumn("dbo.Posts", "categories_DataTextField");
            DropColumn("dbo.Posts", "categories_DataGroupField");
        }
    }
}
