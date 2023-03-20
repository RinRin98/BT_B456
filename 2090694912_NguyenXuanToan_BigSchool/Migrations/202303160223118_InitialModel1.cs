namespace _2090694912_NguyenXuanToan_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        AttendeeID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseId, t.AttendeeID })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.AttendeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendences", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendences", "AttendeeID", "dbo.AspNetUsers");
            DropIndex("dbo.Attendences", new[] { "AttendeeID" });
            DropIndex("dbo.Attendences", new[] { "CourseId" });
            DropTable("dbo.Attendences");
        }
    }
}
