namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_AddNewPropertiesAndValidations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TotalHours", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Courses", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Courses", "Title", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Title", c => c.String());
            DropColumn("dbo.Courses", "ReleaseDate");
            DropColumn("dbo.Courses", "IsActive");
            DropColumn("dbo.Courses", "TotalHours");
        }
    }
}
