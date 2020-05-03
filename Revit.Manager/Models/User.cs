using ModBox.FamFactory.Revit.Manager.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public enum EntityStates { Enabled, Disabled }
    public class User : ModelBase<User>
    {
        public enum UsersTableColumnNames { Id, Name, FirstName, LastName, Email, Password, ProfilePic, RegistrationDate, LastLogInDate, PermissionId, State, TempFolder }
        public string Id { get { return InternalDataRowView[UsersTableColumnNames.Id.ToString()].ToString(); } 
            set { InternalDataRowView[UsersTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }
        public string Name { get { return InternalDataRowView[UsersTableColumnNames.Name.ToString()].ToString(); } 
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public string FirstName { get { return InternalDataRowView[UsersTableColumnNames.FirstName.ToString()].ToString(); } 
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.FirstName.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public string LastName { get { return InternalDataRowView[UsersTableColumnNames.LastName.ToString()].ToString(); } 
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.LastName.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public string Email { get { return InternalDataRowView[UsersTableColumnNames.Email.ToString()].ToString(); } 
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.Email.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public string Password { get { return InternalDataRowView[UsersTableColumnNames.Password.ToString()].ToString(); } 
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.Password.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }
        public object ProfilePic { get { return InternalDataRowView[UsersTableColumnNames.ProfilePic.ToString()]; } 
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.ProfilePic.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public object RegistrationDate { get { return InternalDataRowView[UsersTableColumnNames.RegistrationDate.ToString()]; } 
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.RegistrationDate.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public Permission Permission { 
            get 
            {
                return UserPermissions.Where(x => x.Id == InternalDataRowView[UsersTableColumnNames.PermissionId.ToString()].ToString()).FirstOrDefault(); 
            }
            set
            {
                InternalDataRowView[UsersTableColumnNames.PermissionId.ToString()] = ((Permission)value).Id; 
                NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged");
            }
        }

        public object LastLogInDate { get { return InternalDataRowView[UsersTableColumnNames.LastLogInDate.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.LastLogInDate.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public EntityStates State { get { return (EntityStates)InternalDataRowView[UsersTableColumnNames.State.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public string TempFolder
        {
            get { return InternalDataRowView[UsersTableColumnNames.TempFolder.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[UsersTableColumnNames.TempFolder.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public ObservableCollection<Permission> UserPermissions 
        {
            get 
            {
                ObservableCollection<Permission> temp = new ObservableCollection<Permission>();
                foreach (DataRowView row in InternalDataRowView.Row.Table.DataSet.Tables["FFPermissions"].DefaultView)
                {
                    temp.Add(new Permission(row));
                }
                return temp;
            } 
        }


        public User(DataRowView rowView) : base(rowView)
        {
        }
        
        public static User NewUser(DataView rowView)
        {
            DataRowView row = rowView.AddNew();
            
            User user = new User(row);
            user.Id = Guid.NewGuid().ToString();
            user.ProfilePic = Utils.ImageToByte(Resources.UserIcon);
            user.RegistrationDate = DateTime.Now;
            user.State = EntityStates.Enabled;
            user.LastLogInDate = DateTime.Now;
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
    }
}
