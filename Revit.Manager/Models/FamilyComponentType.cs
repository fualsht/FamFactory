using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyComponentType : ModelBase<FamilyComponentType>
    {
        public string Description
        {
            get { return internalDataRowView[FamilyComponentTypesColumnNames.Description].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesColumnNames.Description] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public byte[] Thumbnail
        {
            get { return (byte[])internalDataRowView[FamilyComponentTypesColumnNames.Thumbnail]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesColumnNames.Thumbnail] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public FamilyComponentType(DataRowView rowView, SQLiteConnection connection, User user) : base(rowView, connection, user)
        {
            Id = rowView[FamilyComponentTypesColumnNames.Id].ToString();
            Name = rowView[FamilyComponentTypesColumnNames.Name].ToString();
            Description = rowView[FamilyComponentTypesColumnNames.Description].ToString();
            Thumbnail = (byte[])rowView[FamilyComponentTypesColumnNames.Thumbnail];
        }

        public override void RefreshCollections()
        {

        }

        public override void RefreshCollections(string sortColumn, string filter)
        {

        }
    }
}
