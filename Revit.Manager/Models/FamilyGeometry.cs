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
            get { return internalDataRowView[FamilyGeometryColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView[FamilyGeometryColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string FamilyId
        {
            get { return internalDataRowView[FamilyGeometryColumnNames.FamilyId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Name
        {
            get { return internalDataRowView[FamilyGeometryColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return internalDataRowView[FamilyGeometryColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ElementId
        {
            get { return (int)internalDataRowView[FamilyGeometryColumnNames.ElementId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.ElementId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string GeometryType
        {
            get { return internalDataRowView[FamilyGeometryColumnNames.GeometryType.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.GeometryType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int MaterialId
        {
            get { return (int)internalDataRowView[FamilyGeometryColumnNames.MaterialId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.MaterialId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsActive
        {
            get { return (bool)internalDataRowView[FamilyGeometryColumnNames.IsActive.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ProfileFamily1Id
        {
            get { return (int)internalDataRowView[FamilyGeometryColumnNames.ProfileFamily1Id.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.ProfileFamily1Id.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ProfileFamily2Id
        {
            get { return (int)internalDataRowView[FamilyGeometryColumnNames.ProfileFamily2Id.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.ProfileFamily2Id.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int HostId
        {
            get { return (int)internalDataRowView[FamilyGeometryColumnNames.HostId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.HostId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Category
        {
            get { return internalDataRowView[FamilyGeometryColumnNames.Category.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.Category.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string SubCategory
        {
            get { return internalDataRowView[FamilyGeometryColumnNames.SubCategory.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.SubCategory.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string UniqueId
        {
            get { return internalDataRowView[FamilyGeometryColumnNames.UniqueId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.UniqueId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int OwnerViewId
        {
            get { return (int)internalDataRowView[FamilyGeometryColumnNames.OwnerViewId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.OwnerViewId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int LevelId
        {
            get { return (int)internalDataRowView[FamilyGeometryColumnNames.LevelId.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.LevelId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsSolid
        {
            get { return (bool)internalDataRowView[FamilyGeometryColumnNames.IsSolid.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyGeometryColumnNames.IsSolid.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public FamilyGeometry(DataRowView dataRowView, SQLiteConnection connection) : base(dataRowView, connection)
        {

        }

        internal static FamilyGeometry NewFamilyGeometry(SQLiteConnection connection, DataView familyTemplateGeometryView)
        {
            DataRowView row = familyTemplateGeometryView.AddNew();

            FamilyGeometry geometry = new FamilyGeometry(row, connection);
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
