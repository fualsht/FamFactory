using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyGeometry : ModelBase<FamilyGeometry>
    {
        public string Id
        {
            get { return internalDataRowView[FamilyGeometriesColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[FamilyGeometriesColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string FamilyId
        {
            get { return internalDataRowView[FamilyGeometriesColumnNames.FamilyId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Name
        {
            get { return internalDataRowView[FamilyGeometriesColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Description
        {
            get { return internalDataRowView[FamilyGeometriesColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int ElementId
        {
            get { return (int)internalDataRowView[FamilyGeometriesColumnNames.ElementId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.ElementId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string GeometryType
        {
            get { return internalDataRowView[FamilyGeometriesColumnNames.GeometryType.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.GeometryType.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int MaterialId
        {
            get { return (int)internalDataRowView[FamilyGeometriesColumnNames.MaterialId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.MaterialId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsActive
        {
            get { return (bool)internalDataRowView[FamilyGeometriesColumnNames.IsActive.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int ProfileFamily1Id
        {
            get { return (int)internalDataRowView[FamilyGeometriesColumnNames.ProfileFamily1Id.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.ProfileFamily1Id.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int ProfileFamily2Id
        {
            get { return (int)internalDataRowView[FamilyGeometriesColumnNames.ProfileFamily2Id.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.ProfileFamily2Id.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int HostId
        {
            get { return (int)internalDataRowView[FamilyGeometriesColumnNames.HostId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.HostId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Category
        {
            get { return internalDataRowView[FamilyGeometriesColumnNames.Category.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.Category.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string SubCategory
        {
            get { return internalDataRowView[FamilyGeometriesColumnNames.SubCategory.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.SubCategory.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string UniqueId
        {
            get { return internalDataRowView[FamilyGeometriesColumnNames.UniqueId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.UniqueId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int OwnerViewId
        {
            get { return (int)internalDataRowView[FamilyGeometriesColumnNames.OwnerViewId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.OwnerViewId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public int LevelId
        {
            get { return (int)internalDataRowView[FamilyGeometriesColumnNames.LevelId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.LevelId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public bool IsSolid
        {
            get { return (bool)internalDataRowView[FamilyGeometriesColumnNames.IsSolid.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometriesColumnNames.IsSolid.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public FamilyGeometry(DataRowView dataRowView, SQLiteConnection connection, User user) : base(dataRowView, connection, user)
        {

        }

        internal static FamilyGeometry NewFamilyGeometry(SQLiteConnection connection, DataView familyTemplateGeometryView, User user)
        {
            DataRowView row = familyTemplateGeometryView.AddNew();

            FamilyGeometry geometry = new FamilyGeometry(row, connection, user);
            geometry.Id = Guid.NewGuid().ToString();
            geometry.DateCreated = DateTime.Now;
            geometry.DateModified = DateTime.Now;

            return geometry;
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
