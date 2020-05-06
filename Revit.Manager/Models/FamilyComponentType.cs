using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyComponentType : ModelBase<FamilyComponentType>
    {
        public enum FamilyComponentTypesTableColumnNames { Id, Name, Description, Thumbnail }
        public FamilyComponentType(DataRowView rowView) : base(rowView)
        {
            
        }
    }
}
