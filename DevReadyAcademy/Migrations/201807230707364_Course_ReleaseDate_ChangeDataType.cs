namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_ReleaseDate_ChangeDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "ReleaseDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
