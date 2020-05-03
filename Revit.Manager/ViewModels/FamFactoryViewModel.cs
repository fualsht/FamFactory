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
        public UsersViewModel UsersViewModel { get { return _UsersViewModel; } }

        FamilyTemplatesViewModel _FamilyTemplatesViewModel;
        public FamilyTemplatesViewModel FamilyTemplatesViewModel { get { return _FamilyTemplatesViewModel; } }

        public FamFactoryViewModel(DataSet dataset) : base(dataset)
        {
            StartApplication();
        }

        public FamFactoryViewModel(DataSet dataset, Autodesk.Revit.ApplicationServices.Application adskApplication) : base(dataset, adskApplication)
        {
            StartApplication();
        }

        private void StartApplication()
        {
            try
            {
                _UsersViewModel = new UsersViewModel(InternalDataSet);
                NotifyPropertyChanged("UsersViewModel");
                _FamilyTemplatesViewModel = new FamilyTemplatesViewModel(InternalDataSet, ADSKApplciation);
                NotifyPropertyChanged("FamilyTemplatesViewModel");

                Pages.SystemConfigurationView systemConfigurationView = new Pages.SystemConfigurationView(this);
                Pages.UsersView usersView = new Pages.UsersView(this);
                Pages.FamilyTemplatesView tempView = new Pages.FamilyTemplatesView(this);
                AddElement(usersView);
                AddElement(systemConfigurationView);
                AddElement(tempView, true);
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

        public override void NewElement()
        {

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
