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
        public string Id { get { return internalDataRowView[UsersColumnNames.Id.ToString()].ToString(); } 
            set { internalDataRowView[UsersColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }
        public string Name { get { return internalDataRowView[UsersColumnNames.Name.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); } }
        public string FirstName { get { return internalDataRowView[UsersColumnNames.FirstName.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersColumnNames.FirstName.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); } }
        public string LastName { get { return internalDataRowView[UsersColumnNames.LastName.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersColumnNames.LastName.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); } }
        public string Email { get { return internalDataRowView[UsersColumnNames.Email.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersColumnNames.Email.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); } }
        public string Password { get { return internalDataRowView[UsersColumnNames.Password.ToString()].ToString(); } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersColumnNames.Password.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); } }
        public object ProfilePic { get { return internalDataRowView[UsersColumnNames.ProfilePic.ToString()]; } 
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersColumnNames.ProfilePic.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); } }

        public string PermissionId { 
            get 
            {
                return internalDataRowView[UsersColumnNames.PermissionId.ToString()].ToString(); 
            }
            set
            {
                internalDataRowView[UsersColumnNames.PermissionId.ToString()] = value; 
                NotifyPropertyChanged(); NotifyValueChanged();
            }
        }

        public object LogInDate { get { return internalDataRowView[UsersColumnNames.LogInDate.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersColumnNames.LogInDate.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); } }

        public EntityStates State { get { return (EntityStates)internalDataRowView[UsersColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersColumnNames.State.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); } }

        public string TempFolder
        {
            get { return internalDataRowView[UsersColumnNames.TempFolder.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[UsersColumnNames.TempFolder.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
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
