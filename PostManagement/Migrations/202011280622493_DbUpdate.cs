namespace PostManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostID" });
            AddColumn("dbo.Comments", "Post_PostID", c => c.Int());
            AddColumn("dbo.Comments", "Post_PostID1", c => c.Int());
            AddColumn("dbo.Comments", "Post_PostID2", c => c.Int());
            AlterColumn("dbo.Comments", "ModificationDate", c => c.DateTime());
            AlterColumn("dbo.Comments", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.Posts", "ModificationDate", c => c.DateTime());
            AlterColumn("dbo.Posts", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.Rules", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.Rules", "ModificationDate", c => c.DateTime());
            CreateIndex("dbo.Comments", "Post_PostID");
            CreateIndex("dbo.Comments", "Post_PostID1");
            CreateIndex("dbo.Comments", "Post_PostID2");
            AddForeignKey("dbo.Comments", "Post_PostID", "dbo.Posts", "PostID");
            AddForeignKey("dbo.Comments", "Post_PostID2", "dbo.Posts", "PostID");
            AddForeignKey("dbo.Comments", "Post_PostID1", "dbo.Posts", "PostID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_PostID1", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Post_PostID2", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Post_PostID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_PostID2" });
            DropIndex("dbo.Comments", new[] { "Post_PostID1" });
            DropIndex("dbo.Comments", new[] { "Post_PostID" });
            AlterColumn("dbo.Rules", "ModificationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rules", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "ModificationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "ModificationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Comments", "Post_PostID2");
            DropColumn("dbo.Comments", "Post_PostID1");
            DropColumn("dbo.Comments", "Post_PostID");
            CreateIndex("dbo.Comments", "PostID");
            AddForeignKey("dbo.Comments", "PostID", "dbo.Posts", "PostID", cascadeDelete: true);
        }
    }
}
