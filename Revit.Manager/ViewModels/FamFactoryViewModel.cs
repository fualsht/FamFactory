using ModBox.FamFactory.Revit.Manager.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamFactoryViewModel : ViewModelBase<Page>
    {
        UsersViewModel _UsersViewModel;
        public UsersViewModel UserItems { get { return _UsersViewModel; } }

        FamilyTemplatesViewModel _FamilyTemplatesViewModel;
        public FamilyTemplatesViewModel FamilyTemplatesViewModel { get { return _FamilyTemplatesViewModel; } }

        FamFactoryComponentViewModel _FamilyComponentViewModel;
        public FamFactoryComponentViewModel FamilyComponentViewModel { get { return _FamilyComponentViewModel; } }

        public FamFactoryViewModel(DataSet dataset, System.Data.SQLite.SQLiteConnection sQLiteConnection) : base(dataset, sQLiteConnection)
        {
            StartApplication();
        }

        public FamFactoryViewModel(DataSet dataset, System.Data.SQLite.SQLiteConnection sQLiteConnection, Autodesk.Revit.ApplicationServices.Application adskApplication) : base(dataset, sQLiteConnection, adskApplication)
        {
            StartApplication();
        }

        private void StartApplication()
        {
            try
            {
                FamFactoryDataSet.UpdateDataSetFromDataSource(SQLiteConnection, InternalDataSet);
                _UsersViewModel = new UsersViewModel(InternalDataSet, SQLiteConnection);
                _FamilyTemplatesViewModel = new FamilyTemplatesViewModel(InternalDataSet, SQLiteConnection, ADSKApplciation);
                _FamilyComponentViewModel = new FamFactoryComponentViewModel(InternalDataSet, SQLiteConnection, ADSKApplciation);

                Pages.SystemConfigurationView systemConfigurationView = new Pages.SystemConfigurationView(this);
                Pages.UsersView usersView = new Pages.UsersView(this);
                Pages.FamilyTemplatesView FamTempView = new Pages.FamilyTemplatesView(this);
                Pages.FamilyComponentView familyComponentView = new Pages.FamilyComponentView(this);

                AddElement(usersView);
                AddElement(systemConfigurationView);
                AddElement(FamTempView, true);
                AddElement(familyComponentView);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool LaunchManagerWindow()
        {
            MainWindow window = new MainWindow(this);
            if(window.ShowDialog() == true)
                return true;
            else
                return false;
        }

        public override bool CanAddElement()
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

        public override object NewElement()
        {
            return null;
        }

        public override void SaveElement(Page element)
        {

        }

        public override bool CanCreateNewElement()
        {
            return true;
        }

        public override void CancelElementChanges()
        {

        }

        public override bool CanCancelElementChanges()
        {
            return true;
        }

        public void LogIn(User user)
        {
            SetActiveUser(user);
            UserItems.SetActiveUser(user);
            FamilyTemplatesViewModel.SetActiveUser(user);
            FamilyComponentViewModel.SetActiveUser(user);
        }

        public override void SetActiveUser(User user)
        {
            ActiveUser = user;
        }

        public override void RefreshCollection()
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollection(string sortColumn, string filter)
        {
            throw new NotImplementedException();
        }
    }
}
