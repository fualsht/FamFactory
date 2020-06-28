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
        public string Id { get { return internalDataRowView[FamilyBuildsColumnNames.Id.ToString()].ToString(); } set { internalDataRowView[FamilyBuildsColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }

        public string Name
        {
            get { return internalDataRowView[FamilyBuildsColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildsColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Description
        {
            get { return internalDataRowView[FamilyBuildsColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildsColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public string FamilyTemplateId
        {
            get { return internalDataRowView[FamilyBuildsColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildsColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public EntityStates State
        {
            get { return (EntityStates)internalDataRowView[FamilyBuildsColumnNames.State.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildsColumnNames.State.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
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
