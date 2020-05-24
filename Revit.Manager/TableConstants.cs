using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory
{
    public enum EntityStates { Enabled, Disabled }

    public enum TableNames  {   FF_Permissions, 
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
                                FF_FamilyBuildComponentPositions
    }
    public enum TableRelations  {
                                UsersPermissionId_PermissionsId,
                                EmailProfilesCreatedBy_UsersId,
                                EmailProfilesModifiedBy_UsersId,
                                SystemConfigurationsCreatedBy_UsersId,
                                SystemConfigurationsModifiedBy_UsersId,
                                FamilyTemplatesCreatedByUserId_UsersId, 
                                FamilyComponentsFamilyComponentTypeId_FamilyComponentsId, 
                                FamilyComponentsCreatedByUserId_UsersId,
                                FamilyTemplatesReferencePlaneFamilyId_FamilyTemplatesId, 
                                FamilyComponentsReferencePlaneId_FamilyComponentsId, 
                                FamilyTemplateParametersFamilyId_FamilyTemplatesId,
                                FamilyComponentParametersFamilyId_FamilyComponentsId, 
                                FamilyTemplateGeometriesFamilyId_FamilyTemplatesId, 
                                FamilyComponentGeometriesFamilyId_FamilyComponentsId, 
                                FamilyTemplateComponentsFamilyId_FamilyTemplateId,
                                FamilyTemplateComponentsXRefferencePlaneId_FamilyTemplateReferencePlanesId,
                                FamilyTemplateComponentsYRefferencePlaneId_FamilyTemplateReferencePlanesId,
                                FamilyTemplateComponentsZRefferencePlaneId_FamilyTemplateReferencePlanesId,
                                FamilyBuildComponentsFamilyBuildId_FamilyBuildsId,
                                FamilyBuildComponentsFamilyComponentId_FamilyComponentsId,
                                FamilyBuildComponentPositionsFamilyBuildComponentId_FamilyBuildComponentsId,
                                FamilyBuildComponentPositionsTemplateReferencePlaneXId_FamilyTemplateReferencePlanesId,
                                FamilyBuildComponentPositionsTemplateReferencePlaneYId_FamilyTemplateReferencePlanesId,
                                FamilyBuildComponentPositionsTemplateReferencePlaneZId_FamilyTemplateReferencePlanesId,
                                FamilyBuildComponentPositionsComponentReferencePlaneXId_FamilyComponentReferencePlanesId,
                                FamilyBuildComponentPositionsComponentReferencePlaneYId_FamilyComponentReferencePlanesId,
                                FamilyBuildComponentPositionsComponentReferencePlaneZId_FamilyComponentReferencePlanesId
    }
}
