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
        public string Id
        {
            get { return internalDataRowView[FamilyComponentTypesColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public string Name
        {
            get { return internalDataRowView[FamilyComponentTypesColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public string Description
        {
            get { return internalDataRowView[FamilyComponentTypesColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public byte[] Thumbnail
        {
            get { return (byte[])internalDataRowView[FamilyComponentTypesColumnNames.Thumbnail.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesColumnNames.Thumbnail.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        public FamilyComponentType(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
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
