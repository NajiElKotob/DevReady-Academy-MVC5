namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_Enrollment_AddNewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DeactivateDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Enrollments", "Grade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollments", "Grade");
            DropColumn("dbo.Courses", "DeactivateDate");
        }
    }
}
