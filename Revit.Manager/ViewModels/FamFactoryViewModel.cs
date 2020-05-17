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
        private User _ActiveUser;

        UsersViewModel _UsersViewModel;
        public UsersViewModel UsersViewModel { get { return _UsersViewModel; } }

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
            Utils.UpdateDataSetFromDataSource(SQLiteConnection, InternalDataSet);
            StartApplication();
        }

        private void StartApplication()
        {
            try
            {
                _UsersViewModel = new UsersViewModel(InternalDataSet, SQLiteConnection);
                NotifyPropertyChanged("UsersViewModel");
                _FamilyTemplatesViewModel = new FamilyTemplatesViewModel(InternalDataSet, SQLiteConnection, ADSKApplciation);
                NotifyPropertyChanged("FamilyTemplatesViewModel");
                _FamilyComponentViewModel = new FamFactoryComponentViewModel(InternalDataSet, SQLiteConnection, ADSKApplciation);
                NotifyPropertyChanged("FamilyComponentViewModel");

                Pages.SystemConfigurationView systemConfigurationView = new Pages.SystemConfigurationView(this);
                Pages.UsersView usersView = new Pages.UsersView(this);
                Pages.FamilyTemplatesView FamTempView = new Pages.FamilyTemplatesView(this);
                Pages.FamilyComponentView familyComponentView = new Pages.FamilyComponentView(this);
                AddElement(usersView);
                AddElement(systemConfigurationView);
                AddElement(FamTempView);
                AddElement(familyComponentView, true);
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
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public override object NewElement(User user)
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
    }
}
