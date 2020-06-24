using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyBuild : ModelBase<FamilyBuild>
    {
        public string Id { get { return internalDataRowView[FamilyBuildColumnNames.Id.ToString()].ToString(); } set { internalDataRowView[FamilyBuildColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }

        public string Name
        {
            get { return internalDataRowView[FamilyBuildColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return internalDataRowView[FamilyBuildColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string FamilyTemplateId
        {
            get { return internalDataRowView[FamilyBuildColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[FamilyBuildColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildColumnNames.State.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public FamilyBuild(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {

        }

        public static FamilyBuild newFamilyBuild(SQLiteConnection connection, DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            FamilyBuild build = new FamilyBuild(row, connection);
            build.Id = Guid.NewGuid().ToString();
            return build;
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
