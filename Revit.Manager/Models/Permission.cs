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
            get { return internalDataRowView[PermissionsColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[PermissionsColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[PermissionsColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public string Description
        {
            get { return internalDataRowView[PermissionsColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Create
        {
            get { return internalDataRowView[PermissionsColumnNames.CanCreate.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.CanCreate.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Read
        {
            get { return internalDataRowView[PermissionsColumnNames.CanRead.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.CanRead.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Write
        {
            get { return internalDataRowView[PermissionsColumnNames.CanWrite.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.CanWrite.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string CanDelete
        {
            get { return internalDataRowView[PermissionsColumnNames.Special.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.CanDelete.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Special
        {
            get { return internalDataRowView[PermissionsColumnNames.Special.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[PermissionsColumnNames.Special.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
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
