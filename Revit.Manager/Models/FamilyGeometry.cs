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
        public enum FamilyGeometryColumnNames { Id, Name, Description, GeometryType, MaterialId, IsActive, ProfileFamily1Id, ProfileFamily2Id, HostId }

        public string Id
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[FamilyGeometryColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
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
        public string GeometryType
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.GeometryType.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.GeometryType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string MaterialId
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.MaterialId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.MaterialId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string IsActive
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.IsActive.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.IsActive.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ProfileFamily1Id
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.ProfileFamily1Id.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.ProfileFamily1Id.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ProfileFamily2Id
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.ProfileFamily2Id.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.ProfileFamily2Id.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string HostId
        {
            get { return InternalDataRowView[FamilyGeometryColumnNames.HostId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyGeometryColumnNames.HostId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public FamilyGeometry(DataRowView dataRowView) : base(dataRowView)
        {

        }
    }
}
