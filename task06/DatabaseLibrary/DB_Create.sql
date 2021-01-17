CREATE DATABASE StudentSessionReports;
GO

USE StudentSessionReports;

CREATE TABLE [Groups] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255) not null
)

CREATE TABLE [Students] (
  [Id] int PRIMARY KEY IDENTITY,
  [LastName] nvarchar(255) not null,
  [FirstName] nvarchar(255) not null,
  [MiddleName] nvarchar(255) not null,
  [Gender] nvarchar(255) not null,
  [Birthday] date not null,
  [GroupId] int not null
)

CREATE TABLE [Sessions] (
  [Id] int PRIMARY KEY IDENTITY,
  [NumberOfSession] int not null,
  [StudentId] int not null
)

CREATE TABLE [SessionResults] (
  [Id] int PRIMARY KEY IDENTITY,
  [SessionId] int not null,
  [SubjectName] nvarchar(255) not null,
  [SubjectCheckType] nvarchar(255) not null,
  [DateOfPassing] date not null, 
  [Mark] int not null
)
GO

ALTER TABLE [Students] ADD FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [Sessions] ADD FOREIGN KEY ([StudentId]) REFERENCES [Students] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [SessionResults] ADD FOREIGN KEY ([SessionId]) REFERENCES [Sessions] ([Id]) ON DELETE CASCADE
GO
