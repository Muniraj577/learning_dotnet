namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkinpost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "CatId");
            RenameColumn(table: "dbo.Posts", name: "Category_Id", newName: "CatId");
            RenameIndex(table: "dbo.Posts", name: "IX_Category_Id", newName: "IX_CatId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_CatId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Posts", name: "CatId", newName: "Category_Id");
            AddColumn("dbo.Posts", "CatId", c => c.Int());
        }
    }
}
