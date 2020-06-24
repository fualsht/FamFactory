using ModBox.FamFactory.Revit.Manager.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    
    public class User : ModelBase<User>
    {
        public string Id { get { return internalDataRowView[UsersTableColumnNames.Id.ToString()].ToString(); } 
            set { internalDataRowView[UsersTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }
        public string Name { get { return internalDataRowView[UsersTableColumnNames.Name.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public string FirstName { get { return internalDataRowView[UsersTableColumnNames.FirstName.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersTableColumnNames.FirstName.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public string LastName { get { return internalDataRowView[UsersTableColumnNames.LastName.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersTableColumnNames.LastName.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public string Email { get { return internalDataRowView[UsersTableColumnNames.Email.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersTableColumnNames.Email.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public string Password { get { return internalDataRowView[UsersTableColumnNames.Password.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersTableColumnNames.Password.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public object ProfilePic { get { return internalDataRowView[UsersTableColumnNames.ProfilePic.ToString()]; } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersTableColumnNames.ProfilePic.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public string PermissionId { 
            get 
            {
                return internalDataRowView[UsersTableColumnNames.PermissionId.ToString()].ToString(); 
            }
            set
            {
                internalDataRowView[UsersTableColumnNames.PermissionId.ToString()] = value; 
                NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged");
            }
        }

        public object LogInDate { get { return internalDataRowView[UsersTableColumnNames.LogInDate.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersTableColumnNames.LogInDate.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public EntityStates State { get { return (EntityStates)internalDataRowView[UsersTableColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersTableColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public string TempFolder
        {
            get { return internalDataRowView[UsersTableColumnNames.TempFolder.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersTableColumnNames.TempFolder.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public User(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {
        }
        
        public static User NewUser(SQLiteConnection connection, DataView rowView)
        {
            DataRowView row = rowView.AddNew();
            
            User user = new User(row, connection);
            user.Id = Guid.NewGuid().ToString();
            user.ProfilePic = Utils.ImageToByte(Resources.UserIcon);
            user.DateCreated = DateTime.Now;
            user.State = EntityStates.Enabled;
            user.LogInDate = DateTime.Now;
            user.DateCreated = DateTime.Now;
            user.DateModified = DateTime.Now;
            user.State = EntityStates.Enabled;
            return user;
        }

        public bool isUsernameValid()
        {
            bool isValid = true;

            if (Name.Length < 6)
                isValid = false;

            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(Name))
                isValid = false;

            return isValid;
        }

        public bool InputEmailValid()
        {
            string tempEmail = Email;

            if (string.IsNullOrWhiteSpace(tempEmail.ToString()))
                return false;
            
            try
            {
                // Normalize the domain
                tempEmail = Regex.Replace(tempEmail.ToString(), @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(tempEmail.ToString(),
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User))
                return false;

            return ((User)obj).Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() & Name.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Name} : ({FirstName} {LastName})";
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
