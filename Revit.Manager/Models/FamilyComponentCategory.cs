using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyComponentCategory : ModelBase<FamilyComponentCategory>
    {
        public enum FamilyComponentCategoryColumnNames { Id, Name, Description, Thumbnail, DateCreated, DateModified, CreatedById, ModifiedById, ParentId }
        public FamilyComponentCategory(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {
        }
    }
}
