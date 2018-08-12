namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_Enhancements : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "FirstDeactivationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "FirstDeactivationDate", c => c.DateTime());
        }
    }
}
