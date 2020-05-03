using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public struct Version
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Revision { get; set; }

        public string VersionText { get { return "v." + Major + "." + Minor + "." + Revision; } }

        public Version(int maj, int min, int rev)
        {
            Major = maj;
            Minor = min;
            Revision = rev;
        }

        public override string ToString()
        {
            return "v." + Major + "." + Minor + "." + Revision;
        }

        public static Version AsVersion(string version)
        {
            try
            {
                string[] vals = version.Split('.');
                Version v = new Version();
                v.Major = Convert.ToInt32(vals[1]);
                v.Minor = Convert.ToInt32(vals[2]);
                v.Revision = Convert.ToInt32(vals[3]);
                return v;
            }
            catch (Exception e)
            {
                throw new Exception("Error Parsing String to Version.", e);
            }
        }
    }
}
