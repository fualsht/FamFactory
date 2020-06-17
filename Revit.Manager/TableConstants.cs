using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory
{
    public enum EntityStates { Enabled, Disabled }

    public enum TableNames
    {
        FF_Permissions,
        FF_Users,
        FF_EmailProfiles,
        FF_SystemConfigurations,
        FF_FamilyComponentTypes,
        FF_FamilyComponents,
        FF_FamilyTemplates,
        FF_FamilyTemplateReferencePlanes,
        FF_FamilyTemplateGeometries,
        FF_FamilyTemplateParameters,
        FF_FamilyComponentReferencePlanes,
        FF_FamilyComponentGeometries,
        FF_FamilyComponentParameters,
        FF_FamilyTemplateComponents,
        FF_FamilyBuilds,
        FF_FamilyBuildComponents,
        FF_FamilyBuildComponentPositions,
        FF_FamilyComponents_FamilyComponentSerchTerms,
        FF_FamilyComponents_FamilyComponentCategories,
        FF_FamilyComponentSearchTerms,
        FF_FamilyComponentCategories
    }
    public enum TableRelations
    {
        Users_PermissionId__Permissions_Id,

        EmailProfiles_CreatedById__Users_Id,
        EmailProfiles_ModifiedById__Users_Id,

        SystemConfigurations_CreatedById__Users_Id,
        SystemConfigurations_ModifiedById__Users_Id,

        FamilyTemplates_CreatedById__Users_Id,
        FamilyTemplates_ModifiedById__Users_Id,

        FamilyTemplateReferencePlanes_FamilyId__FamilyTemplates_Id,
        FamilyTemplateReferencePlanes_CreatedById__Users_Id,
        FamilyTemplateReferencePlanes_ModifiedById__Users_Id,

        FamilyTemplateParameters_FamilyId__FamilyTemplates_Id,
        FamilyTemplateParameters_CreatedById__Users_Id,
        FamilyTemplateParameters_ModifiedById__Users_Id,

        FamilyTemplateGeometries_FamilyId__FamilyTemplates_Id,
        FamilyTemplateGeometries_CreatedById__Users_Id,
        FamilyTemplateGeometries_ModifiedById__Users_Id,

        FamilyComponents_FamilyComponentTypeId__FamilyComponentTypes_Id,
        FamilyComponents_CreatedById__Users_Id,
        FamilyComponents_ModifiedById__Users_Id,

        FamilyComponentReferencePlanes_FamilyId__FamilyComponents_Id,
        FamilyComponentReferencePlanes_CreatedById__Users_Id,
        FamilyComponentReferencePlanes_ModifiedById__Users_Id,

        FamilyComponentParameters_FamilyId__FamilyComponents_Id,
        FamilyComponentParameters_CreatedById__Users_Id,
        FamilyComponentParameters_ModifiedById__Users_Id,

        FamilyComponentGeometries_FamilyId__FamilyComponents_Id,
        FamilyComponentGeometries_CreatedById__Users_Id,
        FamilyComponentGeometries_ModifiedById__Users_Id,

        FamilyTemplateComponents_FamilyId__FamilyTemplate_Id,
        FamilyTemplateComponents_CreatedById__Users_Id,
        FamilyTemplateComponents_ModifiedById__Users_Id,
        FamilyTemplateComponents_XReferencePlaneId__FamilyTemplateReferencePlanes_Id,
        FamilyTemplateComponents_YReferencePlaneId__FamilyTemplateReferencePlanes_Id,
        FamilyTemplateComponents_ZReferencePlaneId__FamilyTemplateReferencePlanes_Id,
        FamilyTemplateComponents_ProfileGeometryId__FamilyTemplateGeometries_Id,
        FamilyTemplateComponents_FamilyComponentTypeId__FamilyComponentTypes_Id,

        FamilyBuilds_FamilyTemplateId__FamilyTemplates_Id,
        FamilyBuilds_CreatedById__Users_Id,
        FamilyBuilds_ModifiedById__Users_Id,

        FamilyBuildComponents_FamilyBuildId__FamilyBuilds_Id,
        FamilyBuildComponents_FamilyComponentId__FamilyComponents_Id,
        FamilyBuildComponents_CreatedById__Users_Id,
        FamilyBuildComponents_ModifiedById__Users_Id,

        FamilyBuildComponentPositions_FamilyBuildComponentId_FamilyBuildComponents_Id,
        FamilyBuildComponentPositions_TemplateReferencePlaneXId__FamilyTemplateReferencePlanes_Id,
        FamilyBuildComponentPositions_TemplateReferencePlaneYId__FamilyTemplateReferencePlanes_Id,
        FamilyBuildComponentPositions_TemplateReferencePlaneZId__FamilyTemplateReferencePlanes_Id,
        FamilyBuildComponentPositions_ComponentReferencePlaneXId__FamilyComponents_Id,
        FamilyBuildComponentPositions_ComponentReferencePlaneYId__FamilyComponents_Id,
        FamilyBuildComponentPositions_ComponentReferencePlaneZId__FamilyComponents_Id,
        FamilyBuildComponentPositions_CreatedById__Users_Id,
        FamilyBuildComponentPositions_ModifiedById__Users_Id,

        FamilyComponents_FamilyComponentCategories_FamilyComponentCategoryId__FamilyComponentCateroies_Id,
        FamilyComponents_FamilyComponentCategories_FamilyComponentId__FamilyComponents_Id,

        FamilyComponents_FamilyComponentSerchTerms_FamilyComponentId__FamilyComponents_Id,
        FamilyComponents_FamilyComponentSerchTerms_FamilyComponentSearchTermId__FamilyComoponentSearchTerms_Id,

        FamilyComponentSearchTerms_CreatedById__Users_Id,
        FamilyComponentSearchTerms_ModifiedById__Users_Id,

        FamilyComponentTypes_CreatedById__Users_Id,
        FamilyComponentTypes_ModifiedById__Users_Id,

    }
}
