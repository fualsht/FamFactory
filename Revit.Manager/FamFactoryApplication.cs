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
            System.Data.SQLite.SQLiteConnection conn = FamFactoryDataSet.GetSQlteConnection(@"c:\temp\famFactoryDatabase.db");
            //famFactoryViewModel = new FamFactoryViewModel(set, conn);
            //famFactoryViewModel.LogIn(famFactoryViewModel.UserItems.InternalCollection[0]);


            User user = FamFactoryDataSet.AuthenticateUser("Admin", "Password", conn);
            famFactoryViewModel = new FamFactoryViewModel(set, conn, user);
        }
    }
}
