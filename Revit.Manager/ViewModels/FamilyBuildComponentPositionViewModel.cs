using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyBuildComponentPositionViewModel : ViewModelBase<FamilyBuildComponentPosition>
    {
        public FamilyBuildComponentPositionViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection) : base(dataSet, sQLiteConnection)
        {
        }

        public FamilyBuildComponentPositionViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, object application) : base(dataSet, sQLiteConnection, application)
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

        public override void EditElement(FamilyBuildComponentPosition element)
        {
            throw new NotImplementedException();
        }

        public override object NewElement(object parent)
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollection()
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollection(string sortColumn, string filter)
        {
            throw new NotImplementedException();
        }

        public override void SaveElement(FamilyBuildComponentPosition element)
        {
            throw new NotImplementedException();
        }

        public override void SetActiveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
