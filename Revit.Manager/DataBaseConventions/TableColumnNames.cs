using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public static class EmailProfilesColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string Name { get { return "Name"; } }
        public static string Description { get { return "Description"; } }
        public static string ServerAddress { get { return "ServerAddress"; } }
        public static string Port { get { return "Port"; } }
        public static string SSL { get { return "SSL"; } }
        public static string Username { get { return "Username"; } }
        public static string Password { get { return "Password"; } }
        public static string State { get { return "State"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
    }
    public static class FamilyBuildsColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string Name { get { return "Name"; } }
        public static string Description { get { return "Description"; } }
        public static string FamilyTemplateId { get { return "FamilyTemplateId"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string State { get { return "State"; } }
    }
    public static class FamilyBuildComponentsColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string FamilyBuildId { get { return "FamilyBuildId"; } }
        public static string FamilyComponentId { get { return "FamilyComponentId"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
    }
    public static class FamilyBuildComponentPostionsColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string FamilyBuildId { get { return "FamilyBuildId"; } }
        public static string FamilyBuildComponentId { get { return "FamilyBuildComponentId"; } }
        public static string TemplateReferencePlaneXId { get { return "TemplateReferencePlaneXId"; } }
        public static string ComponentRefernecePlaneXId { get { return "ComponentRefernecePlaneXId"; } }
        public static string TemplateReferencePlaneYId { get { return "TemplateReferencePlaneYId"; } }
        public static string ComponentRefernecePlaneYId { get { return "ComponentRefernecePlaneYId"; } }
        public static string TemplateReferencePlaneZId { get { return "TemplateReferencePlaneZId"; } }
        public static string ComponentRefernecePlaneZId { get { return "ComponentRefernecePlaneZId"; } }
        public static string XOffset { get { return "XOffset"; } }
        public static string YOffset { get { return "YOffset"; } }
        public static string ZOffset { get { return "ZOffset"; } }
        public static string XRotate { get { return "XRotate"; } }
        public static string YRotate { get { return "YRotate"; } }
        public static string ZRotate { get { return "ZRotate"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
    }
    public static class FamilyComponentsColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string Name { get { return "Name"; } }
        public static string Description { get { return "Description"; } }
        public static string FileSize { get { return "FileSize"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string Version { get { return "Version"; } }
        public static string IsReleased { get { return "IsReleased"; } }
        public static string RoundConnectorDimension { get { return "RoundConnectorDimension"; } }
        public static string PartType { get { return "PartType"; } }
        public static string XRotate { get { return "XRotate"; } }
        public static string YRotate { get { return "YRotate"; } }
        public static string ZRotate { get { return "ZRotate"; } }
        public static string OmniClassNumber { get { return "OmniClassNumber"; } }
        public static string OmniClassTitle { get { return "OmniClassTitle"; } }
        public static string WorkPlaneBased { get { return "WorkPlaneBased"; } }
        public static string FamilyComponentTypeId { get { return "FamilyComponentTypeId"; } }
        public static string FamilyCategory { get { return "FamilyCategory"; } }
        public static string FamilyFile { get { return "FamilyFile"; } }
        public static string AlwaysVertical { get { return "AlwaysVertical"; } }
        public static string CutsWithVoidWhenLoaded { get { return "CutsWithVoidWhenLoaded"; } }
        public static string RoomCalculationPoint { get { return "RoomCalculationPoint"; } }
        public static string State { get { return "State"; } }
        public static string Thumbnail { get { return "Thumbnail"; } }
        public static string IsShared { get { return "IsShared"; } }
        public static string FileName { get { return "FileName"; } }
        public static string CanHostRebar { get { return "CanHostRebar"; } }
    }
    public static class FamilyComponentsCategoryColumnNames 
    {
        public static string Id { get { return "Id"; } }
        public static string Name { get { return "Name"; } }
        public static string Description { get { return "Description"; } }
        public static string Thumbnail { get { return "Thumbnail"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string ParentId { get { return "ParentId"; } }
    }
    public static class FamilyComponents_FamilyComponentCategoryColumnNames 
    {
        public static string Id { get { return "Id"; } }
        public static string FamilyComponentId { get { return "FamilyComponentId"; } }
        public static string FamilyComponentCategoryId { get { return "FamilyComponentCategoryId"; } }
    }
    public static class FamilyComponents_FamilyComponentSerchTermsColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string FamilyComponentId { get { return "FamilyComponentId"; } }
        public static string FamilyComponentSearchTermId { get { return "FamilyComponentSearchTermId"; } }
    }
    public static class FamilyComponentsSearchTermColumnNames 
    {
        public static string Id { get { return "Id"; } }
        public static string Name { get { return "Name"; } }
        public static string Description { get { return "Description"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
    }
    public static class FamilyComponentTypesColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string Thumbnail { get { return "Thumbnail"; } }
        public static string Name { get { return "Name"; } }
        public static string Description { get { return "Description"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
    }
    public static class FamilyGeometriesColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string FamilyId { get { return "FamilyId"; } }
        public static string Name { get { return "Name"; } }
        public static string Description { get { return "Description"; } }
        public static string ElementId { get { return "ElementId"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string GeometryType { get { return "GeometryType"; } }
        public static string MaterialId { get { return "MaterialId"; } }
        public static string IsActive { get { return "IsActive"; } }
        public static string ProfileFamily1Id { get { return "ProfileFamily1Id"; } }
        public static string ProfileFamily2Id { get { return "ProfileFamily2Id"; } }
        public static string HostId { get { return "HostId"; } }
        public static string Category { get { return "Category"; } }
        public static string SubCategory { get { return "SubCategory"; } }
        public static string UniqueId { get { return "UniqueId"; } }
        public static string OwnerViewId { get { return "OwnerViewId"; } }
        public static string LevelId { get { return "LevelId"; } }
        public static string IsSolid { get { return "IsSolid"; } }
    }
    public static class FamilyTemplatesColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string FamilyId { get { return "FamilyId"; } }
        public static string Name { get { return "Name"; } }
        public static string Description { get { return "Description"; } }
        public static string IsReleased { get { return "IsReleased"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string FamilyCategory { get { return "FamilyCategory"; } }
        public static string CanHostRebar { get { return "CanHostRebar"; } }
        public static string RoundConnectorDimension { get { return "RoundConnectorDimension"; } }
        public static string PartType { get { return "PartType"; } }
        public static string OmniClassNumber { get { return "OmniClassNumber"; } }
        public static string OmniClassTitle { get { return "OmniClassTitle"; } }
        public static string WorkPlaneBased { get { return "WorkPlaneBased"; } }
        public static string AlwaysVertical { get { return "AlwaysVertical"; } }
        public static string UniqueId { get { return "UniqueId"; } }
        public static string CutsWithVoidWhenLoaded { get { return "CutsWithVoidWhenLoaded"; } }
        public static string IsShared { get { return "IsShared"; } }
        public static string State { get { return "State"; } }
        public static string RoomCalculationPoint { get { return "RoomCalculationPoint"; } }
        public static string FileName { get { return "FileName"; } }
        public static string Thumbnail { get { return "Thumbnail"; } }
        public static string Version { get { return "Version"; } }
        public static string FileSize { get { return "FileSize"; } }
        public static string FamilyFile { get { return "FamilyFile"; } }
    }
    public static class TemplateComponentsColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string FamilyId { get { return "FamilyId"; } }
        public static string Name { get { return "Name"; } }
        public static string Description { get { return "Description"; } }
        public static string IsProfile { get { return "IsProfile"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string XReferencePlaneId { get { return "XReferencePlaneId"; } }
        public static string YReferencePlaneId { get { return "YReferencePlaneId"; } }
        public static string ZReferencePlaneId { get { return "ZReferencePlaneId"; } }
        public static string ProfileGeometryId { get { return "ProfileGeometryId"; } }
        public static string ProfileTypeNameId { get { return "ProfileTypeNameId"; } }
        public static string ProfileVerticalOffset { get { return "ProfileVerticalOffset"; } }
        public static string ProfileHorizontalOffset { get { return "ProfileHorizontalOffset"; } }
        public static string ProfileAngle { get { return "ProfileAngle"; } }
        public static string ProfileIsFlipped { get { return "ProfileIsFlipped"; } }
        public static string FamilyComponentTypeId { get { return "FamilyComponentTypeId"; } }
    }
    public static class ParametersColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string ElementId { get { return "ElementId"; } }
        public static string Name { get { return "Name"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string ElementGUID { get { return "ElementGUID"; } }
        public static string HasValue { get { return "HasValue"; } }
        public static string IsReadOnly { get { return "IsReadOnly"; } }
        public static string IsShared { get { return "IsShared"; } }
        public static string IsInstance { get { return "IsInstance"; } }
        public static string StorageType { get { return "StorageType"; } }
        public static string IsEditable { get { return "IsEditable"; } }
        public static string FamilyId { get { return "FamilyId"; } }
        public static string IsActive { get { return "IsActive"; } }
        public static string HostId { get { return "HostId"; } }
        public static string IsReporting { get { return "IsReporting"; } }
        public static string BuiltInParamGroup { get { return "BuiltInParamGroup"; } }
        public static string ParameterType { get { return "ParameterType"; } }
        public static string UnitType { get { return "UnitType"; } }
        //public static string UnitType { get { return "UnitType"; } }
        public static string DisplayUnitType { get { return "DisplayUnitType"; } }
        public static string UserModifiable { get { return "UserModifiable"; } }
        public static string IsDeterminedByFormula { get { return "IsDeterminedByFormula"; } }
        public static string Formula { get { return "Formula"; } }
    }
    public static class PermissionsColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string Name { get { return "Name"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string Description { get { return "Description"; } }
        public static string CanCreate { get { return "CanCreate"; } }
        public static string CanRead { get { return "CanRead"; } }
        public static string CanWrite { get { return "CanWrite"; } }
        public static string CanDelete { get { return "CanDelete"; } }
        public static string Special { get { return "Special"; } }
    }
    public static class ReferencePlanesColumnNames
    {
        public static string Id { get { return "Id"; } }
        public static string FamilyId { get { return "FamilyId"; } }
        public static string ElementId { get { return "ElementId"; } }
        public static string UniqueId { get { return "UniqueId"; } }
        public static string LevelId { get { return "LevelId"; } }
        public static string ViewId { get { return "ViewId"; } }
        public static string Category { get { return "Category"; } }
        public static string DirectionX { get { return "DirectionX"; } }
        public static string DirectionY { get { return "DirectionY"; } }
        public static string DirectionZ { get { return "DirectionZ"; } }
        public static string BubbleEndX { get { return "BubbleEndX"; } }
        public static string BubbleEndY { get { return "BubbleEndY"; } }
        public static string BubbleEndZ { get { return "BubbleEndZ"; } }
        public static string NormalX { get { return "NormalX"; } }
        public static string NormalY { get { return "NormalY"; } }
        public static string NormalZ { get { return "NormalZ"; } }
        public static string FreeEndX { get { return "FreeEndX"; } }
        public static string FreeEndY { get { return "FreeEndY"; } }
        public static string FreeEndZ { get { return "FreeEndZ"; } }
        public static string Name { get { return "Name"; } }
        public static string IsActive { get { return "IsActive"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
    }
    public static class SystemConfigurationColumnNames 
    {
        public static string Id { get { return "Id"; } }
        public static string Name { get { return "Name"; } }
        public static string CompanyAddress { get { return "CompanyAddress"; } }
        public static string Email { get { return "Email"; } }
        public static string InstallLocation { get { return "InstallLocation"; } }
        public static string AppVersion { get { return "AppVersion"; } }
        public static string DataBaseVersion { get { return "DataBaseVersion"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string State { get { return "State"; } }
    }
    public static class UsersColumnNames 
    {
        public static string Id { get { return "Id"; } }
        public static string Name { get { return "Name"; } }
        public static string FirstName { get { return "FirstName"; } }
        public static string LastName { get { return "LastName"; } }
        public static string Email { get { return "Email"; } }
        public static string Password { get { return "Password"; } }
        public static string ProfilePic { get { return "ProfilePic"; } }
        public static string CreatedById { get { return "CreatedById"; } }
        public static string ModifiedById { get { return "ModifiedById"; } }
        public static string DateCreated { get { return "DateCreated"; } }
        public static string DateModified { get { return "DateModified"; } }
        public static string State { get { return "State"; } }
        public static string LogInDate { get { return "LogInDate"; } }
        public static string PermissionId { get { return "PermissionId"; } }
        public static string TempFolder { get { return "TempFolder"; } }
        public static string Salt { get { return "Salt"; } }
    }
}


