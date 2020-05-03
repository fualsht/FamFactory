using System;
using System.Collections.Generic;
using System.Data;
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
            get { return InternalDataRowView[PermissionColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[PermissionColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return InternalDataRowView[PermissionColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[PermissionColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string Description
        {
            get { return InternalDataRowView[PermissionColumnNames.Description.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[PermissionColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Create
        {
            get { return InternalDataRowView[PermissionColumnNames.CanCreate.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[PermissionColumnNames.CanCreate.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Read
        {
            get { return InternalDataRowView[PermissionColumnNames.CanRead.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[PermissionColumnNames.CanRead.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Write
        {
            get { return InternalDataRowView[PermissionColumnNames.CanWrite.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[PermissionColumnNames.CanWrite.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CanDelete
        {
            get { return InternalDataRowView[PermissionColumnNames.Special.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[PermissionColumnNames.CanDelete.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Special
        {
            get { return InternalDataRowView[PermissionColumnNames.Special.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[PermissionColumnNames.Special.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public Permission(DataRowView rowView) : base(rowView)
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
    }
}
