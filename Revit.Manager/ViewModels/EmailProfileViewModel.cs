using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class EmailProfileViewModel : ViewModelBase<EmailProfile>
    {
        public EmailProfileViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection) : base(dataSet, sQLiteConnection)
        {

        }

        public EmailProfileViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, object application) : base(dataSet, sQLiteConnection, application)
        {
        }

        public override bool CanAddElement()
        {
            return true;
        }

        public override bool CanCancelElementChanges()
        {
            return true;
        }

        public override void CancelElementChanges()
        {

        }

        public override bool CanCreateNewElement()
        {
            return true;
        }

        public override bool CanDeleteElement()
        {
            return true;
        }

        public override bool CanGoBack()
        {
            return true;
        }

        public override bool CanGoToNext()
        {
            return true;
        }

        public override bool CanSaveElement()
        {
            return true;
        }

        public override object NewElement(object parent)
        {
            return true;
        }

        public override void RefreshCollection()
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollection(string sortColumn, string filter)
        {
            throw new NotImplementedException();
        }

        public override void SaveElement(EmailProfile element)
        {

        }

        public override void SetActiveUser(User user)
        {

        }
    }
}
