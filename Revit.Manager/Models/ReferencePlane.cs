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
        public enum ReferencePlaneTableColumnNames { Id, RevitId, UniqueId, LevelId, ViewId, Category, DirectionX, DirectionY, DirectionZ, LocationX, 
            LocationY, LocationZ, BubbleEndX, BubbleEndY, BubbleEndZ, NormalX, NormalY, NormalZ, FreeEndX, FreeEndY, FreeEndZ, Name, IsActive, HostId }
        public string Id
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[ReferencePlaneTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string RevitId
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.RevitId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.RevitId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string UniqueId
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.UniqueId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.UniqueId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string LevelId
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.LevelId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.LevelId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ViewId
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.ViewId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.ViewId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Category
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.Category.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.Category.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string DirectionX
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.DirectionX.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.DirectionX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string DirectionY
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.DirectionY.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.DirectionY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string DirectionZ
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.DirectionZ.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.DirectionZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string LocationX
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.LocationX.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.LocationX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string LocationY
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.LocationY.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.LocationY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string LocationZ
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.LocationZ.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.LocationZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string BubbleEndX
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndX.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string BubbleEndY
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndY.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string BubbleEndZ
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndZ.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.BubbleEndZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string NormalX
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.NormalX.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.NormalX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string NormalY
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.NormalY.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.NormalY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string NormalZ
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.NormalZ.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.NormalZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FreeEndX
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndX.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndX.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FreeEndY
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndY.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndY.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FreeEndZ
        {
            get { return InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndZ.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.FreeEndZ.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsActive
        {
            get { return (bool)InternalDataRowView[ReferencePlaneTableColumnNames.IsActive.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool HostId
        {
            get { return (bool)InternalDataRowView[ReferencePlaneTableColumnNames.HostId.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[ReferencePlaneTableColumnNames.HostId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public ReferencePlane(DataRowView rowView) : base(rowView)
        {

        }

        public static ReferencePlane NewReferencePlane(DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            ReferencePlane refPlane = new ReferencePlane(row);
            refPlane.Id = Guid.NewGuid().ToString();
            refPlane.Name = "NewElement";
            refPlane.RevitId = "";
            refPlane.UniqueId = "";
            refPlane.LevelId = "";
            refPlane.ViewId = "";
            refPlane.Category = "";
            refPlane.DirectionX = "";
            refPlane.DirectionY = "";
            refPlane.DirectionZ = "";
            refPlane.LocationX = "";
            refPlane.LocationY = "";
            refPlane.LocationZ = "";
            refPlane.BubbleEndX = "";
            refPlane.BubbleEndY = "";
            refPlane.BubbleEndZ = "";
            refPlane.NormalX = "";
            refPlane.NormalY = "";
            refPlane.NormalZ = "";
            refPlane.FreeEndX = "";
            refPlane.FreeEndY = "";
            refPlane.FreeEndZ = "";
            refPlane.Name = "";
            refPlane.IsActive = false;
            return refPlane;
        }


    }
}