using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory
{
    public enum TableNames  {  FF_Permissions,  FF_EmailProfiles, FF_SystemConfiguration, FF_FamilyComponentTypes, FF_FamilyComponents, FF_Users, FF_FamilyTemplates, FF_ReferencePlanes, FF_Geometry, FF_Parameters }
    public enum TableRelations  { PermissionsUserId_UsersId, ParametersFamilyTemplateId_FamilyTemplatesId, ReferencePlanesFamilyTemplateId_FamilyTemplatesId, GeometryFamilyTemplateid_FamilyTemplateId }
}
