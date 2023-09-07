CREATE DATABASE StudentDb;

USE StudentDb;

CREATE  TABLE StudentMarks (
    StudentID INT PRIMARY KEY ,
    StudentName VARCHAR(50) NOT NULL,
    
    Subject VARCHAR(50) NOT NULL,
    Marks INT NOT NULL
)
INSERT INTO StudentMarks  VALUES   (1,'Dhana',  'Math', 90)  
INSERT INTO StudentMarks  VALUES   (2,'Lakshmi',  'Science', 80) 
INSERT INTO StudentMarks  VALUES   (3,'Rani',  'English', 70) 



SELECT AVG(Marks)AS AverageMarks,
MAX(Marks)  AS MaximumMarks ,
MIN(Marks)  AS MinimumMarks
FROM StudentMarks
SELECT * FROM StudentMarks;
