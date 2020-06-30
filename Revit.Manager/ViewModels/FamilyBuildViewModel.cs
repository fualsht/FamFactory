using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyBuildViewModel : ViewModelBase<FamilyBuild>
    {
        public FamilyBuildViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user) : base(dataSet, sQLiteConnection, user)
        {
        }

        public FamilyBuildViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user, object application) : base(dataSet, sQLiteConnection, user, application)
        {
        }

        public override bool CanAddElement()
        {
            throw new NotImplementedException();
        }

        public override bool CanCancelElementChanges()
        {
            throw new NotImplementedException();
        }

        public override void CancelElementChanges()
        {
            throw new NotImplementedException();
        }

        public override bool CanDeleteElement()
        {
            throw new NotImplementedException();
        }

        public override bool CanEditElement()
        {
            throw new NotImplementedException();
        }

        public override bool CanGoBack()
        {
            throw new NotImplementedException();
        }

        public override bool CanGoToNext()
        {
            throw new NotImplementedException();
        }

        public override bool CanSaveElement()
        {
            throw new NotImplementedException();
        }

        public override void DeleteElement(FamilyBuild element)
        {
            throw new NotImplementedException();
        }

        public override void EditElement(FamilyBuild element)
        {
            throw new NotImplementedException();
        }

        public override object NewElement(object parent)
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollections()
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollections(string sortColumn, string filter)
        {
            throw new NotImplementedException();
        }

        public override void SaveElement(FamilyBuild element)
        {
            throw new NotImplementedException();
        }
    }
}
