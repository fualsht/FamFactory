using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyBuildComponent : ModelBase<FamilyBuildComponent>
    {
        public enum FamilyBuildComponentsColumnNames { Id, FamilyBuildId, FamilyComponentId, DateCreated, DateModified, CreatedById, ModifiedById }
        public string Id
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FamilyBuildId
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.FamilyBuildId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.FamilyBuildId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FamilyComponentId
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.FamilyComponentId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.FamilyComponentId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public object DateCreated
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.DateCreated.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public object DateModified
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.DateModified.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string CreatdById
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.CreatedById.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string ModifiedById
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.ModifiedById.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public FamilyBuildComponent(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        { 
        }
    }
}
