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
            get { return internalDataRowView[EmailProfilesColumnNames.Id].ToString(); }
            set { internalDataRowView[EmailProfilesColumnNames.Id] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[EmailProfilesColumnNames.Name].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfilesColumnNames.Name] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Description
        {
            get { return internalDataRowView[EmailProfilesColumnNames.Description].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfilesColumnNames.Description] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string ServerAddress
        {
            get { return internalDataRowView[EmailProfilesColumnNames.ServerAddress].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfilesColumnNames.ServerAddress] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int Port
        {
            get { return (int)internalDataRowView[EmailProfilesColumnNames.Port]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfilesColumnNames.Port] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool SSL
        {
            get { return (bool)internalDataRowView[EmailProfilesColumnNames.SSL]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfilesColumnNames.SSL] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Username
        {
            get { return internalDataRowView[EmailProfilesColumnNames.Username].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfilesColumnNames.Username] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Password
        {
            get { return internalDataRowView[EmailProfilesColumnNames.Password].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfilesColumnNames.Password] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[EmailProfilesColumnNames.State]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[EmailProfilesColumnNames.State] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }


        public EmailProfile(DataRowView rowView, SQLiteConnection connection, User user) : base(rowView, connection, user)
        {
        }

        public static EmailProfile NewEmailProfile(SQLiteConnection connection, DataView rowView, User user)
        {
            DataRowView row = rowView.AddNew();

            EmailProfile emailprofile = new EmailProfile(row, connection, user);
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
