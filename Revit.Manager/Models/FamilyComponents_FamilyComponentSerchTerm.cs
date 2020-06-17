using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyComponents_FamilyComponentSerchTerm : ModelBase<FamilyComponents_FamilyComponentSerchTerm>
    {
        public enum FamilyComponents_FamilyComponentSerchTermsColumnNames { Id, FamilyComponentId, FamilyComponentSearchTermId }
        public FamilyComponents_FamilyComponentSerchTerm(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {
        }
    }
}
