namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_AddNewPropertiesAndValidations1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Description", c => c.String(maxLength: 400));
            AddColumn("dbo.Courses", "PublishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "FirstActivationDate", c => c.DateTime());
            AddColumn("dbo.Courses", "FirstDeactivationDate", c => c.DateTime());
            DropColumn("dbo.Courses", "ReleaseDate");
            DropColumn("dbo.Courses", "DeactivateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "DeactivateDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Courses", "ReleaseDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Courses", "FirstDeactivationDate");
            DropColumn("dbo.Courses", "FirstActivationDate");
            DropColumn("dbo.Courses", "PublishDate");
            DropColumn("dbo.Courses", "Description");
        }
    }
}
