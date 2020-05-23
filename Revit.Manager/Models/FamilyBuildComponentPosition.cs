using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyBuildComponentPosition : ModelBase<FamilyBuildComponentPosition>
    {
        public enum FamilyBuildComponentPostionColumnNames { Id, FamilyBuildComponentId, TemplateReferencePlaneXId, ComponentRefernecePlaneXId, TemplateReferencePlaneYId, ComponentRefernecePlaneYId, TemplateReferencePlaneZId, 
            ComponentRefernecePlaneZId, XOffset, YOffset, ZOffset, XRotate, YRotate, ZRotate }

        public FamilyBuildComponentPosition(DataRowView rowView) : base(rowView)
        {

        }
    }
}
