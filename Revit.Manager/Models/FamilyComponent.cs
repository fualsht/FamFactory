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
        public enum FamilyComponentsTableColumnNames { Id, Name, Description, FamilyComponentTypeId, FamilyCategory, FamilyFile, State,
            Thumbnail, FileSize, DateCreated, DateModified, CreatedById, ModifiedById, Version, IsReleased, RoundConnectorDimention, PartType, 
            OmniClassNumber, OmniClassTitle, WorkPlaneBased, AlwaysVertical, CutsWithVoidWhenLoaded, IsShared, RoomCalculationPoint, 
            FileName, CanHostRebar }

        public string Id
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[FamilyComponentsTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FamilyComponentTypeId
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.FamilyComponentTypeId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.FamilyComponentTypeId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FamilyCategory
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.FamilyCategory.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.FamilyCategory.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public byte[] FamilyFile
        {
            get { return (byte[])internalDataRowView[FamilyComponentsTableColumnNames.FamilyFile.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.FamilyFile.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public byte[] Thumbnail
        {
            get { return (byte[])internalDataRowView[FamilyComponentsTableColumnNames.Thumbnail.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.Thumbnail.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public long FileSize
        {
            get { return (long)internalDataRowView[FamilyComponentsTableColumnNames.FileSize.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.FileSize.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public DateTime DateCreated
        {
            get { return (DateTime)internalDataRowView[FamilyComponentsTableColumnNames.DateCreated.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public DateTime DateModified
        {
            get { return (DateTime)internalDataRowView[FamilyComponentsTableColumnNames.DateModified.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CreatedById
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.CreatedById.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        User _CreatedBy;
        public User CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ModifiedById
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.ModifiedById.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        User _ModifiedBy;
        public User ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public Version Version
        {
            get { return Version.AsVersion(internalDataRowView[FamilyComponentsTableColumnNames.Version.ToString()].ToString()); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.Version.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsReleased
        {
            get { return (bool)internalDataRowView[FamilyComponentsTableColumnNames.IsReleased.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.IsReleased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string RoundConnectorDimention
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.RoundConnectorDimention.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.RoundConnectorDimention.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string PartType
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.PartType.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.PartType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmnoClassNumber
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.OmniClassNumber.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.OmniClassNumber.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmniClassTitle
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.OmniClassTitle.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool WorkPlaneBased
        {
            get { return (bool)internalDataRowView[FamilyComponentsTableColumnNames.WorkPlaneBased.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.WorkPlaneBased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool AlwaysVertical
        {
            get { return (bool)internalDataRowView[FamilyComponentsTableColumnNames.AlwaysVertical.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.AlwaysVertical.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool CutsWithVoidWhenLoaded
        {
            get { return (bool)internalDataRowView[FamilyComponentsTableColumnNames.CutsWithVoidWhenLoaded.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.CutsWithVoidWhenLoaded.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsShared
        {
            get { return (bool)internalDataRowView[FamilyComponentsTableColumnNames.IsShared.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool RoomCalculationPoint
        {
            get { return (bool)internalDataRowView[FamilyComponentsTableColumnNames.RoomCalculationPoint.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.RoomCalculationPoint.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FileName
        {
            get { return internalDataRowView[FamilyComponentsTableColumnNames.FileName.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.FileName.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool CanHostRebar
        {
            get { return (bool)internalDataRowView[FamilyComponentsTableColumnNames.CanHostRebar.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.CanHostRebar.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[FamilyComponentsTableColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentsTableColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public FamilyReferencePlaneViewModel RefferencePlaneItems { get; set; }
        public FamilyGeometryViewModel FamilyGeometryItems { get; set; }
        public FamilyParameterViewModel ParameterItems { get; set; }
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
    }
}
