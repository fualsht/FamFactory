using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory
{
    public enum TableNames  {  FF_Permissions,  FF_EmailProfiles, FF_SystemConfiguration, FF_Users, FF_FamilyTemplates, FF_ReferencePlanes, FF_Geometry, FF_Parameters }
    public enum TableRelations  { UsersPermissionId_PermissionsId }
}
