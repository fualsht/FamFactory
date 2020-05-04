using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class Parameter : ModelBase<Parameter>
    {
        public enum ParameterColumnNames { Id, FamilyTemplateId, Name, ElementId, ElementGUID, HasValue, IsReadOnly, IsShared, IsInstance, StorageType, 
            IsEditable, IsActive, HostId, IsReporting, BuiltInParamGroup, ParameterType, UnitType, DisplayUnitType, UserModifiable, IsDeterminedByFormula, Formula }
        public string Id
        {
            get { return InternalDataRowView[ParameterColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[ParameterColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }

        public string FamilyTemplateId
        {
            get { return InternalDataRowView[ParameterColumnNames.FamilyTemplateId.ToString()].ToString(); }
            set { InternalDataRowView[ParameterColumnNames.FamilyTemplateId.ToString()] = value; NotifyPropertyChanged(); }
        }

        public string Name
        {
            get { return InternalDataRowView[ParameterColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ElementId
        {
            get { return (int)InternalDataRowView[ParameterColumnNames.ElementId.ToString()]; }
            set 
            {
                InternalDataRowView.BeginEdit();
                InternalDataRowView[ParameterColumnNames.ElementId.ToString()] = (int)value;
                NotifyPropertyChanged(); _ValuesChanged = true; 
                NotifyPropertyChanged("ValuesChanged");
            }
        }
        public string ElementGUID
        {
            get { return InternalDataRowView[ParameterColumnNames.ElementGUID.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.ElementGUID.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool HasValue
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.HasValue.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.HasValue.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsReadOnly
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsReadOnly.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsReadOnly.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsShared
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsShared.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsInstance
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsInstance.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsInstance.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public Autodesk.Revit.DB.StorageType StorageType
        {
            get { return (Autodesk.Revit.DB.StorageType)InternalDataRowView[ParameterColumnNames.StorageType.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.StorageType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsEditable
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsEditable.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsEditable.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsActive
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsActive.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string HostId
        {
            get { return InternalDataRowView[ParameterColumnNames.HostId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.HostId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsReporting
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsReporting.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsReporting.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public Autodesk.Revit.DB.BuiltInParameterGroup BuiltInParamGroup
        {
            get { return (Autodesk.Revit.DB.BuiltInParameterGroup)InternalDataRowView[ParameterColumnNames.BuiltInParamGroup.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.BuiltInParamGroup.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public Autodesk.Revit.DB.ParameterType ParameterType
        {
            get { return (Autodesk.Revit.DB.ParameterType)InternalDataRowView[ParameterColumnNames.ParameterType.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.ParameterType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public Autodesk.Revit.DB.UnitType UnitType
        {
            get { return (Autodesk.Revit.DB.UnitType)InternalDataRowView[ParameterColumnNames.UnitType.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.UnitType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public Autodesk.Revit.DB.DisplayUnitType DisplayUnitType
        {
            get { return (Autodesk.Revit.DB.DisplayUnitType)InternalDataRowView[ParameterColumnNames.DisplayUnitType.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.DisplayUnitType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool UserModifiable
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.UserModifiable.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.UnitType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsDeterminedByFormula
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsDeterminedByFormula.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.UnitType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Formula
        {
            get { return InternalDataRowView[ParameterColumnNames.Formula.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.Formula.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public Parameter(DataRowView rowView) : base(rowView)
        {

        }

        public static Parameter newParameter(DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            Parameter parameter = new Parameter(row);
            parameter.Id = Guid.NewGuid().ToString();
            return parameter;
        }
    }
}
