
CREATE TABLE [acc].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[ICnumber] [nvarchar](30) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[Gender] [int] NULL,
	[Permissions] [int] NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](128) NULL,
	[PhoneNumber] [nvarchar](16) NULL,
	[Country] [nvarchar](32) NULL,
	[City] [nvarchar](32) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdateAt] [datetime2](7) NOT NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [acc].[Sessions](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ExpireAt] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  StoredProcedure [acc].[usp_DeleteSessionsByUserId]    Script Date: 24-07-2025 18:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [acc].[usp_DeleteSessionsByUserId]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM 
        [acc].[Sessions]
    WHERE 
        [Id] = @Id;
END;

GO
/****** Object:  StoredProcedure [acc].[usp_DeleteUserById]    Script Date: 24-07-2025 18:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acc].[usp_DeleteUserById]
    @Id UNIQUEIDENTIFIER,
    @DeletedBy UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ReturnStatus INT; -- Variable to store the return status
    SET @ReturnStatus = 1; -- Default to success

    BEGIN TRY
        -- Insert the record into the historical table
        INSERT INTO [AWC_CMS_V2_DB_HIST].[acc].[Users_Hist] (
            Id, ICnumber, PasswordHash, PasswordSalt, FirstName, LastName, 
            Email, PhoneNumber, Country, City, Gender, Permissions, [CreatedAt], CreatedBy, UpdateAt, UpdatedBy, [OperatedType], [OperatedAt], [OperatedBy]
        )
        SELECT 
            Id, ICnumber, PasswordHash, PasswordSalt, FirstName, LastName, 
            Email, PhoneNumber, Country, City, Gender, Permissions, [CreatedAt], CreatedBy, UpdateAt, UpdatedBy, 'DELETE', GETDATE(), @DeletedBy 
        FROM 
            [acc].[Users]
        WHERE 
            [Id] = @Id;

        -- Delete the record from the main table
        DELETE FROM 
            [acc].[Users]
        WHERE 
            [Id] = @Id;
    END TRY
    BEGIN CATCH
        -- Log the error in the ErrorLog table
        INSERT INTO [dbo].[ErrorLog] (
            ErrorMessage,
            ErrorDate,
            ProcedureName,
            ErrorDetails
        )
        VALUES (
            ERROR_MESSAGE(),
            GETDATE(),
            OBJECT_NAME(@@PROCID),
            ERROR_PROCEDURE() + ' - Line: ' + CAST(ERROR_LINE() AS NVARCHAR(MAX))
        );

        -- Set return status to failure
        SET @ReturnStatus = -1;
    END CATCH

    RETURN @ReturnStatus; -- Return the status (1 for success, -1 for failure)
END;
GO




/****** Object:  StoredProcedure [acc].[usp_GetAllSessions]    Script Date: 24-07-2025 18:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [acc].[usp_GetAllSessions] AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM [acc].[vs_Sessions];
END;

GO
/****** Object:  StoredProcedure [acc].[usp_GetPagedUsers]    Script Date: 24-07-2025 18:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [acc].[usp_GetPagedUsers]
    @PageNumber INT,
    @PageSize INT,
    @SearchTerm VARCHAR(255)
AS
BEGIN
    -- Validation
    IF @PageNumber < 1 SET @PageNumber = 1;
    IF @PageSize < 1 SET @PageSize = 10;

    -- Trim and handle nulls for search term
    SET @SearchTerm = ISNULL(LTRIM(RTRIM(@SearchTerm)), '');

    -- Calculate offset for pagination
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

    PRINT 'SearchTerm: ' + @SearchTerm;

    -- Prepare a SARGable version of the search term
    SET @SearchTerm = '%' + @SearchTerm + '%';

    -- First result set: paginated users
    SELECT 
        *
    FROM [acc].[Users]
    WHERE 
        (@SearchTerm = '%%' OR 
         ICnumber LIKE @SearchTerm OR 
         [FirstName] LIKE @SearchTerm OR 
         [LastName] LIKE @SearchTerm OR 
         Email LIKE @SearchTerm)
    ORDER BY CreatedAt DESC
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    -- Second result set: total count
    SELECT COUNT(*) AS TotalCount
    FROM [acc].[Users]
    WHERE 
        (@SearchTerm = '%%' OR 
         ICnumber LIKE @SearchTerm OR 
         [FirstName] LIKE @SearchTerm OR 
         [LastName] LIKE @SearchTerm OR 
         Email LIKE @SearchTerm);
END
GO
/****** Object:  StoredProcedure [acc].[usp_GetSessionsById]    Script Date: 24-07-2025 18:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [acc].[usp_GetSessionsById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        s.Id,
        s.UserId,
        s.ExpireAt,
        s.CreatedAt
    FROM 
        [acc].[Sessions] s
    WHERE 
        s.Id = @Id;
END;
GO
/****** Object:  StoredProcedure [acc].[usp_GetUserByICnumber]    Script Date: 24-07-2025 18:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [acc].[usp_GetUserByICnumber]
    @ICnumber NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        PasswordHash,
        PasswordSalt,
        Permissions
    FROM 
        [acc].[Users]
    WHERE 
        [ICnumber] = @ICnumber;
END;
GO
/****** Object:  StoredProcedure [acc].[usp_GetUserById]    Script Date: 24-07-2025 18:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [acc].[usp_GetUserById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [Id],
        [ICnumber],
        [Gender],
        [Permissions],
        [FirstName],
        [LastName],
        [Email],
        [PhoneNumber],
        [Country],
        [City],
        [CreatedAt],
        [UpdateAt]
    FROM 
        [acc].[Users]
    WHERE 
        [Id] = @Id;
END;
GO
/****** Object:  StoredProcedure [acc].[usp_InsertOrUpdateSession]    Script Date: 24-07-2025 18:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [acc].[usp_InsertOrUpdateSession]
    @UserId UNIQUEIDENTIFIER,
    @ExpireAt DATETIME2,
    @InsertedId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN
        -- Create a temporary table to capture the new ID
        CREATE TABLE #NewIds (NewId UNIQUEIDENTIFIER);

        -- Insert new session
        INSERT INTO [acc].[Sessions] (UserId, ExpireAt)
        OUTPUT INSERTED.Id INTO #NewIds -- Capture the new ID
        VALUES (@UserId, @ExpireAt);
		
        SELECT @InsertedId = NewId FROM #NewIds;
		
		RETURN 1; -- Successfully inserted
    END
END;
GO
/****** Object:  StoredProcedure [acc].[usp_InsertOrUpdateUser]    Script Date: 24-07-2025 18:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [acc].[usp_InsertOrUpdateUser]
    @Id UNIQUEIDENTIFIER,
    @ICnumber NVARCHAR(50),
    @PasswordHash VARBINARY(MAX) = NULL,
    @PasswordSalt VARBINARY(MAX) = NULL,
    @FirstName NVARCHAR(30),
    @LastName NVARCHAR(30),
    @Email NVARCHAR(128),
    @PhoneNumber NVARCHAR(16),
    @Country NVARCHAR(32),
    @City NVARCHAR(32),
    @Gender INT,
    @Permissions INT,
    @CreatedBy UNIQUEIDENTIFIER,
    @UpdatedBy UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF EXISTS (
            SELECT 1 
            FROM [acc].[Users] 
            WHERE (ICnumber = @ICnumber OR Email = @Email) AND Id <> @Id
        )
        BEGIN
            RETURN -3;
        END

        IF EXISTS (SELECT 1 FROM Users WHERE Id = @Id)
        BEGIN
            UPDATE [acc].[Users]
            SET 
                ICnumber = @ICnumber,
                PasswordHash = CASE WHEN @PasswordHash IS NOT NULL THEN @PasswordHash ELSE PasswordHash END,
                PasswordSalt = CASE WHEN @PasswordSalt IS NOT NULL THEN @PasswordSalt ELSE PasswordSalt END,
                FirstName = @FirstName,
                LastName = @LastName,
                Email = @Email,
                PhoneNumber = @PhoneNumber,
                Country = @Country,
                City = @City,
                Gender = @Gender,
                Permissions = @Permissions,
                UpdateAt = GETDATE(),
                [UpdatedBy] = @UpdatedBy
            WHERE 
                Id = @Id;

            RETURN 1;
        END
        ELSE
        BEGIN
            INSERT INTO [acc].[Users] (
                ICnumber, PasswordHash, PasswordSalt, FirstName, LastName, 
                Email, PhoneNumber, Country, City, Gender, Permissions, CreatedBy
            )
            VALUES (
                @ICnumber, @PasswordHash, @PasswordSalt, @FirstName, @LastName, 
                @Email, @PhoneNumber, @Country, @City, @Gender, @Permissions, @CreatedBy
            );

            RETURN 1;
        END
    END TRY
    BEGIN CATCH
        INSERT INTO [dbo].[ErrorLog] (ErrorMessage, ProcedureName, ErrorDetails)
        VALUES (
            ERROR_MESSAGE(), 
            'usp_InsertOrUpdateUser', 
            ERROR_PROCEDURE() + ': ' + ERROR_LINE()
        );

        RETURN -1;
    END CATCH
END;
GO
