namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_Student_AddNewPropertiesAndValidations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FirstName", c => c.String());
            DropColumn("dbo.Students", "FirstMidName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "FirstMidName", c => c.String());
            DropColumn("dbo.Students", "FirstName");
        }
    }
}
