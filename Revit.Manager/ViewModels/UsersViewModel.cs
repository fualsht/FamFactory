using ModBox.FamFactory.Revit.Manager.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModBox.FamFactory.Revit.Manager
{
    public class UsersViewModel : ViewModelBase<User>
    {
        public UsersViewModel(DataSet dataSet, System.Data.SQLite.SQLiteConnection connection) : base(dataSet, connection)
        {
            InternalDataView = InternalDataSet.Tables[TableNames.FF_Users.ToString()].DefaultView;
            RefreshCollection();
        }

        public override void RefreshCollection()
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataView)
                {
                    this.AddElement(new User(item, SQLiteConnection), true);
                }
            }
        }

        public override bool CanAddElement()
        {
            return true;
        }

        public override bool CanCreateNewElement()
        {
            bool canStageUser = true;

            if (SelectedElement != null)
            {
                //if (SelectedElement.IsEdit)
                //    canStageUser = false;

                if (SelectedElement.IsNew)
                    canStageUser = false;
            }

            return canStageUser;
        }

        public override bool CanDeleteElement()
        {

            if (SelectedElement == null)
                return false;

            if (SelectedElement.Name == "Admin")
                return false;

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
            bool canSaveUser = true;

            if (SelectedElement != null)
            {
                // CanSaveUser. Only Save if: Email is valid, Username is valid, Username is not Admin, and length is greather than 5 characters, Is in Edit Mode
                if (!SelectedElement.InputEmailValid())
                    canSaveUser = false;

                if (!SelectedElement.isUsernameValid())
                    canSaveUser = false;

                if (SelectedElement.Name == "Admin")
                    canSaveUser = false;

                if (SelectedElement.Name.Length < 6)
                    canSaveUser = false;

                if (!SelectedElement.IsEdit)
                    canSaveUser = false;
            }
            else
                canSaveUser = false;

            return canSaveUser;
        }

        public override object NewElement(object parent)
        {
            return User.NewUser(SQLiteConnection, InternalDataView);
        }

        public override void SaveElement(User element)
        {
            element.EndEdit();
            //Utils.SaveTable(connection, UsersDataView.Table);
            RefreshCollection();
        }

        public override void CancelElementChanges()
        {
            if (SelectedElement != null)
            {
                if (SelectedElement.IsNew)
                {
                    DeleteElement(SelectedElement);
                    GoToElement(SelectionHistory[SelectionHistory.Count - 1]);
                }
                else
                {
                    int i = SelectedElementIndex;
                    SelectedElement.CancelEdit();
                    NotifyPropertyChanged("SelectedElement");
                    RefreshCollection();
                    GoToElement(i);
                }
            }
        }

        public override bool CanCancelElementChanges()
        {
            bool canCancelElementChanges = false;
            if (SelectedElement != null)
            {
                if (SelectedElement.IsNew || SelectedElement.IsEdit)
                {
                    return true;
                }
            }
            return canCancelElementChanges;
        }

        public override void SetActiveUser(User user)
        {
            ActiveUser = user;
        }

        public override void RefreshCollection(string sortColumn, string filter)
        {
            throw new NotImplementedException();
        }
    }
}
