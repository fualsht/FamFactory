using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyGeometry : ModelBase<FamilyGeometry>
    {
        public enum FamilyGeometryColumnNames { Id, FamilyId, Name, Description, ElementId, GeometryType, MaterialId, IsActive, 
            ProfileFamily1Id, ProfileFamily2Id, HostId, Category, SubCategory, UniqueId, OwnerViewId, LevelId, IsSolid, DateCreated, 
            DateModified, CreatedById, ModifiedById
        }

        public string Id
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[FamilyGeometryColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string FamilyId
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.FamilyId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Name
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.Description.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ElementId
        {
            get { return (int)InternalDataRowView[FamilyGeometryColumnNames.ElementId.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.ElementId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string GeometryType
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.GeometryType.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.GeometryType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int MaterialId
        {
            get { return (int)InternalDataRowView[FamilyGeometryColumnNames.MaterialId.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.MaterialId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsActive
        {
            get { return (bool)InternalDataRowView[FamilyGeometryColumnNames.IsActive.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ProfileFamily1Id
        {
            get { return (int)InternalDataRowView[FamilyGeometryColumnNames.ProfileFamily1Id.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.ProfileFamily1Id.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int ProfileFamily2Id
        {
            get { return (int)InternalDataRowView[FamilyGeometryColumnNames.ProfileFamily2Id.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.ProfileFamily2Id.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int HostId
        {
            get { return (int)InternalDataRowView[FamilyGeometryColumnNames.HostId.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.HostId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Category
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.Category.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.Category.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string SubCategory
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.SubCategory.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.SubCategory.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string UniqueId
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.UniqueId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.UniqueId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int OwnerViewId
        {
            get { return (int)InternalDataRowView[FamilyGeometryColumnNames.OwnerViewId.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.OwnerViewId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public int LevelId
        {
            get { return (int)InternalDataRowView[FamilyGeometryColumnNames.LevelId.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.LevelId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsSolid
        {
            get { return (bool)InternalDataRowView[FamilyGeometryColumnNames.IsSolid.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.IsSolid.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public object DateCreated
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.DateCreated.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public object DateModified
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.DateModified.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CreatedById
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.CreatedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        User _CreatedBy;
        public User CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string ModifiedById
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.ModifiedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        User _ModifiedBy;
        public User ModifieddBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public FamilyGeometry(DataRowView dataRowView) : base(dataRowView)
        {

        }

        internal static FamilyGeometry NewFamilyGeometry(DataView familyTemplateGeometryView)
        {
            DataRowView row = familyTemplateGeometryView.AddNew();

            FamilyGeometry geometry = new FamilyGeometry(row);
            geometry.Id = Guid.NewGuid().ToString();
            geometry.DateCreated = DateTime.Now;
            geometry.DateModified = DateTime.Now;

            return geometry;
        }
    }
}
