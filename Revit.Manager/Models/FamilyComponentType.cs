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
        public enum FamilyComponentTypesTableColumnNames { Id, Name, Description, Thumbnail, DateCreated, DateModified, CreatedById, ModifiedById }
        
        public string Id
        {
            get { return internalDataRowView[FamilyComponentTypesTableColumnNames.Id.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string Name
        {
            get { return internalDataRowView[FamilyComponentTypesTableColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return internalDataRowView[FamilyComponentTypesTableColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesTableColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public byte[] Thumbnail
        {
            get { return (byte[])internalDataRowView[FamilyComponentTypesTableColumnNames.Thumbnail.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[FamilyComponentTypesTableColumnNames.Thumbnail.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public FamilyComponentType(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {
            
        }
    }
}
