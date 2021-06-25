namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postmig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "categories_DataGroupField");
            DropColumn("dbo.Posts", "categories_DataTextField");
            DropColumn("dbo.Posts", "categories_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "categories_DataValueField", c => c.String());
            AddColumn("dbo.Posts", "categories_DataTextField", c => c.String());
            AddColumn("dbo.Posts", "categories_DataGroupField", c => c.String());
        }
    }
}
