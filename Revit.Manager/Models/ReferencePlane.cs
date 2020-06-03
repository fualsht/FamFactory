using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class ReferencePlane : ModelBase<ReferencePlane>
    {
        public enum ReferencePlaneTableColumnNames { Id, FamilyId, ElementId, UniqueId, LevelId, ViewId, Category, DirectionX, DirectionY, 
            DirectionZ, BubbleEndX, BubbleEndY, BubbleEndZ, NormalX, NormalY, NormalZ, FreeEndX, FreeEndY, FreeEndZ, Name, IsActive, 
            DateCreated, DateModified, CreatedById, ModifiedById 
        }

        public string Id
        {
            get { return internalDataRowView[ReferencePlaneTableColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[ReferencePlaneTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }

        public string FamiltyId
        {
            get { return internalDataRowView[ReferencePlaneTableColumnNames.FamilyId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string Name
        {
            get { return internalDataRowView[ReferencePlaneTableColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public int ElementId
        {
            get { return (int)internalDataRowView[ReferencePlaneTableColumnNames.ElementId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.ElementId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string UniqueId
        {
            get { return internalDataRowView[ReferencePlaneTableColumnNames.UniqueId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.UniqueId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int LevelId
        {
            get { return (int)internalDataRowView[ReferencePlaneTableColumnNames.LevelId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.LevelId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ViewId
        {
            get { return (int)internalDataRowView[ReferencePlaneTableColumnNames.ViewId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.ViewId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Category
        {
            get { return internalDataRowView[ReferencePlaneTableColumnNames.Category.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.Category.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double DirectionX
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.DirectionX.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.DirectionX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double DirectionY
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.DirectionY.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.DirectionY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double DirectionZ
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.DirectionZ.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.DirectionZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double BubbleEndX
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.BubbleEndX.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.BubbleEndX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double BubbleEndY
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.BubbleEndY.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.BubbleEndY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double BubbleEndZ
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.BubbleEndZ.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.BubbleEndZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double NormalX
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.NormalX.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.NormalX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double NormalY
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.NormalY.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.NormalY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double NormalZ
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.NormalZ.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.NormalZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double FreeEndX
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.FreeEndX.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.FreeEndX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double FreeEndY
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.FreeEndY.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.FreeEndY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double FreeEndZ
        {
            get { return (double)internalDataRowView[ReferencePlaneTableColumnNames.FreeEndZ.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.FreeEndZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsActive
        {
            get { return (bool)internalDataRowView[ReferencePlaneTableColumnNames.IsActive.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public object DateCreated
        {
            get { return internalDataRowView[ReferencePlaneTableColumnNames.DateCreated.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public object DateModified
        {
            get { return internalDataRowView[ReferencePlaneTableColumnNames.DateModified.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CreatedById
        {
            get { return internalDataRowView[ReferencePlaneTableColumnNames.CreatedById.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        User _CreatedBy;
        public User CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public string ModifiedById
        {
            get { return internalDataRowView[ReferencePlaneTableColumnNames.ModifiedById.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlaneTableColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        User _ModifiedBy;
        public User ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public ReferencePlane(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {

        }

        public static ReferencePlane NewReferencePlane(SQLiteConnection connection, DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            ReferencePlane refPlane = new ReferencePlane(row, connection);
            refPlane.Id = Guid.NewGuid().ToString();
            refPlane.Name = "NewElement";
            refPlane.ElementId = -1;
            refPlane.UniqueId = "";
            refPlane.LevelId = -1;
            refPlane.ViewId = -1;
            refPlane.Category = "";
            refPlane.DirectionX = 0;
            refPlane.DirectionY = 0;
            refPlane.DirectionZ = 0;
            refPlane.BubbleEndX = 0;
            refPlane.BubbleEndY = 0;
            refPlane.BubbleEndZ = 0;
            refPlane.NormalX = 0;
            refPlane.NormalY = 0;
            refPlane.NormalZ = 0;
            refPlane.FreeEndX = 0;
            refPlane.FreeEndY = 0;
            refPlane.FreeEndZ = 0;
            refPlane.IsActive = false;
            refPlane.DateCreated = DateTime.Now;
            refPlane.DateModified = DateTime.Now;
            return refPlane;
        }


    }
}