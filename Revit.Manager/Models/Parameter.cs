using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class Parameter : ModelBase<Parameter>
    {
        

        public string Id
        {
            get { return internalDataRowView[ParameterColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[ParameterColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }

        public string FamilyId
        {
            get { return internalDataRowView[ParameterColumnNames.FamilyId.ToString()].ToString(); }
            set { internalDataRowView[ParameterColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); }
        }

        public string Name
        {
            get { return internalDataRowView[ParameterColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ElementId
        {
            get { return (int)internalDataRowView[ParameterColumnNames.ElementId.ToString()]; }
            set 
            {
                internalDataRowView.BeginEdit();
                internalDataRowView[ParameterColumnNames.ElementId.ToString()] = (int)value;
                NotifyPropertyChanged(); _ValuesChanged = true; 
                NotifyPropertyChanged("ValuesChanged");
            }
        }
        public string ElementGUID
        {
            get { return internalDataRowView[ParameterColumnNames.ElementGUID.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.ElementGUID.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool HasValue
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.HasValue.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.HasValue.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsReadOnly
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.IsReadOnly.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.IsReadOnly.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsShared
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.IsShared.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsInstance
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.IsInstance.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.IsInstance.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int StorageType
        {
            get { return (int)internalDataRowView[ParameterColumnNames.StorageType.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.StorageType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsEditable
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.IsEditable.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.IsEditable.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsActive
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.IsActive.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string HostId
        {
            get { return internalDataRowView[ParameterColumnNames.HostId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.HostId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsReporting
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.IsReporting.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.IsReporting.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int BuiltInParamGroup
        {
            get { return (int)internalDataRowView[ParameterColumnNames.BuiltInParamGroup.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.BuiltInParamGroup.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public int ParameterType
        {
            get { return (int)internalDataRowView[ParameterColumnNames.ParameterType.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.ParameterType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int UnitType
        {
            get { return (int)internalDataRowView[ParameterColumnNames.UnitType.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.UnitType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int DisplayUnitType
        {
            get { return (int)internalDataRowView[ParameterColumnNames.DisplayUnitType.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.DisplayUnitType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool UserModifiable
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.UserModifiable.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.UnitType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsDeterminedByFormula
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.IsDeterminedByFormula.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.UnitType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Formula
        {
            get { return internalDataRowView[ParameterColumnNames.Formula.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.Formula.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public Parameter(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {

        }

        public static Parameter newParameter(SQLiteConnection connection, DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            Parameter parameter = new Parameter(row, connection);
            parameter.Id = Guid.NewGuid().ToString();
            return parameter;
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
