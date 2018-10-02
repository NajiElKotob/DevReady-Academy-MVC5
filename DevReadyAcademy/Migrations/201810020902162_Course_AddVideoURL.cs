namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_AddVideoURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "VideoURL", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "VideoURL");
        }
    }
}
