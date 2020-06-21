using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class Permission : ModelBase<Permission>
    {
        public enum PermissionColumnNames { Id, Name, Description, CanCreate, CanRead, CanWrite, CanDelete, Special }
        public string Id
        {
            get { return internalDataRowView[PermissionColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[PermissionColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[PermissionColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string Description
        {
            get { return internalDataRowView[PermissionColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Create
        {
            get { return internalDataRowView[PermissionColumnNames.CanCreate.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionColumnNames.CanCreate.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Read
        {
            get { return internalDataRowView[PermissionColumnNames.CanRead.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionColumnNames.CanRead.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Write
        {
            get { return internalDataRowView[PermissionColumnNames.CanWrite.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionColumnNames.CanWrite.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CanDelete
        {
            get { return internalDataRowView[PermissionColumnNames.Special.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionColumnNames.CanDelete.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Special
        {
            get { return internalDataRowView[PermissionColumnNames.Special.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionColumnNames.Special.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public Permission(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Permission))
                return false;

            return ((Permission)obj).Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
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
