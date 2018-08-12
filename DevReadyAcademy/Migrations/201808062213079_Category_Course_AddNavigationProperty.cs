namespace DevReadyAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category_Course_AddNavigationProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CategoryId");
        }
    }
}
