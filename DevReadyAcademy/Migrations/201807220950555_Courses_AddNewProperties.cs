namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Courses_AddNewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "CourseVersion", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseVersion");
            DropColumn("dbo.Courses", "CourseNumber");
        }
    }
}
