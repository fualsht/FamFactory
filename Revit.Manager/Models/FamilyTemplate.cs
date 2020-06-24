using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{ 
    public class FamilyTemplate : ModelBase<FamilyTemplate>
    {
        public string Id
        {
            get { return internalDataRowView[ParameterColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[ParameterColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[ParameterColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return internalDataRowView[ParameterColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsReleased
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.IsReleased.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.IsReleased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FamilyCategory
        {
            get { return internalDataRowView[ParameterColumnNames.FamilyCategory.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.FamilyCategory.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool CanHostRebar
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.CanHostRebar.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.CanHostRebar.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string RoundConnectorDimention
        {
            get { return internalDataRowView[ParameterColumnNames.RoundConnectorDimension.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.RoundConnectorDimension.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string PartType
        {
            get { return internalDataRowView[ParameterColumnNames.PartType.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.PartType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmnoClassNumber
        {
            get { return internalDataRowView[ParameterColumnNames.OmniClassNumber.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.OmniClassNumber.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmniClassTitle
        {
            get { return internalDataRowView[ParameterColumnNames.OmniClassTitle.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.OmniClassTitle.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool WorkPlaneBased
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.WorkPlaneBased.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.WorkPlaneBased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool AlwaysVertical
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.AlwaysVertical.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.AlwaysVertical.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool CutsWithVoidWhenLoaded
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.CutsWithVoidWhenLoaded.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.CutsWithVoidWhenLoaded.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsShared
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.IsShared.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool RoomCalculationPoint
        {
            get { return (bool)internalDataRowView[ParameterColumnNames.RoomCalculationPoint.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.RoomCalculationPoint.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FileName
        {
            get { return internalDataRowView[ParameterColumnNames.FileName.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.FileName.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public byte[] Thumbnail
        {
            get { return (byte[])internalDataRowView[ParameterColumnNames.Thumbnail.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.Thumbnail.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public Version Version
        {
            get { return Version.AsVersion(internalDataRowView[ParameterColumnNames.Version.ToString()].ToString()); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.Version.ToString()] = value.ToString(); NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public long FileSize
        {
            get { return (long)internalDataRowView[ParameterColumnNames.FileSize.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.FileSize.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        
        public byte[] FamilyFile
        {
            get { return (byte[])internalDataRowView[ParameterColumnNames.FamilyFile.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.FamilyFile.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        
        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[ParameterColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ParameterColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public FamilyTemplateComponentViewModel FamilyTemplateComponents { get; set; }

        public FamilyTemplateReferencePlaneViewModel FamilyTemplateReferencePlanes { get; set; }

        public FamilyTemplateGeometryViewModel FamilyTemplateGeometries { get; set; }

        public FamilyTemplateParameterViewModel FamilyTemplateParameters { get; set; }

        public FamilyTemplate(DataRowView view, SQLiteConnection connection) : base(view, connection)
        {
            FamilyTemplateComponents = new FamilyTemplateComponentViewModel(view.Row.Table.DataSet, connection);
            FamilyTemplateReferencePlanes = new FamilyTemplateReferencePlaneViewModel(view.Row.Table.DataSet, connection);
            FamilyTemplateGeometries = new FamilyTemplateGeometryViewModel(view.Row.Table.DataSet, connection);
            FamilyTemplateParameters = new FamilyTemplateParameterViewModel(view.Row.Table.DataSet, connection);
        }

        public static FamilyTemplate NewTemplate(SQLiteConnection connection, DataView rowView, User user)
        {
            DataRowView row = rowView.AddNew();

            FamilyTemplate template = new FamilyTemplate(row, connection);
            template.Id = Guid.NewGuid().ToString();
            template.Version = new Version(0, 0, 0);
            template.DateCreated = DateTime.Now;
            template.DateModified = DateTime.Now;
            template.CreatedById = user.Id;
            template.CreatedBy = user;
            template.ModifiedById = user.Id;
            template.ModifiedBy = user;

            return template;
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
