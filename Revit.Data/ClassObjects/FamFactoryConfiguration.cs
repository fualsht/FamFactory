using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace ModBox.FamFactory.Revit.Data
{
    public enum ConfigurationColumnNames { Id, Name, Address, SystemEmail, InstallationDate, EmailProfile, EmailProfileId }
    public class FamFactoryConfiguration : FamFactoryDataObjectBase
    {
        public object Address
        {
            get
            {
                if (dataRowSource[ConfigurationColumnNames.Address.ToString()] == null || dataRowSource[ConfigurationColumnNames.Address.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[ConfigurationColumnNames.Address.ToString()];
            }
            set
            {
                dataRowSource[ConfigurationColumnNames.Address.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object SystemEmail
        {
            get
            {
                if (dataRowSource[ConfigurationColumnNames.SystemEmail.ToString()] == null || dataRowSource[ConfigurationColumnNames.SystemEmail.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[ConfigurationColumnNames.SystemEmail.ToString()];
            }
            set
            {
                dataRowSource[ConfigurationColumnNames.SystemEmail.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object InstallationDate
        {
            get
            {
                if (dataRowSource[ConfigurationColumnNames.InstallationDate.ToString()] == null || dataRowSource[ConfigurationColumnNames.InstallationDate.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[InstallationDate.ToString()];
            }
            set
            {
                dataRowSource[ConfigurationColumnNames.InstallationDate.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object EmailProfile
        {
            get
            {
                if (dataRowSource[ConfigurationColumnNames.EmailProfile.ToString()] == null || dataRowSource[ConfigurationColumnNames.EmailProfile.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[ConfigurationColumnNames.EmailProfile.ToString()];
            }
            set
            {
                dataRowSource[ConfigurationColumnNames.EmailProfile.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
        public object EmailProfileId
        {
            get
            {
                if (dataRowSource[ConfigurationColumnNames.EmailProfileId.ToString()] == null || dataRowSource[ConfigurationColumnNames.EmailProfileId.ToString()] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource[ConfigurationColumnNames.EmailProfileId.ToString()];
            }
            set
            {
                dataRowSource[ConfigurationColumnNames.EmailProfileId.ToString()] = value;
                NotifyPropertyChanged();
            }
        }
    }
}
