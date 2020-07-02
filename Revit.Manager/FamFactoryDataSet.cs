using ModBox.FamFactory.Revit.Manager.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamFactoryDataSet
    {
        public static void InitilizeDataSet(DataSet dataSet)
        {
            InitilizePermissions(dataSet);
            InitilizeUsersTable(dataSet);            
            InitilizeEmailProfiles(dataSet);
            InitilizeSystemConfigurationsTable(dataSet);            
            InitilizeFamilyComponentTypesTable(dataSet);
            InitilizeFamilyComponentsTable(dataSet);
            InitilizeFamilyTemplatesTable(dataSet);
            InitilizeFamilyTemplateReferencePlanesTable(dataSet);
            InitilizeFamilyComponentReferencePlanesTable(dataSet);
            InitilizeFamilyTemplateGeometryTable(dataSet);
            InitilizeFamilyComponentsGeometryTable(dataSet);
            InitilizeFamilyTemplateParametersTable(dataSet);
            InitilizeFamilyComponentsParametersTable(dataSet);
            InitilizeFamilyTemplateComponentsTable(dataSet);
            InitilizeFamilyBuildsTable(dataSet);
            InitilizeFamilyBuildComponentsTable(dataSet);
            InitilizeFamilyBuildComponentPositionsTable(dataSet);
            InitilizeFamilyComponentCategoriesTable(dataSet);
            InitilizeFamilyComponentSearchTermsTable(dataSet);
            InitilizeFamilyComponents_FamilyComponentCategoriesTable(dataSet);
            InitilizeFamilyComponents_FamilyComponentSerchTermsTable(dataSet);
        }

        private static void InitilizePermissions(DataSet dataSet)
        {
            DataTable permissionsTable = new DataTable(TableNames.FF_Permissions.ToString());
            DataColumn IdColumn = permissionsTable.Columns.Add(PermissionsColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            DataColumn NameColumn = permissionsTable.Columns.Add(PermissionsColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.Unique = true;
            DataColumn DescriptionColumn = permissionsTable.Columns.Add(PermissionsColumnNames.Description.ToString(), typeof(string));
            DataColumn CreateColumn = permissionsTable.Columns.Add(PermissionsColumnNames.CanCreate.ToString(), typeof(bool));
            CreateColumn.AllowDBNull = false;
            CreateColumn.DefaultValue = false;
            DataColumn ReadColumn = permissionsTable.Columns.Add(PermissionsColumnNames.CanRead.ToString(), typeof(bool));
            ReadColumn.AllowDBNull = false;
            ReadColumn.DefaultValue = true;
            DataColumn WriteColumn = permissionsTable.Columns.Add(PermissionsColumnNames.CanWrite.ToString(), typeof(bool));
            WriteColumn.AllowDBNull = false;
            WriteColumn.DefaultValue = false;
            DataColumn DeleteColumn = permissionsTable.Columns.Add(PermissionsColumnNames.CanDelete.ToString(), typeof(bool));
            DeleteColumn.AllowDBNull = false;
            DeleteColumn.DefaultValue = false;
            DataColumn SpecialColumn = permissionsTable.Columns.Add(PermissionsColumnNames.Special.ToString(), typeof(bool));
            SpecialColumn.AllowDBNull = false;
            SpecialColumn.DefaultValue = false;

            permissionsTable.PrimaryKey = new DataColumn[] { IdColumn };

            dataSet.Tables.Add(permissionsTable);
        }

        private static void InitilizeUsersTable(DataSet dataSet)
        {
            // Users Table
            DataTable usersTable = new DataTable(TableNames.FF_Users.ToString());

            DataColumn IdColumn = usersTable.Columns.Add(UsersColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn nameColumn = usersTable.Columns.Add(UsersColumnNames.Name.ToString(), typeof(string));
            nameColumn.AllowDBNull = false;
            nameColumn.Unique = true;

            DataColumn firstNameColumn = usersTable.Columns.Add(UsersColumnNames.FirstName.ToString(), typeof(string));
            firstNameColumn.AllowDBNull = false;

            DataColumn lastNameColumn = usersTable.Columns.Add(UsersColumnNames.LastName.ToString(), typeof(string));
            lastNameColumn.AllowDBNull = false;

            DataColumn emailColumn = usersTable.Columns.Add(UsersColumnNames.Email.ToString(), typeof(string));
            emailColumn.AllowDBNull = false;

            DataColumn passwordColumn = usersTable.Columns.Add(UsersColumnNames.Password.ToString(), typeof(string));

            DataColumn profilePicColumn = usersTable.Columns.Add(UsersColumnNames.ProfilePic.ToString(), typeof(byte[]));
            profilePicColumn.AllowDBNull = false;
            profilePicColumn.DefaultValue = Utils.ImageToByte(Resources.UserIcon);

            DataColumn dateCreatdColumn = usersTable.Columns.Add(UsersColumnNames.DateCreated.ToString(), typeof(DateTime));
            dateCreatdColumn.AllowDBNull = false;

            DataColumn datemodColumn = usersTable.Columns.Add(UsersColumnNames.DateModified.ToString(), typeof(DateTime));
            datemodColumn.AllowDBNull = false;

            DataColumn permissionIdColumn = usersTable.Columns.Add(UsersColumnNames.PermissionId.ToString(), typeof(string));
            permissionIdColumn.AllowDBNull = true;

            DataColumn lastLogInDateColumn = usersTable.Columns.Add(UsersColumnNames.LogInDate.ToString(), typeof(DateTime));

            DataColumn stateColumn = usersTable.Columns.Add(UsersColumnNames.State.ToString(), typeof(EntityStates));
            stateColumn.AllowDBNull = false;
            stateColumn.DefaultValue = EntityStates.Enabled;

            DataColumn TempFolderColumn = usersTable.Columns.Add(UsersColumnNames.TempFolder.ToString(), typeof(string));
            TempFolderColumn.AllowDBNull = false;
            TempFolderColumn.DefaultValue = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FamFactory\\Temp";

            DataColumn SaltColumn = usersTable.Columns.Add(UsersColumnNames.Salt, typeof(string));
            TempFolderColumn.AllowDBNull = false;

            //Create and add Primary Keys for Datatable
            usersTable.PrimaryKey = new DataColumn[] { IdColumn };
            // Add DataTable to DataSet befroe adding Datarelations.
            dataSet.Tables.Add(usersTable);

            //Create the DataRelation.
            DataRelation dataRelation = new DataRelation(TableRelations.Users_PermissionId__Permissions_Id.ToString(),
                dataSet.Tables[TableNames.FF_Permissions.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.PermissionId.ToString()]);
            dataSet.Relations.Add(dataRelation);
        }

        private static void InitilizeEmailProfiles(DataSet dataSet)
        {
            DataTable EmailprofilesTable = new DataTable(TableNames.FF_EmailProfiles.ToString());

            DataColumn IdColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn NameColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.Unique = true;

            DataColumn DescriptionColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.Description.ToString(), typeof(string));

            DataColumn ServerColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.ServerAddress.ToString(), typeof(string));
            ServerColumn.AllowDBNull = false;

            DataColumn PortColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.Port.ToString(), typeof(int));
            PortColumn.AllowDBNull = false;
            PortColumn.DefaultValue = 25;

            DataColumn SSLColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.SSL.ToString(), typeof(bool));
            SSLColumn.AllowDBNull = false;
            SSLColumn.DefaultValue = false;

            DataColumn UserNameColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.Username.ToString(), typeof(string));
            UserNameColumn.AllowDBNull = false;
            UserNameColumn.DefaultValue = false;

            DataColumn PasswordColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.Password.ToString(), typeof(string));
            PasswordColumn.AllowDBNull = false;
            PasswordColumn.DefaultValue = false;

            DataColumn StateColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.State.ToString(), typeof(EntityStates));
            StateColumn.AllowDBNull = false;
            StateColumn.DefaultValue = EntityStates.Enabled;

            DataColumn CreatedByColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByColumn.AllowDBNull = false;

            DataColumn ModifiedByColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByColumn.AllowDBNull = false;

            DataColumn DateCreatedColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = EmailprofilesTable.Columns.Add(EmailProfilesColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            EmailprofilesTable.PrimaryKey = new DataColumn[] { IdColumn };

            dataSet.Tables.Add(EmailprofilesTable);

            //Create the DataRelation.
            DataRelation createdByRelation = new DataRelation(TableRelations.EmailProfiles_CreatedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                CreatedByColumn);
            dataSet.Relations.Add(createdByRelation);

            //Create the DataRelation.
            DataRelation modifiedByRelation = new DataRelation(TableRelations.EmailProfiles_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_EmailProfiles.ToString()].Columns[EmailProfilesColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(modifiedByRelation);
        }

        private static void InitilizeSystemConfigurationsTable(DataSet dataSet)
        {
            // System Configuration
            DataTable SysConfigTable = new DataTable(TableNames.FF_SystemConfigurations.ToString());

            DataColumn idColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.Id.ToString(), typeof(string));
            idColumn.AllowDBNull = false;
            idColumn.Unique = true;

            DataColumn nameColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.Name.ToString(), typeof(string));
            nameColumn.AllowDBNull = false;
            nameColumn.Unique = true;

            DataColumn addressColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.CompanyAddress.ToString(), typeof(string));
            addressColumn.AllowDBNull = true;

            DataColumn emailColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.Email.ToString(), typeof(string));
            emailColumn.AllowDBNull = false;

            DataColumn installColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.InstallLocation.ToString(), typeof(string));
            installColumn.AllowDBNull = false;

            DataColumn appVerColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.AppVersion.ToString(), typeof(string));
            appVerColumn.AllowDBNull = false;

            DataColumn dbVersionColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.DataBaseVersion.ToString(), typeof(string));
            dbVersionColumn.AllowDBNull = false;

            DataColumn dateCreatdColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.DateCreated.ToString(), typeof(DateTime));
            dateCreatdColumn.AllowDBNull = false;

            DataColumn dateModifiedColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.DateModified.ToString(), typeof(DateTime));
            dateModifiedColumn.AllowDBNull = false;

            DataColumn createdByIdColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.CreatedById.ToString(), typeof(string));
            createdByIdColumn.AllowDBNull = false;

            DataColumn modifiedByIdColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.ModifiedById.ToString(), typeof(string));
            modifiedByIdColumn.AllowDBNull = false;

            DataColumn stateColumn = SysConfigTable.Columns.Add(SystemConfigurationColumnNames.State.ToString(), typeof(EntityStates));
            stateColumn.AllowDBNull = false;
            stateColumn.DefaultValue = EntityStates.Enabled;

            SysConfigTable.PrimaryKey = new DataColumn[] { idColumn };

            dataSet.Tables.Add(SysConfigTable);

            //Create the DataRelation.
            DataRelation createdByRelation = new DataRelation(TableRelations.SystemConfigurations_CreatedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                createdByIdColumn);
            dataSet.Relations.Add(createdByRelation);

            //Create the DataRelation.
            DataRelation modifiedByRelation = new DataRelation(TableRelations.SystemConfigurations_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_SystemConfigurations.ToString()].Columns[SystemConfigurationColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(modifiedByRelation);
        }

        private static void InitilizeFamilyComponentTypesTable(DataSet dataSet)
        {
            // System Configuration
            DataTable FamilyComponentTypes = new DataTable(TableNames.FF_FamilyComponentTypes.ToString());

            DataColumn idColumn = FamilyComponentTypes.Columns.Add(FamilyComponentTypesColumnNames.Id.ToString(), typeof(string));
            idColumn.AllowDBNull = false;
            idColumn.Unique = true;

            DataColumn nameColumn = FamilyComponentTypes.Columns.Add(FamilyComponentTypesColumnNames.Name.ToString(), typeof(string));
            nameColumn.AllowDBNull = false;
            nameColumn.Unique = true;

            DataColumn addressColumn = FamilyComponentTypes.Columns.Add(FamilyComponentTypesColumnNames.Description.ToString(), typeof(string));
            addressColumn.AllowDBNull = true;

            DataColumn ThumbnailColumn = FamilyComponentTypes.Columns.Add(FamilyComponentTypesColumnNames.Thumbnail.ToString(), typeof(byte[]));
            ThumbnailColumn.AllowDBNull = true;

            DataColumn dateCreatdColumn = FamilyComponentTypes.Columns.Add(FamilyComponentTypesColumnNames.DateCreated.ToString(), typeof(DateTime));
            dateCreatdColumn.AllowDBNull = false;

            DataColumn dateModifiedColumn = FamilyComponentTypes.Columns.Add(FamilyComponentTypesColumnNames.DateModified.ToString(), typeof(DateTime));
            dateModifiedColumn.AllowDBNull = false;

            DataColumn createdByIdColumn = FamilyComponentTypes.Columns.Add(FamilyComponentTypesColumnNames.CreatedById.ToString(), typeof(string));
            createdByIdColumn.AllowDBNull = false;

            DataColumn modifiedByIdColumn = FamilyComponentTypes.Columns.Add(FamilyComponentTypesColumnNames.ModifiedById.ToString(), typeof(string));
            modifiedByIdColumn.AllowDBNull = false;
            
            FamilyComponentTypes.PrimaryKey = new DataColumn[] { idColumn };

            dataSet.Tables.Add(FamilyComponentTypes);
        }

        public static void InitilizeFamilyComponentsTable(DataSet dataSet)
        {
            try
            {
                DataTable FamilyComponentsTable = new DataTable(TableNames.FF_FamilyComponents.ToString());

                DataColumn idColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.Id.ToString(), typeof(string));
                idColumn.AllowDBNull = false;
                idColumn.Unique = true;

                DataColumn nameColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.Name.ToString(), typeof(string));
                nameColumn.AllowDBNull = false;
                nameColumn.Unique = true;

                DataColumn DescriptionColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.Description.ToString(), typeof(string));
                DescriptionColumn.AllowDBNull = true;

                DataColumn FamilyComponentTypeIdColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.FamilyComponentTypeId.ToString(), typeof(string));
                FamilyComponentTypeIdColumn.AllowDBNull = false;

                DataColumn FamilyCategoryColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.FamilyCategory.ToString(), typeof(string));
                FamilyCategoryColumn.AllowDBNull = false;

                DataColumn FamilyFileColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.FamilyFile.ToString(), typeof(byte[]));
                FamilyFileColumn.AllowDBNull = false;
                FamilyFileColumn.DefaultValue = new byte[byte.MaxValue];

                DataColumn ThumbnailColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.Thumbnail.ToString(), typeof(byte[]));
                ThumbnailColumn.AllowDBNull = false;
                ThumbnailColumn.DefaultValue = new byte[byte.MaxValue];

                DataColumn FileSizeColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.FileSize.ToString(), typeof(long));
                FileSizeColumn.AllowDBNull = false;
                FileSizeColumn.DefaultValue = 0;

                DataColumn DateCreatedColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.DateCreated.ToString(), typeof(DateTime));
                DateCreatedColumn.AllowDBNull = false;
                DateCreatedColumn.DefaultValue = DateTime.Now;

                DataColumn DateModifiedColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.DateModified.ToString(), typeof(DateTime));
                DateModifiedColumn.AllowDBNull = false;
                DateModifiedColumn.DefaultValue = DateTime.Now;

                DataColumn CreatedByUserIdColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.CreatedById.ToString(), typeof(string));
                CreatedByUserIdColumn.AllowDBNull = true;

                DataColumn ModifiedByUserIdColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.ModifiedById.ToString(), typeof(string));
                ModifiedByUserIdColumn.AllowDBNull = true;

                DataColumn VersionColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.Version.ToString(), typeof(string));
                VersionColumn.AllowDBNull = false;
                VersionColumn.DefaultValue = "1.0.0";

                DataColumn IsReleasedColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.IsReleased.ToString(), typeof(bool));
                IsReleasedColumn.AllowDBNull = false;
                IsReleasedColumn.DefaultValue = false;

                DataColumn RoundConnectorDimentionColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.RoundConnectorDimension.ToString(), typeof(string));
                RoundConnectorDimentionColumn.AllowDBNull = false;
                RoundConnectorDimentionColumn.DefaultValue = string.Empty;

                DataColumn PartTypeColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.PartType.ToString(), typeof(string));
                PartTypeColumn.AllowDBNull = false;
                PartTypeColumn.DefaultValue = string.Empty;

                DataColumn OmniClassNumberColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.OmniClassNumber.ToString(), typeof(string));
                OmniClassNumberColumn.AllowDBNull = false;
                OmniClassNumberColumn.DefaultValue = string.Empty;

                DataColumn OmniClassTitleColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.OmniClassTitle.ToString(), typeof(string));
                OmniClassTitleColumn.AllowDBNull = false;
                OmniClassTitleColumn.DefaultValue = string.Empty;

                DataColumn WorkPlaneBasedColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.WorkPlaneBased.ToString(), typeof(bool));
                WorkPlaneBasedColumn.AllowDBNull = false;
                WorkPlaneBasedColumn.DefaultValue = false;

                DataColumn AlwaysVerticalColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.AlwaysVertical.ToString(), typeof(bool));
                AlwaysVerticalColumn.AllowDBNull = false;
                AlwaysVerticalColumn.DefaultValue = false;

                DataColumn CutsWithVoidWhenLoadedColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.CutsWithVoidWhenLoaded.ToString(), typeof(bool));
                CutsWithVoidWhenLoadedColumn.AllowDBNull = false;
                CutsWithVoidWhenLoadedColumn.DefaultValue = false;

                DataColumn IsSharedColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.IsShared.ToString(), typeof(bool));
                IsSharedColumn.AllowDBNull = false;
                IsSharedColumn.DefaultValue = false;

                DataColumn RoomCalculationPointColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.RoomCalculationPoint.ToString(), typeof(bool));
                RoomCalculationPointColumn.AllowDBNull = false;
                RoomCalculationPointColumn.DefaultValue = false;

                DataColumn FileNameColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.FileName.ToString(), typeof(string));
                FileNameColumn.AllowDBNull = false;
                FileNameColumn.DefaultValue = string.Empty;

                DataColumn stateColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.State.ToString(), typeof(EntityStates));
                stateColumn.AllowDBNull = false;
                stateColumn.DefaultValue = EntityStates.Enabled;

                DataColumn canhostrebarColumn = FamilyComponentsTable.Columns.Add(FamilyComponentsColumnNames.CanHostRebar.ToString(), typeof(bool));
                canhostrebarColumn.AllowDBNull = false;
                canhostrebarColumn.DefaultValue = false;

                FamilyComponentsTable.PrimaryKey = new DataColumn[] { idColumn };

                dataSet.Tables.Add(FamilyComponentsTable);

                DataRelation FamilyComponentTypeDataRelation = new DataRelation(TableRelations.FamilyComponents_FamilyComponentTypeId__FamilyComponentTypes_Id.ToString(),
                    dataSet.Tables[TableNames.FF_FamilyComponentTypes.ToString()].Columns[FamilyComponentTypesColumnNames.Id.ToString()],
                    dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns[FamilyComponentsColumnNames.FamilyComponentTypeId.ToString()]);
                dataSet.Relations.Add(FamilyComponentTypeDataRelation);

                DataRelation FamilyComponentsCreatedByDataRelation = new DataRelation(TableRelations.FamilyComponents_CreatedById__Users_Id.ToString(),
                    dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
                    dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns[FamilyComponentsColumnNames.CreatedById.ToString()]);
                dataSet.Relations.Add(FamilyComponentsCreatedByDataRelation);

                DataRelation FamilyComponentsModifiedByDataRelation = new DataRelation(TableRelations.FamilyComponents_ModifiedById__Users_Id.ToString(),
                    dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
                    dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns[FamilyComponentsColumnNames.ModifiedById.ToString()]);
                dataSet.Relations.Add(FamilyComponentsModifiedByDataRelation);
            }
            catch (Exception ex)
            {
                throw new Exception("Error initilizing FamilyComponentsTable!!!", ex);
            }

        }

        private static void InitilizeFamilyTemplatesTable(DataSet dataSet)
        {
            DataTable FamilyTemplatesTable = new DataTable(TableNames.FF_FamilyTemplates.ToString());

            DataColumn IdColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn NameColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.Unique = false;

            DataColumn DescriptionColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = true;
            DescriptionColumn.Unique = false;

            DataColumn IsReleasedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.IsReleased.ToString(), typeof(bool));
            IsReleasedColumn.AllowDBNull = false;
            IsReleasedColumn.DefaultValue = false;

            DataColumn FamilyCategoryColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.FamilyCategory.ToString(), typeof(string));
            FamilyCategoryColumn.AllowDBNull = false;

            DataColumn CanHostRebarColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.CanHostRebar.ToString(), typeof(bool));
            CanHostRebarColumn.AllowDBNull = false;
            CanHostRebarColumn.DefaultValue = false;

            DataColumn RoundConnectorDimentionColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.RoundConnectorDimension.ToString(), typeof(string));
            RoundConnectorDimentionColumn.AllowDBNull = false;
            RoundConnectorDimentionColumn.Unique = false;

            DataColumn PartTypeColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.PartType.ToString(), typeof(string));
            PartTypeColumn.AllowDBNull = false;

            DataColumn OmnoClassNumberColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.OmniClassNumber.ToString(), typeof(string));
            OmnoClassNumberColumn.AllowDBNull = true;
            OmnoClassNumberColumn.Unique = false;

            DataColumn OmniClassTitleColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.OmniClassTitle.ToString(), typeof(string));
            OmniClassTitleColumn.AllowDBNull = true;
            OmniClassTitleColumn.Unique = false;

            DataColumn WorkPlaneBasedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.WorkPlaneBased.ToString(), typeof(bool));
            WorkPlaneBasedColumn.AllowDBNull = false;
            WorkPlaneBasedColumn.DefaultValue = false;

            DataColumn AlwaysVerticalColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.AlwaysVertical.ToString(), typeof(bool));
            AlwaysVerticalColumn.AllowDBNull = false;
            AlwaysVerticalColumn.DefaultValue = false;
            AlwaysVerticalColumn.Unique = false;

            DataColumn CutsWithVoidWhenLoadedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.CutsWithVoidWhenLoaded.ToString(), typeof(bool));
            CutsWithVoidWhenLoadedColumn.AllowDBNull = false;
            CutsWithVoidWhenLoadedColumn.DefaultValue = false;

            DataColumn IsSharedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.IsShared.ToString(), typeof(bool));
            IsSharedColumn.AllowDBNull = false;
            IsSharedColumn.DefaultValue = false;

            DataColumn RoomCalculationPointColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.RoomCalculationPoint.ToString(), typeof(bool));
            RoomCalculationPointColumn.AllowDBNull = false;
            RoomCalculationPointColumn.DefaultValue = false;

            DataColumn FileNameColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.FileName.ToString(), typeof(string));
            FileNameColumn.AllowDBNull = false;

            DataColumn ThumbnailColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.Thumbnail.ToString(), typeof(byte[]));
            ThumbnailColumn.AllowDBNull = true;
            ThumbnailColumn.DefaultValue = new byte[byte.MinValue];
            ThumbnailColumn.Unique = false;

            DataColumn VersionColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.Version.ToString(), typeof(string));
            VersionColumn.AllowDBNull = false;
            VersionColumn.Unique = false;

            DataColumn FileSizeColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.FileSize.ToString(), typeof(long));
            FileSizeColumn.AllowDBNull = false;
            FileSizeColumn.DefaultValue = 0;
            FileSizeColumn.Unique = false;

            DataColumn DateCreatedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;
            DateCreatedColumn.DefaultValue = DateTime.Now;
            DateCreatedColumn.Unique = false;

            DataColumn DateModifiedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;
            DateModifiedColumn.DefaultValue = DateTime.Now;
            DateModifiedColumn.Unique = false;

            DataColumn FamilyFileColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.FamilyFile.ToString(), typeof(byte[]));
            FamilyFileColumn.AllowDBNull = false;
            FamilyFileColumn.DefaultValue = new byte[byte.MinValue];
            FamilyFileColumn.Unique = false;

            DataColumn CreatedByIdColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;
            CreatedByIdColumn.Unique = false;

            DataColumn ModifiedByIdColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;
            ModifiedByIdColumn.Unique = false;

            DataColumn stateColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplatesColumnNames.State.ToString(), typeof(EntityStates));
            stateColumn.AllowDBNull = false;
            stateColumn.DefaultValue = EntityStates.Enabled;

            dataSet.Tables.Add(FamilyTemplatesTable);

            DataRelation usersDataRelation = new DataRelation(TableRelations.FamilyTemplates_CreatedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns[FamilyTemplatesColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(usersDataRelation);

            DataRelation usersModDataRelation = new DataRelation(TableRelations.FamilyTemplates_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns[FamilyTemplatesColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(usersModDataRelation);
        }

        private static void InitilizeFamilyTemplateReferencePlanesTable(DataSet dataSet)
        {
            DataTable referencePlaneTable = new DataTable(TableNames.FF_FamilyTemplateReferencePlanes.ToString());

            DataColumn IdColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyTemplateIdColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.FamilyId.ToString(), typeof(string));
            FamilyTemplateIdColumn.AllowDBNull = false;
            FamilyTemplateIdColumn.Unique = false;

            DataColumn NameColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New User";
            NameColumn.Unique = false;

            DataColumn RevitIdColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.ElementId.ToString(), typeof(int));
            RevitIdColumn.AllowDBNull = false;

            DataColumn UniquColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.UniqueId.ToString(), typeof(string));
            UniquColumn.AllowDBNull = false;
            UniquColumn.DefaultValue = false;

            DataColumn LevelColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.LevelId.ToString(), typeof(int));
            LevelColumn.AllowDBNull = false;
            LevelColumn.DefaultValue = 0;

            DataColumn ViewIdColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.ViewId.ToString(), typeof(int));
            ViewIdColumn.AllowDBNull = false;
            ViewIdColumn.DefaultValue = 0;

            DataColumn CategoryColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.Category.ToString(), typeof(string));
            CategoryColumn.AllowDBNull = false;
            CategoryColumn.DefaultValue = "";

            DataColumn DirectionXColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.DirectionX.ToString(), typeof(double));
            DirectionXColumn.AllowDBNull = false;
            DirectionXColumn.DefaultValue = 0;

            DataColumn DirectionYColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.DirectionY.ToString(), typeof(double));
            DirectionYColumn.AllowDBNull = false;
            DirectionYColumn.DefaultValue = 0;

            DataColumn DirectionZColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.DirectionZ.ToString(), typeof(double));
            DirectionZColumn.AllowDBNull = false;
            DirectionZColumn.DefaultValue = 0;

            DataColumn BubbleEndXColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.BubbleEndX.ToString(), typeof(double));
            BubbleEndXColumn.AllowDBNull = false;
            BubbleEndXColumn.DefaultValue = 0;

            DataColumn BubbleEndYColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.BubbleEndY.ToString(), typeof(double));
            BubbleEndYColumn.AllowDBNull = false;
            BubbleEndYColumn.DefaultValue = 0;

            DataColumn BubbleEndZColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.BubbleEndZ.ToString(), typeof(double));
            BubbleEndZColumn.AllowDBNull = false;
            BubbleEndZColumn.DefaultValue = 0;

            DataColumn NormalXColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.NormalX.ToString(), typeof(double));
            NormalXColumn.AllowDBNull = false;
            NormalXColumn.DefaultValue = 0;

            DataColumn NormalYColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.NormalY.ToString(), typeof(double));
            NormalYColumn.AllowDBNull = false;
            NormalYColumn.DefaultValue = 0;

            DataColumn NormalZColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.NormalZ.ToString(), typeof(double));
            NormalZColumn.AllowDBNull = false;
            NormalZColumn.DefaultValue = 0;

            DataColumn FreeEndXColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.FreeEndX.ToString(), typeof(double));
            FreeEndXColumn.AllowDBNull = false;
            FreeEndXColumn.DefaultValue = 0;

            DataColumn FreeEndYColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.FreeEndY.ToString(), typeof(double));
            FreeEndYColumn.AllowDBNull = false;

            DataColumn FreeEndZColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.FreeEndZ.ToString(), typeof(double));
            FreeEndZColumn.AllowDBNull = false;

            DataColumn IsActiveColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = false;

            DataColumn DateCreatedColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            DataColumn CreatedByIdColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;

            DataColumn ModifiedByIdColumn = referencePlaneTable.Columns.Add(ReferencePlanesColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;

            referencePlaneTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };

            dataSet.Tables.Add(referencePlaneTable);

            DataRelation famIdDataRelation = new DataRelation(TableRelations.FamilyTemplateReferencePlanes_FamilyId__FamilyTemplates_Id.ToString(),
              dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns[ParametersColumnNames.Id.ToString()],
              dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns[ReferencePlanesColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(famIdDataRelation);

            DataRelation createdByDataRelation = new DataRelation(TableRelations.FamilyTemplateReferencePlanes_CreatedById__Users_Id.ToString(),
              dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
              dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns[ReferencePlanesColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(createdByDataRelation);

            DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyTemplateReferencePlanes_ModifiedById__Users_Id.ToString(),
              dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
              dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns[ReferencePlanesColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(ModifiedByDataRelation);
        }

        private static void InitilizeFamilyComponentReferencePlanesTable(DataSet dataSet)
        {
            DataTable tbl = new DataTable(TableNames.FF_FamilyComponentReferencePlanes.ToString());

            DataColumn IdColumn = tbl.Columns.Add(ReferencePlanesColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyIdColumn = tbl.Columns.Add(ReferencePlanesColumnNames.FamilyId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = false;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = tbl.Columns.Add(ReferencePlanesColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.Unique = false;

            DataColumn RevitIdColumn = tbl.Columns.Add(ReferencePlanesColumnNames.ElementId.ToString(), typeof(int));
            RevitIdColumn.AllowDBNull = false;

            DataColumn UniquColumn = tbl.Columns.Add(ReferencePlanesColumnNames.UniqueId.ToString(), typeof(string));
            UniquColumn.AllowDBNull = false;
            UniquColumn.DefaultValue = false;

            DataColumn LevelColumn = tbl.Columns.Add(ReferencePlanesColumnNames.LevelId.ToString(), typeof(int));
            LevelColumn.AllowDBNull = false;
            LevelColumn.DefaultValue = 0;

            DataColumn ViewIdColumn = tbl.Columns.Add(ReferencePlanesColumnNames.ViewId.ToString(), typeof(int));
            ViewIdColumn.AllowDBNull = false;
            ViewIdColumn.DefaultValue = 0;

            DataColumn CategoryColumn = tbl.Columns.Add(ReferencePlanesColumnNames.Category.ToString(), typeof(string));
            CategoryColumn.AllowDBNull = false;
            CategoryColumn.DefaultValue = "";

            DataColumn DirectionXColumn = tbl.Columns.Add(ReferencePlanesColumnNames.DirectionX.ToString(), typeof(double));
            DirectionXColumn.AllowDBNull = false;
            DirectionXColumn.DefaultValue = 0;

            DataColumn DirectionYColumn = tbl.Columns.Add(ReferencePlanesColumnNames.DirectionY.ToString(), typeof(double));
            DirectionYColumn.AllowDBNull = false;
            DirectionYColumn.DefaultValue = 0;

            DataColumn DirectionZColumn = tbl.Columns.Add(ReferencePlanesColumnNames.DirectionZ.ToString(), typeof(double));
            DirectionZColumn.AllowDBNull = false;
            DirectionZColumn.DefaultValue = 0;

            DataColumn BubbleEndXColumn = tbl.Columns.Add(ReferencePlanesColumnNames.BubbleEndX.ToString(), typeof(double));
            BubbleEndXColumn.AllowDBNull = false;
            BubbleEndXColumn.DefaultValue = 0;

            DataColumn BubbleEndYColumn = tbl.Columns.Add(ReferencePlanesColumnNames.BubbleEndY.ToString(), typeof(double));
            BubbleEndYColumn.AllowDBNull = false;
            BubbleEndYColumn.DefaultValue = 0;

            DataColumn BubbleEndZColumn = tbl.Columns.Add(ReferencePlanesColumnNames.BubbleEndZ.ToString(), typeof(double));
            BubbleEndZColumn.AllowDBNull = false;
            BubbleEndZColumn.DefaultValue = 0;

            DataColumn NormalXColumn = tbl.Columns.Add(ReferencePlanesColumnNames.NormalX.ToString(), typeof(double));
            NormalXColumn.AllowDBNull = false;
            NormalXColumn.DefaultValue = 0;

            DataColumn NormalYColumn = tbl.Columns.Add(ReferencePlanesColumnNames.NormalY.ToString(), typeof(double));
            NormalYColumn.AllowDBNull = false;
            NormalYColumn.DefaultValue = 0;

            DataColumn NormalZColumn = tbl.Columns.Add(ReferencePlanesColumnNames.NormalZ.ToString(), typeof(double));
            NormalZColumn.AllowDBNull = false;
            NormalZColumn.DefaultValue = 0;

            DataColumn FreeEndXColumn = tbl.Columns.Add(ReferencePlanesColumnNames.FreeEndX.ToString(), typeof(double));
            FreeEndXColumn.AllowDBNull = false;
            FreeEndXColumn.DefaultValue = 0;

            DataColumn FreeEndYColumn = tbl.Columns.Add(ReferencePlanesColumnNames.FreeEndY.ToString(), typeof(double));
            FreeEndYColumn.AllowDBNull = false;
            FreeEndYColumn.DefaultValue = 0;

            DataColumn FreeEndZColumn = tbl.Columns.Add(ReferencePlanesColumnNames.FreeEndZ.ToString(), typeof(double));
            FreeEndZColumn.AllowDBNull = false;
            FreeEndZColumn.DefaultValue = 0;

            DataColumn IsActiveColumn = tbl.Columns.Add(ReferencePlanesColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = false;

            DataColumn DateCreatedColumn = tbl.Columns.Add(ReferencePlanesColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = tbl.Columns.Add(ReferencePlanesColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            DataColumn CreatedByIdColumn = tbl.Columns.Add(ReferencePlanesColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;

            DataColumn ModifiedByIdColumn = tbl.Columns.Add(ReferencePlanesColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;

            tbl.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };

            dataSet.Tables.Add(tbl);

            DataRelation ReferencePlanesDataRelation = new DataRelation(TableRelations.FamilyComponentReferencePlanes_FamilyId__FamilyComponents_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns[ReferencePlanesColumnNames.Id.ToString()],
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns[ReferencePlanesColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(ReferencePlanesDataRelation);

            DataRelation RCreatedByDataRelation = new DataRelation(TableRelations.FamilyComponentReferencePlanes_CreatedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns[ReferencePlanesColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(RCreatedByDataRelation);

            DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyComponentReferencePlanes_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns[ReferencePlanesColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(ModifiedByDataRelation);
        }

        private static void InitilizeFamilyTemplateGeometryTable(DataSet dataSet)
        {
            DataTable tbl = new DataTable(TableNames.FF_FamilyTemplateGeometries.ToString());

            DataColumn IdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.FamilyId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = false;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Sweep";
            NameColumn.Unique = false;

            DataColumn ElementIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.ElementId.ToString(), typeof(int));
            ElementIdColumn.AllowDBNull = false;
            ElementIdColumn.DefaultValue = -1;
            ElementIdColumn.Unique = false;

            DataColumn DescriptionColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = false;
            DescriptionColumn.DefaultValue = "";
            DescriptionColumn.Unique = false;

            DataColumn GeometryTypeColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.GeometryType.ToString(), typeof(string));
            GeometryTypeColumn.AllowDBNull = false;
            GeometryTypeColumn.DefaultValue = "Sweep";
            GeometryTypeColumn.Unique = false;

            DataColumn MaterialIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.MaterialId.ToString(), typeof(int));
            MaterialIdColumn.AllowDBNull = false;
            MaterialIdColumn.DefaultValue = -1;
            MaterialIdColumn.Unique = false;

            DataColumn IsActiveColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = true;
            IsActiveColumn.Unique = false;

            DataColumn ProfileFamily1IdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.ProfileFamily1Id.ToString(), typeof(int));
            ProfileFamily1IdColumn.AllowDBNull = false;
            ProfileFamily1IdColumn.DefaultValue = -1;
            ProfileFamily1IdColumn.Unique = false;

            DataColumn ProfileFamily2IdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.ProfileFamily2Id.ToString(), typeof(int));
            ProfileFamily2IdColumn.AllowDBNull = false;
            ProfileFamily2IdColumn.DefaultValue = -1;
            ProfileFamily2IdColumn.Unique = false;

            DataColumn HostIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.HostId.ToString(), typeof(int));
            HostIdColumn.AllowDBNull = false;
            HostIdColumn.DefaultValue = -1;
            HostIdColumn.Unique = false;

            DataColumn CategoryColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.Category.ToString(), typeof(string));
            CategoryColumn.AllowDBNull = false;
            CategoryColumn.DefaultValue = "";
            CategoryColumn.Unique = false;

            DataColumn SubCategoryColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.SubCategory.ToString(), typeof(string));
            SubCategoryColumn.AllowDBNull = false;
            SubCategoryColumn.DefaultValue = "";
            SubCategoryColumn.Unique = false;

            DataColumn UniqueIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.UniqueId.ToString(), typeof(string));
            UniqueIdColumn.AllowDBNull = false;
            UniqueIdColumn.DefaultValue = -1;
            UniqueIdColumn.Unique = false;

            DataColumn OwnerViewIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.OwnerViewId.ToString(), typeof(int));
            OwnerViewIdColumn.AllowDBNull = false;
            OwnerViewIdColumn.DefaultValue = -1;
            OwnerViewIdColumn.Unique = false;

            DataColumn LevelIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.LevelId.ToString(), typeof(int));
            LevelIdColumn.AllowDBNull = false;
            LevelIdColumn.DefaultValue = -1;
            LevelIdColumn.Unique = false;

            DataColumn IsSolidColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.IsSolid.ToString(), typeof(bool));
            LevelIdColumn.AllowDBNull = false;
            LevelIdColumn.DefaultValue = true;
            LevelIdColumn.Unique = false;

            DataColumn DateCreatedColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            DataColumn CreatedByIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;

            DataColumn ModifiedByIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;

            dataSet.Tables.Add(tbl);

            DataRelation geometryDataRelation = new DataRelation(TableRelations.FamilyTemplateGeometries_FamilyId__FamilyTemplates_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateGeometries.ToString()].Columns[FamilyGeometriesColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(geometryDataRelation);

            DataRelation CreatedByDataRelation = new DataRelation(TableRelations.FamilyTemplateGeometries_CreatedById__Users_Id.ToString(),
               dataSet.Tables[TableNames.FF_Users.ToString()].Columns[FamilyGeometriesColumnNames.Id.ToString()],
               dataSet.Tables[TableNames.FF_FamilyTemplateGeometries.ToString()].Columns[FamilyGeometriesColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(CreatedByDataRelation);

            DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyTemplateGeometries_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[FamilyGeometriesColumnNames.Id.ToString()],
                dataSet.Tables[TableNames.FF_FamilyTemplateGeometries.ToString()].Columns[FamilyGeometriesColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(ModifiedByDataRelation);
        }

        private static void InitilizeFamilyComponentsGeometryTable(DataSet dataSet)
        {
            DataTable tbl = new DataTable(TableNames.FF_FamilyComponentGeometries.ToString());

            DataColumn IdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.FamilyId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = false;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Sweep";
            NameColumn.Unique = false;

            DataColumn ElementIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.ElementId.ToString(), typeof(int));
            ElementIdColumn.AllowDBNull = false;
            ElementIdColumn.DefaultValue = -1;
            ElementIdColumn.Unique = false;

            DataColumn DescriptionColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = false;
            DescriptionColumn.DefaultValue = "";
            DescriptionColumn.Unique = false;

            DataColumn GeometryTypeColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.GeometryType.ToString(), typeof(string));
            GeometryTypeColumn.AllowDBNull = false;
            GeometryTypeColumn.DefaultValue = "Sweep";
            GeometryTypeColumn.Unique = false;

            DataColumn MaterialIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.MaterialId.ToString(), typeof(int));
            MaterialIdColumn.AllowDBNull = false;
            MaterialIdColumn.DefaultValue = -1;
            MaterialIdColumn.Unique = false;

            DataColumn IsActiveColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = true;
            IsActiveColumn.Unique = false;

            DataColumn ProfileFamily1IdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.ProfileFamily1Id.ToString(), typeof(int));
            ProfileFamily1IdColumn.AllowDBNull = false;
            ProfileFamily1IdColumn.DefaultValue = -1;
            ProfileFamily1IdColumn.Unique = false;

            DataColumn ProfileFamily2IdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.ProfileFamily2Id.ToString(), typeof(int));
            ProfileFamily2IdColumn.AllowDBNull = false;
            ProfileFamily2IdColumn.DefaultValue = -1;
            ProfileFamily2IdColumn.Unique = false;

            DataColumn HostIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.HostId.ToString(), typeof(int));
            HostIdColumn.AllowDBNull = false;
            HostIdColumn.DefaultValue = -1;
            HostIdColumn.Unique = false;

            DataColumn CategoryColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.Category.ToString(), typeof(string));
            CategoryColumn.AllowDBNull = false;
            CategoryColumn.DefaultValue = "";
            CategoryColumn.Unique = false;

            DataColumn SubCategoryColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.SubCategory.ToString(), typeof(string));
            SubCategoryColumn.AllowDBNull = false;
            SubCategoryColumn.DefaultValue = "";
            SubCategoryColumn.Unique = false;

            DataColumn UniqueIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.UniqueId.ToString(), typeof(int));
            UniqueIdColumn.AllowDBNull = false;
            UniqueIdColumn.DefaultValue = -1;
            UniqueIdColumn.Unique = false;

            DataColumn OwnerViewIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.OwnerViewId.ToString(), typeof(int));
            OwnerViewIdColumn.AllowDBNull = false;
            OwnerViewIdColumn.DefaultValue = -1;
            OwnerViewIdColumn.Unique = false;

            DataColumn LevelIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.LevelId.ToString(), typeof(int));
            LevelIdColumn.AllowDBNull = false;
            LevelIdColumn.DefaultValue = -1;
            LevelIdColumn.Unique = false;

            DataColumn IsSolidColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.IsSolid.ToString(), typeof(bool));
            LevelIdColumn.AllowDBNull = false;
            LevelIdColumn.DefaultValue = true;
            LevelIdColumn.Unique = false;

            DataColumn DateCreatedColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            DataColumn CreatedByIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;

            DataColumn ModifiedByIdColumn = tbl.Columns.Add(FamilyGeometriesColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;

            dataSet.Tables.Add(tbl);

            DataRelation geometryDataRelation = new DataRelation(TableRelations.FamilyComponentGeometries_FamilyId__FamilyComponents_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyComponentGeometries.ToString()].Columns[FamilyGeometriesColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(geometryDataRelation);

            DataRelation CreatedByDataRelation = new DataRelation(TableRelations.FamilyComponentGeometries_CreatedById__Users_Id.ToString(),
               dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
               dataSet.Tables[TableNames.FF_FamilyComponentGeometries.ToString()].Columns[FamilyGeometriesColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(CreatedByDataRelation);

            DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyComponentGeometries_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[UsersColumnNames.Id.ToString()],
                dataSet.Tables[TableNames.FF_FamilyComponentGeometries.ToString()].Columns[FamilyGeometriesColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(ModifiedByDataRelation);
        }

        private static void InitilizeFamilyTemplateParametersTable(DataSet dataSet)
        {
            try
            {
                DataTable ParametersTable = new DataTable(TableNames.FF_FamilyTemplateParameters.ToString());

                DataColumn IdColumn = ParametersTable.Columns.Add(ParametersColumnNames.Id.ToString(), typeof(string));
                IdColumn.AllowDBNull = false;
                IdColumn.Unique = true;

                DataColumn FamilyTemplateIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.FamilyId.ToString(), typeof(string));
                FamilyTemplateIdColumn.AllowDBNull = false;
                FamilyTemplateIdColumn.Unique = false;

                DataColumn NameColumn = ParametersTable.Columns.Add(ParametersColumnNames.Name.ToString(), typeof(string));
                NameColumn.AllowDBNull = false;
                NameColumn.Unique = false;

                DataColumn ElementIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.ElementId.ToString(), typeof(int));
                ElementIdColumn.AllowDBNull = false;
                ElementIdColumn.DefaultValue = 0;
                ElementIdColumn.Unique = false;

                DataColumn ElementGUIDColumn = ParametersTable.Columns.Add(ParametersColumnNames.ElementGUID.ToString(), typeof(string));
                ElementGUIDColumn.AllowDBNull = false;
                ElementGUIDColumn.DefaultValue = string.Empty;
                ElementGUIDColumn.Unique = false;

                DataColumn HasValueColumn = ParametersTable.Columns.Add(ParametersColumnNames.HasValue.ToString(), typeof(bool));
                HasValueColumn.AllowDBNull = false;
                HasValueColumn.DefaultValue = false;
                HasValueColumn.Unique = false;

                DataColumn IsReadOnlyColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsReadOnly.ToString(), typeof(bool));
                IsReadOnlyColumn.AllowDBNull = false;
                IsReadOnlyColumn.DefaultValue = false;
                IsReadOnlyColumn.Unique = false;

                DataColumn IsSharedParamColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsShared.ToString(), typeof(bool));
                IsSharedParamColumn.AllowDBNull = false;
                IsSharedParamColumn.DefaultValue = false;
                IsSharedParamColumn.Unique = false;

                DataColumn IsInstanceColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsInstance.ToString(), typeof(bool));
                IsInstanceColumn.AllowDBNull = false;
                IsInstanceColumn.DefaultValue = false;
                IsInstanceColumn.Unique = false;

                DataColumn StorageTypeColumn = ParametersTable.Columns.Add(ParametersColumnNames.StorageType.ToString(), typeof(int));
                StorageTypeColumn.AllowDBNull = false;
                StorageTypeColumn.DefaultValue = 0;
                StorageTypeColumn.Unique = false;

                DataColumn IsEditableColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsEditable.ToString(), typeof(bool));
                IsEditableColumn.AllowDBNull = false;
                IsEditableColumn.Unique = false;

                DataColumn IsActiveColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsActive.ToString(), typeof(bool));
                IsActiveColumn.AllowDBNull = false;
                IsActiveColumn.DefaultValue = false;
                IsActiveColumn.Unique = false;

                DataColumn HostIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.HostId.ToString(), typeof(string));
                HostIdColumn.AllowDBNull = false;
                HostIdColumn.DefaultValue = string.Empty;
                HostIdColumn.Unique = false;

                DataColumn IsReportingColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsReporting.ToString(), typeof(bool));
                IsReportingColumn.AllowDBNull = false;
                IsReportingColumn.DefaultValue = false;
                IsReportingColumn.Unique = false;

                DataColumn BuiltInParamGroupColumn = ParametersTable.Columns.Add(ParametersColumnNames.BuiltInParamGroup.ToString(), typeof(int));
                BuiltInParamGroupColumn.AllowDBNull = false;
                BuiltInParamGroupColumn.DefaultValue = -1;
                BuiltInParamGroupColumn.Unique = false;

                DataColumn ParameterTypeColumn = ParametersTable.Columns.Add(ParametersColumnNames.ParameterType.ToString(), typeof(int));
                ParameterTypeColumn.AllowDBNull = false;
                ParameterTypeColumn.DefaultValue = 1;
                ParameterTypeColumn.Unique = false;

                DataColumn UnitTypeColumn = ParametersTable.Columns.Add(ParametersColumnNames.UnitType.ToString(), typeof(int));
                UnitTypeColumn.AllowDBNull = false;
                UnitTypeColumn.DefaultValue = -1;
                UnitTypeColumn.Unique = false;

                DataColumn DisplayUnitTypeColumn = ParametersTable.Columns.Add(ParametersColumnNames.DisplayUnitType.ToString(), typeof(int));
                DisplayUnitTypeColumn.AllowDBNull = false;
                DisplayUnitTypeColumn.DefaultValue = 2;
                DisplayUnitTypeColumn.Unique = false;

                DataColumn UserModifiableColumn = ParametersTable.Columns.Add(ParametersColumnNames.UserModifiable.ToString(), typeof(bool));
                UserModifiableColumn.AllowDBNull = false;
                UserModifiableColumn.DefaultValue = false;
                UserModifiableColumn.Unique = false;

                DataColumn IsDeterminedByFormulaColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsDeterminedByFormula.ToString(), typeof(bool));
                IsDeterminedByFormulaColumn.AllowDBNull = false;
                IsDeterminedByFormulaColumn.DefaultValue = false;
                IsDeterminedByFormulaColumn.Unique = false;

                DataColumn FormulaColumn = ParametersTable.Columns.Add(ParametersColumnNames.Formula.ToString(), typeof(string));
                FormulaColumn.AllowDBNull = true;
                FormulaColumn.DefaultValue = string.Empty;
                FormulaColumn.Unique = false;

                DataColumn DateCreatedColumn = ParametersTable.Columns.Add(ParametersColumnNames.DateCreated.ToString(), typeof(DateTime));
                DateCreatedColumn.AllowDBNull = false;

                DataColumn DateModifiedColumn = ParametersTable.Columns.Add(ParametersColumnNames.DateModified.ToString(), typeof(DateTime));
                DateModifiedColumn.AllowDBNull = false;

                DataColumn CreatedByIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.CreatedById.ToString(), typeof(string));
                CreatedByIdColumn.AllowDBNull = false;

                DataColumn ModifiedByIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.ModifiedById.ToString(), typeof(string));
                ModifiedByIdColumn.AllowDBNull = false;

                ParametersTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };
                dataSet.Tables.Add(ParametersTable);

                DataRelation parametersDataRelation = new DataRelation(TableRelations.FamilyTemplateParameters_FamilyId__FamilyTemplates_Id.ToString(),
                   dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                   dataSet.Tables[TableNames.FF_FamilyTemplateParameters.ToString()].Columns[ParametersColumnNames.FamilyId.ToString()]);
                dataSet.Relations.Add(parametersDataRelation);

                DataRelation CreatedByDataRelation = new DataRelation(TableRelations.FamilyTemplateParameters_CreatedById__Users_Id.ToString(),
                    dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyTemplateParameters.ToString()].Columns[ParametersColumnNames.CreatedById.ToString()]);
                dataSet.Relations.Add(CreatedByDataRelation);

                DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyTemplateParameters_ModifiedById__Users_Id.ToString(),
                    dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyTemplateParameters.ToString()].Columns[ParametersColumnNames.ModifiedById.ToString()]);
                dataSet.Relations.Add(ModifiedByDataRelation);
            }
            catch (Exception ex)
            {

            }
        }

        private static void InitilizeFamilyComponentsParametersTable(DataSet dataSet)
        {
            DataTable ParametersTable = new DataTable(TableNames.FF_FamilyComponentParameters.ToString());

            DataColumn IdColumn = ParametersTable.Columns.Add(ParametersColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyTemplateIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.FamilyId.ToString(), typeof(string));
            FamilyTemplateIdColumn.AllowDBNull = false;
            FamilyTemplateIdColumn.Unique = false;

            DataColumn NameColumn = ParametersTable.Columns.Add(ParametersColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.Unique = false;

            DataColumn ElementIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.ElementId.ToString(), typeof(int));
            ElementIdColumn.AllowDBNull = false;
            ElementIdColumn.DefaultValue = 0;
            ElementIdColumn.Unique = false;

            DataColumn ElementGUIDColumn = ParametersTable.Columns.Add(ParametersColumnNames.ElementGUID.ToString(), typeof(string));
            ElementGUIDColumn.AllowDBNull = false;
            ElementGUIDColumn.DefaultValue = string.Empty;
            ElementGUIDColumn.Unique = false;

            DataColumn HasValueColumn = ParametersTable.Columns.Add(ParametersColumnNames.HasValue.ToString(), typeof(bool));
            HasValueColumn.AllowDBNull = false;
            HasValueColumn.DefaultValue = false;
            HasValueColumn.Unique = false;

            DataColumn IsReadOnlyColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsReadOnly.ToString(), typeof(bool));
            IsReadOnlyColumn.AllowDBNull = false;
            IsReadOnlyColumn.DefaultValue = false;
            IsReadOnlyColumn.Unique = false;

            DataColumn IsSharedParamColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsShared.ToString(), typeof(bool));
            IsSharedParamColumn.AllowDBNull = false;
            IsSharedParamColumn.DefaultValue = false;
            IsSharedParamColumn.Unique = false;

            DataColumn IsInstanceColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsInstance.ToString(), typeof(bool));
            IsInstanceColumn.AllowDBNull = false;
            IsInstanceColumn.DefaultValue = false;
            IsInstanceColumn.Unique = false;

            DataColumn StorageTypeColumn = ParametersTable.Columns.Add(ParametersColumnNames.StorageType.ToString(), typeof(int));
            StorageTypeColumn.AllowDBNull = false;
            StorageTypeColumn.DefaultValue = 0;
            StorageTypeColumn.Unique = false;

            DataColumn IsEditableColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsEditable.ToString(), typeof(bool));
            IsEditableColumn.AllowDBNull = false;
            IsEditableColumn.Unique = false;

            DataColumn IsActiveColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = false;
            IsActiveColumn.Unique = false;

            DataColumn HostIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.HostId.ToString(), typeof(string));
            HostIdColumn.AllowDBNull = false;
            HostIdColumn.DefaultValue = string.Empty;
            HostIdColumn.Unique = false;

            DataColumn IsReportingColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsReporting.ToString(), typeof(bool));
            IsReportingColumn.AllowDBNull = false;
            IsReportingColumn.DefaultValue = false;
            IsReportingColumn.Unique = false;

            DataColumn BuiltInParamGroupColumn = ParametersTable.Columns.Add(ParametersColumnNames.BuiltInParamGroup.ToString(), typeof(int));
            BuiltInParamGroupColumn.AllowDBNull = false;
            BuiltInParamGroupColumn.DefaultValue = -1;
            BuiltInParamGroupColumn.Unique = false;

            DataColumn ParameterTypeColumn = ParametersTable.Columns.Add(ParametersColumnNames.ParameterType.ToString(), typeof(int));
            ParameterTypeColumn.AllowDBNull = false;
            ParameterTypeColumn.DefaultValue = 1;
            ParameterTypeColumn.Unique = false;

            DataColumn UnitTypeColumn = ParametersTable.Columns.Add(ParametersColumnNames.UnitType.ToString(), typeof(int));
            UnitTypeColumn.AllowDBNull = false;
            UnitTypeColumn.DefaultValue = -1;
            UnitTypeColumn.Unique = false;

            DataColumn DisplayUnitTypeColumn = ParametersTable.Columns.Add(ParametersColumnNames.DisplayUnitType.ToString(), typeof(int));
            DisplayUnitTypeColumn.AllowDBNull = false;
            DisplayUnitTypeColumn.DefaultValue = 2;
            DisplayUnitTypeColumn.Unique = false;

            DataColumn UserModifiableColumn = ParametersTable.Columns.Add(ParametersColumnNames.UserModifiable.ToString(), typeof(bool));
            UserModifiableColumn.AllowDBNull = false;
            UserModifiableColumn.DefaultValue = false;
            UserModifiableColumn.Unique = false;

            DataColumn IsDeterminedByFormulaColumn = ParametersTable.Columns.Add(ParametersColumnNames.IsDeterminedByFormula.ToString(), typeof(bool));
            IsDeterminedByFormulaColumn.AllowDBNull = false;
            IsDeterminedByFormulaColumn.DefaultValue = false;
            IsDeterminedByFormulaColumn.Unique = false;

            DataColumn FormulaColumn = ParametersTable.Columns.Add(ParametersColumnNames.Formula.ToString(), typeof(string));
            FormulaColumn.AllowDBNull = true;
            FormulaColumn.DefaultValue = string.Empty;
            FormulaColumn.Unique = false;

            DataColumn DateCreatedColumn = ParametersTable.Columns.Add(ParametersColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = ParametersTable.Columns.Add(ParametersColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            DataColumn CreatedByIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;

            DataColumn ModifiedByIdColumn = ParametersTable.Columns.Add(ParametersColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;

            ParametersTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };
            dataSet.Tables.Add(ParametersTable);

            DataRelation parametersDataRelation = new DataRelation(TableRelations.FamilyComponentParameters_FamilyId__FamilyComponents_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyComponentParameters.ToString()].Columns[ParametersColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(parametersDataRelation);

            DataRelation CreatedByDataRelation = new DataRelation(TableRelations.FamilyComponentParameters_CreatedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyComponentParameters.ToString()].Columns[ParametersColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(CreatedByDataRelation);
            DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyComponentParameters_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyComponentParameters.ToString()].Columns[ParametersColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(ModifiedByDataRelation);
        }

        private static void InitilizeFamilyTemplateComponentsTable(DataSet dataSet)
        {
            DataTable FamilyTemplateComponentsTable = new DataTable(TableNames.FF_FamilyTemplateComponents.ToString());

            DataColumn IdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyIdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.FamilyId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = false;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Template Component";
            NameColumn.Unique = false;

            DataColumn DescriptionColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = false;
            DescriptionColumn.Unique = false;

            DataColumn XRefferencePlaneIdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.XReferencePlaneId.ToString(), typeof(string));
            XRefferencePlaneIdColumn.AllowDBNull = true;
            XRefferencePlaneIdColumn.Unique = false;

            DataColumn YRefferencePlaneIdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.YReferencePlaneId.ToString(), typeof(string));
            YRefferencePlaneIdColumn.AllowDBNull = true;
            YRefferencePlaneIdColumn.Unique = false;

            DataColumn ZRefferencePlaneIdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.ZReferencePlaneId.ToString(), typeof(string));
            ZRefferencePlaneIdColumn.AllowDBNull = true;
            ZRefferencePlaneIdColumn.Unique = false;

            DataColumn DateCreatedColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            DataColumn CreatedByIdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;

            DataColumn ModifiedByIdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;

            DataColumn IsProfileColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.IsProfile.ToString(), typeof(bool));
            IsProfileColumn.AllowDBNull = false;
            IsProfileColumn.DefaultValue = false;

            DataColumn ProfileGeometryIdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.ProfileGeometryId.ToString(), typeof(string));
            ProfileGeometryIdColumn.AllowDBNull = true;

            DataColumn ProfileTypeNameIdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.ProfileTypeNameId.ToString(), typeof(string));
            ProfileTypeNameIdColumn.AllowDBNull = true;

            DataColumn ProfileHorizontalOffsetColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.ProfileHorizontalOffset.ToString(), typeof(decimal));
            ProfileHorizontalOffsetColumn.AllowDBNull = true;

            DataColumn ProfileVerticalOffsetColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.ProfileVerticalOffset.ToString(), typeof(decimal));
            ProfileVerticalOffsetColumn.AllowDBNull = true;

            DataColumn ProfileAngleColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.ProfileAngle.ToString(), typeof(decimal));
            ProfileAngleColumn.AllowDBNull = true;

            DataColumn ProfileIsFlippedColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.ProfileIsFlipped.ToString(), typeof(bool));
            ProfileIsFlippedColumn.AllowDBNull = true;

            DataColumn FamilyComponentTypeIdColumn = FamilyTemplateComponentsTable.Columns.Add(TemplateComponentsColumnNames.FamilyComponentTypeId.ToString(), typeof(string));
            FamilyComponentTypeIdColumn.AllowDBNull = false;

            FamilyTemplateComponentsTable.PrimaryKey = new DataColumn[] { IdColumn };
            dataSet.Tables.Add(FamilyTemplateComponentsTable);

            DataRelation TemplateIdDataRelation = new DataRelation(TableRelations.FamilyTemplateComponents_FamilyId__FamilyTemplate_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[TemplateComponentsColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(TemplateIdDataRelation);

            DataRelation ReferencePlaneIdXDataRelation = new DataRelation(TableRelations.FamilyTemplateComponents_XReferencePlaneId__FamilyTemplateReferencePlanes_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[TemplateComponentsColumnNames.XReferencePlaneId.ToString()]);
            dataSet.Relations.Add(ReferencePlaneIdXDataRelation);

            DataRelation ReferencePlaneIdYDataRelation = new DataRelation(TableRelations.FamilyTemplateComponents_YReferencePlaneId__FamilyTemplateReferencePlanes_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[TemplateComponentsColumnNames.YReferencePlaneId.ToString()]);
            dataSet.Relations.Add(ReferencePlaneIdYDataRelation);

            DataRelation ReferencePlaneIdZDataRelation = new DataRelation(TableRelations.FamilyTemplateComponents_ZReferencePlaneId__FamilyTemplateReferencePlanes_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[TemplateComponentsColumnNames.ZReferencePlaneId.ToString()]);
            dataSet.Relations.Add(ReferencePlaneIdZDataRelation);

            DataRelation CreatedByDataRelation = new DataRelation(TableRelations.FamilyTemplateComponents_CreatedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[TemplateComponentsColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(CreatedByDataRelation);

            DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyTemplateComponents_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[TemplateComponentsColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(ModifiedByDataRelation);

            DataRelation ProfileGeometryRelation = new DataRelation(TableRelations.FamilyTemplateComponents_ProfileGeometryId__FamilyTemplateGeometries_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateGeometries.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[TemplateComponentsColumnNames.ProfileGeometryId.ToString()]);
            dataSet.Relations.Add(ProfileGeometryRelation);

            DataRelation ComponentTypeRelation = new DataRelation(TableRelations.FamilyTemplateComponents_FamilyComponentTypeId__FamilyComponentTypes_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponentTypes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[TemplateComponentsColumnNames.FamilyComponentTypeId.ToString()]);
            dataSet.Relations.Add(ComponentTypeRelation);
        }

        private static void InitilizeFamilyBuildsTable(DataSet dataSet)
        {
            DataTable FamilyBuildsTable = new DataTable(TableNames.FF_FamilyBuilds.ToString());

            DataColumn IdColumn = FamilyBuildsTable.Columns.Add(FamilyBuildsColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyIdColumn = FamilyBuildsTable.Columns.Add(FamilyBuildsColumnNames.FamilyTemplateId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = true;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = FamilyBuildsTable.Columns.Add(FamilyBuildsColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.Unique = false;

            DataColumn DescriptionColumn = FamilyBuildsTable.Columns.Add(FamilyBuildsColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = true;
            DescriptionColumn.Unique = false;

            DataColumn DateCreatedColumn = FamilyBuildsTable.Columns.Add(FamilyBuildsColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = FamilyBuildsTable.Columns.Add(FamilyBuildsColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            DataColumn CreatedByIdColumn = FamilyBuildsTable.Columns.Add(FamilyBuildsColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;

            DataColumn ModifiedByIdColumn = FamilyBuildsTable.Columns.Add(FamilyBuildsColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;

            DataColumn stateColumn = FamilyBuildsTable.Columns.Add(FamilyBuildsColumnNames.State.ToString(), typeof(EntityStates));
            stateColumn.AllowDBNull = false;
            stateColumn.DefaultValue = EntityStates.Enabled;

            FamilyBuildsTable.PrimaryKey = new DataColumn[] { IdColumn };
            dataSet.Tables.Add(FamilyBuildsTable);

            DataRelation TemplateIdDataRelation = new DataRelation(TableRelations.FamilyBuilds_FamilyTemplateId__FamilyTemplates_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuilds.ToString()].Columns[FamilyBuildsColumnNames.FamilyTemplateId.ToString()]);
            dataSet.Relations.Add(TemplateIdDataRelation);

            DataRelation CreatedByDataRelation = new DataRelation(TableRelations.FamilyBuilds_CreatedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuilds.ToString()].Columns[FamilyBuildsColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(CreatedByDataRelation);

            DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyBuilds_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuilds.ToString()].Columns[FamilyBuildsColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(ModifiedByDataRelation);
        }

        private static void InitilizeFamilyBuildComponentsTable(DataSet dataSet)
        {
            DataTable FamilyBuildComponentsTable = new DataTable(TableNames.FF_FamilyBuildComponents.ToString());

            DataColumn IdColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponentsColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyBuildIdColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponentsColumnNames.FamilyBuildId.ToString(), typeof(string));
            FamilyBuildIdColumn.AllowDBNull = false;
            FamilyBuildIdColumn.Unique = false;

            DataColumn FamilyComponentIdColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponentsColumnNames.FamilyComponentId.ToString(), typeof(string));
            FamilyComponentIdColumn.AllowDBNull = false;
            FamilyComponentIdColumn.Unique = false;

            DataColumn DateCreatedColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponentsColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponentsColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            DataColumn CreatedByIdColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponentsColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;

            DataColumn ModifiedByIdColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponentsColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;

            FamilyBuildComponentsTable.PrimaryKey = new DataColumn[] { IdColumn };
            dataSet.Tables.Add(FamilyBuildComponentsTable);

            DataRelation FamilyBuildDataRelation = new DataRelation(TableRelations.FamilyBuildComponents_FamilyBuildId__FamilyBuilds_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyBuilds.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponents.ToString()].Columns[FamilyBuildComponentsColumnNames.FamilyBuildId.ToString()]);
            dataSet.Relations.Add(FamilyBuildDataRelation);

            DataRelation FamilyBuildComponentsDataRelation = new DataRelation(TableRelations.FamilyBuildComponents_FamilyComponentId__FamilyComponents_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponents.ToString()].Columns[FamilyBuildComponentsColumnNames.FamilyBuildId.ToString()]);
            dataSet.Relations.Add(FamilyBuildComponentsDataRelation);

            DataRelation createdDataRelation = new DataRelation(TableRelations.FamilyBuildComponents_CreatedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponents.ToString()].Columns[FamilyBuildComponentsColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(createdDataRelation);

            DataRelation modifiedDataRelation = new DataRelation(TableRelations.FamilyBuildComponents_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponents.ToString()].Columns[FamilyBuildComponentsColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(modifiedDataRelation);
        }

        private static void InitilizeFamilyBuildComponentPositionsTable(DataSet dataSet)
        {
            DataTable buildPositions = new DataTable(TableNames.FF_FamilyBuildComponentPositions.ToString());

            DataColumn IdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyBuildComponentIdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.FamilyBuildComponentId.ToString(), typeof(string));
            FamilyBuildComponentIdColumn.AllowDBNull = false;
            FamilyBuildComponentIdColumn.Unique = false;

            DataColumn TemplateReferencePlaneXIdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.TemplateReferencePlaneXId.ToString(), typeof(string));
            TemplateReferencePlaneXIdColumn.AllowDBNull = false;
            TemplateReferencePlaneXIdColumn.Unique = false;

            DataColumn TemplateReferencePlaneYIdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.TemplateReferencePlaneYId.ToString(), typeof(string));
            TemplateReferencePlaneYIdColumn.AllowDBNull = false;
            TemplateReferencePlaneYIdColumn.Unique = false;

            DataColumn TemplateReferencePlaneZIdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.TemplateReferencePlaneZId.ToString(), typeof(string));
            TemplateReferencePlaneZIdColumn.AllowDBNull = false;
            TemplateReferencePlaneZIdColumn.Unique = false;

            DataColumn ComponentRefernecePLaneXIdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.ComponentRefernecePlaneXId.ToString(), typeof(string));
            ComponentRefernecePLaneXIdColumn.AllowDBNull = false;
            ComponentRefernecePLaneXIdColumn.Unique = false;

            DataColumn ComponentRefernecePLaneYIdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.ComponentRefernecePlaneYId.ToString(), typeof(string));
            ComponentRefernecePLaneYIdColumn.AllowDBNull = false;
            ComponentRefernecePLaneYIdColumn.Unique = false;

            DataColumn ComponentRefernecePLaneZIdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.ComponentRefernecePlaneZId.ToString(), typeof(string));
            ComponentRefernecePLaneZIdColumn.AllowDBNull = false;
            ComponentRefernecePLaneZIdColumn.Unique = false;

            DataColumn XOffsetColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.XOffset.ToString(), typeof(double));
            XOffsetColumn.AllowDBNull = false;
            XOffsetColumn.Unique = false;
            XOffsetColumn.DefaultValue = 0;

            DataColumn YOffsetColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.YOffset.ToString(), typeof(double));
            YOffsetColumn.AllowDBNull = false;
            YOffsetColumn.Unique = false;
            YOffsetColumn.DefaultValue = 0;

            DataColumn ZOffsetColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.ZOffset.ToString(), typeof(double));
            ZOffsetColumn.AllowDBNull = false;
            ZOffsetColumn.Unique = false;
            ZOffsetColumn.DefaultValue = 0;

            DataColumn XRotateColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.XRotate.ToString(), typeof(double));
            XRotateColumn.AllowDBNull = false;
            XRotateColumn.Unique = false;
            XRotateColumn.DefaultValue = 0;

            DataColumn YRotateColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.YRotate.ToString(), typeof(double));
            YRotateColumn.AllowDBNull = false;
            YRotateColumn.Unique = false;
            YRotateColumn.DefaultValue = 0;

            DataColumn ZRotateColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.ZRotate.ToString(), typeof(double));
            ZRotateColumn.AllowDBNull = false;
            ZRotateColumn.Unique = false;
            ZRotateColumn.DefaultValue = 0;

            DataColumn DateCreatedColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;

            DataColumn DateModifiedColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;

            DataColumn CreatedByIdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.CreatedById.ToString(), typeof(string));
            CreatedByIdColumn.AllowDBNull = false;

            DataColumn ModifiedByIdColumn = buildPositions.Columns.Add(FamilyBuildComponentPostionsColumnNames.ModifiedById.ToString(), typeof(string));
            ModifiedByIdColumn.AllowDBNull = false;

            buildPositions.PrimaryKey = new DataColumn[] { IdColumn };
            dataSet.Tables.Add(buildPositions);

            DataRelation FamilyBuildComponentDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositions_FamilyBuildComponentId_FamilyBuildComponents_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyBuildComponents.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPostionsColumnNames.FamilyBuildComponentId.ToString()]);
            dataSet.Relations.Add(FamilyBuildComponentDataRelation);

            DataRelation TemplateReferencePlaneXIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositions_TemplateReferencePlaneXId__FamilyTemplateReferencePlanes_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPostionsColumnNames.TemplateReferencePlaneXId.ToString()]);
            dataSet.Relations.Add(TemplateReferencePlaneXIdDataRelation);

            DataRelation TemplateReferencePlaneYIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositions_TemplateReferencePlaneYId__FamilyTemplateReferencePlanes_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPostionsColumnNames.TemplateReferencePlaneYId.ToString()]);
            dataSet.Relations.Add(TemplateReferencePlaneYIdDataRelation);

            DataRelation TemplateReferencePlaneZIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositions_TemplateReferencePlaneZId__FamilyTemplateReferencePlanes_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPostionsColumnNames.TemplateReferencePlaneZId.ToString()]);
            dataSet.Relations.Add(TemplateReferencePlaneZIdDataRelation);

            DataRelation ComponentRefernecePlaneXIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositions_ComponentReferencePlaneXId__FamilyComponents_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPostionsColumnNames.ComponentRefernecePlaneXId.ToString()]);
            dataSet.Relations.Add(ComponentRefernecePlaneXIdDataRelation);

            DataRelation ComponentRefernecePlaneYIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositions_ComponentReferencePlaneYId__FamilyComponents_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPostionsColumnNames.ComponentRefernecePlaneYId.ToString()]);
            dataSet.Relations.Add(ComponentRefernecePlaneYIdDataRelation);

            DataRelation ComponentRefernecePlaneZIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositions_ComponentReferencePlaneZId__FamilyComponents_Id.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPostionsColumnNames.ComponentRefernecePlaneZId.ToString()]);
            dataSet.Relations.Add(ComponentRefernecePlaneZIdDataRelation);

            DataRelation CreatedByDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositions_CreatedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPostionsColumnNames.CreatedById.ToString()]);
            dataSet.Relations.Add(CreatedByDataRelation);

            DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositions_ModifiedById__Users_Id.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPostionsColumnNames.ModifiedById.ToString()]);
            dataSet.Relations.Add(ModifiedByDataRelation);
        }

        private static void InitilizeFamilyComponentCategoriesTable(DataSet dataSet)
        {
            try
            {
                DataTable FamilyComponentCategoriesTable = new DataTable(TableNames.FF_FamilyComponentCategories.ToString());

                DataColumn IdColumn = FamilyComponentCategoriesTable.Columns.Add(FamilyComponentsCategoryColumnNames.Id.ToString(), typeof(string));
                IdColumn.AllowDBNull = false;
                IdColumn.Unique = true;

                DataColumn nameColumn = FamilyComponentCategoriesTable.Columns.Add(FamilyComponentsCategoryColumnNames.Name.ToString(), typeof(string));
                nameColumn.AllowDBNull = false;
                nameColumn.Unique = false;

                DataColumn DescriptionColumn = FamilyComponentCategoriesTable.Columns.Add(FamilyComponentsCategoryColumnNames.Description.ToString(), typeof(string));
                DescriptionColumn.AllowDBNull = true;

                DataColumn ThumbnailColumn = FamilyComponentCategoriesTable.Columns.Add(FamilyComponentsCategoryColumnNames.Thumbnail.ToString(), typeof(byte[]));
                ThumbnailColumn.AllowDBNull = true;

                DataColumn DateCreatedColumn = FamilyComponentCategoriesTable.Columns.Add(FamilyComponentsCategoryColumnNames.DateCreated.ToString(), typeof(DateTime));
                DateCreatedColumn.AllowDBNull = false;

                DataColumn DateModififedColumn = FamilyComponentCategoriesTable.Columns.Add(FamilyComponentsCategoryColumnNames.DateModified.ToString(), typeof(DateTime));
                DateModififedColumn.AllowDBNull = false;

                DataColumn CreatedByIdColumn = FamilyComponentCategoriesTable.Columns.Add(FamilyComponentsCategoryColumnNames.CreatedById.ToString(), typeof(string));
                CreatedByIdColumn.AllowDBNull = false;

                DataColumn ModifiedByIdColumn = FamilyComponentCategoriesTable.Columns.Add(FamilyComponentsCategoryColumnNames.ModifiedById.ToString(), typeof(string));
                ModifiedByIdColumn.AllowDBNull = false;

                DataColumn ParentIdColumn = FamilyComponentCategoriesTable.Columns.Add(FamilyComponentsCategoryColumnNames.ParentId.ToString(), typeof(string));
                ParentIdColumn.AllowDBNull = true;

                FamilyComponentCategoriesTable.PrimaryKey = new DataColumn[] { IdColumn };
                dataSet.Tables.Add(FamilyComponentCategoriesTable);

                DataRelation CreatedByDataRelation = new DataRelation(TableRelations.FamilyComponentCategories_CreatedById__Users_Id.ToString(),
                    dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyComponentCategories.ToString()].Columns[FamilyBuildComponentsColumnNames.CreatedById.ToString()]);
                dataSet.Relations.Add(CreatedByDataRelation);

                DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyComponentCategories_ModifiedById__Users_Id.ToString(),
                    dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyComponentCategories.ToString()].Columns[FamilyBuildComponentsColumnNames.ModifiedById.ToString()]);
                dataSet.Relations.Add(ModifiedByDataRelation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            
        }

        private static void InitilizeFamilyComponentSearchTermsTable(DataSet dataSet)
        {
            try
            {
                DataTable FamilyComponentSearchTermsTable = new DataTable(TableNames.FF_FamilyComponentSearchTerms.ToString());

                DataColumn IdColumn = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponentsSearchTermColumnNames.Id.ToString(), typeof(string));
                IdColumn.AllowDBNull = false;
                IdColumn.Unique = true;

                DataColumn nameColumn = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponentsSearchTermColumnNames.Name.ToString(), typeof(string));
                nameColumn.AllowDBNull = false;
                nameColumn.Unique = false;

                DataColumn DescriptionColumn = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponentsSearchTermColumnNames.Description.ToString(), typeof(string));
                DescriptionColumn.AllowDBNull = true;

                DataColumn DateCreatedColumn = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponentsSearchTermColumnNames.DateCreated.ToString(), typeof(DateTime));
                DateCreatedColumn.AllowDBNull = false;

                DataColumn DateModififedColumn = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponentsSearchTermColumnNames.DateModified.ToString(), typeof(DateTime));
                DateModififedColumn.AllowDBNull = false;

                DataColumn CreatedByIdColumn = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponentsSearchTermColumnNames.CreatedById.ToString(), typeof(string));
                CreatedByIdColumn.AllowDBNull = false;

                DataColumn ModifiedByIdColumn = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponentsSearchTermColumnNames.ModifiedById.ToString(), typeof(string));
                ModifiedByIdColumn.AllowDBNull = false;

                FamilyComponentSearchTermsTable.PrimaryKey = new DataColumn[] { IdColumn };
                dataSet.Tables.Add(FamilyComponentSearchTermsTable);

                DataRelation CreatedByDataRelation = new DataRelation(TableRelations.FamilyComponentSearchTerms_CreatedById__Users_Id.ToString(),
                    dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyComponentSearchTerms.ToString()].Columns[FamilyComponentsSearchTermColumnNames.CreatedById.ToString()]);
                dataSet.Relations.Add(CreatedByDataRelation);

                DataRelation ModifiedByDataRelation = new DataRelation(TableRelations.FamilyComponentSearchTerms_ModifiedById__Users_Id.ToString(),
                    dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyComponentSearchTerms.ToString()].Columns[FamilyComponentsSearchTermColumnNames.ModifiedById.ToString()]);
                dataSet.Relations.Add(ModifiedByDataRelation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private static void InitilizeFamilyComponents_FamilyComponentCategoriesTable(DataSet dataSet)
        {
            try
            {
                DataTable FamilyComponentSearchCategoriesSearchTermsTable = new DataTable(TableNames.FF_FamilyComponents_FamilyComponentCategories.ToString());

                DataColumn IdColumn = FamilyComponentSearchCategoriesSearchTermsTable.Columns.Add(FamilyComponents_FamilyComponentCategoryColumnNames.Id.ToString(), typeof(string));
                IdColumn.AllowDBNull = false;
                IdColumn.Unique = false;

                DataColumn FamilyComponentIdColumn = FamilyComponentSearchCategoriesSearchTermsTable.Columns.Add(FamilyComponents_FamilyComponentCategoryColumnNames.FamilyComponentId.ToString(), typeof(string));
                FamilyComponentIdColumn.AllowDBNull = false;
                FamilyComponentIdColumn.Unique = false;

                DataColumn FamilyComponentCategoryId = FamilyComponentSearchCategoriesSearchTermsTable.Columns.Add(FamilyComponents_FamilyComponentCategoryColumnNames.FamilyComponentCategoryId.ToString(), typeof(string));
                FamilyComponentCategoryId.AllowDBNull = true;

                FamilyComponentSearchCategoriesSearchTermsTable.PrimaryKey = new DataColumn[] { IdColumn };
                dataSet.Tables.Add(FamilyComponentSearchCategoriesSearchTermsTable);

                DataRelation ComponetnCategoriesRelation = new DataRelation(TableRelations.FamilyComponents_FamilyComponentCategories_FamilyComponentCategoryId__FamilyComponentCateroies_Id.ToString(),
                    dataSet.Tables[TableNames.FF_FamilyComponentCategories.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyComponents_FamilyComponentCategories.ToString()].Columns[FamilyComponents_FamilyComponentCategoryColumnNames.FamilyComponentCategoryId.ToString()]);
                dataSet.Relations.Add(ComponetnCategoriesRelation);

                DataRelation ComponentSearchtermRelation = new DataRelation(TableRelations.FamilyComponents_FamilyComponentCategories_FamilyComponentId__FamilyComponents_Id.ToString(),
                    dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyComponents_FamilyComponentCategories.ToString()].Columns[FamilyComponents_FamilyComponentCategoryColumnNames.FamilyComponentId.ToString()]);
                dataSet.Relations.Add(ComponentSearchtermRelation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private static void InitilizeFamilyComponents_FamilyComponentSerchTermsTable(DataSet dataSet)
        {
            try
            {
                DataTable FamilyComponentSearchTermsTable = new DataTable(TableNames.FF_FamilyComponents_FamilyComponentSerchTerms.ToString());

                DataColumn IdColumn = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponents_FamilyComponentCategoryColumnNames.Id.ToString(), typeof(string));
                IdColumn.AllowDBNull = false;
                IdColumn.Unique = false;

                DataColumn FamilyComponentIdColumn = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponents_FamilyComponentSerchTermsColumnNames.FamilyComponentId.ToString(), typeof(string));
                FamilyComponentIdColumn.AllowDBNull = false;
                FamilyComponentIdColumn.Unique = false;

                DataColumn FamilyComponentCategoryId = FamilyComponentSearchTermsTable.Columns.Add(FamilyComponents_FamilyComponentSerchTermsColumnNames.FamilyComponentSearchTermId.ToString(), typeof(string));
                FamilyComponentCategoryId.AllowDBNull = true;

                FamilyComponentSearchTermsTable.PrimaryKey = new DataColumn[] { IdColumn };
                dataSet.Tables.Add(FamilyComponentSearchTermsTable);

                DataRelation ComponetnCategoriesRelation = new DataRelation(TableRelations.FamilyComponents_FamilyComponentSerchTerms_FamilyComponentId__FamilyComponents_Id.ToString(),
                    dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyComponents_FamilyComponentSerchTerms.ToString()].Columns[FamilyComponents_FamilyComponentSerchTermsColumnNames.FamilyComponentId.ToString()]);
                dataSet.Relations.Add(ComponetnCategoriesRelation);

                DataRelation ComponentSearchtermRelation = new DataRelation(TableRelations.FamilyComponents_FamilyComponentSerchTerms_FamilyComponentSearchTermId__FamilyComponentSearchTerms_Id.ToString(),
                    dataSet.Tables[TableNames.FF_FamilyComponentSearchTerms.ToString()].Columns["Id"],
                    dataSet.Tables[TableNames.FF_FamilyComponents_FamilyComponentSerchTerms.ToString()].Columns[FamilyComponents_FamilyComponentSerchTermsColumnNames.FamilyComponentSearchTermId.ToString()]);
                dataSet.Relations.Add(ComponentSearchtermRelation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static void InstallRequierments(System.Data.SQLite.SQLiteConnection connection, DataSet dataSet)
        {
            //Admin Level
            DataTable permissionsTable = dataSet.Tables[TableNames.FF_Permissions.ToString()];
            DataRow adminPermissionDatarow = permissionsTable.NewRow();
            adminPermissionDatarow[PermissionsColumnNames.Id.ToString()] = Guid.NewGuid();
            adminPermissionDatarow[PermissionsColumnNames.Name.ToString()] = "Admin";
            adminPermissionDatarow[PermissionsColumnNames.Description.ToString()] = "Admin permissions with full permissions.";
            adminPermissionDatarow[PermissionsColumnNames.CanCreate.ToString()] = true;
            adminPermissionDatarow[PermissionsColumnNames.CanRead.ToString()] = true;
            adminPermissionDatarow[PermissionsColumnNames.CanWrite.ToString()] = true;
            adminPermissionDatarow[PermissionsColumnNames.CanDelete.ToString()] = true;
            adminPermissionDatarow[PermissionsColumnNames.Special.ToString()] = true;
            permissionsTable.Rows.Add(adminPermissionDatarow);

            //Viewer Level
            DataRow viewPermissionDatarow = permissionsTable.NewRow();
            viewPermissionDatarow[PermissionsColumnNames.Id.ToString()] = Guid.NewGuid();
            viewPermissionDatarow[PermissionsColumnNames.Name.ToString()] = "Viewer";
            viewPermissionDatarow[PermissionsColumnNames.Description.ToString()] = "Admin permissions with full permissions.";
            viewPermissionDatarow[PermissionsColumnNames.CanCreate.ToString()] = false;
            viewPermissionDatarow[PermissionsColumnNames.CanRead.ToString()] = true;
            viewPermissionDatarow[PermissionsColumnNames.CanWrite.ToString()] = false;
            viewPermissionDatarow[PermissionsColumnNames.CanDelete.ToString()] = false;
            viewPermissionDatarow[PermissionsColumnNames.Special.ToString()] = false;
            permissionsTable.Rows.Add(viewPermissionDatarow);

            //Editor Level
            DataRow userPermissionDatarow = permissionsTable.NewRow();
            userPermissionDatarow[PermissionsColumnNames.Id.ToString()] = Guid.NewGuid();
            userPermissionDatarow[PermissionsColumnNames.Name.ToString()] = "Editor";
            userPermissionDatarow[PermissionsColumnNames.Description.ToString()] = "Admin permissions with full permissions.";
            userPermissionDatarow[PermissionsColumnNames.CanCreate.ToString()] = true;
            userPermissionDatarow[PermissionsColumnNames.CanRead.ToString()] = true;
            userPermissionDatarow[PermissionsColumnNames.CanWrite.ToString()] = true;
            userPermissionDatarow[PermissionsColumnNames.CanDelete.ToString()] = true;
            userPermissionDatarow[PermissionsColumnNames.Special.ToString()] = false;
            permissionsTable.Rows.Add(userPermissionDatarow);

            //Users
            DataTable usersTable = dataSet.Tables[TableNames.FF_Users.ToString()];
            DataRow adminUserDataRow = usersTable.NewRow();
            adminUserDataRow[UsersColumnNames.Id.ToString()] = Guid.NewGuid();
            adminUserDataRow[UsersColumnNames.Name.ToString()] = "Admin";
            adminUserDataRow[UsersColumnNames.FirstName.ToString()] = "Admin";
            adminUserDataRow[UsersColumnNames.LastName.ToString()] = "";
            adminUserDataRow[UsersColumnNames.Email.ToString()] = "Admin@Comapny.com";
            adminUserDataRow[UsersColumnNames.ProfilePic.ToString()] = Utils.ImageToByte(Resources.UserIcon);
            adminUserDataRow[UsersColumnNames.PermissionId.ToString()] = dataSet.Tables[TableNames.FF_Permissions.ToString()].Select("Name = 'Editor'").FirstOrDefault()["Id"];
            adminUserDataRow[UsersColumnNames.LogInDate.ToString()] = DateTime.Now;
            adminUserDataRow[UsersColumnNames.State.ToString()] = EntityStates.Enabled;
            adminUserDataRow[UsersColumnNames.TempFolder.ToString()] = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FamFactory\\Temp";
            adminUserDataRow[UsersColumnNames.DateCreated.ToString()] = DateTime.Now;
            adminUserDataRow[UsersColumnNames.DateModified.ToString()] = DateTime.Now;
            adminUserDataRow[UsersColumnNames.State.ToString()] = EntityStates.Enabled;

            string hash = "";
            string salt = "";
            Utils.GenerateSaltedHash("Password", out hash, out salt);
            adminUserDataRow[UsersColumnNames.Salt.ToString()] = salt;
            adminUserDataRow[UsersColumnNames.Password.ToString()] = hash;
            usersTable.Rows.Add(adminUserDataRow);

            // System Configuration
            DataTable SysConfigTable = dataSet.Tables[TableNames.FF_SystemConfigurations.ToString()];
            DataRow SystemConfigDataRow = SysConfigTable.NewRow();
            SystemConfigDataRow[SystemConfigurationColumnNames.Id.ToString()] = Guid.NewGuid();
            SystemConfigDataRow[SystemConfigurationColumnNames.Name.ToString()] = "<DefaultCompany>";
            SystemConfigDataRow[SystemConfigurationColumnNames.CompanyAddress.ToString()] = string.Empty;
            SystemConfigDataRow[SystemConfigurationColumnNames.Email.ToString()] = "admin@company.com";
            SystemConfigDataRow[SystemConfigurationColumnNames.InstallLocation.ToString()] = "C:\\programfiles\\FamFactory";
            SystemConfigDataRow[SystemConfigurationColumnNames.AppVersion.ToString()] = "v.1.0.0";
            SystemConfigDataRow[SystemConfigurationColumnNames.DataBaseVersion.ToString()] = "v.1.0.0";
            SystemConfigDataRow[SystemConfigurationColumnNames.DateCreated.ToString()] = DateTime.Now;
            SystemConfigDataRow[SystemConfigurationColumnNames.DateModified.ToString()] = DateTime.Now;
            SystemConfigDataRow[SystemConfigurationColumnNames.State.ToString()] = EntityStates.Enabled;
            SystemConfigDataRow[SystemConfigurationColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            SystemConfigDataRow[SystemConfigurationColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            SysConfigTable.Rows.Add(SystemConfigDataRow);

            //Email Profile
            DataTable EmailprofilesTable = dataSet.Tables[TableNames.FF_EmailProfiles.ToString()];
            DataRow EmailProfileDatarow = EmailprofilesTable.NewRow();
            EmailProfileDatarow[EmailProfilesColumnNames.Id.ToString()] = Guid.NewGuid();
            EmailProfileDatarow[EmailProfilesColumnNames.Name.ToString()] = "Admin";
            EmailProfileDatarow[EmailProfilesColumnNames.Description.ToString()] = "Admin permissions with full permissions.";
            EmailProfileDatarow[EmailProfilesColumnNames.ServerAddress.ToString()] = "mail.server.com";
            EmailProfileDatarow[EmailProfilesColumnNames.Port.ToString()] = 25;
            EmailProfileDatarow[EmailProfilesColumnNames.SSL.ToString()] = false;
            EmailProfileDatarow[EmailProfilesColumnNames.Username.ToString()] = "";
            EmailProfileDatarow[EmailProfilesColumnNames.Password.ToString()] = "";
            EmailProfileDatarow[EmailProfilesColumnNames.DateCreated.ToString()] = DateTime.Now;
            EmailProfileDatarow[EmailProfilesColumnNames.DateModified.ToString()] = DateTime.Now;
            EmailProfileDatarow[EmailProfilesColumnNames.State.ToString()] = EntityStates.Enabled;
            EmailProfileDatarow[EmailProfilesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            EmailProfileDatarow[EmailProfilesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            EmailprofilesTable.Rows.Add(EmailProfileDatarow);

            //FamilyComponentTypes
            // Handles
            DataTable FamilyComponentTypesTable = dataSet.Tables[TableNames.FF_FamilyComponentTypes.ToString()];
            DataRow FamilyComponentTypeDatarow = FamilyComponentTypesTable.NewRow();
            FamilyComponentTypeDatarow[FamilyComponentTypesColumnNames.Id.ToString()] = Guid.NewGuid();
            FamilyComponentTypeDatarow[FamilyComponentTypesColumnNames.Name.ToString()] = "Handle";
            FamilyComponentTypeDatarow[FamilyComponentTypesColumnNames.Description.ToString()] = "Describes all 'Handle' component types.";
            FamilyComponentTypeDatarow[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.FamilyComponentIcon64);
            FamilyComponentTypeDatarow[FamilyComponentTypesColumnNames.DateCreated.ToString()] = DateTime.Now;
            FamilyComponentTypeDatarow[FamilyComponentTypesColumnNames.DateModified.ToString()] = DateTime.Now;
            FamilyComponentTypeDatarow[FamilyComponentTypesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypeDatarow[FamilyComponentTypesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypesTable.Rows.Add(FamilyComponentTypeDatarow);

            // Profiles
            DataRow DoorProfileDatarow = FamilyComponentTypesTable.NewRow();
            DoorProfileDatarow[FamilyComponentTypesColumnNames.Id.ToString()] = Guid.NewGuid();
            DoorProfileDatarow[FamilyComponentTypesColumnNames.Name.ToString()] = "Profile";
            DoorProfileDatarow[FamilyComponentTypesColumnNames.Description.ToString()] = "Describes all 'Profile' component types.";
            DoorProfileDatarow[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.FamilyComponentIcon64);
            DoorProfileDatarow[FamilyComponentTypesColumnNames.DateCreated.ToString()] = DateTime.Now;
            DoorProfileDatarow[FamilyComponentTypesColumnNames.DateModified.ToString()] = DateTime.Now;
            DoorProfileDatarow[FamilyComponentTypesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            DoorProfileDatarow[FamilyComponentTypesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypesTable.Rows.Add(DoorProfileDatarow);

            // Door Leaf
            DataRow DoorLeafDatarow = FamilyComponentTypesTable.NewRow();
            DoorLeafDatarow[FamilyComponentTypesColumnNames.Id.ToString()] = Guid.NewGuid();
            DoorLeafDatarow[FamilyComponentTypesColumnNames.Name.ToString()] = "Door Leaf";
            DoorLeafDatarow[FamilyComponentTypesColumnNames.Description.ToString()] = "Describes all 'Door Leaf or Panel' component types.";
            DoorLeafDatarow[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.FamilyComponentIcon64);
            DoorLeafDatarow[FamilyComponentTypesColumnNames.DateCreated.ToString()] = DateTime.Now;
            DoorLeafDatarow[FamilyComponentTypesColumnNames.DateModified.ToString()] = DateTime.Now;
            DoorLeafDatarow[FamilyComponentTypesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            DoorLeafDatarow[FamilyComponentTypesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypesTable.Rows.Add(DoorLeafDatarow);

            // Hinge
            DataRow hingeDatarow = FamilyComponentTypesTable.NewRow();
            hingeDatarow[FamilyComponentTypesColumnNames.Id.ToString()] = Guid.NewGuid();
            hingeDatarow[FamilyComponentTypesColumnNames.Name.ToString()] = "Hinge";
            hingeDatarow[FamilyComponentTypesColumnNames.Description.ToString()] = "Describes all 'Door Leaf or Panel' component types.";
            hingeDatarow[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.FamilyComponentIcon64);
            hingeDatarow[FamilyComponentTypesColumnNames.DateCreated.ToString()] = DateTime.Now;
            hingeDatarow[FamilyComponentTypesColumnNames.DateModified.ToString()] = DateTime.Now;
            hingeDatarow[FamilyComponentTypesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            hingeDatarow[FamilyComponentTypesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypesTable.Rows.Add(hingeDatarow);

            // Door
            DataRow DoorDatarow = FamilyComponentTypesTable.NewRow();
            DoorDatarow[FamilyComponentTypesColumnNames.Id.ToString()] = Guid.NewGuid();
            DoorDatarow[FamilyComponentTypesColumnNames.Name.ToString()] = "Door";
            DoorDatarow[FamilyComponentTypesColumnNames.Description.ToString()] = "Describes all 'Door ' component types.";
            DoorDatarow[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.FamilyComponentIcon64);
            DoorDatarow[FamilyComponentTypesColumnNames.DateCreated.ToString()] = DateTime.Now;
            DoorDatarow[FamilyComponentTypesColumnNames.DateModified.ToString()] = DateTime.Now;
            DoorDatarow[FamilyComponentTypesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            DoorDatarow[FamilyComponentTypesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypesTable.Rows.Add(DoorDatarow);
            // Lintil
            DataRow LintilDatarow = FamilyComponentTypesTable.NewRow();
            LintilDatarow[FamilyComponentTypesColumnNames.Id.ToString()] = Guid.NewGuid();
            LintilDatarow[FamilyComponentTypesColumnNames.Name.ToString()] = "Lintil";
            LintilDatarow[FamilyComponentTypesColumnNames.Description.ToString()] = "Describes all 'Lintil' component types.";
            LintilDatarow[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.FamilyComponentIcon64);
            LintilDatarow[FamilyComponentTypesColumnNames.DateCreated.ToString()] = DateTime.Now;
            LintilDatarow[FamilyComponentTypesColumnNames.DateModified.ToString()] = DateTime.Now;
            LintilDatarow[FamilyComponentTypesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            LintilDatarow[FamilyComponentTypesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypesTable.Rows.Add(LintilDatarow);
            // Window
            DataRow WindowDatarow = FamilyComponentTypesTable.NewRow();
            WindowDatarow[FamilyComponentTypesColumnNames.Id.ToString()] = Guid.NewGuid();
            WindowDatarow[FamilyComponentTypesColumnNames.Name.ToString()] = "Window";
            WindowDatarow[FamilyComponentTypesColumnNames.Description.ToString()] = "Describes all 'Window' component types.";
            WindowDatarow[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.FamilyComponentIcon64);
            WindowDatarow[FamilyComponentTypesColumnNames.DateCreated.ToString()] = DateTime.Now;
            WindowDatarow[FamilyComponentTypesColumnNames.DateModified.ToString()] = DateTime.Now;
            WindowDatarow[FamilyComponentTypesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            WindowDatarow[FamilyComponentTypesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypesTable.Rows.Add(WindowDatarow);
            // Sill
            DataRow SillDatarow = FamilyComponentTypesTable.NewRow();
            SillDatarow[FamilyComponentTypesColumnNames.Id.ToString()] = Guid.NewGuid();
            SillDatarow[FamilyComponentTypesColumnNames.Name.ToString()] = "Sill";
            SillDatarow[FamilyComponentTypesColumnNames.Description.ToString()] = "Describes all 'Sill' component types.";
            SillDatarow[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.FamilyComponentIcon64);
            SillDatarow[FamilyComponentTypesColumnNames.DateCreated.ToString()] = DateTime.Now;
            SillDatarow[FamilyComponentTypesColumnNames.DateModified.ToString()] = DateTime.Now;
            SillDatarow[FamilyComponentTypesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            SillDatarow[FamilyComponentTypesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypesTable.Rows.Add(SillDatarow);
            // Fastning
            DataRow FastningDatarow = FamilyComponentTypesTable.NewRow();
            FastningDatarow[FamilyComponentTypesColumnNames.Id.ToString()] = Guid.NewGuid();
            FastningDatarow[FamilyComponentTypesColumnNames.Name.ToString()] = "Fastining";
            FastningDatarow[FamilyComponentTypesColumnNames.Description.ToString()] = "Describes all 'Fastning' component types.";
            FastningDatarow[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.FamilyComponentIcon64);
            FastningDatarow[FamilyComponentTypesColumnNames.DateCreated.ToString()] = DateTime.Now;
            FastningDatarow[FamilyComponentTypesColumnNames.DateModified.ToString()] = DateTime.Now;
            FastningDatarow[FamilyComponentTypesColumnNames.CreatedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FastningDatarow[FamilyComponentTypesColumnNames.ModifiedById.ToString()] = dataSet.Tables[TableNames.FF_Users.ToString()].Rows[0][UsersColumnNames.Id.ToString()];
            FamilyComponentTypesTable.Rows.Add(FastningDatarow);

            using (System.Data.SQLite.SQLiteConnection connect = new System.Data.SQLite.SQLiteConnection(connection))
            {
                foreach (DataTable table in dataSet.Tables)
                {
                    FamFactoryDataSet.SaveTableChangesToDatbase(connect, table);
                }
            }
        }

        public static bool CreateSQliteDataBase(string filePath, string script, DataSet set)
        {
            System.Data.SQLite.SQLiteConnection connection = GetSQlteConnection(filePath);
            try
            {
                if (!System.IO.File.Exists(filePath))
                {
                    System.Data.SQLite.SQLiteConnection.CreateFile(filePath);
                    using (connection)
                    {
                        connection.Open();
                        using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(script, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                        FamFactoryDataSet.InitilizeDataSet(set);
                        return true;
                    }
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                if (connection != null)
                {
                    connection.Close();
                }
                string s = ex.Message;
                return false;
            }
        }

        public static void UpdateDataSetFromDataSource(System.Data.SQLite.SQLiteConnection connection, DataSet dataSet)
        {
            try
            {
                using (System.Data.SQLite.SQLiteConnection connec = new System.Data.SQLite.SQLiteConnection(connection))
                {
                    connec.Open();
                    foreach (DataTable table in dataSet.Tables)
                    {
                        using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(String.Format("Select * From '{0}'", table.TableName), connec))
                        {
                            using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
                                table.Load(reader);
                        }
                    }
                    connec.Close();
                }
            }
            catch (Exception ex)
            {
                if (connection != null)
                {
                    connection.Close();
                }
                string s = ex.Message;
            }
        }

        public static void UpdateDataTableFromDataSource(System.Data.SQLite.SQLiteConnection connection, DataTable datatable)
        {
            try
            {
                using (System.Data.SQLite.SQLiteConnection connec = new System.Data.SQLite.SQLiteConnection(connection))
                {
                    connec.Open();
                    using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(String.Format("Select * From '{0}'", datatable.TableName), connec))
                    {
                        using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
                            datatable.Load(reader);
                    }
                    connec.Close();
                }
            }
            catch (Exception ex)
            {
                if (connection != null)
                {
                    connection.Close();
                }
                string s = ex.Message;
            }
        }

        public static bool SaveTableChangesToDatbase(System.Data.SQLite.SQLiteConnection connection, DataTable dataTable)
        {
            try
            {
                using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection(connection))
                {
                    using (System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(string.Format("Select * from '{0}'", dataTable.TableName), con))
                    {
                        using (System.Data.SQLite.SQLiteCommandBuilder sqliteCmdBuilder = new System.Data.SQLite.SQLiteCommandBuilder(adapter))
                        {
                            adapter.InsertCommand = sqliteCmdBuilder.GetInsertCommand();
                            adapter.DeleteCommand = sqliteCmdBuilder.GetDeleteCommand();
                            adapter.UpdateCommand = sqliteCmdBuilder.GetUpdateCommand();
                            DataTable table = dataTable.GetChanges();
                            if (table != null)
                            {
                                con.Open();
                                adapter.Update(table);
                                con.Close();
                                dataTable.AcceptChanges();
                            }
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                throw new Exception("Failed to Update FamFactoryTemplateItems!", ex);
            }
        }

        public static System.Data.SQLite.SQLiteConnection GetSQlteConnection(string dataBasePath)
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            System.Data.SQLite.SQLiteConnectionStringBuilder connSB = new System.Data.SQLite.SQLiteConnectionStringBuilder();
            connSB.DataSource = dataBasePath;
            connSB.FailIfMissing = false;
            return new System.Data.SQLite.SQLiteConnection(connSB.ConnectionString);
        }

        public static User AuthenticateUser(string username, string password, System.Data.SQLite.SQLiteConnection connection)
        {

            DataTable usersTable = new DataTable(TableNames.FF_Users);
            UpdateDataTableFromDataSource(connection, usersTable);
            DataRow userrow = null;
            foreach (DataRow item in usersTable.Rows)
            {
                if (item[UsersColumnNames.Name].ToString().ToLower() == username.ToLower())
                    userrow = item;
            }
            DataRowView user = usersTable.DefaultView[usersTable.Rows.IndexOf(userrow)];

            if (user != null)
            {
                if (Utils.VerifyPassword(password, user[UsersColumnNames.Password].ToString(), user[UsersColumnNames.Salt].ToString()))
                {
                    User usr = new User(user, connection);
                    return usr;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
