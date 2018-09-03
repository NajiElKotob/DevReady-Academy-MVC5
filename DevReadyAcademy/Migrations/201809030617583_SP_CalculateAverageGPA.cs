namespace DevReadyAcademy.Migrations
{
    using DevReadyAcademy.Models.SQL.StoredProcedure;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_CalculateAverageGPA : DbMigration
    {
        public override void Up()
        {
            /*
                Sql("CREATE OR ALTER PROCEDURE usp_CalculateAverageGPA " +
                "@StudentId INT " +
                "AS " +
                "SET NOCOUNT ON; " +
                "SELECT AVG(Enrollments.Grade) AS AverageGPA " +
                "FROM Enrollments INNER JOIN " +
                "Students ON Enrollments.StudentId = Students.Id " +
                "WHERE Students.Id = @StudentId " +
                "GROUP BY Students.Id");
                */

            //Use Embedded Resources/SQL files instead of the concatenated text
            Sql(StoredProcedures.usp_CalculateAverageGPA_Up__1809030001);
        }

        public override void Down()
        {
            // Sql("DROP PROC IF EXISTS usp_CalculateAverageGPA");
            Sql(StoredProcedures.usp_CalculateAverageGPA_Down__1809030001);

        }
    }
}
