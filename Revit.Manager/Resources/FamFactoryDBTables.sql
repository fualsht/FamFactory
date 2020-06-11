--
-- File generated with SQLiteStudio v3.2.1 on Wed May 27 23:07:40 2020
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: FF_EmailProfiles
DROP TABLE IF EXISTS FF_EmailProfiles;

CREATE TABLE FF_EmailProfiles (
    Id            STRING (36, 36) PRIMARY KEY
                                  NOT NULL
                                  UNIQUE,
    Name          STRING          NOT NULL
                                  UNIQUE
                                  DEFAULT ('NewEmailProfile'),
    Description   STRING,
    ServerAddress STRING          NOT NULL
                                  UNIQUE
                                  DEFAULT ('mail.server.com'),
    Port          INTEGER         NOT NULL
                                  DEFAULT (25),
    SSL           BOOLEAN         NOT NULL
                                  DEFAULT (false),
    Username      STRING,
    Password      STRING,
    State         BOOLEAN         NOT NULL
                                  DEFAULT (false),
    DateCreated   DATETIME        NOT NULL,
    DateModified  DATETIME        NOT NULL,
    CreatedById   STRING (36, 36) NOT NULL,
    ModifiedById  STRING (36, 36) NOT NULL,
    CONSTRAINT EmailProfiles_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT EmailProfiles_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyBuildComponentPositions
DROP TABLE IF EXISTS FF_FamilyBuildComponentPositions;

CREATE TABLE FF_FamilyBuildComponentPositions (
    Id                         STRING (36, 36) NOT NULL
                                               PRIMARY KEY
                                               UNIQUE,
    FamilyBuildComponentId     STRING (36, 36),
    TemplateReferencePlaneXId  STRING (36, 36),
    TemplateReferencePlaneYId  STRING (36, 36),
    TemplateReferencePlaneZId  STRING (36, 36),
    ComponentRefernecePlaneXId STRING (36, 36),
    ComponentRefernecePlaneYId STRING (36, 36),
    ComponentRefernecePlaneZId STRING (36, 36),
    XOffset                    DECIMAL         NOT NULL
                                               DEFAULT (0),
    YOffset                    DECIMAL         NOT NULL
                                               DEFAULT (0),
    ZOffset                    DOUBLE          NOT NULL
                                               DEFAULT (0),
    XRotate                    DECIMAL         NOT NULL
                                               DEFAULT (0),
    YRotate                    DOUBLE          NOT NULL
                                               DEFAULT (0),
    ZRotate                    DOUBLE          NOT NULL
                                               DEFAULT (0),
    CreatedBy                  STRING (36, 36) NOT NULL,
    ModifiedBy                 STRING (36, 36) NOT NULL,
    DateCreated                DATETIME        NOT NULL,
    DateModified               DATETIME        NOT NULL,
    CONSTRAINT FamilyBuildComponentPositions_FamilyBuildComponentId_FamilyBuildComponents_Id FOREIGN KEY (
        FamilyBuildComponentId
    )
    REFERENCES FF_FamilyBuildComponents (Id),
    CONSTRAINT FamilyBuildComponentPositions_TemplateReferencePlaneXId__FamilyTemplateReferencePlanes_Id FOREIGN KEY (
        TemplateReferencePlaneXId
    )
    REFERENCES FF_FamilyTemplateReferencePlanes (Id),
    CONSTRAINT FamilyBuildComponentPositions_TemplateReferencePlaneYId__FamilyTemplateReferencePlanes_Id FOREIGN KEY (
        TemplateReferencePlaneYId
    )
    REFERENCES FF_FamilyTemplateReferencePlanes (Id),
    CONSTRAINT FamilyBuildComponentPositions_TemplateReferencePlaneZId__FamilyTemplateReferencePlanes_Id FOREIGN KEY (
        TemplateReferencePlaneZId
    )
    REFERENCES FF_FamilyTemplateReferencePlanes (Id),
    CONSTRAINT FamilyBuildComponentPositions_ComponentReferencePlaneXId__FamilyComponent_ReferencePlanes_Id FOREIGN KEY (
        ComponentRefernecePlaneXId
    )
    REFERENCES FF_FamilyComponentReferencePlanes (Id),
    CONSTRAINT FamilyBuildComponentPositions_ComponentReferencePlaneYId__FamilyComponent_ReferencePlanes_Id FOREIGN KEY (
        ComponentRefernecePlaneYId
    )
    REFERENCES FF_FamilyComponentReferencePlanes (Id),
    CONSTRAINT FamilyBuildComponentPositions_ComponentReferencePlaneZId__FamilyComponent_ReferencePlanes_Id FOREIGN KEY (
        ComponentRefernecePlaneZId
    )
    REFERENCES FF_FamilyComponentReferencePlanes (Id),
    CONSTRAINT FamilyBuildComponentPositions_CreatedById__Users_Id FOREIGN KEY (
        CreatedBy
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyBuildComponentPositions_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedBy
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyBuildComponents
DROP TABLE IF EXISTS FF_FamilyBuildComponents;

CREATE TABLE FF_FamilyBuildComponents (
    Id                STRING (36, 36) NOT NULL
                                      PRIMARY KEY
                                      UNIQUE,
    FamilyBuildId     STRING (36, 36) NOT NULL,
    FamilyComponentId STRING (36, 36) NOT NULL,
    DateCreated       DATETIME        NOT NULL,
    DateModified      DATETIME        NOT NULL,
    CreatedById       STRING (36, 36) NOT NULL,
    ModifiedById      STRING (36, 36) NOT NULL,
    CONSTRAINT FamilyBuildComponents_FamilyBuildId__FamilyBuilds_Id FOREIGN KEY (
        FamilyBuildId
    )
    REFERENCES FF_FamilyBuilds (Id),
    CONSTRAINT FamilyBuildComponents_FamilyComponentId__FamilyComponents_Id FOREIGN KEY (
        FamilyComponentId
    )
    REFERENCES FF_FamilyComponents (Id),
    CONSTRAINT FamilyBuildComponents_CreatedByIdId__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyBuildComponents_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyBuilds
DROP TABLE IF EXISTS FF_FamilyBuilds;

CREATE TABLE FF_FamilyBuilds (
    Id               STRING (36, 36) PRIMARY KEY
                                     UNIQUE
                                     NOT NULL,
    FamilyTemplateId STRING (36, 36) NOT NULL ON CONFLICT ROLLBACK,
    Name             STRING          UNIQUE,
    Description      STRING,
    DateCreated      DATETIME        NOT NULL,
    DateModified     DATETIME        NOT NULL,
    CreatedById      STRING (36, 36) NOT NULL,
    ModifiedById     STRING (36, 36) NOT NULL,
    State            INT             NOT NULL
                                     DEFAULT (0),
    CONSTRAINT FamilyBuilds_FamilyTemplateId__FamilyTemplates_Id FOREIGN KEY (
        FamilyTemplateId
    )
    REFERENCES FF_FamilyTemplates (Id),
    CONSTRAINT FamilyBuilds_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyBuilds_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyComponentGeometries
DROP TABLE IF EXISTS FF_FamilyComponentGeometries;

CREATE TABLE FF_FamilyComponentGeometries (
    Id               STRING (36, 36) NOT NULL
                                     UNIQUE
                                     PRIMARY KEY,
    FamilyId         STRING (36, 36) NOT NULL,
    Name             STRING          NOT NULL,
    ElementId        STRING (36, 36) NOT NULL,
    Description      STRING,
    GeometryType     STRING          NOT NULL
                                     DEFAULT ('SWEEP'),
    MaterialId       INTEGER         NOT NULL
                                     DEFAULT ( -1),
    IsActive         BOOLEAN         NOT NULL
                                     DEFAULT (false),
    ProfileFamily1Id INTEGER         NOT NULL
                                     DEFAULT ( -1),
    ProfileFamily2Id INTEGER         NOT NULL
                                     DEFAULT ( -1),
    HostId           INTEGER         NOT NULL
                                     DEFAULT ( -1),
    Category         STRING          NOT NULL,
    SubCategory      STRING          NOT NULL,
    UniqueId         STRING,
    OwnerViewId      INTEGER         NOT NULL
                                     DEFAULT ( -1),
    LevelId          INTEGER         NOT NULL
                                     DEFAULT ( -1),
    IsSolid          BOOLEAN         NOT NULL
                                     DEFAULT (true),
    DateCreated      DATETIME        NOT NULL,
    DateModified     DATETIME        NOT NULL,
    CreatedById      STRING (36, 36) NOT NULL,
    ModifiedById     STRING (36, 36),
    CONSTRAINT FamilyComponentGeometries_FamilyId__FamilyComponents_Id FOREIGN KEY (
        FamilyId
    )
    REFERENCES FF_FamilyComponents (Id),
    CONSTRAINT FamilyComponentGeometries_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyComponentGeometries_ModifedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyComponentParameters
DROP TABLE IF EXISTS FF_FamilyComponentParameters;

CREATE TABLE FF_FamilyComponentParameters (
    Id                    STRING (36, 36)   UNIQUE
                                            PRIMARY KEY
                                            NOT NULL,
    FamilyId              STRING (36, 36)   NOT NULL,
    Name                  STRING            NOT NULL,
    ElementId             INTEGER           NOT NULL
                                            DEFAULT ( -1),
    ElementGUID           STRING            NOT NULL,
    HasValue              BOOLEAN           DEFAULT (false) 
                                            NOT NULL,
    IsReadOnly            BOOLEAN           NOT NULL
                                            DEFAULT (false),
    IsShared              BOOLEAN           NOT NULL
                                            DEFAULT (false),
    IsInstance            BOOLEAN           NOT NULL
                                            DEFAULT (false),
    StorageType           INTEGER           NOT NULL
                                            DEFAULT ( -1),
    IsEditable            BOOLEAN           NOT NULL
                                            DEFAULT (false),
    IsActive              BOOLEAN           NOT NULL
                                            DEFAULT (false),
    HostId                STRING,
    IsReporting           BOOLEAN           NOT NULL
                                            DEFAULT (false),
    BuiltInParamGroup     INTEGER           NOT NULL
                                            DEFAULT ( -1),
    ParameterType         INTEGER           NOT NULL
                                            DEFAULT (1),
    UnitType              INTEGER           NOT NULL
                                            DEFAULT ( -1),
    DisplayUnitType       INTEGER           DEFAULT (2) 
                                            NOT NULL,
    UserModifiable        BOOLEAN           NOT NULL
                                            DEFAULT (false),
    IsDeterminedByFormula BOOLEAN           NOT NULL
                                            DEFAULT (false),
    Formula               STRING,
    DateCreated           DATETIME (36, 36) NOT NULL,
    DateModified          DATETIME          NOT NULL,
    CreatedById           STRING (36, 36)   NOT NULL,
    ModifiedById          STRING (36, 36)   NOT NULL,
    CONSTRAINT FamilyComponentParameters_FamilyId__FamilyComponents_Id FOREIGN KEY (
        FamilyId
    )
    REFERENCES FF_FamilyComponents (Id),
    CONSTRAINT FamilyComponentParameters_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyComponentParameters_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyComponentReferencePlanes
DROP TABLE IF EXISTS FF_FamilyComponentReferencePlanes;

CREATE TABLE FF_FamilyComponentReferencePlanes (
    Id           STRING (36, 36) PRIMARY KEY
                                 NOT NULL
                                 UNIQUE,
    FamilyId     STRING (36, 36) NOT NULL,
    Name         STRING          NOT NULL,
    ElementId    INTEGER         NOT NULL
                                 DEFAULT ( -1),
    UniqueId     STRING,
    LevelId      INTEGER         NOT NULL
                                 DEFAULT ( -1),
    ViewId       INTEGER         DEFAULT ( -1) 
                                 NOT NULL,
    Category     STRING          NOT NULL,
    DirectionX   DOUBLE          NOT NULL
                                 DEFAULT (0),
    DirectionY   DOUBLE          NOT NULL
                                 DEFAULT (0),
    DirectionZ   STRING          NOT NULL
                                 DEFAULT (0),
    BubbleEndX   DOUBLE          NOT NULL
                                 DEFAULT (0),
    BubbleEndY   DOUBLE          NOT NULL
                                 DEFAULT (0),
    BubbleEndZ   DOUBLE          NOT NULL
                                 DEFAULT (0),
    NormalX      DOUBLE          NOT NULL
                                 DEFAULT (0),
    NormalY      DOUBLE          NOT NULL
                                 DEFAULT (0),
    NormalZ      DOUBLE          NOT NULL
                                 DEFAULT (0),
    FreeEndX     DOUBLE          NOT NULL
                                 DEFAULT (0),
    FreeEndY     DOUBLE          NOT NULL
                                 DEFAULT (0),
    FreeEndZ     DOUBLE          NOT NULL
                                 DEFAULT (0),
    IsActive     BOOLEAN         NOT NULL
                                 DEFAULT (false),
    CreatedById  STRING (36, 36) NOT NULL,
    ModifiedById STRING (36, 36) NOT NULL,
    DateCreated  DATETIME        NOT NULL,
    DateModified DATETIME        NOT NULL,
    CONSTRAINT FamilyComponentReferencePlanes_FamilyId__FamilyComponents_Id FOREIGN KEY (
        FamilyId
    )
    REFERENCES FF_FamilyComponents (Id),
    CONSTRAINT FamilyComponentReferencePlanes_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyComponentReferencePlanes_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyComponents
DROP TABLE IF EXISTS FF_FamilyComponents;

CREATE TABLE FF_FamilyComponents (
    Id                      STRING (36, 36) PRIMARY KEY
                                            UNIQUE
                                            NOT NULL,
    Name                    STRING          UNIQUE
                                            NOT NULL
                                            DEFAULT ('New Family Component'),
    Description             STRING,
    FamilyComponentTypeId   STRING (36, 36),
    FamilyCategory          STRING          NOT NULL,
    FamilyFile              BLOB,
    Thumbnail               BLOB,
    FileSize                INT,
    DateCreated             DATETIME        NOT NULL,
    DateModified            DATETIME        NOT NULL,
    CreatedById             STRING (36, 36) NOT NULL,
    ModifiedById            STRING (36, 36) NOT NULL,
    Version                 STRING          NOT NULL
                                            DEFAULT ('v.1.0.0'),
    IsReleased              BOOLEAN         NOT NULL
                                            DEFAULT (false),
    RoundConnectorDimension STRING          NOT NULL,
    PartType                STRING          NOT NULL,
    ComniClassNumber        STRING          NOT NULL,
    OmniClassTitle          STRING          NOT NULL,
    WorkPlaneBased          BOOLEAN         DEFAULT (false) 
                                            NOT NULL,
    AlwaysVertical          BOOLEAN         NOT NULL
                                            DEFAULT (false),
    CutsWithVoidWhenLoaded  BOOLEAN         NOT NULL
                                            DEFAULT (false),
    IsShared                BOOLEAN         NOT NULL
                                            DEFAULT (false),
    RoomCalculationPoint    BOOLEAN         NOT NULL
                                            DEFAULT (false),
    FileName                STRING,
    CanHostRebar            BOOLEAN         NOT NULL
                                            DEFAULT (false),
    State                   INT             NOT NULL DEFAULT (0),
    CONSTRAINT FamilyComponents_FamilyComponentTypeId__FamilyComponents_Id FOREIGN KEY (
        FamilyComponentTypeId
    )
    REFERENCES FF_FamilyComponentTypes (Id),
    CONSTRAINT FamilyComponents_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyComponents_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyComponentTypes
DROP TABLE IF EXISTS FF_FamilyComponentTypes;

CREATE TABLE FF_FamilyComponentTypes (
    Id           STRING (36, 36) PRIMARY KEY
                                 NOT NULL
                                 UNIQUE,
    Name         STRING          NOT NULL
                                 UNIQUE
                                 DEFAULT ('New Type'),
    Description  STRING,
    Thumbnail    BLOB,
    DateCreated  DATETIME        NOT NULL,
    DateModified DATETIME        NOT NULL,
    CreatedBy    STRING (36, 36) NOT NULL,
    ModifiedBy   STRING (36, 36) NOT NULL ON CONFLICT IGNORE
);


-- Table: FF_FamilyTemplateComponents
DROP TABLE IF EXISTS FF_FamilyTemplateComponents;

CREATE TABLE FF_FamilyTemplateComponents (
    Id                 STRING (36, 36)   NOT NULL
                                         PRIMARY KEY
                                         UNIQUE,
    FamilyId           STRING (36, 36)   NOT NULL,
    [ Name]            STRING (36, 36)   NOT NULL,
    Description        STRING,
    XReferencePlaneId STRING (36, 36)   NOT NULL,
    YReferencePlaneId STRING (36, 36)   NOT NULL,
    ZReferencePlaneId STRING (36, 36)   NOT NULL,
    DateCreated        DATETIME (36, 36) NOT NULL,
    DateModified       DATETIME (36, 36) NOT NULL,
    CreatedById        STRING (36, 36)   NOT NULL,
    ModifiedById       STRING (36, 36)   NOT NULL,
    CONSTRAINT FamilyTemplateComponents_FamilyId__FamilyTemplate_Id FOREIGN KEY (
        FamilyId
    )
    REFERENCES FF_FamilyTemplates (Id),
    CONSTRAINT FamilyTemplateComponents_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyTemplateComponents_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyTemplateComponents_XReferencePlaneId__FamilyTemplateReferencePlanes_Id FOREIGN KEY (
        XRefferencePlaneId
    )
    REFERENCES FF_FamilyTemplateReferencePlanes (Id),
    CONSTRAINT FamilyTemplateComponents_YReferencePlaneId__FamilyTemplateReferencePlanes_Id FOREIGN KEY (
        YRefferencePlaneId
    )
    REFERENCES FF_FamilyTemplateReferencePlanes (Id),
    CONSTRAINT FamilyTemplateComponents_ZReferencePlaneId__FamilyTemplateReferencePlanes_Id FOREIGN KEY (
        ZRefferencePlaneId
    )
    REFERENCES FF_FamilyTemplateReferencePlanes (Id) 
);


-- Table: FF_FamilyTemplateGeometries
DROP TABLE IF EXISTS FF_FamilyTemplateGeometries;

CREATE TABLE FF_FamilyTemplateGeometries (
    Id               STRING (36, 36) NOT NULL
                                     UNIQUE
                                     PRIMARY KEY,
    FamilyId         STRING (36, 36) NOT NULL,
    Name             STRING          NOT NULL,
    ElementId        STRING (36, 36) NOT NULL,
    Description      STRING,
    GeometryType     STRING          NOT NULL
                                     DEFAULT ('SWEEP'),
    MaterialId       INTEGER         NOT NULL
                                     DEFAULT ( -1),
    IsActive         BOOLEAN         NOT NULL
                                     DEFAULT (false),
    ProfileFamily1Id INTEGER         NOT NULL
                                     DEFAULT ( -1),
    ProfileFamily2Id INTEGER         NOT NULL
                                     DEFAULT ( -1),
    HostId           INTEGER         NOT NULL
                                     DEFAULT ( -1),
    Category         STRING          NOT NULL,
    SubCategory      STRING          NOT NULL,
    UniqueId         STRING,
    OwnerViewId      INTEGER         NOT NULL
                                     DEFAULT ( -1),
    LevelId          INTEGER         NOT NULL
                                     DEFAULT ( -1),
    IsSolid          BOOLEAN         NOT NULL
                                     DEFAULT (true),
    CreatedById      STRING (36, 36) NOT NULL,
    ModifiedById     STRING (36, 36) NOT NULL,
    DateCreated      DATETIME        NOT NULL,
    DateModified     DATETIME        NOT NULL,
    CONSTRAINT FamilyTemplateGeometries_FamilyId__FamilyTemplates_Id FOREIGN KEY (
        FamilyId
    )
    REFERENCES FF_FamilyTemplates (Id),
    CONSTRAINT FamilyTemplateGeometries_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyTemplateGeometries_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyTemplateParameters
DROP TABLE IF EXISTS FF_FamilyTemplateParameters;

CREATE TABLE FF_FamilyTemplateParameters (
    Id                    STRING (36, 36) UNIQUE
                                          PRIMARY KEY
                                          NOT NULL,
    FamilyId              STRING (36, 36) NOT NULL,
    Name                  STRING          NOT NULL,
    ElementId             INTEGER         NOT NULL
                                          DEFAULT ( -1),
    ElementGUID           STRING          NOT NULL,
    HasValue              BOOLEAN         DEFAULT (false) 
                                          NOT NULL,
    IsReadOnly            BOOLEAN         NOT NULL
                                          DEFAULT (false),
    IsShared              BOOLEAN         NOT NULL
                                          DEFAULT (false),
    IsInstance            BOOLEAN         NOT NULL
                                          DEFAULT (false),
    StorageType           INTEGER         NOT NULL
                                          DEFAULT ( -1),
    IsEditable            BOOLEAN         NOT NULL
                                          DEFAULT (false),
    IsActive              BOOLEAN         NOT NULL
                                          DEFAULT (false),
    HostId                STRING,
    IsReporting           BOOLEAN         NOT NULL
                                          DEFAULT (false),
    BuiltInParamGroup     INTEGER         NOT NULL
                                          DEFAULT ( -1),
    ParameterType         INTEGER         NOT NULL
                                          DEFAULT (1),
    UnitType              INTEGER         NOT NULL
                                          DEFAULT ( -1),
    DisplayUnitType       INTEGER         DEFAULT (2) 
                                          NOT NULL,
    UserModifiable        BOOLEAN         NOT NULL
                                          DEFAULT (false),
    IsDeterminedByFormula BOOLEAN         NOT NULL
                                          DEFAULT (false),
    Formula               STRING,
    DateCreated           DATETIME        NOT NULL,
    DateModified          DATETIME        NOT NULL,
    CreatedById           STRING (36, 36) NOT NULL,
    ModifiedById          STRING (36, 36) NOT NULL,
    CONSTRAINT FamilyTemplateParameters_FamilyId__FamilyTemplates_Id FOREIGN KEY (
        FamilyId
    )
    REFERENCES FF_FamilyTemplates (Id),
    CONSTRAINT FamilyTemplateParameters_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyTemplateParameters_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyTemplateReferencePlanes
DROP TABLE IF EXISTS FF_FamilyTemplateReferencePlanes;

CREATE TABLE FF_FamilyTemplateReferencePlanes (
    Id           STRING (36, 36) PRIMARY KEY
                                 NOT NULL
                                 UNIQUE,
    FamilyId     STRING (36, 36) NOT NULL,
    Name         STRING          NOT NULL,
    ElementId    INTEGER         NOT NULL
                                 DEFAULT ( -1),
    UniqueId     STRING,
    LevelId      INTEGER         NOT NULL
                                 DEFAULT ( -1),
    ViewId       INTEGER         DEFAULT ( -1) 
                                 NOT NULL,
    Category     STRING          NOT NULL,
    DirectionX   DOUBLE          NOT NULL
                                 DEFAULT (0),
    DirectionY   DOUBLE          NOT NULL
                                 DEFAULT (0),
    DirectionZ   STRING          NOT NULL
                                 DEFAULT (0),
    BubbleEndX   DOUBLE          NOT NULL
                                 DEFAULT (0),
    BubbleEndY   DOUBLE          NOT NULL
                                 DEFAULT (0),
    BubbleEndZ   DOUBLE          NOT NULL
                                 DEFAULT (0),
    NormalX      DOUBLE          NOT NULL
                                 DEFAULT (0),
    NormalY      DOUBLE          NOT NULL
                                 DEFAULT (0),
    NormalZ      DOUBLE          NOT NULL
                                 DEFAULT (0),
    FreeEndX     DOUBLE          NOT NULL
                                 DEFAULT (0),
    FreeEndY     DOUBLE          NOT NULL
                                 DEFAULT (0),
    FreeEndZ     DOUBLE          NOT NULL
                                 DEFAULT (0),
    IsActive     BOOLEAN         DEFAULT (false) 
                                 NOT NULL,
    DateCreated  DATETIME        NOT NULL,
    DateModified DATETIME        NOT NULL,
    CreatedById  STRING (36, 36) NOT NULL,
    ModifiedById STRING (36, 36) NOT NULL,
    CONSTRAINT FamilyTemplateReferencePlanes_FamilyId__FamilyTemplates_Id FOREIGN KEY (
        FamilyId
    )
    REFERENCES FF_FamilyTemplates (Id),
    CONSTRAINT FamilyTemplateReferencePlanes_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyTemplateReferencePlanes_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_FamilyTemplates
DROP TABLE IF EXISTS FF_FamilyTemplates;

CREATE TABLE FF_FamilyTemplates (
    Id                      STRING (36, 36) PRIMARY KEY
                                            UNIQUE
                                            NOT NULL,
    Name                    STRING          UNIQUE
                                            NOT NULL
                                            DEFAULT ('New Family Template'),
    Description             STRING,
    FamilyCategory          STRING          NOT NULL,
    FamilyFile              BLOB            NOT NULL,
    Thumbnail               BLOB            NOT NULL,
    FileSize                INT             NOT NULL,
    DateCreated             DATETIME        NOT NULL,
    DateModified            DATETIME        NOT NULL,
    CreatedById             STRING (36, 36) NOT NULL,
    ModifiedById            STRING (36, 36) NOT NULL,
    Version                 STRING          NOT NULL
                                            DEFAULT ('v.1.0.0'),
    IsReleased              BOOLEAN         NOT NULL
                                            DEFAULT (false),
    RoundConnectorDimension STRING          NOT NULL,
    PartType                STRING          NOT NULL,
    OmniClassNumber         STRING          NOT NULL,
    OmniClassTitle          STRING          NOT NULL,
    WorkPlaneBased          BOOLEAN         DEFAULT (false) 
                                            NOT NULL,
    AlwaysVertical          BOOLEAN         NOT NULL
                                            DEFAULT (false),
    CutsWithVoidWhenLoaded  BOOLEAN         NOT NULL
                                            DEFAULT (false),
    IsShared                BOOLEAN         NOT NULL
                                            DEFAULT (false),
    RoomCalculationPoint    BOOLEAN         NOT NULL
                                            DEFAULT (false),
    FileName                STRING          NOT NULL,
    CanHostRebar            BOOLEAN         DEFAULT (false) 
                                            NOT NULL,
    State               INT             NOT NULL DEFAULT (0),
    CONSTRAINT FamilyTemplates_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT FamilyTemplates_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_Permissions
DROP TABLE IF EXISTS FF_Permissions;

CREATE TABLE FF_Permissions (
    Id          STRING (36, 36) PRIMARY KEY
                                UNIQUE
                                NOT NULL,
    Name        STRING          UNIQUE
                                NOT NULL,
    Description STRING,
    CanRead     BOOLEAN         NOT NULL
                                DEFAULT (TRUE),
    CanWrite    BOOLEAN         NOT NULL
                                DEFAULT (TRUE),
    CanCreate   BOOLEAN         NOT NULL
                                DEFAULT (TRUE),
    CanDelete   BOOLEAN         NOT NULL
                                DEFAULT (TRUE),
    Special     BOOLEAN         NOT NULL
                                DEFAULT (TRUE) 
);


-- Table: FF_SystemConfigurations
DROP TABLE IF EXISTS FF_SystemConfigurations;

CREATE TABLE FF_SystemConfigurations (
    Id              STRING (36, 36) PRIMARY KEY
                                    UNIQUE
                                    NOT NULL,
    Name            STRING          NOT NULL
                                    UNIQUE
                                    DEFAULT ('New System'),
    CompanyAddress  STRING,
    Email           STRING          NOT NULL
                                    DEFAULT ('admin@company.com'),
    InstallLocation STRING          NOT NULL,
    AppVersion      STRING          NOT NULL
                                    DEFAULT ('v.1.0.0'),
    DataBaseVersion STRING          NOT NULL
                                    DEFAULT ('v.1.0.0'),
    DateCreated     DATETIME        NOT NULL,
    DateModified    DATETIME        NOT NULL,
    CreatedById     STRING (36, 36) NOT NULL,
    ModifiedById    STRING (36, 36) NOT NULL,
    State           INT             NOT NULL
                                    DEFAULT (0),
    CONSTRAINT SystemConfigurations_CreatedById__Users_Id FOREIGN KEY (
        CreatedById
    )
    REFERENCES FF_Users (Id),
    CONSTRAINT SystemConfigurations_ModifiedById__Users_Id FOREIGN KEY (
        ModifiedById
    )
    REFERENCES FF_Users (Id) 
);


-- Table: FF_Users
DROP TABLE IF EXISTS FF_Users;

CREATE TABLE FF_Users (
    Id           STRING (36, 36) PRIMARY KEY
                                 UNIQUE
                                 NOT NULL,
    Name         STRING          UNIQUE
                                 NOT NULL,
    FirstName    STRING          NOT NULL,
    LastName     STRING          NOT NULL,
    Email        STRING          NOT NULL,
    Password     STRING          NOT NULL,
    ProfilePic   BLOB,
    DateCreated  DATETIME        NOT NULL,
    LogInDate    DATETIME        NOT NULL,
    PermissionId STRING,
    State        Int             NOT NULL DEFAULT (0),
    TempFolder   STRING          NOT NULL
                                 DEFAULT ('C:\temp'),
    DateModified DATETIME        NOT NULL,
    CONSTRAINT Users_PermissionId__Permissions_Id FOREIGN KEY (
        PermissionId
    )
    REFERENCES FF_Permissions (Id) 
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
