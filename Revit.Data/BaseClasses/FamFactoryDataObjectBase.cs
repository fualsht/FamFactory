using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace ModBox.FamFactory.Revit.Data
{
    public abstract class FamFactoryDataObjectBase : IFamFactory
    {
        internal DataRow dataRowSource;
        public object Id
        {
            get
            {
                if (dataRowSource["Id"] == null || dataRowSource["Id"] is DBNull)
                    return string.Empty;
                else
                    return dataRowSource["Id"];
            }
            set
            {
                dataRowSource["Id"] = value;
            }
        }

        

        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; NotifyPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        internal protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
