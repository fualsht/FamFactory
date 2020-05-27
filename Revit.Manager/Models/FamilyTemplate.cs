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
        public enum ParameterColumnNames { Id, Name, Description, IsReleased, FamilyCategory, CanHostRebar, RoundConnectorDimension, 
            PartType, OmniClassNumber, OmniClassTitle, WorkPlaneBased, AlwaysVertical, CutsWithVoidWhenLoaded, IsShared, State,
            RoomCalculationPoint, FileName, Thumbnail, Version, FileSize, DateCreated, DateModified, FamilyFile, CreatedById, ModifiedById
        }

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
        public bool IsReleased
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsReleased.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsReleased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FamilyCategory
        {
            get { return InternalDataRowView[ParameterColumnNames.FamilyCategory.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.FamilyCategory.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool CanHostRebar
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.CanHostRebar.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.CanHostRebar.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string RoundConnectorDimention
        {
            get { return InternalDataRowView[ParameterColumnNames.RoundConnectorDimension.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.RoundConnectorDimension.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string PartType
        {
            get { return InternalDataRowView[ParameterColumnNames.PartType.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.PartType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmnoClassNumber
        {
            get { return InternalDataRowView[ParameterColumnNames.OmniClassNumber.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.OmniClassNumber.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmniClassTitle
        {
            get { return InternalDataRowView[ParameterColumnNames.OmniClassTitle.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.OmniClassTitle.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool WorkPlaneBased
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.WorkPlaneBased.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.WorkPlaneBased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool AlwaysVertical
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.AlwaysVertical.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.AlwaysVertical.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool CutsWithVoidWhenLoaded
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.CutsWithVoidWhenLoaded.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.CutsWithVoidWhenLoaded.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsShared
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.IsShared.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool RoomCalculationPoint
        {
            get { return (bool)InternalDataRowView[ParameterColumnNames.RoomCalculationPoint.ToString()]; }
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
        public string CreatedById
        {
            get { return InternalDataRowView[ParameterColumnNames.CreatedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ModifiedById
        {
            get { return InternalDataRowView[ParameterColumnNames.ModifiedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public EntityStates State
        {
            get { return (EntityStates)InternalDataRowView[ParameterColumnNames.State.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ParameterColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public ObservableCollection<ReferencePlane> RefferencePlaneItems { get; set; }
        public ObservableCollection<FamilyGeometry> FamilyGeometryItems { get; set; }
        public ObservableCollection<Parameter> ParameterItems { get; set; }

        ObservableCollection<FamilyTemplateComponent> TemplateComponents { get; set; }

        DataView _FamilyTemplateReferencePlanesView;
        public DataView FamilyTemplateReferencePlanesView { get { return _FamilyTemplateReferencePlanesView; } }

        DataView _FamilyTemplateParametersView;
        public DataView FamilyTemplateParametersView { get { return _FamilyTemplateParametersView; } }

        DataView _FamilyTemplateGeometryView;
        public DataView FamilyTemplateGeometryView { get { return _FamilyTemplateGeometryView; } }

        DataView _FamilyTemplateComponentsView;
        public DataView FamilyTemplateComponentsView { get { return _FamilyTemplateComponentsView; } }

        public FamilyTemplate(DataRowView view) : base(view)
        {
            RefferencePlaneItems = new ObservableCollection<ReferencePlane>();
            FamilyGeometryItems = new ObservableCollection<FamilyGeometry>();
            ParameterItems = new ObservableCollection<Parameter>();
            TemplateComponents = new ObservableCollection<FamilyTemplateComponent>();

            _FamilyTemplateParametersView = InternalDataRowView.CreateChildView(TableRelations.FamilyTemplateParameters_FamilyId__FamilyTemplates_Id.ToString());
            _FamilyTemplateReferencePlanesView = InternalDataRowView.CreateChildView(TableRelations.FamilyTemplateReferencePlanes_FamilyId__FamilyTemplates_Id.ToString());
            _FamilyTemplateGeometryView = InternalDataRowView.CreateChildView(TableRelations.FamilyTemplateGeometries_FamilyId__FamilyTemplates_Id.ToString());
            _FamilyTemplateComponentsView = InternalDataRowView.CreateChildView(TableRelations.FamilyTemplateComponents_FamilyId__FamilyTemplate_Id.ToString());
            RefreshChildRows();
        }

        private void RefreshChildRows()
        {
            ParameterItems.Clear();
            foreach (DataRowView item in FamilyTemplateParametersView)
                ParameterItems.Add(new Parameter(item));
   
            RefferencePlaneItems.Clear();
            foreach (DataRowView item in FamilyTemplateReferencePlanesView)
                RefferencePlaneItems.Add(new ReferencePlane(item));
            
            FamilyGeometryItems.Clear();
            foreach (DataRowView item in FamilyTemplateGeometryView)
                FamilyGeometryItems.Add(new FamilyGeometry(item));

            TemplateComponents.Clear();
            foreach (DataRowView item in FamilyTemplateComponentsView)
                TemplateComponents.Add(new FamilyTemplateComponent(item));
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
