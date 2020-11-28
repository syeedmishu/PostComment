namespace PostManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentDescription = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ActiveStatus = c.Boolean(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Dislikes",
                c => new
                    {
                        DislikeID = c.Int(nullable: false, identity: true),
                        CreatedBy = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CommentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DislikeID)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: true)
                .Index(t => t.CommentID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeID = c.Int(nullable: false, identity: true),
                        CreatedBy = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CommentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LikeID)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: true)
                .Index(t => t.CommentID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(),
                        PostDescription = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ActiveStatus = c.Boolean(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        EmailAddress = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        RoleID = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreattionDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModiticationDate = c.DateTime(nullable: false),
                        ActiveStaus = c.Boolean(nullable: false),
                        Role_RodeID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Rules", t => t.Role_RodeID)
                .Index(t => t.Role_RodeID);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        RodeID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        ActiveStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RodeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_RodeID", "dbo.Rules");
            DropForeignKey("dbo.Posts", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Likes", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Dislikes", "CommentID", "dbo.Comments");
            DropIndex("dbo.Users", new[] { "Role_RodeID" });
            DropIndex("dbo.Posts", new[] { "User_UserID" });
            DropIndex("dbo.Likes", new[] { "CommentID" });
            DropIndex("dbo.Dislikes", new[] { "CommentID" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropTable("dbo.Rules");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Likes");
            DropTable("dbo.Dislikes");
            DropTable("dbo.Comments");
        }
    }
}
