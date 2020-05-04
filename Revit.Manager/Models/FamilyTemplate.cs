using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{ 
    public class FamilyTemplate : ModelBase<FamilyTemplate>
    {
        public enum ParameterColumnNames { Id, Name, Description, IsReleased, FamilyCategory, CanHostRebar, RoundConnectorDimention, PartType, OmnoClassNumber,
            OmniClassTitle, WorkPlaneBased, AlwaysVertical, CutsWithVoidWhenLoaded, IsShared, RoomCalculationPoint, FileName, Thumbnail, Version, FileSize, DateCreated, DateModified, FamilyFile }
        public string Id
        {
            get { return InternalDataRowView[ParameterColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[ParameterColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return InternalDataRowView[ParameterColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return InternalDataRowView[ParameterColumnNames.Description.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string IsReleased
        {
            get { return InternalDataRowView[ParameterColumnNames.IsReleased.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsReleased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FamilyCategory
        {
            get { return InternalDataRowView[ParameterColumnNames.FamilyCategory.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.FamilyCategory.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CanHostRebar
        {
            get { return InternalDataRowView[ParameterColumnNames.CanHostRebar.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.CanHostRebar.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string RoundConnectorDimention
        {
            get { return InternalDataRowView[ParameterColumnNames.RoundConnectorDimention.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.RoundConnectorDimention.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string PartType
        {
            get { return InternalDataRowView[ParameterColumnNames.PartType.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.PartType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmnoClassNumber
        {
            get { return InternalDataRowView[ParameterColumnNames.OmnoClassNumber.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.OmnoClassNumber.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmniClassTitle
        {
            get { return InternalDataRowView[ParameterColumnNames.OmniClassTitle.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.OmniClassTitle.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string WorkPlaneBased
        {
            get { return InternalDataRowView[ParameterColumnNames.WorkPlaneBased.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.WorkPlaneBased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string AlwaysVertical
        {
            get { return InternalDataRowView[ParameterColumnNames.AlwaysVertical.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.AlwaysVertical.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CutsWithVoidWhenLoaded
        {
            get { return InternalDataRowView[ParameterColumnNames.CutsWithVoidWhenLoaded.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.CutsWithVoidWhenLoaded.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsShared
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsShared.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string RoomCalculationPoint
        {
            get { return InternalDataRowView[ParameterColumnNames.RoomCalculationPoint.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.RoomCalculationPoint.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FileName
        {
            get { return InternalDataRowView[ParameterColumnNames.FileName.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.FileName.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public byte[] Thumbnail
        {
            get { return (byte[])InternalDataRowView[ParameterColumnNames.Thumbnail.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.Thumbnail.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public Version Version
        {
            get { return Version.AsVersion(InternalDataRowView[ParameterColumnNames.Version.ToString()].ToString()); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.Version.ToString()] = value.ToString(); NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public long FileSize
        {
            get { return (long)InternalDataRowView[ParameterColumnNames.FileSize.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.FileSize.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public DateTime DateCreated
        {
            get { return (DateTime)InternalDataRowView[ParameterColumnNames.DateCreated.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public DateTime DateModified
        {
            get { return (DateTime)InternalDataRowView[ParameterColumnNames.DateModified.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public byte[] FamilyFile
        {
            get { return (byte[])InternalDataRowView[ParameterColumnNames.FamilyFile.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.FamilyFile.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public ObservableCollection<Parameter> RefferencePlaneItems { get; set; }
        public ObservableCollection<FamilyGeometry> FamilyGeometryItems { get; set; }
        public ObservableCollection<Parameter> ParameterItems { get; set; }

        public FamilyTemplate(DataRowView view) : base(view)
        {
            RefferencePlaneItems = new ObservableCollection<Parameter>();
            FamilyGeometryItems = new ObservableCollection<FamilyGeometry>();
            ParameterItems = new ObservableCollection<Parameter>();
            //DataView v = view.CreateChildView();
        }

        public static FamilyTemplate NewTemplate(DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            FamilyTemplate template = new FamilyTemplate(row);
            template.Id = Guid.NewGuid().ToString();
            template.Version = new Version(0, 0, 0);
            template.DateCreated = DateTime.Now;
            template.DateModified = DateTime.Now;

            return template;
        }
    }
}
