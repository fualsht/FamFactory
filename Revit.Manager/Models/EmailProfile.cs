using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
            get { return internalDataRowView[EmailProfileColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[EmailProfileColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[EmailProfileColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return internalDataRowView[EmailProfileColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ServerAddress
        {
            get { return internalDataRowView[EmailProfileColumnNames.ServerAddress.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.ServerAddress.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int Port
        {
            get { return (int)internalDataRowView[EmailProfileColumnNames.Port.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Port.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool SSL
        {
            get { return (bool)internalDataRowView[EmailProfileColumnNames.SSL.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.SSL.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Username
        {
            get { return internalDataRowView[EmailProfileColumnNames.Username.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Username.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Password
        {
            get { return internalDataRowView[EmailProfileColumnNames.Password.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Password.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[EmailProfileColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public EmailProfile(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {

        }

        public static EmailProfile NewEmailProfile(SQLiteConnection connection, DataView rowView, User user)
        {
            DataRowView row = rowView.AddNew();

            EmailProfile emailprofile = new EmailProfile(row, connection);
            emailprofile.Id = Guid.NewGuid().ToString();
            emailprofile.State = EntityStates.Enabled;
            emailprofile.DateCreated = DateTime.Now;
            emailprofile.DateModified = DateTime.Now;
            emailprofile.CreatedById = user.Id;
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
