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

        public FamFactoryViewModel(DataSet dataset, System.Data.SQLite.SQLiteConnection sQLiteConnection, User user) : base(dataset, sQLiteConnection, user)
        {
            StartApplication();
        }

        public FamFactoryViewModel(DataSet dataset, System.Data.SQLite.SQLiteConnection sQLiteConnection, User user, Autodesk.Revit.ApplicationServices.Application adskApplication) : base(dataset, sQLiteConnection, user, adskApplication)
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

        public override object NewElement(object parent)
        {
            return null;
        }

        public override void SaveElement(Page element)
        {

        }

        public override void CancelElementChanges()
        {

        }

        public override bool CanCancelElementChanges()
        {
            return true;
        }
        
        public override void RefreshCollections()
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollections(string sortColumn, string filter)
        {
            throw new NotImplementedException();
        }

        public override void EditElement(Page element)
        {
            throw new NotImplementedException();
        }

        public override bool CanEditElement()
        {
            throw new NotImplementedException();
        }

        public override void DeleteElement(Page element)
        {
            throw new NotImplementedException();
        }
    }
}
