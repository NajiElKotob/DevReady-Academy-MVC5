namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_AddPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Photo", c => c.Binary());
            AddColumn("dbo.Students", "PhotoType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "PhotoType");
            DropColumn("dbo.Students", "Photo");
        }
    }
}
