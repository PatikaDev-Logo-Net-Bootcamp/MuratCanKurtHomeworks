-- create database if the database does not already exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LogoDb')
BEGIN
	CREATE DATABASE [LogoDb]
END
GO

-- create schema if the schema does not already exist
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'CustomerData')
BEGIN
	EXEC ('CREATE SCHEMA CustomerData')
END
GO

-- select database to query
USE LogoDb
GO

-- create Companies table with primary key and other attributes, if the the table does not already exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Companies')
BEGIN
	CREATE TABLE Companies (
		Id INT PRIMARY KEY IDENTITY(100,1), --id starts from 100 and increases 1
		Name NVARCHAR(150) NOT NULL,
		StAddress NVARCHAR(250),
		City NVARCHAR (100) NOT NULL,
		Country NVARCHAR (100) NOT NULL DEFAULT 'Turkey',
		IsDeleted BIT NOT NULL DEFAULT 0
	)
END
GO

-- create Users table with primary and foreign keys and other attributes, if the table does not already exist 
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
	CREATE TABLE Users (
		Id INT PRIMARY KEY IDENTITY(1,1),
		CompanyId INT CONSTRAINT FK_CompanyId FOREIGN KEY (CompanyId) REFERENCES Companies(Id),
		FullName NVARCHAR(150) NOT NULL,
		IsFemale BIT NOT NULL DEFAULT 1,
		BirthDate DATE,
		City NVARCHAR (100) NOT NULL,
		IsDeleted BIT NOT NULL DEFAULT 0
	)
END
GO


-- Create stored procedure to insert Company
CREATE PROCEDURE InsertCompany @Name NVARCHAR(150), @StAddress NVARCHAR(250), @City NVARCHAR(100), @Country NVARCHAR(100)
AS
INSERT INTO Companies (Name, StAddress, City, Country) VALUES (@Name, @StAddress, @City, @Country)
GO


-- Create stored procedure to insert User
CREATE PROCEDURE InsertUser @CompanyId INT, @Name NVARCHAR(150), @IsFemale BIT, @BirthDate DATE, @City NVARCHAR(100)
AS
INSERT INTO Users(CompanyId, FullName, IsFemale, BirthDate, City) VALUES (@CompanyId, @Name, @IsFemale, @BirthDate, @City)
GO


-- Sample use of InsertCompany procedure: insert 2 company entries.
EXEC InsertCompany @Name = 'MucroSoft', @StAddress = 'Ataturk Cd.', @City = 'Antalya', @Country = 'Turkey'
EXEC InsertCompany @Name = 'LOGO Software INC.', @StAddress = 'Mustafa Kemal Cd.', @City = 'New York', @Country = 'USA'


-- Sample use of InsertUser procedure: insert 3 user entries, Note that we can execute procedures without explicitly using parameters.
EXEC InsertUser 100, 'John Doe' , 0, '2000-02-02', 'Şanlıurfa'
EXEC InsertUser 101, 'Jane Boe' , 1, '1988-06-01', 'Yalova'
EXEC InsertUser 101, 'Murat Can Kurt' , 0, '1986-03-21', 'Antalya'


-- Check tables...
SELECT * FROM Companies
SELECT * FROM Users
