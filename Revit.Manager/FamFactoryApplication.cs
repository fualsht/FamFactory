using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamFactoryApplication
    {
        FamFactoryDataSet set { get; set; } = new FamFactoryDataSet("FamFactoryDataContext");
        public FamFactoryViewModel famFactoryViewModel { get; set; }

        public FamFactoryApplication()
        {
            famFactoryViewModel = new FamFactoryViewModel(set.FFDataSet);
        }
    }
}
