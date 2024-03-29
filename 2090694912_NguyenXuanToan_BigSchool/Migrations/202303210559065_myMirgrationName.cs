﻿namespace _2090694912_NguyenXuanToan_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMirgrationName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropColumn("dbo.Courses", "Name");
            DropTable("dbo.Followings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId });
            
            AddColumn("dbo.Courses", "Name", c => c.String());
            CreateIndex("dbo.Followings", "FolloweeId");
            CreateIndex("dbo.Followings", "FollowerId");
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers", "Id");
        }
    }
}
