using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyBuildComponent : ModelBase<FamilyBuildComponent>
    {
        public enum FamilyBuildComponentsColumnNames { Id, FamilyBuildId, FamilyComponentId }
        public FamilyBuildComponent(DataRowView rowView) : base(rowView)
        {
        }
    }
}
