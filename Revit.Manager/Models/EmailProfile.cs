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

        public string Id
        {
            get { return internalDataRowView[EmailProfileColumnNames.Id].ToString(); }
            set { internalDataRowView[EmailProfileColumnNames.Id] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[EmailProfileColumnNames.Name].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Name] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return internalDataRowView[EmailProfileColumnNames.Description].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Description] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ServerAddress
        {
            get { return internalDataRowView[EmailProfileColumnNames.ServerAddress].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.ServerAddress] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int Port
        {
            get { return (int)internalDataRowView[EmailProfileColumnNames.Port]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Port] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool SSL
        {
            get { return (bool)internalDataRowView[EmailProfileColumnNames.SSL]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.SSL] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Username
        {
            get { return internalDataRowView[EmailProfileColumnNames.Username].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Username] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Password
        {
            get { return internalDataRowView[EmailProfileColumnNames.Password].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.Password] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[EmailProfileColumnNames.State]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfileColumnNames.State] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
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
