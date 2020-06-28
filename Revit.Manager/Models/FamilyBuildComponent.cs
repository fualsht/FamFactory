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
        public string Id
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string FamilyBuildId
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.FamilyBuildId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.FamilyBuildId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string FamilyComponentId
        {
            get { return internalDataRowView[FamilyBuildComponentsColumnNames.FamilyComponentId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyBuildComponentsColumnNames.FamilyComponentId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        
        public FamilyBuildComponent(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        { 
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
