CREATE OR ALTER PROCEDURE usp_CalculateAverageGPA 
	@StudentId INT 
AS 
	SET NOCOUNT ON;
	SELECT AVG(Enrollments.Grade) AS AverageGPA 
	FROM Enrollments INNER JOIN 
	Students ON Enrollments.StudentId = Students.Id 
	WHERE Students.Id = @StudentId 
	GROUP BY Students.Id
GO