using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory
{
    public enum EntityStates { Enabled, Disabled }

    public static class TableNames
    {
        public static string FF_Permissions { get { return "FF_Permissions"; } }
        public static string FF_Users { get { return "FF_Users"; } }
        public static string FF_EmailProfiles { get { return "FF_EmailProfiles"; } }
        public static string FF_SystemConfigurations { get { return "FF_SystemConfigurations"; } }
        public static string FF_FamilyComponentTypes { get { return "FF_FamilyComponentTypes"; } }
        public static string FF_FamilyComponents { get { return "FF_FamilyComponents"; } }
        public static string FF_FamilyTemplates { get { return "FF_FamilyTemplates"; } }
        public static string FF_FamilyTemplateReferencePlanes { get { return "FF_FamilyTemplateReferencePlanes"; } }
        public static string FF_FamilyTemplateGeometries { get { return "FF_FamilyTemplateGeometries"; } }
        public static string FF_FamilyTemplateParameters { get { return "FF_FamilyTemplateParameters"; } }
        public static string FF_FamilyComponentReferencePlanes { get { return "FF_FamilyComponentReferencePlanes"; } }
        public static string FF_FamilyComponentGeometries { get { return "FF_FamilyComponentGeometries"; } }
        public static string FF_FamilyComponentParameters { get { return "FF_FamilyComponentParameters"; } }
        public static string FF_FamilyTemplateComponents { get { return "FF_FamilyTemplateComponents"; } }
        public static string FF_FamilyBuilds { get { return "FF_FamilyBuilds"; } }
        public static string FF_FamilyBuildComponents { get { return "FF_FamilyBuildComponents"; } }
        public static string FF_FamilyBuildComponentPositions { get { return "FF_FamilyBuildComponentPositions"; } }
        public static string FF_FamilyComponents_FamilyComponentSerchTerms { get { return "FF_FamilyComponents_FamilyComponentSerchTerms"; } }
        public static string FF_FamilyComponents_FamilyComponentCategories { get { return "FF_FamilyComponents_FamilyComponentCategories"; } }
        public static string FF_FamilyComponentSearchTerms { get { return "FF_FamilyComponentSearchTerms"; } }
        public static string FF_FamilyComponentCategories { get { return "FF_FamilyComponentCategories"; } }
    }

    public static class TableRelations
    {
        public static string Users_PermissionId__Permissions_Id { get { return "Users_PermissionId__Permissions_Id"; } }

        public static string EmailProfiles_CreatedById__Users_Id { get { return "EmailProfiles_CreatedById__Users_Id"; } }
        public static string EmailProfiles_ModifiedById__Users_Id { get { return "EmailProfiles_ModifiedById__Users_Id"; } }

        public static string SystemConfigurations_CreatedById__Users_Id { get { return "SystemConfigurations_CreatedById__Users_Id"; } }
        public static string SystemConfigurations_ModifiedById__Users_Id { get { return "SystemConfigurations_ModifiedById__Users_Id"; } }

        public static string FamilyTemplates_CreatedById__Users_Id { get { return "FamilyTemplates_CreatedById__Users_Id"; } }
        public static string FamilyTemplates_ModifiedById__Users_Id { get { return "FamilyTemplates_ModifiedById__Users_Id"; } }

        public static string FamilyTemplateReferencePlanes_FamilyId__FamilyTemplates_Id { get { return "FamilyTemplateReferencePlanes_FamilyId__FamilyTemplates_Id"; } }
        public static string FamilyTemplateReferencePlanes_CreatedById__Users_Id { get { return "FamilyTemplateReferencePlanes_CreatedById__Users_Id"; } }
        public static string FamilyTemplateReferencePlanes_ModifiedById__Users_Id { get { return "FamilyTemplateReferencePlanes_ModifiedById__Users_Id"; } }

        public static string FamilyTemplateParameters_FamilyId__FamilyTemplates_Id { get { return "FamilyTemplateParameters_FamilyId__FamilyTemplates_Id"; } }
        public static string FamilyTemplateParameters_CreatedById__Users_Id { get { return "FamilyTemplateParameters_CreatedById__Users_Id"; } }
        public static string FamilyTemplateParameters_ModifiedById__Users_Id { get { return "FamilyTemplateParameters_ModifiedById__Users_Id"; } }

        public static string FamilyTemplateGeometries_FamilyId__FamilyTemplates_Id { get { return "FamilyTemplateGeometries_FamilyId__FamilyTemplates_Id"; } }
        public static string FamilyTemplateGeometries_CreatedById__Users_Id { get { return "FamilyTemplateGeometries_CreatedById__Users_Id"; } }
        public static string FamilyTemplateGeometries_ModifiedById__Users_Id { get { return "FamilyTemplateGeometries_ModifiedById__Users_Id"; } }

        public static string FamilyComponents_FamilyComponentTypeId__FamilyComponentTypes_Id { get { return "FamilyComponents_FamilyComponentTypeId__FamilyComponentTypes_Id"; } }
        public static string FamilyComponents_CreatedById__Users_Id { get { return "FamilyComponents_CreatedById__Users_Id"; } }
        public static string FamilyComponents_ModifiedById__Users_Id { get { return "FamilyComponents_ModifiedById__Users_Id"; } }

        public static string FamilyComponentReferencePlanes_FamilyId__FamilyComponents_Id { get { return "FamilyComponentReferencePlanes_FamilyId__FamilyComponents_Id"; } }
        public static string FamilyComponentReferencePlanes_CreatedById__Users_Id { get { return "FamilyComponentReferencePlanes_CreatedById__Users_Id"; } }
        public static string FamilyComponentReferencePlanes_ModifiedById__Users_Id { get { return "FamilyComponentReferencePlanes_ModifiedById__Users_Id"; } }

        public static string FamilyComponentParameters_FamilyId__FamilyComponents_Id { get { return "FamilyComponentParameters_FamilyId__FamilyComponents_Id"; } }
        public static string FamilyComponentParameters_CreatedById__Users_Id { get { return "FamilyComponentParameters_CreatedById__Users_Id"; } }
        public static string FamilyComponentParameters_ModifiedById__Users_Id { get { return "FamilyComponentParameters_ModifiedById__Users_Id"; } }

        public static string FamilyComponentGeometries_FamilyId__FamilyComponents_Id { get { return "FamilyComponentGeometries_FamilyId__FamilyComponents_Id"; } }
        public static string FamilyComponentGeometries_CreatedById__Users_Id { get { return "FamilyComponentGeometries_CreatedById__Users_Id"; } }
        public static string FamilyComponentGeometries_ModifiedById__Users_Id { get { return "FamilyComponentGeometries_ModifiedById__Users_Id"; } }

        public static string FamilyTemplateComponents_FamilyId__FamilyTemplate_Id { get { return "FamilyTemplateComponents_FamilyId__FamilyTemplate_Id"; } }
        public static string FamilyTemplateComponents_CreatedById__Users_Id { get { return "FamilyTemplateComponents_CreatedById__Users_Id"; } }
        public static string FamilyTemplateComponents_ModifiedById__Users_Id { get { return "FamilyTemplateComponents_ModifiedById__Users_Id"; } }
        public static string FamilyTemplateComponents_XReferencePlaneId__FamilyTemplateReferencePlanes_Id { get { return "FamilyTemplateComponents_XReferencePlaneId__FamilyTemplateReferencePlanes_Id"; } }
        public static string FamilyTemplateComponents_YReferencePlaneId__FamilyTemplateReferencePlanes_Id { get { return "FamilyTemplateComponents_YReferencePlaneId__FamilyTemplateReferencePlanes_Id"; } }
        public static string FamilyTemplateComponents_ZReferencePlaneId__FamilyTemplateReferencePlanes_Id { get { return "FamilyTemplateComponents_ZReferencePlaneId__FamilyTemplateReferencePlanes_Id"; } }
        public static string FamilyTemplateComponents_ProfileGeometryId__FamilyTemplateGeometries_Id { get { return "FamilyTemplateComponents_ProfileGeometryId__FamilyTemplateGeometries_Id"; } }
        public static string FamilyTemplateComponents_FamilyComponentTypeId__FamilyComponentTypes_Id { get { return "FamilyTemplateComponents_FamilyComponentTypeId__FamilyComponentTypes_Id"; } }

        public static string FamilyBuilds_FamilyTemplateId__FamilyTemplates_Id { get { return "FamilyBuilds_FamilyTemplateId__FamilyTemplates_Id"; } }
        public static string FamilyBuilds_CreatedById__Users_Id { get { return "FamilyBuilds_CreatedById__Users_Id"; } }
        public static string FamilyBuilds_ModifiedById__Users_Id { get { return "FamilyBuilds_ModifiedById__Users_Id"; } }

        public static string FamilyBuildComponents_FamilyBuildId__FamilyBuilds_Id { get { return "FamilyBuildComponents_FamilyBuildId__FamilyBuilds_Id"; } }
        public static string FamilyBuildComponents_FamilyComponentId__FamilyComponents_Id { get { return "FamilyBuildComponents_FamilyComponentId__FamilyComponents_Id"; } }
        public static string FamilyBuildComponents_CreatedById__Users_Id { get { return "FamilyBuildComponents_CreatedById__Users_Id"; } }
        public static string FamilyBuildComponents_ModifiedById__Users_Id { get { return "FamilyBuildComponents_ModifiedById__Users_Id"; } }

        public static string FamilyBuildComponentPositions_FamilyBuildComponentId_FamilyBuildComponents_Id { get { return "FamilyBuildComponentPositions_FamilyBuildComponentId_FamilyBuildComponents_Id"; } }
        public static string FamilyBuildComponentPositions_TemplateReferencePlaneXId__FamilyTemplateReferencePlanes_Id { get { return "FamilyBuildComponentPositions_TemplateReferencePlaneXId__FamilyTemplateReferencePlanes_Id"; } }
        public static string FamilyBuildComponentPositions_TemplateReferencePlaneYId__FamilyTemplateReferencePlanes_Id { get { return "FamilyBuildComponentPositions_TemplateReferencePlaneYId__FamilyTemplateReferencePlanes_Id"; } }
        public static string FamilyBuildComponentPositions_TemplateReferencePlaneZId__FamilyTemplateReferencePlanes_Id { get { return "FamilyBuildComponentPositions_TemplateReferencePlaneZId__FamilyTemplateReferencePlanes_Id"; } }
        public static string FamilyBuildComponentPositions_ComponentReferencePlaneXId__FamilyComponents_Id { get { return "FamilyBuildComponentPositions_ComponentReferencePlaneXId__FamilyComponents_Id"; } }
        public static string FamilyBuildComponentPositions_ComponentReferencePlaneYId__FamilyComponents_Id { get { return "FamilyBuildComponentPositions_ComponentReferencePlaneYId__FamilyComponents_Id"; } }
        public static string FamilyBuildComponentPositions_ComponentReferencePlaneZId__FamilyComponents_Id { get { return "FamilyBuildComponentPositions_ComponentReferencePlaneZId__FamilyComponents_Id"; } }
        public static string FamilyBuildComponentPositions_CreatedById__Users_Id { get { return "FamilyBuildComponentPositions_CreatedById__Users_Id"; } }
        public static string FamilyBuildComponentPositions_ModifiedById__Users_Id { get { return "FamilyBuildComponentPositions_ModifiedById__Users_Id"; } }

        public static string FamilyComponents_FamilyComponentCategories_FamilyComponentCategoryId__FamilyComponentCateroies_Id { get { return "FamilyComponents_FamilyComponentCategories_FamilyComponentCategoryId__FamilyComponentCateroies_Id"; } }
        public static string FamilyComponents_FamilyComponentCategories_FamilyComponentId__FamilyComponents_Id { get { return "FamilyComponents_FamilyComponentCategories_FamilyComponentId__FamilyComponents_Id"; } }
        public static string FamilyComponentCategories_CreatedById__Users_Id { get { return "FamilyComponentCategories_CreatedById__Users_Id"; } }
        public static string FamilyComponentCategories_ModifiedById__Users_Id { get { return "FamilyComponentCategories_ModifiedById__Users_Id"; } }

        public static string FamilyComponents_FamilyComponentSerchTerms_FamilyComponentId__FamilyComponents_Id { get { return "FamilyComponents_FamilyComponentSerchTerms_FamilyComponentId__FamilyComponents_Id"; } }
        public static string FamilyComponents_FamilyComponentSerchTerms_FamilyComponentSearchTermId__FamilyComponentSearchTerms_Id { get { return "FamilyComponents_FamilyComponentSerchTerms_FamilyComponentSearchTermId__FamilyComponentSearchTerms_Id"; } }


        public static string FamilyComponentSearchTerms_CreatedById__Users_Id { get { return "FamilyComponentSearchTerms_CreatedById__Users_Id"; } }
        public static string FamilyComponentSearchTerms_ModifiedById__Users_Id { get { return "FamilyComponentSearchTerms_ModifiedById__Users_Id"; } }
        public static string FamilyComponentTypes_CreatedById__Users_Id { get { return "FamilyComponentTypes_CreatedById__Users_Id"; } }
        public static string FamilyComponentTypes_ModifiedById__Users_Id { get { return "FamilyComponentTypes_ModifiedById__Users_Id"; } }
    }
}
