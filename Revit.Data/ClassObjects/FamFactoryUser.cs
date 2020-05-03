using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Data
{
    public enum UserColumnNames { Id, Name, UserImage, Username, FirstName, LastName, Email, Password, RegistrationDate }
    public class FamFactoryUser : FamFactoryDataObjectBase
    {
        public object UserImage
        {
            get
            {
                if (dataRowSource[UserColumnNames.UserImage.ToString()] == null || dataRowSource[UserColumnNames.UserImage.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[UserColumnNames.UserImage.ToString()];
            }
            set
            {
                dataRowSource[UserColumnNames.UserImage.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object Username
        {
            get
            {
                if (dataRowSource[UserColumnNames.Username.ToString()] == null || dataRowSource[UserColumnNames.Username.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[UserColumnNames.Username.ToString()];
            }
            set
            {
                dataRowSource[UserColumnNames.Username.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object FirstName
        {
            get
            {
                if (dataRowSource[UserColumnNames.FirstName.ToString()] == null || dataRowSource[UserColumnNames.FirstName.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[UserColumnNames.FirstName.ToString()];
            }
            set
            {
                dataRowSource[UserColumnNames.FirstName.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object LastName
        {
            get
            {
                if (dataRowSource[UserColumnNames.LastName.ToString()] == null || dataRowSource[UserColumnNames.LastName.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[UserColumnNames.LastName.ToString()];
            }
            set
            {
                dataRowSource[UserColumnNames.LastName.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object Email
        {
            get
            {
                if (dataRowSource[UserColumnNames.Email.ToString()] == null || dataRowSource[UserColumnNames.Email.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[UserColumnNames.Email.ToString()];
            }
            set
            {
                dataRowSource[UserColumnNames.Email.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object Password
        {
            get
            {
                if (dataRowSource[UserColumnNames.Password.ToString()] == null || dataRowSource[UserColumnNames.Password.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[UserColumnNames.Password.ToString()];
            }
            set
            {
                dataRowSource[UserColumnNames.Password.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object RegistrationDate
        {
            get
            {
                if (dataRowSource[UserColumnNames.RegistrationDate.ToString()] == null || dataRowSource[UserColumnNames.RegistrationDate.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[UserColumnNames.RegistrationDate.ToString()];
            }
            set
            {
                dataRowSource[UserColumnNames.RegistrationDate.ToString()] = value;
                NotifyPropertyChanged();
            }
        }

    }
}
