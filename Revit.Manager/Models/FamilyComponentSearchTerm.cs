using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyComponentSearchTerm : ModelBase<FamilyComponentSearchTerm>
    {
        public enum FamilyComponentSearchTermColumnNames { Id, Name, Description, DateCreated, DateModified, CreatedById, ModifiedById }
        public FamilyComponentSearchTerm(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
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
