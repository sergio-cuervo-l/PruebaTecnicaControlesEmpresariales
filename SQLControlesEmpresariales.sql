-- Eliminar la base de datos si existe
IF DB_ID(N'ControlesEmpresariales_Test') IS NOT NULL
    DROP DATABASE ControlesEmpresariales_Test;

-- Crear la base de datos
CREATE DATABASE ControlesEmpresariales_Test;
GO

-- Usar la base de datos recién creada
USE ControlesEmpresariales_Test;
GO

CREATE TABLE Department(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NULL
);

INSERT INTO Department VALUES ('Sin Departamento Asignado');

CREATE TABLE Project(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NULL
);

INSERT INTO Project VALUES ('Sin Proyecto Asignado');

CREATE TABLE Employee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    CurrentPosition INT NOT NULL,
    Salary DECIMAL NULL,
    IdDepartment INT NOT NULL,
    IdProject INT NOT NULL,
    CONSTRAINT FK_Department_Employee FOREIGN KEY (IdDepartment) REFERENCES dbo.Department(Id),
    CONSTRAINT FK_Project_Employee FOREIGN KEY (IdProject) REFERENCES dbo.Project(Id),
);

CREATE TABLE PositionHistory(
    EmployeeId INT NOT NULL,
    Position NVARCHAR(100) NULL,
    StartDate DATETIME NOT NULL DEFAULT(GETDATE()),
    EndDate DATETIME NULL,
    CONSTRAINT FK_Employee_PositionHistory FOREIGN KEY (EmployeeId) REFERENCES dbo.Employee(Id),
);

CREATE TABLE Users(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NULL,
    Password NVARCHAR(100) NOT NULL DEFAULT(GETDATE()),
    Role NVARCHAR(100) NULL
);