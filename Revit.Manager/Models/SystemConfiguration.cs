﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class SystemConfiguration : ModelBase<SystemConfiguration>
    {
        public enum SystemConfigurationTableColumnNames { Id, Name, CompanyAddress, Email, InstallLocation, AppVersion, DataBaseVersion, CreatedById, ModifiedById, DateCreated, DateModified }
        public string Id
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[SystemConfigurationTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CompanyAddress
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.CompanyAddress.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.CompanyAddress.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Email
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.Email.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.Email.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string InstallLocataion
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.InstallLocation.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.InstallLocation.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string AppVersion
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.AppVersion.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.AppVersion.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string DataBaseVersion
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.DataBaseVersion.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.DataBaseVersion.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CreatedById
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.CreatedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.DataBaseVersion.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ModifiedBy
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.ModifiedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.DataBaseVersion.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public object DateCreated
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.DateCreated.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.DataBaseVersion.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public object DateModified
        {
            get { return InternalDataRowView[SystemConfigurationTableColumnNames.DateModified.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[SystemConfigurationTableColumnNames.DataBaseVersion.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public SystemConfiguration(DataRowView rowView) : base(rowView)
        {
        }

        public static SystemConfiguration NewSystemConfiguration(DataView view)
        {
            DataRowView row = view.AddNew();

            SystemConfiguration sysconfig = new SystemConfiguration(row);
            sysconfig.Id = Guid.NewGuid().ToString();
            sysconfig.AppVersion = "1.0.0";
            sysconfig.DataBaseVersion = "1.0.0";
            return sysconfig;
        }
    }
}
