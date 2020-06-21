using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyComponents_FamilyComponentCategory : ModelBase<FamilyComponents_FamilyComponentCategory>
    {
        public enum FamilyComponents_FamilyComponentCategoryColumnNames { Id, FamilyComponentId, FamilyComponentCategoryId }
        public FamilyComponents_FamilyComponentCategory(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
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
