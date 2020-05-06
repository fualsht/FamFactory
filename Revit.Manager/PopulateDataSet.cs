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
    public static class PopulateDataSet
    {
        public static void InitilizeDataSet(DataSet dataSet)
        {
            InitilizePermissions(dataSet);
            InitilizeEmailProfiles(dataSet);
            InitilizeSystemConfigurationTable(dataSet);
            InitilizeUsersTable(dataSet);
            InitilizeFamilyComponentTypesTable(dataSet);
            InitilizeFamilyComponentsTable(dataSet);
            InitilizeFamilyTemplatesTable(dataSet);
            InitilizeReferencePlaneTable(dataSet);
            InitilizeGeometryTable(dataSet);
            InitilizeParametersTable(dataSet);
            
            InstallSampleData(dataSet);
        }

        private static void InitilizeEmailProfiles(DataSet dataSet)
        {
            DataTable EmailprofilesTable = new DataTable(TableNames.FF_EmailProfiles.ToString());
            DataColumn IdColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";
            DataColumn NameColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New User";
            NameColumn.Unique = true;
            DataColumn DescriptionColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.Description.ToString(), typeof(string));
            DataColumn ServerColumn = EmailprofilesTable.Columns.Add(EmailProfile.EmailProfileColumnNames.ServerAddress.ToString(), typeof(string));
            ServerColumn.AllowDBNull = false;
            ServerColumn.DefaultValue = "mail.domain.com";
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

            EmailprofilesTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };

            dataSet.Tables.Add(EmailprofilesTable);
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

            permissionsTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };

            //Admin Level
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
            lastNameColumn.Caption = "Email";
            lastNameColumn.AllowDBNull = false;
            lastNameColumn.DefaultValue = "user@email.com";
            DataColumn passwordColumn = usersTable.Columns.Add(User.UsersTableColumnNames.Password.ToString(), typeof(string));
            lastNameColumn.Caption = "Passowrd";
            DataColumn profilePicColumn = usersTable.Columns.Add(User.UsersTableColumnNames.ProfilePic.ToString(), typeof(byte[]));
            lastNameColumn.Caption = "Profile Picture";
            lastNameColumn.AllowDBNull = false;
            lastNameColumn.DefaultValue = Utils.ImageToByte(Resources.UserIcon);
            DataColumn regColumn = usersTable.Columns.Add(User.UsersTableColumnNames.RegistrationDate.ToString(), typeof(DateTime));
            regColumn.Caption = "Registration Date";
            regColumn.AllowDBNull = false;
            regColumn.DefaultValue = DateTime.Now;
            DataColumn permissionIdColumn = usersTable.Columns.Add(User.UsersTableColumnNames.PermissionId.ToString(), typeof(string));
            permissionIdColumn.Caption = "Permission";
            permissionIdColumn.AllowDBNull = true;
            permissionIdColumn.DefaultValue = dataSet.Tables[TableNames.FF_Permissions.ToString()].Select("Name = 'Editor'").FirstOrDefault()["Id"];
            DataColumn lastLogInDateColumn = usersTable.Columns.Add(User.UsersTableColumnNames.LastLogInDate.ToString(), typeof(DateTime));
            lastNameColumn.Caption = "Last Login Date";
            DataColumn stateColumn = usersTable.Columns.Add(User.UsersTableColumnNames.State.ToString(), typeof(EntityStates));
            lastNameColumn.Caption = "State";
            lastNameColumn.AllowDBNull = false;
            lastNameColumn.DefaultValue = EntityStates.Enabled;
            DataColumn TempFolderColumn = usersTable.Columns.Add(User.UsersTableColumnNames.TempFolder.ToString(), typeof(string));
            TempFolderColumn.Caption = "Temp Folder";
            TempFolderColumn.AllowDBNull = false;
            TempFolderColumn.DefaultValue = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FamFactory\\Temp";

            //Create and add Primary Keys for Datatable
            usersTable.PrimaryKey = new DataColumn[] { IdColumn, nameColumn };
            // Add DataTable to DataSet befroe adding Datarelations.
            dataSet.Tables.Add(usersTable);
            //Create the DataRelation.
            DataRelation dataRelation = new DataRelation(TableRelations.PermissionsUserId_UsersId.ToString(), 
                dataSet.Tables[TableNames.FF_Permissions.ToString()].Columns["Id"], 
                dataSet.Tables[TableNames.FF_Users.ToString()].Columns[User.UsersTableColumnNames.PermissionId.ToString()]);
            dataSet.Relations.Add(dataRelation);
        }

        private static void InitilizeSystemConfigurationTable(DataSet dataSet)
        {
            // System Configuration
            DataTable SysConfigTable = new DataTable(TableNames.FF_SystemConfiguration.ToString());
            DataColumn idColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.Id.ToString(), typeof(string));
            idColumn.Caption = "Id";
            idColumn.AllowDBNull = false;
            idColumn.Unique = true;
            DataColumn nameColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.Name.ToString(), typeof(string));
            nameColumn.Caption = "Comany Name";
            nameColumn.AllowDBNull = false;
            nameColumn.Unique = true;
            DataColumn addressColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.CompanyAddress.ToString(), typeof(string));
            addressColumn.Caption = "Address";
            addressColumn.AllowDBNull = true;
            DataColumn emailColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.Email.ToString(), typeof(string));
            emailColumn.AllowDBNull = false;
            emailColumn.Caption = "System Email";
            DataColumn installColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.InstallLocataion.ToString(), typeof(string));
            installColumn.Caption = "Installation Location";
            installColumn.AllowDBNull = true;
            DataColumn appVerColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.AppVersion.ToString(), typeof(string));
            appVerColumn.Caption = "Application Version";
            appVerColumn.AllowDBNull = false;
            appVerColumn.DefaultValue = "1.0.0";
            DataColumn dbVersionColumn = SysConfigTable.Columns.Add(SystemConfiguration.SystemConfigurationTableColumnNames.DataBaseVersion.ToString(), typeof(string));
            dbVersionColumn.Caption = "Database Version";
            dbVersionColumn.AllowDBNull = false;
            dbVersionColumn.DefaultValue = "1.0.0";

            dataSet.Tables.Add(SysConfigTable);
        }

        public static void InitilizeFamilyComponentTypesTable(DataSet dataSet)
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

                dataSet.Tables.Add(FamilyComponentsTable);
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
            DescriptionColumn.AllowDBNull = false;
            DescriptionColumn.DefaultValue = string.Empty;
            DescriptionColumn.Unique = false;

            DataColumn IsReleasedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.IsReleased.ToString(), typeof(bool));
            IsReleasedColumn.AllowDBNull = false;
            IsReleasedColumn.DefaultValue = false;
            IsReleasedColumn.Unique = false;

            DataColumn FamilyCategoryColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.FamilyCategory.ToString(), typeof(string));
            FamilyCategoryColumn.AllowDBNull = false;
            FamilyCategoryColumn.DefaultValue = "Generic Model";
            FamilyCategoryColumn.Unique = false;

            DataColumn CanHostRebarColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.CanHostRebar.ToString(), typeof(bool));
            CanHostRebarColumn.AllowDBNull = false;
            CanHostRebarColumn.DefaultValue = false;
            CanHostRebarColumn.Unique = false;

            DataColumn RoundConnectorDimentionColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.RoundConnectorDimention.ToString(), typeof(string));
            RoundConnectorDimentionColumn.AllowDBNull = false;
            RoundConnectorDimentionColumn.DefaultValue = "Diameter";
            RoundConnectorDimentionColumn.Unique = false;

            DataColumn PartTypeColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.PartType.ToString(), typeof(string));
            PartTypeColumn.AllowDBNull = false;
            PartTypeColumn.DefaultValue = false;
            PartTypeColumn.Unique = false;

            DataColumn OmnoClassNumberColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.OmnoClassNumber.ToString(), typeof(string));
            OmnoClassNumberColumn.AllowDBNull = true;
            OmnoClassNumberColumn.Unique = false;

            DataColumn OmniClassTitleColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.OmniClassTitle.ToString(), typeof(string));
            OmniClassTitleColumn.AllowDBNull = true;
            OmniClassTitleColumn.Unique = false;

            DataColumn WorkPlaneBasedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.WorkPlaneBased.ToString(), typeof(bool));
            WorkPlaneBasedColumn.AllowDBNull = false;
            WorkPlaneBasedColumn.DefaultValue = false;
            WorkPlaneBasedColumn.Unique = false;

            DataColumn AlwaysVerticalColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.AlwaysVertical.ToString(), typeof(bool));
            AlwaysVerticalColumn.AllowDBNull = false;
            AlwaysVerticalColumn.DefaultValue = false;
            AlwaysVerticalColumn.Unique = false;

            DataColumn CutsWithVoidWhenLoadedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.CutsWithVoidWhenLoaded.ToString(), typeof(bool));
            CutsWithVoidWhenLoadedColumn.AllowDBNull = false;
            CutsWithVoidWhenLoadedColumn.DefaultValue = false;
            CutsWithVoidWhenLoadedColumn.Unique = false;

            DataColumn IsSharedColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.IsShared.ToString(), typeof(bool));
            IsSharedColumn.AllowDBNull = false;
            IsSharedColumn.DefaultValue = false;
            IsSharedColumn.Unique = false;

            DataColumn RoomCalculationPointColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.RoomCalculationPoint.ToString(), typeof(bool));
            RoomCalculationPointColumn.AllowDBNull = false;
            RoomCalculationPointColumn.DefaultValue = false;
            RoomCalculationPointColumn.Unique = false;

            DataColumn FileNameColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.FileName.ToString(), typeof(string));
            FileNameColumn.AllowDBNull = false;
            FileNameColumn.DefaultValue = "New File";
            FileNameColumn.Unique = false;

            DataColumn ThumbnailColumn = FamilyTemplatesTable.Columns.Add(FamilyTemplate.ParameterColumnNames.Thumbnail.ToString(), typeof(byte[]));
            ThumbnailColumn.AllowDBNull = false;
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

            dataSet.Tables.Add(FamilyTemplatesTable);
        }
        
        private static void InitilizeReferencePlaneTable(DataSet dataSet)
        {
            DataTable referencePlaneTable = new DataTable(TableNames.FF_ReferencePlanes.ToString());

            DataColumn IdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;

            DataColumn FamilyTemplateIdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FamilyTemplateId.ToString(), typeof(string));
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

            DataRelation ReferencePlanesDataRelation = new DataRelation(TableRelations.ReferencePlanesFamilyTemplateId_FamilyTemplatesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_ReferencePlanes.ToString()].Columns[ReferencePlane.ReferencePlaneTableColumnNames.FamilyTemplateId.ToString()]);
            dataSet.Relations.Add(ReferencePlanesDataRelation);
        }

        private static void InitilizeGeometryTable(DataSet dataSet)
        {
            DataTable GeometryTable = new DataTable(TableNames.FF_Geometry.ToString());

            DataColumn IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";

            DataColumn FamilyTemplateIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.FamilyTemplateId.ToString(), typeof(string));
            FamilyTemplateIdColumn.AllowDBNull = false;
            FamilyTemplateIdColumn.Unique = false;

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

            DataRelation geometryDataRelation = new DataRelation(TableRelations.GeometryFamilyTemplateid_FamilyTemplateId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_Geometry.ToString()].Columns[FamilyGeometry.FamilyGeometryColumnNames.FamilyTemplateId.ToString()]);
            dataSet.Relations.Add(geometryDataRelation);
        }

        private static void InitilizeParametersTable(DataSet dataSet)
        {
            DataTable ParametersTable = new DataTable(TableNames.FF_Parameters.ToString());

            DataColumn IdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";

            DataColumn FamilyTemplateIdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.FamilyTemplateId.ToString(), typeof(string));
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

            DataRelation parametersDataRelation = new DataRelation(TableRelations.ParametersFamilyTemplateId_FamilyTemplatesId.ToString(),
                dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].Columns["Id"],
                dataSet.Tables[TableNames.FF_Parameters.ToString()].Columns[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()]);
            dataSet.Relations.Add(parametersDataRelation);
        }

        private static void InstallSampleData(DataSet dataSet)
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

            DataRow testUserDataRow = usersTable.NewRow();
            testUserDataRow[User.UsersTableColumnNames.Id.ToString()] = Guid.NewGuid();
            testUserDataRow[User.UsersTableColumnNames.Name.ToString()] = "User";
            testUserDataRow[User.UsersTableColumnNames.FirstName.ToString()] = "User";
            testUserDataRow[User.UsersTableColumnNames.LastName.ToString()] = "";
            testUserDataRow[User.UsersTableColumnNames.Email.ToString()] = "user@company.com";
            testUserDataRow[User.UsersTableColumnNames.Password.ToString()] = "Password";
            testUserDataRow[User.UsersTableColumnNames.ProfilePic.ToString()] = Utils.ImageToByte(Resources.UserIcon);
            testUserDataRow[User.UsersTableColumnNames.PermissionId.ToString()] = dataSet.Tables[TableNames.FF_Permissions.ToString()].Select("Name = 'Editor'").FirstOrDefault()["Id"];
            testUserDataRow[User.UsersTableColumnNames.LastLogInDate.ToString()] = DateTime.Now;
            testUserDataRow[User.UsersTableColumnNames.State.ToString()] = Manager.EntityStates.Enabled;
            testUserDataRow[User.UsersTableColumnNames.TempFolder.ToString()] = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FamFactory\\Temp";
            usersTable.Rows.Add(testUserDataRow);

            // System Configuration
            DataTable SysConfigTable = dataSet.Tables[TableNames.FF_SystemConfiguration.ToString()];
            DataRow SystemConfigDataRow = SysConfigTable.NewRow();
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.Id.ToString()] = Guid.NewGuid();
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.Name.ToString()] = "<DefaultCompany>";
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.CompanyAddress.ToString()] = string.Empty;
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.Email.ToString()] = "admin@company.com";
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.InstallLocataion.ToString()] = "C:\\programfiles\\FamFactory";
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.AppVersion.ToString()] = "v.1.0.0";
            SystemConfigDataRow[SystemConfiguration.SystemConfigurationTableColumnNames.DataBaseVersion.ToString()] = "v.1.0.0";
            SysConfigTable.Rows.Add(SystemConfigDataRow);

            // FamilyTemplates
            DataTable FamilyTemplatesTable = dataSet.Tables[TableNames.FF_FamilyTemplates.ToString()];
            DataRow FamilyTemplateRow1 = FamilyTemplatesTable.NewRow();
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Name.ToString()] = "New Family Template";
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Description.ToString()] = "";
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.IsReleased.ToString()] = true;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.FamilyCategory.ToString()] = "New Category";
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.CanHostRebar.ToString()] = false;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.RoundConnectorDimention.ToString()] = 0;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.PartType.ToString()] = "";
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.OmnoClassNumber.ToString()] = "";
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.OmniClassTitle.ToString()] = "";
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.WorkPlaneBased.ToString()] = true;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.AlwaysVertical.ToString()] = false;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.CutsWithVoidWhenLoaded.ToString()] = false;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.IsShared.ToString()] = false;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.RoomCalculationPoint.ToString()] = false;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.FileName.ToString()] = "file.rfa";
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Thumbnail.ToString()] = new byte[byte.MinValue];
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Version.ToString()] = "v.1.0.0";
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.FileSize.ToString()] = 300240;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.DateCreated.ToString()] = DateTime.Now;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.DateModified.ToString()] = DateTime.Now;
            FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.FamilyFile.ToString()] = new byte[byte.MinValue];
            FamilyTemplatesTable.Rows.Add(FamilyTemplateRow1);

            // Parameters
            DataTable ParametersTable = dataSet.Tables[TableNames.FF_Parameters.ToString()];
            DataRow ParametersRow = ParametersTable.NewRow();
            ParametersRow[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter1";
            ParametersRow[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow);

            DataRow ParametersRow1 = ParametersTable.NewRow();
            ParametersRow1[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow1[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow1[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter2";
            ParametersRow1[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow1[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow1[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow1[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow1[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow1[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow1[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow1[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow1[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow1[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow1[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow1[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow1[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow1[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow1[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow1[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow1[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow1[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow1);

            DataRow ParametersRow2 = ParametersTable.NewRow();
            ParametersRow2[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow2[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow2[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter3";
            ParametersRow2[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow2[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow2[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow2[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow2[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow2[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow2[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow2[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow2[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow2[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow2[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow2[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow2[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow2[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow2[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow2[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow2[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow2[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow2);

            DataRow ParametersRow3 = ParametersTable.NewRow();
            ParametersRow3[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow3[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow3[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter4";
            ParametersRow3[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow3[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow3[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow3[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow3[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow3[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow3[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow3[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow3[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow3[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow3[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow3[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow3[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow3[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow3[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow3[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow3[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow3[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow3);

            DataRow ParametersRow4 = ParametersTable.NewRow();
            ParametersRow4[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow4[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow4[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter5";
            ParametersRow4[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow4[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow4[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow4[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow4[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow4[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow4[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow4[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow4[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow4[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow4[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow4[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow4[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow4[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow4[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow4[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow4[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow4[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow4);

            DataRow ParametersRow5 = ParametersTable.NewRow();
            ParametersRow5[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow5[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow5[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter6";
            ParametersRow5[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow5[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow5[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow5[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow5[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow5[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow5[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow5[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow5[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow5[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow5[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow5[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow5[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow5[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow5[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow5[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow5[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow5[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow5);

            DataRow ParametersRow6 = ParametersTable.NewRow();
            ParametersRow6[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow6[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow6[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter7";
            ParametersRow6[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow6[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow6[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow6[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow6[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow6[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow6[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow6[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow6[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow6[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow6[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow6[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow6[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow6[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow6[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow6[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow6[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow6[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow6);

            DataRow ParametersRow7 = ParametersTable.NewRow();
            ParametersRow7[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow7[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow7[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter8";
            ParametersRow7[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow7[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow7[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow7[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow7[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow7[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow7[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow7[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow7[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow7[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow7[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow7[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow7[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow7[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow7[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow7[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow7[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow7[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow7);

            DataRow ParametersRow8 = ParametersTable.NewRow();
            ParametersRow8[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow8[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow8[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter9";
            ParametersRow8[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow8[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow8[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow8[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow8[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow8[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow8[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow8[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow8[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow8[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow8[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow8[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow8[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow8[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow8[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow8[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow8[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow8[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow8);

            DataRow ParametersRow9 = ParametersTable.NewRow();
            ParametersRow9[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow9[Parameter.ParameterColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ParametersRow9[Parameter.ParameterColumnNames.Name.ToString()] = "NewParameter10";
            ParametersRow9[Parameter.ParameterColumnNames.ElementId.ToString()] = 0;
            ParametersRow9[Parameter.ParameterColumnNames.ElementGUID.ToString()] = Guid.NewGuid();
            ParametersRow9[Parameter.ParameterColumnNames.HasValue.ToString()] = false;
            ParametersRow9[Parameter.ParameterColumnNames.IsReadOnly.ToString()] = false;
            ParametersRow9[Parameter.ParameterColumnNames.IsShared.ToString()] = false;
            ParametersRow9[Parameter.ParameterColumnNames.IsInstance.ToString()] = false;
            ParametersRow9[Parameter.ParameterColumnNames.StorageType.ToString()] = 3;
            ParametersRow9[Parameter.ParameterColumnNames.IsEditable.ToString()] = false;
            ParametersRow9[Parameter.ParameterColumnNames.IsActive.ToString()] = true;
            ParametersRow9[Parameter.ParameterColumnNames.HostId.ToString()] = Guid.NewGuid().ToString();
            ParametersRow9[Parameter.ParameterColumnNames.IsReporting.ToString()] = false;
            ParametersRow9[Parameter.ParameterColumnNames.BuiltInParamGroup.ToString()] = -1;
            ParametersRow9[Parameter.ParameterColumnNames.ParameterType.ToString()] = 1;
            ParametersRow9[Parameter.ParameterColumnNames.UnitType.ToString()] = -1;
            ParametersRow9[Parameter.ParameterColumnNames.DisplayUnitType.ToString()] = 2;
            ParametersRow9[Parameter.ParameterColumnNames.UserModifiable.ToString()] = false;
            ParametersRow9[Parameter.ParameterColumnNames.IsDeterminedByFormula.ToString()] = false;
            ParametersRow9[Parameter.ParameterColumnNames.Formula.ToString()] = "N/A";
            ParametersTable.Rows.Add(ParametersRow9);

            // Reference Plane
            DataTable referencePlaneTable = dataSet.Tables[TableNames.FF_ReferencePlanes.ToString()];
            DataRow ReferencePlaneDatarow = referencePlaneTable.NewRow();
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString()] = Guid.NewGuid();
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.Name.ToString()] = "NewReferencePlane1";
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.ElementId.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.UniqueId.ToString()] = "";
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.LevelId.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.ViewId.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.Category.ToString()] = "";
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.DirectionX.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.DirectionY.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.DirectionZ.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndX.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndY.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndZ.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.NormalX.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.NormalY.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.NormalZ.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndX.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndY.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndZ.ToString()] = 0;
            ReferencePlaneDatarow[ReferencePlane.ReferencePlaneTableColumnNames.IsActive.ToString()] = true;
            referencePlaneTable.Rows.Add(ReferencePlaneDatarow);

            DataRow ReferencePlaneDatarow1 = referencePlaneTable.NewRow();
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString()] = Guid.NewGuid();
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.Name.ToString()] = "NewReferencePlane2";
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.ElementId.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.UniqueId.ToString()] = "";
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.LevelId.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.ViewId.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.Category.ToString()] = "";
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.DirectionX.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.DirectionY.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.DirectionZ.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndX.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndY.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndZ.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.NormalX.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.NormalY.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.NormalZ.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndX.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndY.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndZ.ToString()] = 0;
            ReferencePlaneDatarow1[ReferencePlane.ReferencePlaneTableColumnNames.IsActive.ToString()] = true;
            referencePlaneTable.Rows.Add(ReferencePlaneDatarow1);

            DataRow ReferencePlaneDatarow2 = referencePlaneTable.NewRow();
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString()] = Guid.NewGuid();
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.Name.ToString()] = "NewReferencePlane1";
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.ElementId.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.UniqueId.ToString()] = "";
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.LevelId.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.ViewId.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.Category.ToString()] = "";
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.DirectionX.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.DirectionY.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.DirectionZ.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndX.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndY.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndZ.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.NormalX.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.NormalY.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.NormalZ.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndX.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndY.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndZ.ToString()] = 0;
            ReferencePlaneDatarow2[ReferencePlane.ReferencePlaneTableColumnNames.IsActive.ToString()] = true;
            referencePlaneTable.Rows.Add(ReferencePlaneDatarow2);

            DataRow ReferencePlaneDatarow3 = referencePlaneTable.NewRow();
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString()] = Guid.NewGuid();
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.Name.ToString()] = "NewReferencePlane1";
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.ElementId.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.UniqueId.ToString()] = "";
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.LevelId.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.ViewId.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.Category.ToString()] = "";
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.DirectionX.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.DirectionY.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.DirectionZ.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndX.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndY.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndZ.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.NormalX.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.NormalY.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.NormalZ.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndX.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndY.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndZ.ToString()] = 0;
            ReferencePlaneDatarow3[ReferencePlane.ReferencePlaneTableColumnNames.IsActive.ToString()] = true;
            referencePlaneTable.Rows.Add(ReferencePlaneDatarow3);

            DataRow ReferencePlaneDatarow4 = referencePlaneTable.NewRow();
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString()] = Guid.NewGuid();
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.Name.ToString()] = "NewReferencePlane1";
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.ElementId.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.UniqueId.ToString()] = "";
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.LevelId.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.ViewId.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.Category.ToString()] = "";
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.DirectionX.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.DirectionY.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.DirectionZ.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndX.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndY.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndZ.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.NormalX.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.NormalY.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.NormalZ.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndX.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndY.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.FreeEndZ.ToString()] = 0;
            ReferencePlaneDatarow4[ReferencePlane.ReferencePlaneTableColumnNames.IsActive.ToString()] = true;
            referencePlaneTable.Rows.Add(ReferencePlaneDatarow4);

            // Geometry
            try
            {
                DataTable geometryTable = dataSet.Tables[TableNames.FF_Geometry.ToString()];
                DataRow geometryDatarow = geometryTable.NewRow();
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Id.ToString()] = Guid.NewGuid();
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Name.ToString()] = "NewReferencePlane1";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ElementId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Description.ToString()] = "";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.GeometryType.ToString()] = "Sweep";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.MaterialId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsActive.ToString()] = true;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily1Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily2Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.HostId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Category.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.SubCategory.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.UniqueId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.LevelId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsSolid.ToString()] = -1;
                geometryTable.Rows.Add(geometryDatarow);

                DataRow geometryDatarow1 = geometryTable.NewRow();
                geometryDatarow1[FamilyGeometry.FamilyGeometryColumnNames.Id.ToString()] = Guid.NewGuid();
                geometryDatarow1[FamilyGeometry.FamilyGeometryColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
                geometryDatarow1[FamilyGeometry.FamilyGeometryColumnNames.Name.ToString()] = "NewReferencePlane2";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ElementId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Description.ToString()] = "";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.GeometryType.ToString()] = "Sweep";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.MaterialId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsActive.ToString()] = true;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily1Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily2Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.HostId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Category.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.SubCategory.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.UniqueId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.LevelId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsSolid.ToString()] = true;
                geometryTable.Rows.Add(geometryDatarow1);

                DataRow geometryDatarow2 = geometryTable.NewRow();
                geometryDatarow2[FamilyGeometry.FamilyGeometryColumnNames.Id.ToString()] = Guid.NewGuid();
                geometryDatarow2[FamilyGeometry.FamilyGeometryColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ElementId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Description.ToString()] = "";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.GeometryType.ToString()] = "Sweep";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.MaterialId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsActive.ToString()] = true;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily1Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily2Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.HostId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Category.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.SubCategory.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.UniqueId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.LevelId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsSolid.ToString()] = true;
                geometryTable.Rows.Add(geometryDatarow2);

                DataRow geometryDatarow3 = geometryTable.NewRow();
                geometryDatarow3[FamilyGeometry.FamilyGeometryColumnNames.Id.ToString()] = Guid.NewGuid();
                geometryDatarow3[FamilyGeometry.FamilyGeometryColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
                geometryDatarow3[FamilyGeometry.FamilyGeometryColumnNames.Name.ToString()] = "NewReferencePlane4";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ElementId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Description.ToString()] = "";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.GeometryType.ToString()] = "Sweep";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.MaterialId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsActive.ToString()] = true;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily1Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily2Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.HostId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Category.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.SubCategory.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.UniqueId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.LevelId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsSolid.ToString()] = true;
                geometryTable.Rows.Add(geometryDatarow3);

                DataRow geometryDatarow4 = geometryTable.NewRow();
                geometryDatarow4[FamilyGeometry.FamilyGeometryColumnNames.Id.ToString()] = Guid.NewGuid();
                geometryDatarow4[FamilyGeometry.FamilyGeometryColumnNames.FamilyTemplateId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
                geometryDatarow4[FamilyGeometry.FamilyGeometryColumnNames.Name.ToString()] = "NewReferencePlane5";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ElementId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Description.ToString()] = "";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.GeometryType.ToString()] = "Sweep";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.MaterialId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsActive.ToString()] = true;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily1Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily2Id.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.HostId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Category.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.SubCategory.ToString()] = "Default Category";
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.UniqueId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.LevelId.ToString()] = -1;
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.IsSolid.ToString()] = true;
                geometryTable.Rows.Add(geometryDatarow4);
            }
            catch (Exception e)
            {
                string s = "";
            }
        }
    }
}
