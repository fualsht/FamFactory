using System.Data;
using System.Data.SQLite;
using System.Windows.Input;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyTemplateComponentViewModel : ViewModelBase<FamilyTemplateComponent>
    {
        RelayCommand _AddTemplateComponentCommand;
        public ICommand AddTemplateComponentCommand
        {
            get => _AddTemplateComponentCommand ?? (_AddTemplateComponentCommand = new RelayCommand(param => this.NewElement(), param => this.CanCreateNewElement()));
        }

        public FamilyTemplateComponentViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection) : base(dataSet, sQLiteConnection)
        {
            InternalDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].DefaultView;
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

        public override object NewElement()
        {
            return true;
        }

        public override void SaveElement(FamilyTemplateComponent element)
        {
            FamilyTemplateComponent comp = FamilyTemplateComponent.NewTemplateComponent(SQLiteConnection,InternalDataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].DefaultView, ActiveUser);
            comp.Name = "New Component Reference Pair";
            comp.Description = "A Pair of reference Planes to alighn and lock to.";
            comp.FamilyId = SelectedElement.Id;
        }

        public override void SetActiveUser(User user)
        {
            ActiveUser = user;
        }

        public override void RefreshCollection()
        {

        }
    }
}
