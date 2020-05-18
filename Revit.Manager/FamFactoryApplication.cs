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
            System.Data.SQLite.SQLiteConnection conn = Utils.GetSQlteConnection(@"c:\temp\famFactoryDatabase.db");
            famFactoryViewModel = new FamFactoryViewModel(set, conn);
            famFactoryViewModel.LogIn(famFactoryViewModel.UsersViewModel.InternalCollection[0]);
        }
    }
}
