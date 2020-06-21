using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class SystemConfiguration : ModelBase<SystemConfiguration>
    {
        public enum SystemConfigurationTableColumnNames { Id, Name, CompanyAddress, Email, InstallLocation, AppVersion, DataBaseVersion, CreatedById, ModifiedById, DateCreated, DateModified, State }
        public string Id
        {
            get { return internalDataRowView[SystemConfigurationTableColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[SystemConfigurationTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[SystemConfigurationTableColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CompanyAddress
        {
            get { return internalDataRowView[SystemConfigurationTableColumnNames.CompanyAddress.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationTableColumnNames.CompanyAddress.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Email
        {
            get { return internalDataRowView[SystemConfigurationTableColumnNames.Email.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationTableColumnNames.Email.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string InstallLocataion
        {
            get { return internalDataRowView[SystemConfigurationTableColumnNames.InstallLocation.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationTableColumnNames.InstallLocation.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string AppVersion
        {
            get { return internalDataRowView[SystemConfigurationTableColumnNames.AppVersion.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationTableColumnNames.AppVersion.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string DataBaseVersion
        {
            get { return internalDataRowView[SystemConfigurationTableColumnNames.DataBaseVersion.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationTableColumnNames.DataBaseVersion.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[SystemConfigurationTableColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationTableColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public SystemConfiguration(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {
        }

        public static SystemConfiguration NewSystemConfiguration(SQLiteConnection connection, DataView view)
        {
            DataRowView row = view.AddNew();

            SystemConfiguration sysconfig = new SystemConfiguration(row, connection);
            sysconfig.Id = Guid.NewGuid().ToString();
            sysconfig.AppVersion = "1.0.0";
            sysconfig.DataBaseVersion = "1.0.0";
            return sysconfig;
        }

        public override void RefreshCollections()
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollections(string sortColumn, string filter)
        {
            throw new NotImplementedException();
        }
    }
}
