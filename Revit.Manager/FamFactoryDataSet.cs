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
        private DataSet _FFDataSet; 
        public readonly System.Data.SQLite.SQLiteConnection connection;

        public DataSet FFDataSet { get { return _FFDataSet; } set { _FFDataSet = value; } }

        public FamFactoryDataSet(string filePath)
        {
            FFDataSet = new DataSet("FamFactoryDatabase");
            connection = new System.Data.SQLite.SQLiteConnection(Utils.GetSQlteConnection(filePath));
            Utils.CreateSQliteDataBase(filePath);
            Utils.ReadDataSet(connection, FFDataSet);
        }

        public static void InitilizeFamilyComponentTypesTable(DataSet dataSet)
        {
            //DataRow drow = FamilyComponentTypes.NewRow();
            //drow[FamilyComponentType.FamilyComponentTypesTableColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            //drow[FamilyComponentType.FamilyComponentTypesTableColumnNames.Name.ToString()] = "Doors";
            //drow[FamilyComponentType.FamilyComponentTypesTableColumnNames.Description.ToString()] = "";
            //drow[FamilyComponentType.FamilyComponentTypesTableColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.key);
            //FamilyComponentTypes.Rows.Add(drow);
            
            //DataRow drow1 = FamilyComponentTypes.NewRow();
            //drow1[FamilyComponentType.FamilyComponentTypesTableColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            //drow1[FamilyComponentType.FamilyComponentTypesTableColumnNames.Name.ToString()] = "Windows";
            //drow1[FamilyComponentType.FamilyComponentTypesTableColumnNames.Description.ToString()] = "";
            //drow1[FamilyComponentType.FamilyComponentTypesTableColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.key);
            //FamilyComponentTypes.Rows.Add(drow1);

            //DataRow drow2 = FamilyComponentTypes.NewRow();
            //drow2[FamilyComponentType.FamilyComponentTypesTableColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            //drow2[FamilyComponentType.FamilyComponentTypesTableColumnNames.Name.ToString()] = "Profiels";
            //drow2[FamilyComponentType.FamilyComponentTypesTableColumnNames.Description.ToString()] = "";
            //drow2[FamilyComponentType.FamilyComponentTypesTableColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.key);
            //FamilyComponentTypes.Rows.Add(drow2);

            //DataRow drow3 = FamilyComponentTypes.NewRow();
            //drow3[FamilyComponentType.FamilyComponentTypesTableColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            //drow3[FamilyComponentType.FamilyComponentTypesTableColumnNames.Name.ToString()] = "Tap";
            //drow3[FamilyComponentType.FamilyComponentTypesTableColumnNames.Description.ToString()] = "";
            //drow3[FamilyComponentType.FamilyComponentTypesTableColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.key);
            //FamilyComponentTypes.Rows.Add(drow3);

            //DataRow drow4 = FamilyComponentTypes.NewRow();
            //drow4[FamilyComponentType.FamilyComponentTypesTableColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            //drow4[FamilyComponentType.FamilyComponentTypesTableColumnNames.Name.ToString()] = "Plug";
            //drow4[FamilyComponentType.FamilyComponentTypesTableColumnNames.Description.ToString()] = "";
            //drow4[FamilyComponentType.FamilyComponentTypesTableColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.key);
            //FamilyComponentTypes.Rows.Add(drow4);

            //DataRow drow5 = FamilyComponentTypes.NewRow();
            //drow5[FamilyComponentType.FamilyComponentTypesTableColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            //drow5[FamilyComponentType.FamilyComponentTypesTableColumnNames.Name.ToString()] = "Waste Trap";
            //drow5[FamilyComponentType.FamilyComponentTypesTableColumnNames.Description.ToString()] = "";
            //drow5[FamilyComponentType.FamilyComponentTypesTableColumnNames.Thumbnail.ToString()] = Utils.ImageToByte(Resources.key);
            //FamilyComponentTypes.Rows.Add(drow5);
        }
        
        public static DataSet LoadDataSet(System.Data.SQLite.SQLiteConnection sqliteConnection, DataSet dSet = null)
        {
            //DataSet dataset;
            //if (dSet == null)
            //    dataset = DefaultDataSet();
            //else
            //    dataset = dSet;

            //System.Data.SQLite.SQLiteDataAdapter  sqlDataAdapter = new System.Data.SQLite.SQLiteDataAdapter(string.Format("Select * From {0}"), sqliteConnection);
            //using (System.Data.SQLite.SQLiteConnection con = sqlDataAdapter.SelectCommand.Connection)
            //{
            //    using (System.Data.SQLite.SQLiteCommand command = sqlDataAdapter.SelectCommand)
            //    {
            //        con.Open();
            //        using (System.Data.SQLite.SQLiteDataReader myReader = command.ExecuteReader())
            //        {
            //            dataset.Load(myReader, LoadOption.OverwriteChanges, new DataTable[] { });
            //            con.Close();
            //        }
            //    }
            //}
            throw new NotImplementedException();
        }

        public static void LoadDataTable(DataTable dataTable, System.Data.SQLite.SQLiteConnection sqliteConnection)
        {
            System.Data.SQLite.SQLiteDataAdapter sqlDataAdapter = new System.Data.SQLite.SQLiteDataAdapter(string.Format("Select * From {0}", dataTable.TableName), sqliteConnection);
            using (System.Data.SQLite.SQLiteConnection con = sqlDataAdapter.SelectCommand.Connection)
            {
                using (System.Data.SQLite.SQLiteCommand command = sqlDataAdapter.SelectCommand)
                {
                    con.Open();
                    using (System.Data.SQLite.SQLiteDataReader myReader = command.ExecuteReader())
                    {
                        dataTable.Load(myReader, LoadOption.OverwriteChanges);
                        con.Close();
                    }
                }
            }
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
            DataTable ParametersTable = dataSet.Tables[TableNames.FF_FamilyTemplateParameters.ToString()];
            DataRow ParametersRow = ParametersTable.NewRow();
            ParametersRow[Parameter.ParameterColumnNames.Id.ToString()] = Guid.NewGuid().ToString();
            ParametersRow[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            ParametersRow1[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            ParametersRow2[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            ParametersRow3[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            ParametersRow4[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            ParametersRow5[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            ParametersRow6[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            ParametersRow7[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            ParametersRow8[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            ParametersRow9[Parameter.ParameterColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
            DataTable referencePlaneTable = dataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()];
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
                DataTable geometryTable = dataSet.Tables[TableNames.FF_FamilyTemplateGeometry.ToString()];
                DataRow geometryDatarow = geometryTable.NewRow();
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.Id.ToString()] = Guid.NewGuid();
                geometryDatarow[FamilyGeometry.FamilyGeometryColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
                geometryDatarow1[FamilyGeometry.FamilyGeometryColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
                geometryDatarow2[FamilyGeometry.FamilyGeometryColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
                geometryDatarow3[FamilyGeometry.FamilyGeometryColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
                geometryDatarow4[FamilyGeometry.FamilyGeometryColumnNames.FamilyId.ToString()] = FamilyTemplateRow1[FamilyTemplate.ParameterColumnNames.Id.ToString()];
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
