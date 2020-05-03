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
            InitilizeFamilyTemplatesTable(dataSet);
            InitilizeReferencePlaneTable(dataSet);
            InitilizeGeometryTable(dataSet);
            InitilizeParametersTable(dataSet);
        }

        private static void InitilizeEmailProfiles(DataSet dataSet)
        {
            DataTable EmailprofilesTable = new DataTable("FFEmailProfiles");
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

            //Email Profile
            DataRow EmailProfileDatarow = EmailprofilesTable.NewRow();
            EmailProfileDatarow[IdColumn.ColumnName] = Guid.NewGuid();
            EmailProfileDatarow[NameColumn.ColumnName] = "Admin";
            EmailProfileDatarow[DescriptionColumn.ColumnName] = "Admin permissions with full permissions.";
            EmailProfileDatarow[ServerColumn.ColumnName] = "mail.server.com";
            EmailProfileDatarow[PortColumn.ColumnName] = 25;
            EmailProfileDatarow[SSLColumn.ColumnName] = false;
            EmailProfileDatarow[UserNameColumn.ColumnName] = "";
            EmailProfileDatarow[PasswordColumn.ColumnName] = "";
            EmailProfileDatarow[StateColumn.ColumnName] = true;
            EmailprofilesTable.Rows.Add(EmailProfileDatarow);

            dataSet.Tables.Add(EmailprofilesTable);
        }

        private static void InitilizePermissions(DataSet dataSet)
        {
            DataTable permissionsTable = new DataTable("FFPermissions");
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
            DataTable usersTable = new DataTable("FFUsers");
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
            permissionIdColumn.DefaultValue = dataSet.Tables["FFPermissions"].Select("Name = 'Editor'").FirstOrDefault()["Id"];
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
            DataRelation dataRelation = new DataRelation("Users_PermissionId_Permissions_Id", dataSet.Tables["FFPermissions"].Columns["Id"], dataSet.Tables["FFUsers"].Columns["PermissionId"]);
            dataSet.Relations.Add(dataRelation);

            DataRow adminUserDataRow = usersTable.NewRow();
            adminUserDataRow[User.UsersTableColumnNames.Id.ToString()] = Guid.NewGuid();
            adminUserDataRow[User.UsersTableColumnNames.Name.ToString()] = "Admin";
            adminUserDataRow[User.UsersTableColumnNames.FirstName.ToString()] = "Admin";
            adminUserDataRow[User.UsersTableColumnNames.LastName.ToString()] = "";
            adminUserDataRow[User.UsersTableColumnNames.Email.ToString()] = "Admin@Comapny.com";
            adminUserDataRow[User.UsersTableColumnNames.Password.ToString()] = Utils.GetPasswordHash(SHA256.Create("SHA256"), "Password");
            adminUserDataRow[User.UsersTableColumnNames.ProfilePic.ToString()] = Utils.ImageToByte(Resources.UserIcon);
            adminUserDataRow[User.UsersTableColumnNames.PermissionId.ToString()] = dataSet.Tables["FFPermissions"].Select().FirstOrDefault(x => x["Name"].ToString() == "Admin")["Id"];
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
            testUserDataRow[User.UsersTableColumnNames.PermissionId.ToString()] = dataSet.Tables["FFPermissions"].Select().FirstOrDefault(x => x["Name"].ToString() == "Editor")["Id"];
            testUserDataRow[User.UsersTableColumnNames.LastLogInDate.ToString()] = DateTime.Now;
            testUserDataRow[User.UsersTableColumnNames.State.ToString()] = Manager.EntityStates.Enabled;
            testUserDataRow[User.UsersTableColumnNames.TempFolder.ToString()] = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FamFactory\\Temp";
            usersTable.Rows.Add(testUserDataRow);
        }

        private static void InitilizeSystemConfigurationTable(DataSet dataSet)
        {
            // System Configuration
            DataTable SysConfigTable = new DataTable("FFSysConfigs");
            DataColumn idColumn = SysConfigTable.Columns.Add("Id", typeof(string));
            idColumn.Caption = "Id";
            idColumn.AllowDBNull = false;
            idColumn.Unique = true;
            DataColumn nameColumn = SysConfigTable.Columns.Add("Name", typeof(string));
            nameColumn.Caption = "Comany Name";
            nameColumn.AllowDBNull = false;
            nameColumn.Unique = true;
            DataColumn addressColumn = SysConfigTable.Columns.Add("CompanyAddress", typeof(string));
            addressColumn.Caption = "Address";
            addressColumn.AllowDBNull = true;
            DataColumn emailColumn = SysConfigTable.Columns.Add("Email", typeof(string));
            emailColumn.AllowDBNull = false;
            emailColumn.Caption = "System Email";
            DataColumn installColumn = SysConfigTable.Columns.Add("InstallLocation", typeof(string));
            installColumn.Caption = "Installation Location";
            installColumn.AllowDBNull = true;
            DataColumn appVerColumn = SysConfigTable.Columns.Add("AppVersion", typeof(string));
            appVerColumn.Caption = "Application Version";
            appVerColumn.AllowDBNull = false;
            appVerColumn.DefaultValue = "1.0.0";
            DataColumn dbVersionColumn = SysConfigTable.Columns.Add("DataBaseVersion", typeof(string));
            dbVersionColumn.Caption = "Database Version";
            dbVersionColumn.AllowDBNull = false;
            dbVersionColumn.DefaultValue = "1.0.0";

            DataRow SystemConfigDataRow = SysConfigTable.NewRow();
            SystemConfigDataRow["Id"] = Guid.NewGuid();
            SystemConfigDataRow["Name"] = "<DefaultCompany>";
            SystemConfigDataRow["CompanyAddress"] = string.Empty;
            SystemConfigDataRow["Email"] = "admin@company.com";
            SystemConfigDataRow["InstallLocation"] = "C:\\programfiles\\FamFactory";
            SystemConfigDataRow["AppVersion"] = "1.0.0";
            SystemConfigDataRow["DataBaseVersion"] = "1.0.0";
            SysConfigTable.Rows.Add(SystemConfigDataRow);
            dataSet.Tables.Add(SysConfigTable);
        }

        private static void InitilizeFamilyTemplatesTable(DataSet dataSet)
        {
            DataTable FamilyTemplatesTable = new DataTable("FFTemplates");

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
            DataTable referencePlaneTable = new DataTable("FFReferencePlanes");
            DataColumn IdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";
            DataColumn NameColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New User";
            NameColumn.Unique = true;
            DataColumn RevitIdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.RevitId.ToString(), typeof(string));
            RevitIdColumn.AllowDBNull = false;
            RevitIdColumn.DefaultValue = "";
            DataColumn UniquColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.UniqueId.ToString(), typeof(string));
            UniquColumn.AllowDBNull = false;
            UniquColumn.DefaultValue = "";
            DataColumn LevelColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.LevelId.ToString(), typeof(string));
            LevelColumn.AllowDBNull = false;
            LevelColumn.DefaultValue = "";
            DataColumn ViewIdColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.ViewId.ToString(), typeof(string));
            ViewIdColumn.AllowDBNull = false;
            ViewIdColumn.DefaultValue = "";
            DataColumn CategoryColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.Category.ToString(), typeof(string));
            CategoryColumn.AllowDBNull = false;
            CategoryColumn.DefaultValue = "";
            DataColumn DirectionXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.DirectionX.ToString(), typeof(string));
            DirectionXColumn.AllowDBNull = false;
            DirectionXColumn.DefaultValue = "";
            DataColumn DirectionYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.DirectionY.ToString(), typeof(string));
            DirectionYColumn.AllowDBNull = false;
            DirectionYColumn.DefaultValue = "";
            DataColumn DirectionZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.DirectionZ.ToString(), typeof(string));
            DirectionZColumn.AllowDBNull = false;
            DirectionZColumn.DefaultValue = "";
            DataColumn LocationXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.LocationX.ToString(), typeof(string));
            LocationXColumn.AllowDBNull = false;
            LocationXColumn.DefaultValue = "";
            DataColumn LocationYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.LocationY.ToString(), typeof(string));
            LocationYColumn.AllowDBNull = false;
            LocationYColumn.DefaultValue = "";
            DataColumn LocationZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.LocationZ.ToString(), typeof(string));
            LocationZColumn.AllowDBNull = false;
            LocationZColumn.DefaultValue = "";
            DataColumn BubbleEndXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndX.ToString(), typeof(string));
            BubbleEndXColumn.AllowDBNull = false;
            BubbleEndXColumn.DefaultValue = "";
            DataColumn BubbleEndYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndY.ToString(), typeof(string));
            BubbleEndYColumn.AllowDBNull = false;
            BubbleEndYColumn.DefaultValue = "";
            DataColumn BubbleEndZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.BubbleEndZ.ToString(), typeof(string));
            BubbleEndZColumn.AllowDBNull = false;
            BubbleEndZColumn.DefaultValue = "";
            DataColumn NormalXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.NormalX.ToString(), typeof(string));
            NormalXColumn.AllowDBNull = false;
            NormalXColumn.DefaultValue = "";
            DataColumn NormalYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.NormalY.ToString(), typeof(string));
            NormalYColumn.AllowDBNull = false;
            NormalYColumn.DefaultValue = "";
            DataColumn NormalZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.NormalZ.ToString(), typeof(string));
            NormalZColumn.AllowDBNull = false;
            NormalZColumn.DefaultValue = "";
            DataColumn FreeEndXColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FreeEndX.ToString(), typeof(string));
            FreeEndXColumn.AllowDBNull = false;
            FreeEndXColumn.DefaultValue = "";
            DataColumn FreeEndYColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FreeEndY.ToString(), typeof(string));
            FreeEndYColumn.AllowDBNull = false;
            FreeEndYColumn.DefaultValue = "";
            DataColumn FreeEndZColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.FreeEndZ.ToString(), typeof(string));
            FreeEndZColumn.AllowDBNull = false;
            FreeEndZColumn.DefaultValue = "";
            DataColumn IsActiveColumn = referencePlaneTable.Columns.Add(ReferencePlane.ReferencePlaneTableColumnNames.IsActive.ToString(), typeof(bool));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = false;

            referencePlaneTable.PrimaryKey = new DataColumn[] { IdColumn, NameColumn };
            
            //Admin Level
            DataRow adminPermissionDatarow = referencePlaneTable.NewRow();
            adminPermissionDatarow["Id"] = Guid.NewGuid();
            adminPermissionDatarow["Name"] = "new";
            adminPermissionDatarow["RevitId"] = "";
            adminPermissionDatarow["UniqueId"] = "";
            adminPermissionDatarow["LevelId"] = "";
            adminPermissionDatarow["ViewId"] = "";
            adminPermissionDatarow["Category"] = "";
            adminPermissionDatarow["DirectionX"] = "";
            adminPermissionDatarow["DirectionY"] = "";
            adminPermissionDatarow["DirectionZ"] = "";
            adminPermissionDatarow["LocationX"] = "";
            adminPermissionDatarow["LocationY"] = "";
            adminPermissionDatarow["LocationZ"] = "";
            adminPermissionDatarow["BubbleEndX"] = "";
            adminPermissionDatarow["BubbleEndY"] = "";
            adminPermissionDatarow["BubbleEndZ"] = "";
            adminPermissionDatarow["NormalX"] = "";
            adminPermissionDatarow["NormalY"] = "";
            adminPermissionDatarow["NormalZ"] = "";
            adminPermissionDatarow["FreeEndX"] = "";
            adminPermissionDatarow["FreeEndY"] = "";
            adminPermissionDatarow["FreeEndZ"] = "";
            adminPermissionDatarow["IsActive"] = false;
            referencePlaneTable.Rows.Add(adminPermissionDatarow);
        }

        private static void InitilizeGeometryTable(DataSet dataSet)
        {
            DataTable GeometryTable = new DataTable("FFGeometry");

            DataColumn IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";

            DataColumn NameColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Name.ToString(), typeof(string));
            NameColumn.AllowDBNull = false;
            NameColumn.DefaultValue = "New Sweep";
            NameColumn.Unique = false;

            DataColumn DescriptionColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.Description.ToString(), typeof(string));
            DescriptionColumn.AllowDBNull = false;
            DescriptionColumn.DefaultValue = "New Sweep";
            NameColumn.Unique = false; 

            DataColumn GeometryTypeColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.GeometryType.ToString(), typeof(string));
            GeometryTypeColumn.AllowDBNull = false;
            GeometryTypeColumn.DefaultValue = "New Sweep";
            GeometryTypeColumn.Unique = false; 
            
            DataColumn MaterialIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.MaterialId.ToString(), typeof(string));
            MaterialIdColumn.AllowDBNull = false;
            MaterialIdColumn.DefaultValue = "New Sweep";
            MaterialIdColumn.Unique = false; 
            
            DataColumn IsActiveColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.IsActive.ToString(), typeof(string));
            IsActiveColumn.AllowDBNull = false;
            IsActiveColumn.DefaultValue = "New Sweep";
            IsActiveColumn.Unique = false;

            DataColumn ProfileFamily1IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily1Id.ToString(), typeof(string));
            ProfileFamily1IdColumn.AllowDBNull = false;
            ProfileFamily1IdColumn.DefaultValue = "New Sweep";
            ProfileFamily1IdColumn.Unique = false;

            DataColumn ProfileFamily2IdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.ProfileFamily2Id.ToString(), typeof(string));
            ProfileFamily2IdColumn.AllowDBNull = false;
            ProfileFamily2IdColumn.DefaultValue = "New Sweep";
            ProfileFamily2IdColumn.Unique = false; 
            
            DataColumn HostIdColumn = GeometryTable.Columns.Add(FamilyGeometry.FamilyGeometryColumnNames.HostId.ToString(), typeof(string));
            HostIdColumn.AllowDBNull = false;
            HostIdColumn.DefaultValue = "New Sweep";
            HostIdColumn.Unique = false;
            
            dataSet.Tables.Add(GeometryTable);
        }

        private static void InitilizeParametersTable(DataSet dataSet)
        {
            DataTable ParametersTable = new DataTable("FFParameters");

            DataColumn IdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.Id.ToString(), typeof(string));
            IdColumn.AllowDBNull = false;
            IdColumn.Unique = true;
            IdColumn.Caption = "Id";

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

            DataColumn ParamIdColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.ParamId.ToString(), typeof(string));
            ParamIdColumn.AllowDBNull = false;
            ParamIdColumn.DefaultValue = string.Empty;
            ParamIdColumn.Unique = false;

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

            DataColumn StorageTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.StorageType.ToString(), typeof(Autodesk.Revit.DB.StorageType));
            StorageTypeColumn.AllowDBNull = false;
            StorageTypeColumn.DefaultValue = Autodesk.Revit.DB.StorageType.None;
            StorageTypeColumn.Unique = false;

            DataColumn IsEditableColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.IsEditable.ToString(), typeof(bool));
            IsEditableColumn.AllowDBNull = false;
            //IsEditableColumn.DefaultValue = false;
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

            DataColumn BuiltInParamGroupColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.BuiltInParamGroup.ToString(), typeof(Autodesk.Revit.DB.BuiltInParameterGroup));
            BuiltInParamGroupColumn.AllowDBNull = false;
            BuiltInParamGroupColumn.DefaultValue = Autodesk.Revit.DB.BuiltInParameterGroup.INVALID;
            BuiltInParamGroupColumn.Unique = false;

            DataColumn ParameterTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.ParameterType.ToString(), typeof(Autodesk.Revit.DB.ParameterType));
            ParameterTypeColumn.AllowDBNull = false;
            ParameterTypeColumn.DefaultValue = Autodesk.Revit.DB.ParameterType.Text;
            ParameterTypeColumn.Unique = false;

            DataColumn UnitTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.UnitType.ToString(), typeof(Autodesk.Revit.DB.UnitType));
            UnitTypeColumn.AllowDBNull = false;
            UnitTypeColumn.DefaultValue = Autodesk.Revit.DB.UnitType.UT_Custom;
            UnitTypeColumn.Unique = false;
            
            DataColumn DisplayUnitTypeColumn = ParametersTable.Columns.Add(Parameter.ParameterColumnNames.DisplayUnitType.ToString(), typeof(Autodesk.Revit.DB.DisplayUnitType));
            DisplayUnitTypeColumn.AllowDBNull = false;
            DisplayUnitTypeColumn.DefaultValue = Autodesk.Revit.DB.DisplayUnitType.DUT_MILLIMETERS;
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
            FormulaColumn.AllowDBNull = false;
            FormulaColumn.DefaultValue = string.Empty;
            FormulaColumn.Unique = false;
               


            dataSet.Tables.Add(ParametersTable);
        }
    }
}
