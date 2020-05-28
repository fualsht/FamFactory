using System;
using System.Collections.Generic;
using System.Data;
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
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[ReferencePlaneTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }

        public string FamiltyId
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.FamilyId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string Name
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public int ElementId
        {
            get { return (int)InternalDataRowView[ReferencePlaneTableColumnNames.ElementId.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.ElementId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string UniqueId
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.UniqueId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.UniqueId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int LevelId
        {
            get { return (int)InternalDataRowView[ReferencePlaneTableColumnNames.LevelId.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.LevelId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ViewId
        {
            get { return (int)InternalDataRowView[ReferencePlaneTableColumnNames.ViewId.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.ViewId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Category
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.Category.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.Category.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double DirectionX
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.DirectionX.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.DirectionX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double DirectionY
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.DirectionY.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.DirectionY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double DirectionZ
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.DirectionZ.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.DirectionZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double BubbleEndX
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndX.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double BubbleEndY
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndY.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double BubbleEndZ
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndZ.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double NormalX
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.NormalX.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.NormalX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double NormalY
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.NormalY.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.NormalY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double NormalZ
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.NormalZ.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.NormalZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double FreeEndX
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndX.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double FreeEndY
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndY.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public double FreeEndZ
        {
            get { return (double)InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndZ.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsActive
        {
            get { return (bool)InternalDataRowView[ReferencePlaneTableColumnNames.IsActive.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public object DateCreated
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.DateCreated.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public object DateModified
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.DateModified.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CreatedById
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.CreatedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        User _CreatedBy;
        public User CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public string ModifiedById
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.ModifiedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        User _ModifiedBy;
        public User ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); } }

        public ReferencePlane(DataRowView rowView) : base(rowView)
        {

        }

        public static ReferencePlane NewReferencePlane(DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            ReferencePlane refPlane = new ReferencePlane(row);
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