using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyBuild : ModelBase<FamilyBuild>
    {
        public enum FamilyBuildsColumnNames { Id, Name, Description, FamilyTemplateId, DateCreated, DateModified, CreatedById, ModifiedById, State }
        public string Id { get { return InternalDataRowView[FamilyBuildsColumnNames.Id.ToString()].ToString(); } set { InternalDataRowView[FamilyBuildsColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }

        public string Name
        {
            get { return InternalDataRowView[FamilyBuildsColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return InternalDataRowView[FamilyBuildsColumnNames.Description.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string FamilyTemplateId
        {
            get { return InternalDataRowView[FamilyBuildsColumnNames.Description.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public object DateCreated
        {
            get { return InternalDataRowView[FamilyBuildsColumnNames.DateCreated.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public object DateModified
        {
            get { return InternalDataRowView[FamilyBuildsColumnNames.DateModified.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string CreatdById
        {
            get { return InternalDataRowView[FamilyBuildsColumnNames.CreatedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string ModifiedById
        {
            get { return InternalDataRowView[FamilyBuildsColumnNames.ModifiedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public EntityStates State
        {
            get { return (EntityStates)InternalDataRowView[FamilyBuildsColumnNames.State.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public FamilyBuild(DataRowView rowView) : base(rowView)
        {

        }

        public static FamilyBuild newFamilyBuild(DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            FamilyBuild build = new FamilyBuild(row);
            build.Id = Guid.NewGuid().ToString();
            return build;
        }
    }
}
