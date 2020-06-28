using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyComponent : ModelBase<FamilyComponent>
    {
        public string Id
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[FamilyComponentsColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _valuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); ; }
        }
        public string FamilyComponentTypeId
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.FamilyComponentTypeId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.FamilyComponentTypeId.ToString()] = value;}
        }
        public string FamilyCategory
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.FamilyCategory.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.FamilyCategory.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public byte[] FamilyFile
        {
            get { return (byte[])internalDataRowView[FamilyComponentsColumnNames.FamilyFile.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.FamilyFile.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public byte[] Thumbnail
        {
            get { return (byte[])internalDataRowView[FamilyComponentsColumnNames.Thumbnail.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.Thumbnail.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public long FileSize
        {
            get { return (long)internalDataRowView[FamilyComponentsColumnNames.FileSize.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.FileSize.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public Version Version
        {
            get { return Version.AsVersion(internalDataRowView[FamilyComponentsColumnNames.Version.ToString()].ToString()); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.Version.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsReleased
        {
            get { return (bool)internalDataRowView[FamilyComponentsColumnNames.IsReleased.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.IsReleased.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string RoundConnectorDimention
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.RoundConnectorDimention.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.RoundConnectorDimention.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string PartType
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.PartType.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.PartType.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string OmnoClassNumber
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.OmniClassNumber.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.OmniClassNumber.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string OmniClassTitle
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.OmniClassTitle.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool WorkPlaneBased
        {
            get { return (bool)internalDataRowView[FamilyComponentsColumnNames.WorkPlaneBased.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.WorkPlaneBased.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool AlwaysVertical
        {
            get { return (bool)internalDataRowView[FamilyComponentsColumnNames.AlwaysVertical.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.AlwaysVertical.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool CutsWithVoidWhenLoaded
        {
            get { return (bool)internalDataRowView[FamilyComponentsColumnNames.CutsWithVoidWhenLoaded.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.CutsWithVoidWhenLoaded.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsShared
        {
            get { return (bool)internalDataRowView[FamilyComponentsColumnNames.IsShared.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool RoomCalculationPoint
        {
            get { return (bool)internalDataRowView[FamilyComponentsColumnNames.RoomCalculationPoint.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.RoomCalculationPoint.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string FileName
        {
            get { return internalDataRowView[FamilyComponentsColumnNames.FileName.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.FileName.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool CanHostRebar
        {
            get { return (bool)internalDataRowView[FamilyComponentsColumnNames.CanHostRebar.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.CanHostRebar.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[FamilyComponentsColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsColumnNames.State.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public FamilyTemplateReferencePlaneViewModel RefferencePlaneItems { get; set; }
        public FamilyTemplateGeometryViewModel FamilyGeometryItems { get; set; }
        public FamilyTemplateParameterViewModel ParameterItems { get; set; }
        public FamilyComponentTypeViewModel ComponentTypeItems { get; set; }

        public FamilyComponent(DataRowView view, SQLiteConnection connection) : base(view, connection)
        {
            
        }

        public static FamilyComponent NewFamilyComponent(SQLiteConnection connection, DataView rowView, User user, FamilyComponentType type)
        {
            DataRowView row = rowView.AddNew();

            FamilyComponent component = new FamilyComponent(row, connection);
            component.Id = Guid.NewGuid().ToString();
            component.Thumbnail = new byte[byte.MaxValue];
            component.Version = new Version(0, 0, 0);
            component.DateCreated = DateTime.Now;
            component.DateModified = DateTime.Now;
            component.CreatedById = user.Id;
            component.ModifiedById = user.Id;
            component.CreatedBy = user;
            component.ModifiedBy = user;
            component.FamilyComponentTypeId = type.Id;

            return component;
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
