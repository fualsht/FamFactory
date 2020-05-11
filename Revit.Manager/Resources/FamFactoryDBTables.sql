--
-- File generated with SQLiteStudio v3.2.1 on Mon May 11 23:21:50 2020
--
-- Text encoding used: System
--
BEGIN TRANSACTION;

-- Table: FF_EmailProfiles
CREATE TABLE FF_EmailProfiles (Id STRING (36, 36) PRIMARY KEY NOT NULL UNIQUE, 
                               Name STRING NOT NULL UNIQUE DEFAULT ('NewEmailProfile'), 
                               Description STRING, 
                               Server STRING NOT NULL UNIQUE DEFAULT ('mail.server.com'), 
                               Port INTEGER NOT NULL DEFAULT (25), 
                               SSL BOOLEAN NOT NULL DEFAULT (false), 
                               UserName STRING, 
                               Password STRING, 
                               State BOOLEAN NOT NULL DEFAULT (false));

-- Table: FF_Permissions
CREATE TABLE FF_Permissions (Id STRING (36, 36) PRIMARY KEY UNIQUE NOT NULL,                              Name STRING UNIQUE NOT NULL,                              Description STRING,                              CanRead BOOLEAN NOT NULL DEFAULT (TRUE),                              CanWrite BOOLEAN NOT NULL DEFAULT (TRUE),
                             CanCreate BOOLEAN NOT NULL DEFAULT (TRUE), 
                             CanDelete BOOLEAN NOT NULL DEFAULT (TRUE), 
                             Special BOOLEAN NOT NULL DEFAULT (TRUE));

-- Table: FF_Users
CREATE TABLE FF_Users(Id STRING (36, 36) PRIMARY KEY UNIQUE NOT NULL,                       Name STRING UNIQUE NOT NULL,                       FirstName TEXT NOT NULL,                       LastName STRING NOT NULL,                       Email STRING NOT NULL,                       Password BOOLEAN NOT NULL,                       ProfilePic BLOB,                       RegistrationDate DATETIME NOT NULL DEFAULT(datetime('Now')),                       LastLogInDate DATETIME NOT NULL DEFAULT(datetime('Now')),
                      PermissionId STRING, State BOOLEAN NOT NULL DEFAULT(FALSE),
                      TempFolder STRING NOT NULL DEFAULT('C:\temp'),
                      CONSTRAINT PermissionsUserId_UsersId FOREIGN KEY(PermissionId) REFERENCES FF_Permissions(Id) ON DELETE SET DEFAULT ON UPDATE CASCADE);

-- Table: FF_SystemConfiguration
CREATE TABLE FF_SystemConfiguration (Id STRING (36, 36) PRIMARY KEY UNIQUE NOT NULL, 
                                     Name STRING NOT NULL UNIQUE DEFAULT ('New System'), 
                                     CompanyAddress STRING, 
                                     Email STRING NOT NULL DEFAULT ('admin@company.com'), 
                                     InstallLocation STRING NOT NULL, 
                                     AppVersion STRING NOT NULL DEFAULT ('v.1.0.0'), 
                                     DataBaseVersion STRING NOT NULL DEFAULT ('v.1.0.0'));

COMMIT TRANSACTION;
