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
                               ServerAddress STRING NOT NULL UNIQUE DEFAULT ('mail.server.com'), 
                               Port INTEGER NOT NULL DEFAULT (25), 
                               SSL BOOLEAN NOT NULL DEFAULT (false), 
                               Username STRING, 
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

-- Table: FF_FamilyComponentTypes
CREATE TABLE FF_FamilyComponentTypes (Id STRING (36, 36) PRIMARY KEY NOT NULL UNIQUE,
                                      Name STRING NOT NULL UNIQUE DEFAULT ('New Type'),
                                      Description STRING,
                                      Thumbnail BLOB);
          
-- Table: FF_FamilyTemplates
CREATE TABLE FF_FamilyTemplates (Id STRING (36, 36) PRIMARY KEY UNIQUE NOT NULL, 
                                  Name STRING UNIQUE NOT NULL DEFAULT ('New Family Template'), 
                                  Description STRING, 
                                  FamilyCategory STRING NOT NULL, 
                                  FamilyFile BLOB NOT NULL, 
                                  Thumbnail BLOB NOT NULL, 
                                  FileSize INT NOT NULL, 
                                  DateCreated DATETIME NOT NULL, 
                                  DateModified DATETIME NOT NULL, 
                                  CreatedByUserId STRING (36, 36) NOT NULL, 
                                  Version STRING NOT NULL DEFAULT ('v.1.0.0'), 
                                  IsReleased BOOLEAN NOT NULL DEFAULT (false), 
                                  RoundConnectorDimension STRING NOT NULL, 
                                  PartType STRING NOT NULL, 
                                  OmniClassNumber STRING NOT NULL, 
                                  OmniClassTitle STRING NOT NULL, 
                                  WorkPlaneBased BOOLEAN DEFAULT (false) NOT NULL, 
                                  AlwaysVertical BOOLEAN NOT NULL DEFAULT (false), 
                                  CutsWithVoidWhenLoaded BOOLEAN NOT NULL DEFAULT (false), 
                                  IsShared BOOLEAN NOT NULL DEFAULT (false), 
                                  RoomCalculationPoint BOOLEAN NOT NULL DEFAULT (false), 
                                  FileName STRING NOT NULL, 
                                  CanHostRebar BOOLEAN DEFAULT (false) NOT NULL,
                                  CONSTRAINT FamilyTemplateCreatedByUserId_UserId FOREIGN KEY (CreatedByUserId) REFERENCES FF_Users (Id));


-- Table: FF_FamilyComponents
CREATE TABLE FF_FamilyComponents (Id STRING (36, 36) PRIMARY KEY UNIQUE NOT NULL, 
                                  Name STRING UNIQUE NOT NULL DEFAULT ('New Family Component'), 
                                  Description STRING, 
                                  FamilyComponentTypeId STRING (36, 36), 
                                  FamilyCategory STRING NOT NULL, 
                                  FamilyFile BLOB, 
                                  Thumbnail BLOB, 
                                  FileSize INT, 
                                  DateCreated DATETIME NOT NULL, 
                                  DateModified DATETIME NOT NULL, 
                                  CreatedByUserId STRING (36, 36) NOT NULL, 
                                  Version STRING NOT NULL DEFAULT ('v.1.0.0'), 
                                  IsReleased BOOLEAN NOT NULL DEFAULT (false), 
                                  RoundConnectorDimension STRING NOT NULL, 
                                  PartType STRING NOT NULL, 
                                  ComniClassNumber STRING NOT NULL, 
                                  OmniClassTitle STRING NOT NULL, 
                                  WorkPlaneBased BOOLEAN DEFAULT (false) NOT NULL, 
                                  AlwaysVertical BOOLEAN NOT NULL DEFAULT (false), 
                                  CutsWithVoidWhenLoaded BOOLEAN NOT NULL DEFAULT (false), 
                                  IsShared BOOLEAN NOT NULL DEFAULT (false), 
                                  RoomCalculationPoint BOOLEAN NOT NULL DEFAULT (false), 
                                  FileName STRING, 
                                  CONSTRAINT FamilyComponentFamilyComponentTypeId_FamilyComponentId FOREIGN KEY (FamilyComponentTypeId) REFERENCES FF_FamilyComponentTypes (Id), 
                                  CONSTRAINT FamilyComponentCreatedByUserId_UserId FOREIGN KEY (CreatedByUserId) REFERENCES FF_Users (Id));


-- Table: FF_FamilyTemplateReferencePlanes
CREATE TABLE FF_FamilyTemplateReferencePlanes (Id STRING (36, 36) PRIMARY KEY NOT NULL UNIQUE, 
                                               FamilyTemplateId STRING (36, 36) NOT NULL, 
                                               Name STRING NOT NULL UNIQUE, 
                                               ElementId INTEGER NOT NULL DEFAULT (- 1), 
                                               UniqueId STRING, LevelId INTEGER NOT NULL DEFAULT (- 1), 
                                               ViewId INTEGER DEFAULT (- 1) NOT NULL, 
                                               Category STRING NOT NULL, 
                                               DirectionX DOUBLE NOT NULL DEFAULT (0), 
                                               DirectionY DOUBLE NOT NULL DEFAULT (0), 
                                               DirectionZ STRING NOT NULL DEFAULT (0), 
                                               BubbleEndX DOUBLE NOT NULL DEFAULT (0), 
                                               BubbleEndY DOUBLE NOT NULL DEFAULT (0), 
                                               BubbleEndZ DOUBLE NOT NULL DEFAULT (0), 
                                               NormalX DOUBLE NOT NULL DEFAULT (0), 
                                               NormalY DOUBLE NOT NULL DEFAULT (0), 
                                               NormalZ DOUBLE NOT NULL DEFAULT (0), 
                                               FreeEndX DOUBLE NOT NULL DEFAULT (0), 
                                               FreeEndY DOUBLE NOT NULL DEFAULT (0), 
                                               FreeEndZ DOUBLE NOT NULL DEFAULT (0), 
                                               IsActive BOOLEAN DEFAULT (false) NOT NULL, 
                                               CONSTRAINT ReferencePlanesFamilyTemplateId_FamilyTemplateId FOREIGN KEY (FamilyTemplateId) REFERENCES FF_FamilyTemplates (Id));


CREATE TABLE FF_FamilyComponentReferencePlanes (Id STRING (36, 36) PRIMARY KEY NOT NULL UNIQUE, 
                                                FamilyComponentId STRING (36, 36) NOT NULL, 
                                                Name STRING NOT NULL UNIQUE, 
                                                ElementId INTEGER NOT NULL DEFAULT (- 1), 
                                                UniqueId STRING, 
                                                LevelId INTEGER NOT NULL DEFAULT (- 1), 
                                                ViewId INTEGER DEFAULT (- 1) NOT NULL, 
                                                Category STRING NOT NULL, 
                                                DirectionX DOUBLE NOT NULL DEFAULT (0), 
                                                DirectionY DOUBLE NOT NULL DEFAULT (0), 
                                                DirectionZ STRING NOT NULL DEFAULT (0), 
                                                BubbleEndX DOUBLE NOT NULL DEFAULT (0), 
                                                BubbleEndY DOUBLE NOT NULL DEFAULT (0), 
                                                BubbleEndZ DOUBLE NOT NULL DEFAULT (0), 
                                                NormalX DOUBLE NOT NULL DEFAULT (0), 
                                                NormalY DOUBLE NOT NULL DEFAULT (0), 
                                                NormalZ DOUBLE NOT NULL DEFAULT (0), 
                                                FreeEndX DOUBLE NOT NULL DEFAULT (0), 
                                                FreeEndY DOUBLE NOT NULL DEFAULT (0), 
                                                FreeEndZ DOUBLE NOT NULL DEFAULT (0), 
                                                IsActive BOOLEAN NOT NULL DEFAULT (false),
                                                CONSTRAINT ReferencePlanesFamilyComponentId_FamilyComponentId FOREIGN KEY (FamilyComponentId) REFERENCES FF_FamilyComponents (Id));

-- Table: FF_FamilyTemplateParameters
CREATE TABLE FF_FamilyTemplateParameters (Id STRING (36, 36) UNIQUE PRIMARY KEY NOT NULL, 
                                          FamilyTemplateId STRING (36, 36) NOT NULL, 
                                          Name STRING NOT NULL, 
                                          ElementId INTEGER NOT NULL DEFAULT (- 1), 
                                          ElementGUID STRING NOT NULL, 
                                          HasValue BOOLEAN DEFAULT (false) NOT NULL, 
                                          IsReadOnly BOOLEAN NOT NULL DEFAULT (false), 
                                          IsShared BOOLEAN NOT NULL DEFAULT (false), 
                                          IsInstance BOOLEAN NOT NULL DEFAULT (false), 
                                          StorageType INTEGER NOT NULL DEFAULT (- 1), 
                                          IsEditable BOOLEAN NOT NULL DEFAULT (false), 
                                          IsActive BOOLEAN NOT NULL DEFAULT (false), 
                                          HostId STRING, 
                                          IsReporting BOOLEAN NOT NULL DEFAULT (false), 
                                          BuiltInParamGroup INTEGER NOT NULL DEFAULT (- 1), 
                                          ParameterType INTEGER NOT NULL DEFAULT (1), 
                                          UnitType INTEGER NOT NULL DEFAULT (- 1), 
                                          DisplayUnitType INTEGER DEFAULT (2) NOT NULL, 
                                          UserModifiable BOOLEAN NOT NULL DEFAULT (false), 
                                          IsDeterminedByFormula BOOLEAN NOT NULL DEFAULT (false), 
                                          Formula STRING, 
                                          CONSTRAINT ParametersFamilyTemplateId_FamilyTemplatesId FOREIGN KEY (FamilyTemplateId) REFERENCES FF_FamilyTemplates (Id));

-- Table: FF_FamilyComponentParameters
CREATE TABLE FF_FamilyComponentParameters (Id STRING (36, 36) UNIQUE PRIMARY KEY NOT NULL, 
                                           FamilyComponentId STRING (36, 36) NOT NULL, 
                                           Name STRING NOT NULL, 
                                           ElementId INTEGER NOT NULL DEFAULT (- 1), 
                                           ElementGUID STRING NOT NULL, 
                                           HasValue BOOLEAN DEFAULT (false) NOT NULL, 
                                           IsReadOnly BOOLEAN NOT NULL DEFAULT (false), 
                                           IsShared BOOLEAN NOT NULL DEFAULT (false), 
                                           IsInstance BOOLEAN NOT NULL DEFAULT (false), 
                                           StorageType INTEGER NOT NULL DEFAULT (- 1), 
                                           IsEditable BOOLEAN NOT NULL DEFAULT (false), 
                                           IsActive BOOLEAN NOT NULL DEFAULT (false), 
                                           HostId STRING, 
                                           IsReporting BOOLEAN NOT NULL DEFAULT (false), 
                                           BuiltInParamGroup INTEGER NOT NULL DEFAULT (- 1), 
                                           ParameterType INTEGER NOT NULL DEFAULT (1), 
                                           UnitType INTEGER NOT NULL DEFAULT (- 1), 
                                           DisplayUnitType INTEGER DEFAULT (2) NOT NULL, 
                                           UserModifiable BOOLEAN NOT NULL DEFAULT (false), 
                                           IsDeterminedByFormula BOOLEAN NOT NULL DEFAULT (false), 
                                           Formula STRING, 
                                           CONSTRAINT ParametersFamilyComponentId_FamilyComponentsId FOREIGN KEY (FamilyComponentId) REFERENCES FF_FamilyComponents (Id));


-- Table: FF_FamilyTemplateGeometry
CREATE TABLE FF_FamilyTemplateGeometry (Id STRING (36, 36) NOT NULL UNIQUE PRIMARY KEY,
                                        FamilyTemplateId STRING (36, 36) NOT NULL, 
                                        Name STRING NOT NULL UNIQUE, 
                                        ElementId STRING (36, 36) NOT NULL, 
                                        Description STRING, 
                                        GeometryType STRING NOT NULL DEFAULT ('SWEEP'), 
                                        MaterialId INTEGER NOT NULL DEFAULT (- 1), 
                                        IsActive BOOLEAN NOT NULL DEFAULT (false), 
                                        ProfileFamily1Id INTEGER NOT NULL DEFAULT (- 1), 
                                        ProfileFamily2Id INTEGER NOT NULL DEFAULT (- 1), 
                                        HostId INTEGER NOT NULL DEFAULT (- 1), 
                                        Category STRING NOT NULL, 
                                        SubCategory STRING NOT NULL, 
                                        UniqueId STRING, 
                                        OwnerViewId INTEGER NOT NULL DEFAULT (- 1), 
                                        LevelId INTEGER NOT NULL DEFAULT (- 1), 
                                        IsSolid BOOLEAN NOT NULL DEFAULT (true), 
                                        CONSTRAINT FamilyTemplateFamilyGeometryId_FamilyTemplateId FOREIGN KEY (FamilyTemplateId) REFERENCES FF_FamilyTemplates (Id));

-- Table: FF_FamilyComponentGeometry
CREATE TABLE FF_FamilyComponentGeometry (Id STRING (36, 36) NOT NULL UNIQUE PRIMARY KEY, 
                                         FamilyComponentId STRING (36, 36) NOT NULL, 
                                         Name STRING NOT NULL UNIQUE, 
                                         ElementId STRING (36, 36) NOT NULL, 
                                         Description STRING, 
                                         GeometryType STRING NOT NULL DEFAULT ('SWEEP'), 
                                         MaterialId INTEGER NOT NULL DEFAULT (- 1), 
                                         IsActive BOOLEAN NOT NULL DEFAULT (false), 
                                         ProfileFamily1Id INTEGER NOT NULL DEFAULT (- 1), 
                                         ProfileFamily2Id INTEGER NOT NULL DEFAULT (- 1), 
                                         HostId INTEGER NOT NULL DEFAULT (- 1), 
                                         Category STRING NOT NULL, 
                                         SubCategory STRING NOT NULL, 
                                         UniqueId STRING, 
                                         OwnerViewId INTEGER NOT NULL DEFAULT (- 1), 
                                         LevelId INTEGER NOT NULL DEFAULT (- 1), 
                                         IsSolid BOOLEAN NOT NULL DEFAULT (true), 
                                         CONSTRAINT FamilyComponentFamilyGeometryId_FamilyComponentId FOREIGN KEY (FamilyComponentId) REFERENCES FF_FamilyComponents (Id));


COMMIT TRANSACTION;
