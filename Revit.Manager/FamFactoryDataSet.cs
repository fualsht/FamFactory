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
    public static class FamFactoryDataSet
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
            InitilizeFamilyTemplateReferencePlaneTable(dataSet);
            InitilizeFamilyComponentReferencePlanesTable(dataSet);
            InitilizeFamilyTemplateGeometryTable(dataSet);
            InitilizeFamilyComponentsGeometryTable(dataSet);
            InitilizeFamilyTemplateParametersTable(dataSet);
            InitilizeFamilyComponentsParametersTable(dataSet);
            InitilizeFamilyTemplateComponentsTable(dataSet);
            InitilizeFamilyBuildsTable(dataSet);
            InitilizeFamilyBuildComponentsTable(dataSet);
            InitilizeFamilyBuildComponentPositionsTable(dataSet);
        }

        private static void InitilizePermissions(DataSet dataSet)
        {
            DataTable permissionsTable = new DataTable(TableNames.FF_Permissions.ToString());
            DataColumn IdColumn = permissionsTable.Columns.Add(Permission.PermissionColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";
            DataColumn NameColumn = permissionsTable.Columns.Add(Permission.PermissionColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New User";
            NameColumn.Unique = true;
            DataColumn DescriptionColumn = permissionsTable.Columns.Add(Permission.PermissionColumnNames.Description.ToString(), typeof(string));
            DataColumn CreateColumn = permissionsTable.Columns.Add(Permission.PermissionColumnNames.CanCreate.ToString(), typeof(bool));
            CreateColumn.AllowDBNull = false;
            CreateColumn.DefaultValue = false;
            DataColumn ReadColumn = permissionsTable.Columns.Add(Permission.PermissionColumnNames.CanRead.ToString(), typeof(bool));
            ReadColumn.AllowDBNull = false;
            ReadColumn.DefaultValue = true;
            DataColumn WriteColumn = permissionsTable.Columns.Add(Permission.PermissionColumnNames.CanWrite.ToString(), typeof(bool));
            WriteColumn.AllowDBNull = false;
            WriteColumn.DefaultValue = false;
            DataColumn DeleteColumn = permissionsTable.Columns.Add(Permission.PermissionColumnNames.CanDelete.ToString(), typeof(bool));
            DeleteColumn.AllowDBNull = false;
            DeleteColumn.DefaultValue = false;
            DataColumn SpecialColumn = permissionsTable.Columns.Add(Permission.PermissionColumnNames.Special.ToString(), typeof(bool));
            SpecialColumn.AllowDBNull = false;
            SpecialColumn.DefaultValue = false;

            permissionsTable.PrimaryKey = new DataColumn[] { IdColumn };

            dataSet.Tables.Add(permissionsTable);
        }

        private static void InitilizeUsersTable(DataSet dataSet)
        {
            // Users Table
            DataTable usersTable = new DataTable(TableNames.FF_Users.ToString());
            DataColumn IdColumn = usersTable.Columns.Add(User.UsersTableColumnNames.Id.ToString(), typeof(string));
            IdColumn.Caption = "Id";
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            DataColumn nameColumn = usersTable.Columns.Add(User.UsersTableColumnNames.Name.ToString(), typeof(string));
            nameColumn.Caption = "Username";
            nameColumn.AllowDBNull = false;
            nameColumn.Unique = true;
            DataColumn firstNameColumn = usersTable.Columns.Add(User.UsersTableColumnNames.FirstName.ToString(), typeof(string));
            firstNameColumn.Caption = "First Name";
            firstNameColumn.AllowDBNull = false;
            firstNameColumn.DefaultValue = "First Name";
            DataColumn lastNameColumn = usersTable.Columns.Add(User.UsersTableColumnNames.LastName.ToString(), typeof(string));
            lastNameColumn.Caption = "Last Name";
            lastNameColumn.AllowDBNull = false;
            lastNameColumn.DefaultValue = "Last Name";
            DataColumn emailColumn = usersTable.Columns.Add(User.UsersTableColumnNames.Email.ToString(), typeof(string));
            emailColumn.Caption = "Email";
            emailColumn.AllowDBNull = false;
            emailColumn.DefaultValue = "user@email.com";
            DataColumn passwordColumn = usersTable.Columns.Add(User.UsersTableColumnNames.Password.ToString(), typeof(string));
            passwordColumn.Caption = "Passowrd";
            DataColumn profilePicColumn = usersTable.Columns.Add(User.UsersTableColumnNames.ProfilePic.ToString(), typeof(byte[]));
            profilePicColumn.Caption = "Profile Picture";
            profilePicColumn.AllowDBNull = false;
            profilePicColumn.DefaultValue = Utils.ImageToByte(Resources.UserIcon);
            DataColumn regColumn = usersTable.Columns.Add(User.UsersTableColumnNames.RegistrationDate.ToString(), typeof(DateTime));
            regColumn.Caption = "Registration Date";
            regColumn.AllowDBNull = false;
            regColumn.DefaultValue = DateTime.Now;
            DataColumn permissionIdColumn = usersTable.Columns.Add(User.UsersTableColumnNames.PermissionId.ToString(), typeof(string));
            permissionIdColumn.Caption = "Permission";
            permissionIdColumn.AllowDBNull = true;
            DataColumn lastLogInDateColumn = usersTable.Columns.Add(User.UsersTableColumnNames.LastLogInDate.ToString(), typeof(DateTime));
            lastLogInDateColumn.Caption = "Last Login Date";
            DataColumn stateColumn = usersTable.Columns.Add(User.UsersTableColumnNames.State.ToString(), typeof(EntityStates));
            stateColumn.Caption = "State";
            stateColumn.AllowDBNull = false;
            stateColumn.DefaultValue = EntityStates.Enabled;
            DataColumn TempFolderColumn = usersTable.Columns.Add(User.UsersTableColumnNames.TempFolder.ToString(), typeof(string));
            TempFolderColumn.Caption = "Temp Folder";
            TempFolderColumn.AllowDBNull = false;
            TempFolderColumn.DefaultValue = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FamFactory\\Temp";

            //Create and add Primary Keys for Datatable
            usersTable.PrimaryKey = new DataColumn[] { IdColumn };
            // Add DataTable to DataSet befroe adding Datarelations.
            dataSet.Tables.Add(usersTable);

            //Create the DataRelation.
            DataRelation dataRelation = new DataRelation(TableRelations.UsersPermissionId_PermissionsId.ToString(),
                dataSet.Tables[TableNames.FF_Permissions.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[User.UsersTableColumnNames.PermissionId.ToString()]);
            dataSet.Relations.Add(dataRelation);
        }

        private static void InitilizeEmailProfiles(DataSet dataSet)
        {
            DataTable EmailprofilesTable = new DataTable(TableNames.FF_EmailProfiles.ToString());
            DataColumn IdColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            DataColumn NameColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.Unique = true;
            DataColumn DescriptionColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.Description.ToString(), typeof(string));
            DataColumn ServerColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.ServerAddress.ToString(), typeof(string));
            ServerColumn.AllowDBNull = false;
            DataColumn PortColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.Port.ToString(), typeof(int));
            PortColumn.AllowDBNull = false;
            PortColumn.DefaultValue = 25;
            DataColumn SSLColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.SSL.ToString(), typeof(bool));
            SSLColumn.AllowDBNull = false;
            SSLColumn.DefaultValue = false;
            DataColumn UserNameColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.Username.ToString(), typeof(string));
            UserNameColumn.AllowDBNull = false;
            UserNameColumn.DefaultValue = false;
            DataColumn PasswordColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.Password.ToString(), typeof(string));
            PasswordColumn.AllowDBNull = false;
            PasswordColumn.DefaultValue = false;
            DataColumn StateColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.State.ToString(), typeof(EntityStates));
            StateColumn.AllowDBNull = false;
            StateColumn.DefaultValue = EntityStates.Enabled;
            DataColumn CreatedByColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.CreatedBy.ToString(), typeof(EntityStates));
            CreatedByColumn.AllowDBNull = false;
            DataColumn ModifiedByColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.ModifiedBy.ToString(), typeof(EntityStates));
            ModifiedByColumn.AllowDBNull = false;

            EmailprofilesTable.PrimaryKey = new DataColumn[] { IdColumn };

            dataSet.Tables.Add(EmailprofilesTable);

            //Create the DataRelation.
            DataRelation createdByRelation = new DataRelation(TableRelations.EmailProfilesCreatedBy_UsersId.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_EmailProfiles.ToString()].Columns[EmailProfile.EmailProfileColumnNames.CreatedBy.ToString()]);
            dataSet.Relations.Add(createdByRelation);

            //Create the DataRelation.
            DataRelation modifiedByRelation = new DataRelation(TableRelations.EmailProfilesModifiedBy_UsersId.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_EmailProfiles.ToString()].Columns[EmailProfile.EmailProfileColumnNames.ModifiedBy.ToString()]);
            dataSet.Relations.Add(modifiedByRelation);
        }

        private static void InitilizeSystemConfigurationsTable(DataSet dataSet)
        {
            // System Configuration
            DataTable SysConfigTable = new DataTable(TableNames.FF_SystemConfigurations.ToString());
            DataColumn idColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.Id.ToString(), typeof(string));
            idColumn.AllowDBNull = false;
            idColumn.Unique = true;
            DataColumn nameColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.Name.ToString(), typeof(string));
            nameColumn.AllowDBNull = false;
            nameColumn.Unique = true;
            nameColumn.DefaultValue = "New System";
            DataColumn addressColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.CompanyAddress.ToString(), typeof(string));
            addressColumn.AllowDBNull = true;
            DataColumn emailColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.Email.ToString(), typeof(string));
            emailColumn.AllowDBNull = false;
            emailColumn.DefaultValue = "admin@company.com";
            DataColumn installColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.InstallLocation.ToString(), typeof(string));
            installColumn.AllowDBNull = false;
            DataColumn appVerColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.AppVersion.ToString(), typeof(string));
            appVerColumn.AllowDBNull = false;
            appVerColumn.DefaultValue = "v.1.0.0";
            DataColumn dbVersionColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.DataBaseVersion.ToString(), typeof(string));
            dbVersionColumn.AllowDBNull = false;
            dbVersionColumn.DefaultValue = "v.1.0.0";

            SysConfigTable.PrimaryKey = new DataColumn[] { idColumn };

            dataSet.Tables.Add(SysConfigTable);

            //Create the DataRelation.
            DataRelation createdByRelation = new DataRelation(TableRelations.SystemConfigurationsCreatedBy_UsersId.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_EmailProfiles.ToString()].Columns[SystemConfiguration.SystemConfigurationTableColumnNames.CreatedBy.ToString()]);
            dataSet.Relations.Add(createdByRelation);

            //Create the DataRelation.
            DataRelation modifiedByRelation = new DataRelation(TableRelations.SystemConfigurationsModifiedBy_UsersId.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_EmailProfiles.ToString()].Columns[SystemConfiguration.SystemConfigurationTableColumnNames.ModifiedBy.ToString()]);
            dataSet.Relations.Add(modifiedByRelation);
        }

        private static void InitilizeFamilyComponentTypesTable(DataSet dataSet)
        {
            // System Configuration
            DataTable FamilyComponentTypes = new DataTable(TableNames.FF_FamilyComponentTypes.ToString());
            DataColumn idColumn = FamilyComponentTypes.Columns.Add(FamilyComponentType.FamilyComponentTypesTableColumnNames.Id.ToString(), typeof(string));
            idColumn.Caption = "Id";
            idColumn.AllowDBNull = false;
            idColumn.Unique = true;
            DataColumn nameColumn = FamilyComponentTypes.Columns.Add(FamilyComponentType.FamilyComponentTypesTableColumnNames.Name.ToString(), typeof(string));
            nameColumn.Caption = "Name";
            nameColumn.AllowDBNull = false;
            nameColumn.Unique = true;
            DataColumn addressColumn = FamilyComponentTypes.Columns.Add(FamilyComponentType.FamilyComponentTypesTableColumnNames.Description.ToString(), typeof(string));
            addressColumn.AllowDBNull = true;
            DataColumn ThumbnailColumn = FamilyComponentTypes.Columns.Add(FamilyComponentType.FamilyComponentTypesTableColumnNames.Thumbnail.ToString(), typeof(byte[]));
            ThumbnailColumn.AllowDBNull = true;

            FamilyComponentTypes.PrimaryKey = new DataColumn[] { idColumn };

            dataSet.Tables.Add(FamilyComponentTypes);
        }

        public static void InitilizeFamilyComponentsTable(DataSet dataSet)
        {
            try
            {
                DataTable FamilyComponentsTable = new DataTable(TableNames.FF_FamilyComponents.ToString());

                DataColumn idColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.Id.ToString(), typeof(string));
                idColumn.AllowDBNull = false;
                idColumn.Unique = true;

                DataColumn nameColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.Name.ToString(), typeof(string));
                nameColumn.AllowDBNull = false;
                nameColumn.Unique = true;

                DataColumn DescriptionColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.Description.ToString(), typeof(string));
                DescriptionColumn.AllowDBNull = true;

                DataColumn FamilyComponentTypeIdColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.FamilyComponentTypeId.ToString(), typeof(string));
                FamilyComponentTypeIdColumn.AllowDBNull = false;

                DataColumn FamilyCategoryColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.FamilyCategory.ToString(), typeof(string));
                FamilyCategoryColumn.AllowDBNull = false;

                DataColumn FamilyFileColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.FamilyFile.ToString(), typeof(byte[]));
                FamilyFileColumn.AllowDBNull = false;
                FamilyFileColumn.DefaultValue = new byte[byte.MaxValue];

                DataColumn ThumbnailColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.Thumbnail.ToString(), typeof(byte[]));
                ThumbnailColumn.AllowDBNull = false;
                ThumbnailColumn.DefaultValue = new byte[byte.MaxValue];

                DataColumn FileSizeColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.FileSize.ToString(), typeof(long));
                FileSizeColumn.AllowDBNull = false;
                FileSizeColumn.DefaultValue = 0;

                DataColumn DateCreatedColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.DateCreated.ToString(), typeof(DateTime));
                DateCreatedColumn.AllowDBNull = false;
                DateCreatedColumn.DefaultValue = DateTime.Now;

                DataColumn DateModifiedColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.DateModified.ToString(), typeof(DateTime));
                DateModifiedColumn.AllowDBNull = false;
                DateModifiedColumn.DefaultValue = DateTime.Now;

                DataColumn CreatedByUserIdColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.CreatedByUserId.ToString(), typeof(string));
                CreatedByUserIdColumn.AllowDBNull = true;

                DataColumn VersionColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.Version.ToString(), typeof(string));
                VersionColumn.AllowDBNull = false;
                VersionColumn.DefaultValue = "1.0.0";

                DataColumn IsReleasedColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.IsReleased.ToString(), typeof(bool));
                IsReleasedColumn.AllowDBNull = false;
                IsReleasedColumn.DefaultValue = false;

                DataColumn RoundConnectorDimentionColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.RoundConnectorDimention.ToString(), typeof(string));
                RoundConnectorDimentionColumn.AllowDBNull = false;
                RoundConnectorDimentionColumn.DefaultValue = string.Empty;

                DataColumn PartTypeColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.PartType.ToString(), typeof(string));
                PartTypeColumn.AllowDBNull = false;
                PartTypeColumn.DefaultValue = string.Empty;

                DataColumn OmniClassNumberColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.OmniClassNumber.ToString(), typeof(string));
                OmniClassNumberColumn.AllowDBNull = false;
                OmniClassNumberColumn.DefaultValue = string.Empty;

                DataColumn OmniClassTitleColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.OmniClassTitle.ToString(), typeof(string));
                OmniClassTitleColumn.AllowDBNull = false;
                OmniClassTitleColumn.DefaultValue = string.Empty;

                DataColumn WorkPlaneBasedColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.WorkPlaneBased.ToString(), typeof(bool));
                WorkPlaneBasedColumn.AllowDBNull = false;
                WorkPlaneBasedColumn.DefaultValue = false;

                DataColumn AlwaysVerticalColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.AlwaysVertical.ToString(), typeof(bool));
                AlwaysVerticalColumn.AllowDBNull = false;
                AlwaysVerticalColumn.DefaultValue = false;

                DataColumn CutsWithVoidWhenLoadedColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.CutsWithVoidWhenLoaded.ToString(), typeof(bool));
                CutsWithVoidWhenLoadedColumn.AllowDBNull = false;
                CutsWithVoidWhenLoadedColumn.DefaultValue = false;

                DataColumn IsSharedColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.IsShared.ToString(), typeof(bool));
                IsSharedColumn.AllowDBNull = false;
                IsSharedColumn.DefaultValue = false;

                DataColumn RoomCalculationPointColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.RoomCalculationPoint.ToString(), typeof(bool));
                RoomCalculationPointColumn.AllowDBNull = false;
                RoomCalculationPointColumn.DefaultValue = false;

                DataColumn FileNameColumn = FamilyComponentsTable.Columns.Add(FamilyComponent.FamilyComponentsTableColumnNames.FileName.ToString(), typeof(string));
                FileNameColumn.AllowDBNull = false;
                FileNameColumn.DefaultValue = string.Empty;

                FamilyComponentsTable.PrimaryKey = new DataColumn[] { idColumn };

                dataSet.Tables.Add(FamilyComponentsTable);

                DataRelation FamilyComponentTypeDataRelation = new DataRelation(TableRelations.FamilyComponentsFamilyComponentTypeId_FamilyComponentsId.ToString(),
                    dataSet.Tables[TableNames.FF_FamilyComponentTypes.ToString()].Columns[FamilyComponentType.FamilyComponentTypesTableColumnNames.Id.ToString()],
                    dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns[FamilyComponent.FamilyComponentsTableColumnNames.FamilyComponentTypeId.ToString()]);
                dataSet.Relations.Add(FamilyComponentTypeDataRelation);

                DataRelation FamilyComponentsUsersDataRelation = new DataRelation(TableRelations.FamilyComponentsCreatedByUserId_UsersId.ToString(),
                    dataSet.Tables[TableNames.FF_FamilyComponentTypes.ToString()].Columns[FamilyComponentType.FamilyComponentTypesTableColumnNames.Id.ToString()],
                    dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns[FamilyComponent.FamilyComponentsTableColumnNames.FamilyComponentTypeId.ToString()]);
                dataSet.Relations.Add(FamilyComponentsUsersDataRelation);
            }
            catch (Exception ex)
            {
                throw new Exception("Error initilizing FamilyComponentsTable!!!", ex);
            }

        }

        private static void InitilizeFamilyTemplatesTable(DataSet dataSet)
        {
            DataTable FamilyTemplatesTable = new DataTable(TableNames.FF_FamilyTemplates.ToString());

            DataColumn IdColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";

            DataColumn NameColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Template";
            NameColumn.Unique = false;

            DataColumn DescriptionColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = true;
            DescriptionColumn.Unique = false;

            DataColumn IsReleasedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.IsReleased.ToString(), typeof(bool));
            IsReleasedColumn.AllowDBNull = false;
            IsReleasedColumn.DefaultValue = false;

            DataColumn FamilyCategoryColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.FamilyCategory.ToString(), typeof(string));
            FamilyCategoryColumn.AllowDBNull = false;

            DataColumn CanHostRebarColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.CanHostRebar.ToString(), typeof(bool));
            CanHostRebarColumn.AllowDBNull = false;
            CanHostRebarColumn.DefaultValue = false;

            DataColumn RoundConnectorDimentionColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.RoundConnectorDimension.ToString(), typeof(string));
            RoundConnectorDimentionColumn.AllowDBNull = false;
            RoundConnectorDimentionColumn.DefaultValue = "Diameter";
            RoundConnectorDimentionColumn.Unique = false;

            DataColumn PartTypeColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.PartType.ToString(), typeof(string));
            PartTypeColumn.AllowDBNull = false;

            DataColumn OmnoClassNumberColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.OmniClassNumber.ToString(), typeof(string));
            OmnoClassNumberColumn.AllowDBNull = true;
            OmnoClassNumberColumn.Unique = false;

            DataColumn OmniClassTitleColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.OmniClassTitle.ToString(), typeof(string));
            OmniClassTitleColumn.AllowDBNull = true;
            OmniClassTitleColumn.Unique = false;

            DataColumn WorkPlaneBasedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.WorkPlaneBased.ToString(), typeof(bool));
            WorkPlaneBasedColumn.AllowDBNull = false;
            WorkPlaneBasedColumn.DefaultValue = false;

            DataColumn AlwaysVerticalColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.AlwaysVertical.ToString(), typeof(bool));
            AlwaysVerticalColumn.AllowDBNull = false;
            AlwaysVerticalColumn.DefaultValue = false;
            AlwaysVerticalColumn.Unique = false;

            DataColumn CutsWithVoidWhenLoadedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.CutsWithVoidWhenLoaded.ToString(), typeof(bool));
            CutsWithVoidWhenLoadedColumn.AllowDBNull = false;
            CutsWithVoidWhenLoadedColumn.DefaultValue = false;

            DataColumn IsSharedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.IsShared.ToString(), typeof(bool));
            IsSharedColumn.AllowDBNull = false;
            IsSharedColumn.DefaultValue = false;

            DataColumn RoomCalculationPointColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.RoomCalculationPoint.ToString(), typeof(bool));
            RoomCalculationPointColumn.AllowDBNull = false;
            RoomCalculationPointColumn.DefaultValue = false;

            DataColumn FileNameColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.FileName.ToString(), typeof(string));
            FileNameColumn.AllowDBNull = false;
            FileNameColumn.DefaultValue = "New File";

            DataColumn ThumbnailColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.Thumbnail.ToString(), typeof(byte[]));
            ThumbnailColumn.AllowDBNull = true;
            ThumbnailColumn.DefaultValue = new byte[byte.MinValue];
            ThumbnailColumn.Unique = false;

            DataColumn VersionColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.Version.ToString(), typeof(string));
            VersionColumn.AllowDBNull = false;
            VersionColumn.DefaultValue = "v.0.0.0";
            VersionColumn.Unique = false;

            DataColumn FileSizeColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.FileSize.ToString(), typeof(long));
            FileSizeColumn.AllowDBNull = false;
            FileSizeColumn.DefaultValue = 0;
            FileSizeColumn.Unique = false;

            DataColumn DateCreatedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.DateCreated.ToString(), typeof(DateTime));
            DateCreatedColumn.AllowDBNull = false;
            DateCreatedColumn.DefaultValue = new DateTime();
            DateCreatedColumn.Unique = false;

            DataColumn DateModifiedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.DateModified.ToString(), typeof(DateTime));
            DateModifiedColumn.AllowDBNull = false;
            DateModifiedColumn.DefaultValue = new DateTime();
            DateModifiedColumn.Unique = false;

            DataColumn FamilyFileColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.FamilyFile.ToString(), typeof(byte[]));
            FamilyFileColumn.AllowDBNull = false;
            FamilyFileColumn.DefaultValue = new byte[byte.MinValue];
            FamilyFileColumn.Unique = false;

            DataColumn CreatedByUserIdColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.CreatedByUserId.ToString(), typeof(string));
            CreatedByUserIdColumn.AllowDBNull = false;
            CreatedByUserIdColumn.DefaultValue = new byte[byte.MinValue];
            CreatedByUserIdColumn.Unique = false;

            dataSet.Tables.Add(FamilyTemplatesTable);

            DataRelation usersDataRelation = new DataRelation(TableRelations.FamilyTemplatesCreatedByUserId_UsersId.ToString(),
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[User.UsersTableColumnNames.Id.ToString()],
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns[FamilyTemplate.ParameterColumnNames.CreatedByUserId.ToString()]);
            dataSet.Relations.Add(usersDataRelation);
        }

        private static void InitilizeFamilyTemplateReferencePlaneTable(DataSet dataSet)
        {
            DataTable referencePlaneTable = new DataTable(TableNames.FF_FamilyTemplateReferencePlanes.ToString());

            DataColumn IdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyTemplateIdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FamilyId.ToString(), typeof(string));
            FamilyTemplateIdColumn.AllowDBNull = false;
            FamilyTemplateIdColumn.Unique = false;

            DataColumn NameColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New User";
            NameColumn.Unique = false;

            DataColumn RevitIdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.ElementId.ToString(), typeof(int));
            RevitIdColumn.AllowDBNull = false;

            DataColumn UniquColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.UniqueId.ToString(), typeof(string));
            UniquColumn.AllowDBNull = false;
            UniquColumn.DefaultValue = false;

            DataColumn LevelColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.LevelId.ToString(), typeof(int));
            LevelColumn.AllowDBNull = false;
            LevelColumn.DefaultValue = 0;

            DataColumn ViewIdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.ViewId.ToString(), typeof(int));
            ViewIdColumn.AllowDBNull = false;
            ViewIdColumn.DefaultValue = 0;

            DataColumn CategoryColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Category.ToString(), typeof(string));
            CategoryColumn.AllowDBNull = false;
            CategoryColumn.DefaultValue = "";

            DataColumn DirectionXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.DirectionX.ToString(), typeof(double));
            DirectionXColumn.AllowDBNull = false;
            DirectionXColumn.DefaultValue = 0;

            DataColumn DirectionYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.DirectionY.ToString(), typeof(double));
            DirectionYColumn.AllowDBNull = false;
            DirectionYColumn.DefaultValue = 0;

            DataColumn DirectionZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.DirectionZ.ToString(), typeof(double));
            DirectionZColumn.AllowDBNull = false;
            DirectionZColumn.DefaultValue = 0;

            DataColumn BubbleEndXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndX.ToString(), typeof(double));
            BubbleEndXColumn.AllowDBNull = false;
            BubbleEndXColumn.DefaultValue = 0;

            DataColumn BubbleEndYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndY.ToString(), typeof(double));
            BubbleEndYColumn.AllowDBNull = false;
            BubbleEndYColumn.DefaultValue = 0;

            DataColumn BubbleEndZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndZ.ToString(), typeof(double));
            BubbleEndZColumn.AllowDBNull = false;
            BubbleEndZColumn.DefaultValue = 0;

            DataColumn NormalXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.NormalX.ToString(), typeof(double));
            NormalXColumn.AllowDBNull = false;
            NormalXColumn.DefaultValue = 0;

            DataColumn NormalYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.NormalY.ToString(), typeof(double));
            NormalYColumn.AllowDBNull = false;
            NormalYColumn.DefaultValue = 0;

            DataColumn NormalZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.NormalZ.ToString(), typeof(double));
            NormalZColumn.AllowDBNull = false;
            NormalZColumn.DefaultValue = 0;

            DataColumn FreeEndXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FreeEndX.ToString(), typeof(double));
            FreeEndXColumn.AllowDBNull = false;
            FreeEndXColumn.DefaultValue = 0;

            DataColumn FreeEndYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FreeEndY.ToString(), typeof(double));
            FreeEndYColumn.AllowDBNull = false;
            FreeEndYColumn.DefaultValue = 0;

            DataColumn FreeEndZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FreeEndZ.ToString(), typeof(double));
            FreeEndZColumn.AllowDBNull = false;
            FreeEndZColumn.DefaultValue = 0;

            DataColumn IsActiveColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = false;

            referencePlaneTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };

            dataSet.Tables.Add(referencePlaneTable);

            DataRelation ReferencePlanesDataRelation = new DataRelation(TableRelations.FamilyTemplatesReferencePlaneFamilyId_FamilyTemplatesId.ToString(),
              dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns[FamilyTemplate.ParameterColumnNames.Id.ToString()],
              dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns[ReferencePlane.ReferencePlaneTableColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(ReferencePlanesDataRelation);
        }

        private static void InitilizeFamilyComponentReferencePlanesTable(DataSet dataSet)
        {
            DataTable referencePlaneTable = new DataTable(TableNames.FF_FamilyComponentReferencePlanes.ToString());

            DataColumn IdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyIdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FamilyId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = false;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.Unique = false;

            DataColumn RevitIdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.ElementId.ToString(), typeof(int));
            RevitIdColumn.AllowDBNull = false;

            DataColumn UniquColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.UniqueId.ToString(), typeof(string));
            UniquColumn.AllowDBNull = false;
            UniquColumn.DefaultValue = false;

            DataColumn LevelColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.LevelId.ToString(), typeof(int));
            LevelColumn.AllowDBNull = false;
            LevelColumn.DefaultValue = 0;

            DataColumn ViewIdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.ViewId.ToString(), typeof(int));
            ViewIdColumn.AllowDBNull = false;
            ViewIdColumn.DefaultValue = 0;

            DataColumn CategoryColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Category.ToString(), typeof(string));
            CategoryColumn.AllowDBNull = false;
            CategoryColumn.DefaultValue = "";

            DataColumn DirectionXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.DirectionX.ToString(), typeof(double));
            DirectionXColumn.AllowDBNull = false;
            DirectionXColumn.DefaultValue = 0;

            DataColumn DirectionYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.DirectionY.ToString(), typeof(double));
            DirectionYColumn.AllowDBNull = false;
            DirectionYColumn.DefaultValue = 0;

            DataColumn DirectionZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.DirectionZ.ToString(), typeof(double));
            DirectionZColumn.AllowDBNull = false;
            DirectionZColumn.DefaultValue = 0;

            DataColumn BubbleEndXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndX.ToString(), typeof(double));
            BubbleEndXColumn.AllowDBNull = false;
            BubbleEndXColumn.DefaultValue = 0;

            DataColumn BubbleEndYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndY.ToString(), typeof(double));
            BubbleEndYColumn.AllowDBNull = false;
            BubbleEndYColumn.DefaultValue = 0;

            DataColumn BubbleEndZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndZ.ToString(), typeof(double));
            BubbleEndZColumn.AllowDBNull = false;
            BubbleEndZColumn.DefaultValue = 0;

            DataColumn NormalXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.NormalX.ToString(), typeof(double));
            NormalXColumn.AllowDBNull = false;
            NormalXColumn.DefaultValue = 0;

            DataColumn NormalYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.NormalY.ToString(), typeof(double));
            NormalYColumn.AllowDBNull = false;
            NormalYColumn.DefaultValue = 0;

            DataColumn NormalZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.NormalZ.ToString(), typeof(double));
            NormalZColumn.AllowDBNull = false;
            NormalZColumn.DefaultValue = 0;

            DataColumn FreeEndXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FreeEndX.ToString(), typeof(double));
            FreeEndXColumn.AllowDBNull = false;
            FreeEndXColumn.DefaultValue = 0;

            DataColumn FreeEndYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FreeEndY.ToString(), typeof(double));
            FreeEndYColumn.AllowDBNull = false;
            FreeEndYColumn.DefaultValue = 0;

            DataColumn FreeEndZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FreeEndZ.ToString(), typeof(double));
            FreeEndZColumn.AllowDBNull = false;
            FreeEndZColumn.DefaultValue = 0;

            DataColumn IsActiveColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = false;

            referencePlaneTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };

            dataSet.Tables.Add(referencePlaneTable);

            DataRelation ReferencePlanesDataRelation = new DataRelation(TableRelations.FamilyComponentsReferencePlaneId_FamilyComponentsId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns[ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString()],
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns[ReferencePlane.ReferencePlaneTableColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(ReferencePlanesDataRelation);
        }

        private static void InitilizeFamilyTemplateGeometryTable(DataSet dataSet)
        {
            DataTable GeometryTable = new DataTable(TableNames.FF_FamilyTemplateGeometries.ToString());

            DataColumn IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";

            DataColumn FamilyIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.FamilyId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = false;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Sweep";
            NameColumn.Unique = false;

            DataColumn ElementIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.ElementId.ToString(), typeof(int));
            ElementIdColumn.AllowDBNull = false;
            ElementIdColumn.DefaultValue = -1;
            ElementIdColumn.Unique = false;

            DataColumn DescriptionColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = false;
            DescriptionColumn.DefaultValue = "";
            DescriptionColumn.Unique = false;

            DataColumn GeometryTypeColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.GeometryType.ToString(), typeof(string));
            GeometryTypeColumn.AllowDBNull = false;
            GeometryTypeColumn.DefaultValue = "Sweep";
            GeometryTypeColumn.Unique = false;

            DataColumn MaterialIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.MaterialId.ToString(), typeof(int));
            MaterialIdColumn.AllowDBNull = false;
            MaterialIdColumn.DefaultValue = -1;
            MaterialIdColumn.Unique = false;

            DataColumn IsActiveColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = true;
            IsActiveColumn.Unique = false;

            DataColumn ProfileFamily1IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily1Id.ToString(), typeof(int));
            ProfileFamily1IdColumn.AllowDBNull = false;
            ProfileFamily1IdColumn.DefaultValue = -1;
            ProfileFamily1IdColumn.Unique = false;

            DataColumn ProfileFamily2IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily2Id.ToString(), typeof(int));
            ProfileFamily2IdColumn.AllowDBNull = false;
            ProfileFamily2IdColumn.DefaultValue = -1;
            ProfileFamily2IdColumn.Unique = false;

            DataColumn HostIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.HostId.ToString(), typeof(int));
            HostIdColumn.AllowDBNull = false;
            HostIdColumn.DefaultValue = -1;
            HostIdColumn.Unique = false;

            DataColumn CategoryColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Category.ToString(), typeof(string));
            CategoryColumn.AllowDBNull = false;
            CategoryColumn.DefaultValue = "";
            CategoryColumn.Unique = false;

            DataColumn SubCategoryColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.SubCategory.ToString(), typeof(string));
            SubCategoryColumn.AllowDBNull = false;
            SubCategoryColumn.DefaultValue = "";
            SubCategoryColumn.Unique = false;

            DataColumn UniqueIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.UniqueId.ToString(), typeof(int));
            UniqueIdColumn.AllowDBNull = false;
            UniqueIdColumn.DefaultValue = -1;
            UniqueIdColumn.Unique = false;

            DataColumn OwnerViewIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.OwnerViewId.ToString(), typeof(int));
            OwnerViewIdColumn.AllowDBNull = false;
            OwnerViewIdColumn.DefaultValue = -1;
            OwnerViewIdColumn.Unique = false;

            DataColumn LevelIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.LevelId.ToString(), typeof(int));
            LevelIdColumn.AllowDBNull = false;
            LevelIdColumn.DefaultValue = -1;
            LevelIdColumn.Unique = false;

            DataColumn IsSolidColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.IsSolid.ToString(), typeof(bool));
            LevelIdColumn.AllowDBNull = false;
            LevelIdColumn.DefaultValue = true;
            LevelIdColumn.Unique = false;

            dataSet.Tables.Add(GeometryTable);

            DataRelation geometryDataRelation = new DataRelation(TableRelations.FamilyTemplateGeometriesFamilyId_FamilyTemplatesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateGeometries.ToString()].Columns[FamilyGeometry.FamilyGeometryColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(geometryDataRelation);
        }

        private static void InitilizeFamilyComponentsGeometryTable(DataSet dataSet)
        {
            DataTable GeometryTable = new DataTable(TableNames.FF_FamilyComponentGeometries.ToString());

            DataColumn IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";

            DataColumn FamilyIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.FamilyId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = false;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Sweep";
            NameColumn.Unique = false;

            DataColumn ElementIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.ElementId.ToString(), typeof(int));
            ElementIdColumn.AllowDBNull = false;
            ElementIdColumn.DefaultValue = -1;
            ElementIdColumn.Unique = false;

            DataColumn DescriptionColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = false;
            DescriptionColumn.DefaultValue = "";
            DescriptionColumn.Unique = false;

            DataColumn GeometryTypeColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.GeometryType.ToString(), typeof(string));
            GeometryTypeColumn.AllowDBNull = false;
            GeometryTypeColumn.DefaultValue = "Sweep";
            GeometryTypeColumn.Unique = false;

            DataColumn MaterialIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.MaterialId.ToString(), typeof(int));
            MaterialIdColumn.AllowDBNull = false;
            MaterialIdColumn.DefaultValue = -1;
            MaterialIdColumn.Unique = false;

            DataColumn IsActiveColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = true;
            IsActiveColumn.Unique = false;

            DataColumn ProfileFamily1IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily1Id.ToString(), typeof(int));
            ProfileFamily1IdColumn.AllowDBNull = false;
            ProfileFamily1IdColumn.DefaultValue = -1;
            ProfileFamily1IdColumn.Unique = false;

            DataColumn ProfileFamily2IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily2Id.ToString(), typeof(int));
            ProfileFamily2IdColumn.AllowDBNull = false;
            ProfileFamily2IdColumn.DefaultValue = -1;
            ProfileFamily2IdColumn.Unique = false;

            DataColumn HostIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.HostId.ToString(), typeof(int));
            HostIdColumn.AllowDBNull = false;
            HostIdColumn.DefaultValue = -1;
            HostIdColumn.Unique = false;

            DataColumn CategoryColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Category.ToString(), typeof(string));
            CategoryColumn.AllowDBNull = false;
            CategoryColumn.DefaultValue = "";
            CategoryColumn.Unique = false;

            DataColumn SubCategoryColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.SubCategory.ToString(), typeof(string));
            SubCategoryColumn.AllowDBNull = false;
            SubCategoryColumn.DefaultValue = "";
            SubCategoryColumn.Unique = false;

            DataColumn UniqueIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.UniqueId.ToString(), typeof(int));
            UniqueIdColumn.AllowDBNull = false;
            UniqueIdColumn.DefaultValue = -1;
            UniqueIdColumn.Unique = false;

            DataColumn OwnerViewIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.OwnerViewId.ToString(), typeof(int));
            OwnerViewIdColumn.AllowDBNull = false;
            OwnerViewIdColumn.DefaultValue = -1;
            OwnerViewIdColumn.Unique = false;

            DataColumn LevelIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.LevelId.ToString(), typeof(int));
            LevelIdColumn.AllowDBNull = false;
            LevelIdColumn.DefaultValue = -1;
            LevelIdColumn.Unique = false;

            DataColumn IsSolidColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.IsSolid.ToString(), typeof(bool));
            LevelIdColumn.AllowDBNull = false;
            LevelIdColumn.DefaultValue = true;
            LevelIdColumn.Unique = false;

            dataSet.Tables.Add(GeometryTable);

            DataRelation geometryDataRelation = new DataRelation(TableRelations.FamilyComponentGeometriesFamilyId_FamilyComponentsId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyComponentGeometries.ToString()].Columns[FamilyGeometry.FamilyGeometryColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(geometryDataRelation);
        }

        private static void InitilizeFamilyTemplateParametersTable(DataSet dataSet)
        {
            DataTable ParametersTable = new DataTable(TableNames.FF_FamilyTemplateParameters.ToString());

            DataColumn IdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";

            DataColumn FamilyTemplateIdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.FamilyId.ToString(), typeof(string));
            FamilyTemplateIdColumn.AllowDBNull = false;
            FamilyTemplateIdColumn.Unique = false;

            DataColumn NameColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Sweep";
            NameColumn.Unique = false;

            DataColumn ElementIdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.ElementId.ToString(), typeof(int));
            ElementIdColumn.AllowDBNull = false;
            ElementIdColumn.DefaultValue = 0;
            ElementIdColumn.Unique = false;

            DataColumn ElementGUIDColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.ElementGUID.ToString(), typeof(string));
            ElementGUIDColumn.AllowDBNull = false;
            ElementGUIDColumn.DefaultValue = string.Empty;
            ElementGUIDColumn.Unique = false;

            DataColumn HasValueColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.HasValue.ToString(), typeof(bool));
            HasValueColumn.AllowDBNull = false;
            HasValueColumn.DefaultValue = false;
            HasValueColumn.Unique = false;

            DataColumn IsReadOnlyColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsReadOnly.ToString(), typeof(bool));
            IsReadOnlyColumn.AllowDBNull = false;
            IsReadOnlyColumn.DefaultValue = false;
            IsReadOnlyColumn.Unique = false;

            DataColumn IsSharedParamColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsShared.ToString(), typeof(bool));
            IsSharedParamColumn.AllowDBNull = false;
            IsSharedParamColumn.DefaultValue = false;
            IsSharedParamColumn.Unique = false;

            DataColumn IsInstanceColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsInstance.ToString(), typeof(bool));
            IsInstanceColumn.AllowDBNull = false;
            IsInstanceColumn.DefaultValue = false;
            IsInstanceColumn.Unique = false;

            DataColumn StorageTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.StorageType.ToString(), typeof(int));
            StorageTypeColumn.AllowDBNull = false;
            StorageTypeColumn.DefaultValue = 0;
            StorageTypeColumn.Unique = false;

            DataColumn IsEditableColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsEditable.ToString(), typeof(bool));
            IsEditableColumn.AllowDBNull = false;
            IsEditableColumn.Unique = false;

            DataColumn IsActiveColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = false;
            IsActiveColumn.Unique = false;

            DataColumn HostIdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.HostId.ToString(), typeof(string));
            HostIdColumn.AllowDBNull = false;
            HostIdColumn.DefaultValue = string.Empty;
            HostIdColumn.Unique = false;

            DataColumn IsReportingColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsReporting.ToString(), typeof(bool));
            IsReportingColumn.AllowDBNull = false;
            IsReportingColumn.DefaultValue = false;
            IsReportingColumn.Unique = false;

            DataColumn BuiltInParamGroupColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.BuiltInParamGroup.ToString(), typeof(int));
            BuiltInParamGroupColumn.AllowDBNull = false;
            BuiltInParamGroupColumn.DefaultValue = -1;
            BuiltInParamGroupColumn.Unique = false;

            DataColumn ParameterTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.ParameterType.ToString(), typeof(int));
            ParameterTypeColumn.AllowDBNull = false;
            ParameterTypeColumn.DefaultValue = 1;
            ParameterTypeColumn.Unique = false;

            DataColumn UnitTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.UnitType.ToString(), typeof(int));
            UnitTypeColumn.AllowDBNull = false;
            UnitTypeColumn.DefaultValue = -1;
            UnitTypeColumn.Unique = false;

            DataColumn DisplayUnitTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.DisplayUnitType.ToString(), typeof(int));
            DisplayUnitTypeColumn.AllowDBNull = false;
            DisplayUnitTypeColumn.DefaultValue = 2;
            DisplayUnitTypeColumn.Unique = false;

            DataColumn UserModifiableColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.UserModifiable.ToString(), typeof(bool));
            UserModifiableColumn.AllowDBNull = false;
            UserModifiableColumn.DefaultValue = false;
            UserModifiableColumn.Unique = false;

            DataColumn IsDeterminedByFormulaColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString(), typeof(bool));
            IsDeterminedByFormulaColumn.AllowDBNull = false;
            IsDeterminedByFormulaColumn.DefaultValue = false;
            IsDeterminedByFormulaColumn.Unique = false;

            DataColumn FormulaColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.Formula.ToString(), typeof(string));
            FormulaColumn.AllowDBNull = true;
            FormulaColumn.DefaultValue = string.Empty;
            FormulaColumn.Unique = false;

            ParametersTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };
            dataSet.Tables.Add(ParametersTable);

            DataRelation parametersDataRelation = new DataRelation(TableRelations.FamilyTemplateParametersFamilyId_FamilyTemplatesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateParameters.ToString()].Columns[Parameter.ParameterColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(parametersDataRelation);
        }

        private static void InitilizeFamilyComponentsParametersTable(DataSet dataSet)
        {
            DataTable ParametersTable = new DataTable(TableNames.FF_FamilyComponentParameters.ToString());

            DataColumn IdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";

            DataColumn FamilyIdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.FamilyId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = false;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Sweep";
            NameColumn.Unique = false;

            DataColumn ElementIdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.ElementId.ToString(), typeof(int));
            ElementIdColumn.AllowDBNull = false;
            ElementIdColumn.DefaultValue = 0;
            ElementIdColumn.Unique = false;

            DataColumn ElementGUIDColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.ElementGUID.ToString(), typeof(string));
            ElementGUIDColumn.AllowDBNull = false;
            ElementGUIDColumn.DefaultValue = string.Empty;
            ElementGUIDColumn.Unique = false;

            DataColumn HasValueColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.HasValue.ToString(), typeof(bool));
            HasValueColumn.AllowDBNull = false;
            HasValueColumn.DefaultValue = false;
            HasValueColumn.Unique = false;

            DataColumn IsReadOnlyColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsReadOnly.ToString(), typeof(bool));
            IsReadOnlyColumn.AllowDBNull = false;
            IsReadOnlyColumn.DefaultValue = false;
            IsReadOnlyColumn.Unique = false;

            DataColumn IsSharedParamColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsShared.ToString(), typeof(bool));
            IsSharedParamColumn.AllowDBNull = false;
            IsSharedParamColumn.DefaultValue = false;
            IsSharedParamColumn.Unique = false;

            DataColumn IsInstanceColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsInstance.ToString(), typeof(bool));
            IsInstanceColumn.AllowDBNull = false;
            IsInstanceColumn.DefaultValue = false;
            IsInstanceColumn.Unique = false;

            DataColumn StorageTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.StorageType.ToString(), typeof(int));
            StorageTypeColumn.AllowDBNull = false;
            StorageTypeColumn.DefaultValue = 0;
            StorageTypeColumn.Unique = false;

            DataColumn IsEditableColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsEditable.ToString(), typeof(bool));
            IsEditableColumn.AllowDBNull = false;
            IsEditableColumn.Unique = false;

            DataColumn IsActiveColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = false;
            IsActiveColumn.Unique = false;

            DataColumn HostIdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.HostId.ToString(), typeof(string));
            HostIdColumn.AllowDBNull = false;
            HostIdColumn.DefaultValue = string.Empty;
            HostIdColumn.Unique = false;

            DataColumn IsReportingColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsReporting.ToString(), typeof(bool));
            IsReportingColumn.AllowDBNull = false;
            IsReportingColumn.DefaultValue = false;
            IsReportingColumn.Unique = false;

            DataColumn BuiltInParamGroupColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.BuiltInParamGroup.ToString(), typeof(int));
            BuiltInParamGroupColumn.AllowDBNull = false;
            BuiltInParamGroupColumn.DefaultValue = -1;
            BuiltInParamGroupColumn.Unique = false;

            DataColumn ParameterTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.ParameterType.ToString(), typeof(int));
            ParameterTypeColumn.AllowDBNull = false;
            ParameterTypeColumn.DefaultValue = 1;
            ParameterTypeColumn.Unique = false;

            DataColumn UnitTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.UnitType.ToString(), typeof(int));
            UnitTypeColumn.AllowDBNull = false;
            UnitTypeColumn.DefaultValue = -1;
            UnitTypeColumn.Unique = false;

            DataColumn DisplayUnitTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.DisplayUnitType.ToString(), typeof(int));
            DisplayUnitTypeColumn.AllowDBNull = false;
            DisplayUnitTypeColumn.DefaultValue = 2;
            DisplayUnitTypeColumn.Unique = false;

            DataColumn UserModifiableColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.UserModifiable.ToString(), typeof(bool));
            UserModifiableColumn.AllowDBNull = false;
            UserModifiableColumn.DefaultValue = false;
            UserModifiableColumn.Unique = false;

            DataColumn IsDeterminedByFormulaColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString(), typeof(bool));
            IsDeterminedByFormulaColumn.AllowDBNull = false;
            IsDeterminedByFormulaColumn.DefaultValue = false;
            IsDeterminedByFormulaColumn.Unique = false;

            DataColumn FormulaColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.Formula.ToString(), typeof(string));
            FormulaColumn.AllowDBNull = true;
            FormulaColumn.DefaultValue = string.Empty;
            FormulaColumn.Unique = false;

            ParametersTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };
            dataSet.Tables.Add(ParametersTable);

            DataRelation parametersDataRelation = new DataRelation(TableRelations.FamilyComponentParametersFamilyId_FamilyComponentsId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyComponentParameters.ToString()].Columns[Parameter.ParameterColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(parametersDataRelation);
        }

        private static void InitilizeFamilyTemplateComponentsTable(DataSet dataSet)
        {
            DataTable FamilyTemplateComponentsTable = new DataTable(TableNames.FF_FamilyTemplateComponents.ToString());

            DataColumn IdColumn = FamilyTemplateComponentsTable.Columns.Add(FamilyTemplateComponent.TemplateComponentColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyIdColumn = FamilyTemplateComponentsTable.Columns.Add(FamilyTemplateComponent.TemplateComponentColumnNames.FamilyId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = false;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = FamilyTemplateComponentsTable.Columns.Add(FamilyTemplateComponent.TemplateComponentColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Template Component";
            NameColumn.Unique = false;

            DataColumn DescriptionColumn = FamilyTemplateComponentsTable.Columns.Add(FamilyTemplateComponent.TemplateComponentColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = false;
            DescriptionColumn.Unique = false;

            DataColumn XRefferencePlaneIdColumn = FamilyTemplateComponentsTable.Columns.Add(FamilyTemplateComponent.TemplateComponentColumnNames.XRefferencePlaneId.ToString(), typeof(string));
            XRefferencePlaneIdColumn.AllowDBNull = true;
            XRefferencePlaneIdColumn.Unique = false;

            DataColumn YRefferencePlaneIdColumn = FamilyTemplateComponentsTable.Columns.Add(FamilyTemplateComponent.TemplateComponentColumnNames.YRefferencePlaneId.ToString(), typeof(string));
            YRefferencePlaneIdColumn.AllowDBNull = true;
            YRefferencePlaneIdColumn.Unique = false;

            DataColumn ZRefferencePlaneIdColumn = FamilyTemplateComponentsTable.Columns.Add(FamilyTemplateComponent.TemplateComponentColumnNames.ZRefferencePlaneId.ToString(), typeof(string));
            ZRefferencePlaneIdColumn.AllowDBNull = true;
            ZRefferencePlaneIdColumn.Unique = false;

            FamilyTemplateComponentsTable.PrimaryKey = new DataColumn[] { IdColumn };
            dataSet.Tables.Add(FamilyTemplateComponentsTable);

            DataRelation TemplateIdDataRelation = new DataRelation(TableRelations.FamilyTemplateComponentsFamilyId_FamilyTemplateId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[FamilyTemplateComponent.TemplateComponentColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(TemplateIdDataRelation);

            DataRelation ReferencePlaneIdXDataRelation = new DataRelation(TableRelations.FamilyTemplateComponentsXRefferencePlaneId_FamilyTemplateReferencePlanesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[FamilyTemplateComponent.TemplateComponentColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(ReferencePlaneIdXDataRelation);

            DataRelation ReferencePlaneIdYDataRelation = new DataRelation(TableRelations.FamilyTemplateComponentsYRefferencePlaneId_FamilyTemplateReferencePlanesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[FamilyTemplateComponent.TemplateComponentColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(ReferencePlaneIdYDataRelation);

            DataRelation ReferencePlaneIdZDataRelation = new DataRelation(TableRelations.FamilyTemplateComponentsZRefferencePlaneId_FamilyTemplateReferencePlanesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].Columns[FamilyTemplateComponent.TemplateComponentColumnNames.FamilyId.ToString()]);
            dataSet.Relations.Add(ReferencePlaneIdZDataRelation);
        }

        private static void InitilizeFamilyBuildsTable(DataSet dataSet)
        {
            DataTable FamilyBuildsTable = new DataTable(TableNames.FF_FamilyBuilds.ToString());

            DataColumn IdColumn = FamilyBuildsTable.Columns.Add(FamilyBuild.FamilyBuildsColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyIdColumn = FamilyBuildsTable.Columns.Add(FamilyBuild.FamilyBuildsColumnNames.FamilyTemplateId.ToString(), typeof(string));
            FamilyIdColumn.AllowDBNull = true;
            FamilyIdColumn.Unique = false;

            DataColumn NameColumn = FamilyBuildsTable.Columns.Add(FamilyBuild.FamilyBuildsColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.Unique = false;

            DataColumn DescriptionColumn = FamilyBuildsTable.Columns.Add(FamilyBuild.FamilyBuildsColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = true;
            DescriptionColumn.Unique = false;

            FamilyBuildsTable.PrimaryKey = new DataColumn[] { IdColumn };
            dataSet.Tables.Add(FamilyBuildsTable);

            DataRelation TemplateIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentsFamilyBuildId_FamilyBuildsId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuilds.ToString()].Columns[FamilyBuild.FamilyBuildsColumnNames.FamilyTemplateId.ToString()]);
            dataSet.Relations.Add(TemplateIdDataRelation);
        }

        private static void InitilizeFamilyBuildComponentsTable(DataSet dataSet)
        {
            DataTable FamilyBuildComponentsTable = new DataTable(TableNames.FF_FamilyBuildComponents.ToString());

            DataColumn IdColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponent.FamilyBuildComponentsColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyBuildIdColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponent.FamilyBuildComponentsColumnNames.FamilyBuildId.ToString(), typeof(string));
            FamilyBuildIdColumn.AllowDBNull = false;
            FamilyBuildIdColumn.Unique = false;

            DataColumn FamilyComponentIdColumn = FamilyBuildComponentsTable.Columns.Add(FamilyBuildComponent.FamilyBuildComponentsColumnNames.FamilyComponentId.ToString(), typeof(string));
            FamilyComponentIdColumn.AllowDBNull = false;
            FamilyComponentIdColumn.Unique = false;            

            FamilyBuildComponentsTable.PrimaryKey = new DataColumn[] { IdColumn };
            dataSet.Tables.Add(FamilyBuildComponentsTable);

            DataRelation FamilyBuildComponentDataRelation = new DataRelation(TableRelations.FamilyBuildComponentsFamilyComponentId_FamilyComponentsId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponents.ToString()].Columns[FamilyBuildComponent.FamilyBuildComponentsColumnNames.FamilyComponentId.ToString()]);
            dataSet.Relations.Add(FamilyBuildComponentDataRelation);

            DataRelation FamilyBuildDataRelation = new DataRelation(TableRelations.FamilyBuildComponentsFamilyBuildId_FamilyBuildsId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyBuilds.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyComponents.ToString()].Columns[FamilyBuildComponent.FamilyBuildComponentsColumnNames.FamilyBuildId.ToString()]);
            dataSet.Relations.Add(FamilyBuildDataRelation);
        }

        private static void InitilizeFamilyBuildComponentPositionsTable(DataSet dataSet)
        {
            DataTable FamilyBuildComponentPositionsTable = new DataTable(TableNames.FF_FamilyBuildComponentPositions.ToString());

            DataColumn IdColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyBuildComponentIdColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.FamilyBuildComponentId.ToString(), typeof(string));
            FamilyBuildComponentIdColumn.AllowDBNull = false;
            FamilyBuildComponentIdColumn.Unique = false;

            DataColumn TemplateReferencePlaneXIdColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.TemplateReferencePlaneXId.ToString(), typeof(string));
            TemplateReferencePlaneXIdColumn.AllowDBNull = false;
            TemplateReferencePlaneXIdColumn.Unique = false;

            DataColumn TemplateReferencePlaneYIdColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.TemplateReferencePlaneYId.ToString(), typeof(string));
            TemplateReferencePlaneYIdColumn.AllowDBNull = false;
            TemplateReferencePlaneYIdColumn.Unique = false;

            DataColumn TemplateReferencePlaneZIdColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.TemplateReferencePlaneZId.ToString(), typeof(string));
            TemplateReferencePlaneZIdColumn.AllowDBNull = false;
            TemplateReferencePlaneZIdColumn.Unique = false;

            DataColumn ComponentRefernecePLaneXIdColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.ComponentRefernecePlaneXId.ToString(), typeof(string));
            ComponentRefernecePLaneXIdColumn.AllowDBNull = false;
            ComponentRefernecePLaneXIdColumn.Unique = false;

            DataColumn ComponentRefernecePLaneYIdColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.ComponentRefernecePlaneYId.ToString(), typeof(string));
            ComponentRefernecePLaneYIdColumn.AllowDBNull = false;
            ComponentRefernecePLaneYIdColumn.Unique = false;

            DataColumn ComponentRefernecePLaneZIdColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.ComponentRefernecePlaneZId.ToString(), typeof(string));
            ComponentRefernecePLaneZIdColumn.AllowDBNull = false;
            ComponentRefernecePLaneZIdColumn.Unique = false;

            DataColumn XOffsetColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.XOffset.ToString(), typeof(double));
            XOffsetColumn.AllowDBNull = false;
            XOffsetColumn.Unique = false;
            XOffsetColumn.DefaultValue = 0;

            DataColumn YOffsetColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.YOffset.ToString(), typeof(double));
            YOffsetColumn.AllowDBNull = false;
            YOffsetColumn.Unique = false;
            YOffsetColumn.DefaultValue = 0;

            DataColumn ZOffsetColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.ZOffset.ToString(), typeof(double));
            ZOffsetColumn.AllowDBNull = false;
            ZOffsetColumn.Unique = false;
            ZOffsetColumn.DefaultValue = 0;

            DataColumn XRotateColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.XRotate.ToString(), typeof(double));
            XRotateColumn.AllowDBNull = false;
            XRotateColumn.Unique = false;
            XRotateColumn.DefaultValue = 0;

            DataColumn YRotateColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.YRotate.ToString(), typeof(double));
            YRotateColumn.AllowDBNull = false;
            YRotateColumn.Unique = false;
            YRotateColumn.DefaultValue = 0;

            DataColumn ZRotateColumn = FamilyBuildComponentPositionsTable.Columns.Add(FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.ZRotate.ToString(), typeof(double));
            ZRotateColumn.AllowDBNull = false;
            ZRotateColumn.Unique = false;
            ZRotateColumn.DefaultValue = 0;

            FamilyBuildComponentPositionsTable.PrimaryKey = new DataColumn[] { IdColumn };
            dataSet.Tables.Add(FamilyBuildComponentPositionsTable);

            DataRelation FamilyBuildComponentDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositionsFamilyBuildComponentId_FamilyBuildComponentsId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyBuildComponents.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.FamilyBuildComponentId.ToString()]);
            dataSet.Relations.Add(FamilyBuildComponentDataRelation);

            DataRelation TemplateReferencePlaneXIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositionsTemplateReferencePlaneXId_FamilyTemplateReferencePlanesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.TemplateReferencePlaneXId.ToString()]);
            dataSet.Relations.Add(TemplateReferencePlaneXIdDataRelation);

            DataRelation TemplateReferencePlaneYIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositionsTemplateReferencePlaneYId_FamilyTemplateReferencePlanesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.TemplateReferencePlaneYId.ToString()]);
            dataSet.Relations.Add(TemplateReferencePlaneYIdDataRelation);

            DataRelation TemplateReferencePlaneZIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositionsTemplateReferencePlaneZId_FamilyTemplateReferencePlanesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.TemplateReferencePlaneZId.ToString()]);
            dataSet.Relations.Add(TemplateReferencePlaneZIdDataRelation);

            DataRelation ComponentRefernecePlaneXIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositionsComponentReferencePlaneXId_FamilyComponentReferencePlanesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.ComponentRefernecePlaneXId.ToString()]);
            dataSet.Relations.Add(ComponentRefernecePlaneXIdDataRelation);

            DataRelation ComponentRefernecePlaneYIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositionsComponentReferencePlaneYId_FamilyComponentReferencePlanesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.ComponentRefernecePlaneYId.ToString()]);
            dataSet.Relations.Add(ComponentRefernecePlaneYIdDataRelation);

            DataRelation ComponentRefernecePlaneZIdDataRelation = new DataRelation(TableRelations.FamilyBuildComponentPositionsComponentReferencePlaneZId_FamilyComponentReferencePlanesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyComponentReferencePlanes.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_FamilyBuildComponentPositions.ToString()].Columns[FamilyBuildComponentPosition.FamilyBuildComponentPostionColumnNames.ComponentRefernecePlaneZId.ToString()]);
            dataSet.Relations.Add(ComponentRefernecePlaneZIdDataRelation);
        }

        public static void InstallSampleData(System.Data.SQLite.SQLiteConnection connection, DataSet dataSet)
        {
            //Email Profile
            DataTable EmailprofilesTable = dataSet.Tables[TableNames.FF_EmailProfiles.ToString()];
            DataRow EmailProfileDatarow = EmailprofilesTable.NewRow();
            EmailProfileDatarow[EmailProfile.EmailProfileColumnNames.Id.ToString()] = Guid.NewGuid();
            EmailProfileDatarow[EmailProfile.EmailProfileColumnNames.Name.ToString()] = "Admin";
            EmailProfileDatarow[EmailProfile.EmailProfileColumnNames.Description.ToString()] = "Admin permissions with full permissions.";
            EmailProfileDatarow[EmailProfile.EmailProfileColumnNames.ServerAddress.ToString()] = "mail.server.com";
            EmailProfileDatarow[EmailProfile.EmailProfileColumnNames.Port.ToString()] = 25;
            EmailProfileDatarow[EmailProfile.EmailProfileColumnNames.SSL.ToString()] = false;
            EmailProfileDatarow[EmailProfile.EmailProfileColumnNames.Username.ToString()] = "";
            EmailProfileDatarow[EmailProfile.EmailProfileColumnNames.Password.ToString()] = "";
            EmailProfileDatarow[EmailProfile.EmailProfileColumnNames.State.ToString()] = true;
            EmailprofilesTable.Rows.Add(EmailProfileDatarow);

            //Admin Level
            DataTable permissionsTable = dataSet.Tables[TableNames.FF_Permissions.ToString()];
            DataRow adminPermissionDatarow = permissionsTable.NewRow();
            adminPermissionDatarow["Id"] = Guid.NewGuid();
            adminPermissionDatarow["Name"] = "Admin";
            adminPermissionDatarow["Description"] = "Admin permissions with full permissions.";
            adminPermissionDatarow["CanCreate"] = true;
            adminPermissionDatarow["CanRead"] = true;
            adminPermissionDatarow["CanWrite"] = true;
            adminPermissionDatarow["CanDelete"] = true;
            adminPermissionDatarow["Special"] = true;
            permissionsTable.Rows.Add(adminPermissionDatarow);

            //Viewer Level
            DataRow viewPermissionDatarow = permissionsTable.NewRow();
            viewPermissionDatarow["Id"] = Guid.NewGuid();
            viewPermissionDatarow["Name"] = "Viewer";
            viewPermissionDatarow["Description"] = "Admin permissions with full permissions.";
            viewPermissionDatarow["CanCreate"] = false;
            viewPermissionDatarow["CanRead"] = true;
            viewPermissionDatarow["CanWrite"] = false;
            viewPermissionDatarow["CanDelete"] = false;
            viewPermissionDatarow["Special"] = false;
            permissionsTable.Rows.Add(viewPermissionDatarow);

            //Editor Level
            DataRow userPermissionDatarow = permissionsTable.NewRow();
            userPermissionDatarow["Id"] = Guid.NewGuid();
            userPermissionDatarow["Name"] = "Editor";
            userPermissionDatarow["Description"] = "Admin permissions with full permissions.";
            userPermissionDatarow["CanCreate"] = true;
            userPermissionDatarow["CanRead"] = true;
            userPermissionDatarow["CanWrite"] = true;
            userPermissionDatarow["CanDelete"] = true;
            userPermissionDatarow["Special"] = false;
            permissionsTable.Rows.Add(userPermissionDatarow);

            //Users
            DataTable usersTable = dataSet.Tables[TableNames.FF_Users.ToString()];
            DataRow adminUserDataRow = usersTable.NewRow();
            adminUserDataRow[User.UsersTableColumnNames.Id.ToString()] = Guid.NewGuid();
            adminUserDataRow[User.UsersTableColumnNames.Name.ToString()] = "Admin";
            adminUserDataRow[User.UsersTableColumnNames.FirstName.ToString()] = "Admin";
            adminUserDataRow[User.UsersTableColumnNames.LastName.ToString()] = "";
            adminUserDataRow[User.UsersTableColumnNames.Email.ToString()] = "Admin@Comapny.com";
            adminUserDataRow[User.UsersTableColumnNames.Password.ToString()] = Utils.GetPasswordHash(SHA256.Create("SHA256"), "Password");
            adminUserDataRow[User.UsersTableColumnNames.ProfilePic.ToString()] = Utils.ImageToByte(Resources.UserIcon);
            adminUserDataRow[User.UsersTableColumnNames.PermissionId.ToString()] = dataSet.Tables[TableNames.FF_Permissions.ToString()].Select("Name = 'Editor'").FirstOrDefault()["Id"];
            adminUserDataRow[User.UsersTableColumnNames.LastLogInDate.ToString()] = DateTime.Now;
            adminUserDataRow[User.UsersTableColumnNames.State.ToString()] = Manager.EntityStates.Enabled;
            adminUserDataRow[User.UsersTableColumnNames.TempFolder.ToString()] = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FamFactory\\Temp";
            usersTable.Rows.Add(adminUserDataRow);

            // System Configuration
            DataTable SysConfigTable = dataSet.Tables[TableNames.FF_SystemConfigurations.ToString()];
            DataRow SystemConfigDataRow = SysConfigTable.NewRow();
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.Id.ToString()] = Guid.NewGuid();
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.Name.ToString()] = "<DefaultCompany>";
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.CompanyAddress.ToString()] = string.Empty;
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.Email.ToString()] = "admin@company.com";
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.InstallLocation.ToString()] = "C:\\programfiles\\FamFactory";
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.AppVersion.ToString()] = "v.1.0.0";
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.DataBaseVersion.ToString()] = "v.1.0.0";
            SysConfigTable.Rows.Add(SystemConfigDataRow);

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
                        FamFactoryDataSet.InitilizeDataSet(connection, set);
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
    }
}
