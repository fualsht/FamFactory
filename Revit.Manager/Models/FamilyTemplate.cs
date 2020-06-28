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
            get { return internalDataRowView[FamilyTemplatesColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[FamilyTemplatesColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[FamilyTemplatesColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Description
        {
            get { return internalDataRowView[FamilyTemplatesColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsReleased
        {
            get { return (bool)internalDataRowView[FamilyTemplatesColumnNames.IsReleased.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.IsReleased.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string FamilyCategory
        {
            get { return internalDataRowView[FamilyTemplatesColumnNames.FamilyCategory.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.FamilyCategory.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool CanHostRebar
        {
            get { return (bool)internalDataRowView[FamilyTemplatesColumnNames.CanHostRebar.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.CanHostRebar.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string RoundConnectorDimention
        {
            get { return internalDataRowView[FamilyTemplatesColumnNames.RoundConnectorDimension.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.RoundConnectorDimension.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string PartType
        {
            get { return internalDataRowView[FamilyTemplatesColumnNames.PartType.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.PartType.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string OmnoClassNumber
        {
            get { return internalDataRowView[FamilyTemplatesColumnNames.OmniClassNumber.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.OmniClassNumber.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string OmniClassTitle
        {
            get { return internalDataRowView[FamilyTemplatesColumnNames.OmniClassTitle.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.OmniClassTitle.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool WorkPlaneBased
        {
            get { return (bool)internalDataRowView[FamilyTemplatesColumnNames.WorkPlaneBased.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.WorkPlaneBased.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool AlwaysVertical
        {
            get { return (bool)internalDataRowView[FamilyTemplatesColumnNames.AlwaysVertical.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.AlwaysVertical.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool CutsWithVoidWhenLoaded
        {
            get { return (bool)internalDataRowView[FamilyTemplatesColumnNames.CutsWithVoidWhenLoaded.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.CutsWithVoidWhenLoaded.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsShared
        {
            get { return (bool)internalDataRowView[FamilyTemplatesColumnNames.IsShared.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool RoomCalculationPoint
        {
            get { return (bool)internalDataRowView[FamilyTemplatesColumnNames.RoomCalculationPoint.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.RoomCalculationPoint.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string FileName
        {
            get { return internalDataRowView[FamilyTemplatesColumnNames.FileName.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.FileName.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public byte[] Thumbnail
        {
            get { return (byte[])internalDataRowView[FamilyTemplatesColumnNames.Thumbnail.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.Thumbnail.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public Version Version
        {
            get { return Version.AsVersion(internalDataRowView[FamilyTemplatesColumnNames.Version.ToString()].ToString()); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.Version.ToString()] = value.ToString(); NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public long FileSize
        {
            get { return (long)internalDataRowView[FamilyTemplatesColumnNames.FileSize.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.FileSize.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        
        public byte[] FamilyFile
        {
            get { return (byte[])internalDataRowView[FamilyTemplatesColumnNames.FamilyFile.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.FamilyFile.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        
        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[FamilyTemplatesColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyTemplatesColumnNames.State.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
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
