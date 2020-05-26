using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class EmailProfile : ModelBase<EmailProfile>
    {
        public enum EmailProfileColumnNames { Id, Name, Description, ServerAddress, Port, SSL, Username, Password, State, CreatedById, ModifiedById, DateCreated, DateModified }

        public string Id
        {
            get { return InternalDataRowView[EmailProfileColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[EmailProfileColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return InternalDataRowView[EmailProfileColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return InternalDataRowView[EmailProfileColumnNames.Description.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ServerAddress
        {
            get { return InternalDataRowView[EmailProfileColumnNames.ServerAddress.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.ServerAddress.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int Port
        {
            get { return (int)InternalDataRowView[EmailProfileColumnNames.Port.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.Port.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool SSL
        {
            get { return (bool)InternalDataRowView[EmailProfileColumnNames.SSL.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.SSL.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Username
        {
            get { return InternalDataRowView[EmailProfileColumnNames.Username.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.Username.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Password
        {
            get { return InternalDataRowView[EmailProfileColumnNames.Password.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.Password.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public EntityStates State
        {
            get { return (EntityStates)InternalDataRowView[EmailProfileColumnNames.State.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CreatedById
        {
            get { return InternalDataRowView[EmailProfileColumnNames.CreatedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ModifiedById
        {
            get { return InternalDataRowView[EmailProfileColumnNames.ModifiedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public object DateCreated
        {
            get { return InternalDataRowView[EmailProfileColumnNames.ModifiedById.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public object DateModified
        {
            get { return InternalDataRowView[EmailProfileColumnNames.ModifiedById.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[EmailProfileColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public EmailProfile(DataRowView rowView) : base( rowView)
        {

        }

        public static EmailProfile NewEmailProfile(DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            EmailProfile emailprofile = new EmailProfile(row);
            emailprofile.Id = Guid.NewGuid().ToString();
            emailprofile.State = EntityStates.Enabled;
            return emailprofile;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EmailProfile))
                return false;

            return ((EmailProfile)obj).Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() & Name.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Name} : ({ServerAddress})";
        }
    }
}
