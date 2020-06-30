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
        public string Id
        {
            get { return internalDataRowView[PermissionsColumnNames.Id].ToString(); }
            set { internalDataRowView[PermissionsColumnNames.Id] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[PermissionsColumnNames.Name].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.Name] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public string Description
        {
            get { return internalDataRowView[PermissionsColumnNames.Description].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.Description] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool CanCreate
        {
            get { return (bool)internalDataRowView[PermissionsColumnNames.CanCreate]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.CanCreate] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool CanRead
        {
            get { return (bool)internalDataRowView[PermissionsColumnNames.CanRead]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.CanRead] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool CanWrite
        {
            get { return (bool)internalDataRowView[PermissionsColumnNames.CanWrite]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.CanWrite] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool CanDelete
        {
            get { return (bool)internalDataRowView[PermissionsColumnNames.Special]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.CanDelete] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool Special
        {
            get { return (bool)internalDataRowView[PermissionsColumnNames.Special]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.Special] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public Permission(DataRowView rowView, SQLiteConnection connection, User user) : base(rowView, connection, user)
        {

        }

        public static Permission newPermission(SQLiteConnection connection, DataView rowView, User user)
        {
            DataRowView row = rowView.AddNew();

            Permission permission = new Permission(row, connection, user);
            permission.Id = Guid.NewGuid().ToString();
            permission.Name = "New Permission";
            permission.Description = "";
            permission.CanRead = false;
            permission.CanWrite = false;
            permission.CanCreate = false;
            permission.CanDelete = false;
            permission.Special = false;
            return permission;
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
