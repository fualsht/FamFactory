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
        public string Id
        {
            get { return internalDataRowView[SystemConfigurationColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[SystemConfigurationColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[SystemConfigurationColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string CompanyAddress
        {
            get { return internalDataRowView[SystemConfigurationColumnNames.CompanyAddress.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationColumnNames.CompanyAddress.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Email
        {
            get { return internalDataRowView[SystemConfigurationColumnNames.Email.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationColumnNames.Email.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string InstallLocataion
        {
            get { return internalDataRowView[SystemConfigurationColumnNames.InstallLocation.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationColumnNames.InstallLocation.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string AppVersion
        {
            get { return internalDataRowView[SystemConfigurationColumnNames.AppVersion.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationColumnNames.AppVersion.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string DataBaseVersion
        {
            get { return internalDataRowView[SystemConfigurationColumnNames.DataBaseVersion.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationColumnNames.DataBaseVersion.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[SystemConfigurationColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[SystemConfigurationColumnNames.State.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public SystemConfiguration(DataRowView rowView, SQLiteConnection connection, User user) : base(rowView, connection, user)
        {
        }

        public static SystemConfiguration NewSystemConfiguration(SQLiteConnection connection, DataView view, User user)
        {
            DataRowView row = view.AddNew();

            SystemConfiguration sysconfig = new SystemConfiguration(row, connection, user);
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
