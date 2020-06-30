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
            get { return internalDataRowView[ParametersColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[ParametersColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }

        public string FamilyId
        {
            get { return internalDataRowView[ParametersColumnNames.FamilyId.ToString()].ToString(); }
            set { internalDataRowView[ParametersColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); }
        }

        public string Name
        {
            get { return internalDataRowView[ParametersColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int ElementId
        {
            get { return (int)internalDataRowView[ParametersColumnNames.ElementId.ToString()]; }
            set 
            {
                internalDataRowView.BeginEdit();
                internalDataRowView[ParametersColumnNames.ElementId.ToString()] = (int)value;
                NotifyPropertyChanged(); _valuesChanged = true; 
                NotifyPropertyChanged("ValuesChanged");
            }
        }
        public string ElementGUID
        {
            get { return internalDataRowView[ParametersColumnNames.ElementGUID.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.ElementGUID.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool HasValue
        {
            get { return (bool)internalDataRowView[ParametersColumnNames.HasValue.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.HasValue.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsReadOnly
        {
            get { return (bool)internalDataRowView[ParametersColumnNames.IsReadOnly.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.IsReadOnly.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsShared
        {
            get { return (bool)internalDataRowView[ParametersColumnNames.IsShared.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsInstance
        {
            get { return (bool)internalDataRowView[ParametersColumnNames.IsInstance.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.IsInstance.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int StorageType
        {
            get { return (int)internalDataRowView[ParametersColumnNames.StorageType.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.StorageType.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsEditable
        {
            get { return (bool)internalDataRowView[ParametersColumnNames.IsEditable.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.IsEditable.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsActive
        {
            get { return (bool)internalDataRowView[ParametersColumnNames.IsActive.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string HostId
        {
            get { return internalDataRowView[ParametersColumnNames.HostId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.HostId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsReporting
        {
            get { return (bool)internalDataRowView[ParametersColumnNames.IsReporting.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.IsReporting.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int BuiltInParamGroup
        {
            get { return (int)internalDataRowView[ParametersColumnNames.BuiltInParamGroup.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.BuiltInParamGroup.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public int ParameterType
        {
            get { return (int)internalDataRowView[ParametersColumnNames.ParameterType.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.ParameterType.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int UnitType
        {
            get { return (int)internalDataRowView[ParametersColumnNames.UnitType.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.UnitType.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int DisplayUnitType
        {
            get { return (int)internalDataRowView[ParametersColumnNames.DisplayUnitType.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.DisplayUnitType.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool UserModifiable
        {
            get { return (bool)internalDataRowView[ParametersColumnNames.UserModifiable.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.UnitType.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsDeterminedByFormula
        {
            get { return (bool)internalDataRowView[ParametersColumnNames.IsDeterminedByFormula.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.UnitType.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Formula
        {
            get { return internalDataRowView[ParametersColumnNames.Formula.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParametersColumnNames.Formula.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public Parameter(DataRowView rowView, SQLiteConnection connection, User user) : base(rowView, connection, user)
        {

        }

        public static Parameter newParameter(SQLiteConnection connection, DataView rowView, User user)
        {
            DataRowView row = rowView.AddNew();

            Parameter parameter = new Parameter(row, connection, user);
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
