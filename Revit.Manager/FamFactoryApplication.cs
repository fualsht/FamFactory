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
        DataSet set { get; set; } = new DataSet("FamFactoryDataContext");
        public FamFactoryViewModel famFactoryViewModel { get; set; }

        public FamFactoryApplication()
        {
            PopulateDataSet.InitilizeDataSet(set);
            famFactoryViewModel = new FamFactoryViewModel(set);
        }
    }
}
