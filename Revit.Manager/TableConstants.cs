﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory
{
    public enum TableNames  {  FF_Permissions,  FF_EmailProfiles, FF_SystemConfiguration, FF_FamilyComponentTypes, FF_FamilyComponents, FF_Users, FF_FamilyTemplates, FF_FamilyTemplateReferencePlanes, 
        FF_FamilyTemplateGeometry, FF_FamilyTemplateParameters, FF_FamilyComponentReferencePlanes, FF_FamilyComponentGeometry, FF_FamilyComponentParameters, FF_FamFactoryBuildConfigurations, FF_FamFactoryBuilds }
    public enum TableRelations  {
        UsersPermissionId_PermissionId, FamilyTemplatesCreatedByUserId_UsersId, FamilyComponentsFamilyFamilyComponentTypeId_FamilyComponentsId, FamilyComponentsCreatedByUserId_UsersId,
            FamilyTemplateReferencePlaneFamilyId_FamilyTemplatesId, FamilyComponentReferencePlaneFamilyId_FamilyComponentsId, FamilyTemplateParametersFamilyId_FamilyTemplatesId,
        FamilyComponentParametersFamilyId_FamilyComponentsId, FamilyTemplateGeometryFamilyId_FamilyTemplatesId, FamilyComponentGeometryFamilyId_FamilyComponentsId
    }
}
