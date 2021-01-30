USE StudentSessionReportsLINQ

SET NOCOUNT ON

DECLARE @RowCount int,
		@RowIndex int,

		@SpecialityName varchar(255),

		@GroupName varchar(255),
		@SpecialtyId int,
		
		@LastName varchar(255),
		@FirstName varchar(255),
		@MiddleName varchar(255),
		@Gender varchar(6),
		@Birthday date,
		@GroupId int,

		@NumberOfSession int,
		@StudentId int,

		@SessionId int,
		@SubjectName varchar(255),
		@SubjectCheckType varchar(8),
		@TeacherFullName varchar(255),
		@DateOfPassing date,
		@Mark int

---- Table "Specialities"
SET @RowCount = 10
SET @RowIndex = 1

WHILE @RowIndex <= @RowCount
BEGIN
	SET @SpecialityName = 'specialty' + CONVERT(VARCHAR(4), @RowIndex)

	INSERT INTO Specialties(Name) VALUES (@SpecialityName)

	SET @RowIndex += 1
END

---- Table "Groups".
SET @RowCount = 100
SET @RowIndex = 1

WHILE @RowIndex <= @RowCount
BEGIN
	SET @GroupName = 'group' + CONVERT(VARCHAR(4), @RowIndex)
	SET @SpecialtyId = RAND()*9 + 1

	INSERT INTO Groups(Name, SpecialtyId) VALUES (@GroupName, @SpecialtyId)

	SET @RowIndex += 1
END

-- Table "Students".
SET @RowCount = 1000
SET @RowIndex = 1

WHILE @RowIndex <= @RowCount
BEGIN
	SET @LastName = 'lastName' + CONVERT(VARCHAR(4), @RowIndex)
	SET @FirstName = 'firstName' + CONVERT(VARCHAR(4), @RowIndex)
	SET @MiddleName = 'middleName' + CONVERT(VARCHAR(4), @RowIndex)		
	
	IF ROUND(RAND(), 0) = 0
		SET @Gender = 'Male'
	ELSE
		SET @Gender = 'Female'

	SET @Birthday = GETDATE() + (365 * 2 * RAND() - 365)
	SET @GroupId = RAND()*(99)+1

	INSERT INTO Students(LastName, FirstName, MiddleName, Gender, Birthday, GroupId) VALUES (@LastName, @FirstName, @MiddleName, @Gender, @Birthday, @GroupId)

	SET @RowIndex += 1
END

-- Table "Sessions".
SET @RowCount = 1000
SET @RowIndex = 1

WHILE @RowIndex <= @RowCount
BEGIN
	SET @NumberOfSession = RAND()*(8)+1
	SET @StudentId = RAND()*(999)+1

	INSERT INTO Sessions(NumberOfSession, StudentId) VALUES (@NumberOfSession, @StudentId)

	SET @RowIndex += 1
END

-- Table "SessionResults".
SET @RowCount = 1000
SET @RowIndex = 1

WHILE @RowIndex <= @RowCount
BEGIN
	SET @SessionId = RAND()*(999)+1
	SET @SubjectName = 'SubjectName' + CONVERT(VARCHAR(4), @RowIndex)

	IF ROUND(RAND(), 0) = 0
		SET @SubjectCheckType = 'Exam'
	ELSE
		SET @SubjectCheckType = 'Test'

	SET @TeacherFullName = 'teacherFullName' + CONVERT(VARCHAR(4), @RowIndex)
	SET @DateOfPassing = GETDATE() + (365 * 2 * RAND() - 365)
	SET @Mark = RAND()*(9)+1

	INSERT INTO SessionResults(SessionId, SubjectName, SubjectCheckType, TeacherFullName, DateOfPassing, Mark) VALUES (@SessionId, @SubjectName, @SubjectCheckType, @TeacherFullName, @DateOfPassing, @Mark)

	SET @RowIndex += 1
END