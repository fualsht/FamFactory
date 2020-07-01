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

        public string FamiltyId
        {
            get { return internalDataRowView[ReferencePlanesColumnNames.FamilyId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public int ElementId
        {
            get { return (int)internalDataRowView[ReferencePlanesColumnNames.ElementId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.ElementId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string UniqueId
        {
            get { return internalDataRowView[ReferencePlanesColumnNames.UniqueId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.UniqueId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int LevelId
        {
            get { return (int)internalDataRowView[ReferencePlanesColumnNames.LevelId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.LevelId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int ViewId
        {
            get { return (int)internalDataRowView[ReferencePlanesColumnNames.ViewId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.ViewId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Category
        {
            get { return internalDataRowView[ReferencePlanesColumnNames.Category.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.Category.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double DirectionX
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.DirectionX.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.DirectionX.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double DirectionY
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.DirectionY.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.DirectionY.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double DirectionZ
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.DirectionZ.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.DirectionZ.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double BubbleEndX
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.BubbleEndX.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.BubbleEndX.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double BubbleEndY
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.BubbleEndY.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.BubbleEndY.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double BubbleEndZ
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.BubbleEndZ.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.BubbleEndZ.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double NormalX
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.NormalX.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.NormalX.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double NormalY
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.NormalY.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.NormalY.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double NormalZ
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.NormalZ.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.NormalZ.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double FreeEndX
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.FreeEndX.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.FreeEndX.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double FreeEndY
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.FreeEndY.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.FreeEndY.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public double FreeEndZ
        {
            get { return (double)internalDataRowView[ReferencePlanesColumnNames.FreeEndZ.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.FreeEndZ.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsActive
        {
            get { return (bool)internalDataRowView[ReferencePlanesColumnNames.IsActive.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[ReferencePlanesColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public ReferencePlane(DataRowView rowView, SQLiteConnection connection, User user) : base(rowView, connection, user)
        {

        }

        public static ReferencePlane NewReferencePlane(SQLiteConnection connection, DataView rowView, User user)
        {
            DataRowView row = rowView.AddNew();

            ReferencePlane refPlane = new ReferencePlane(row, connection, user);
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