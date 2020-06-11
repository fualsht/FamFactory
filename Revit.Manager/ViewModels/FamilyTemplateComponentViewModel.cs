using System.Data;
using System.Data.SQLite;
using System.Windows.Input;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyTemplateComponentViewModel : ViewModelBase<FamilyTemplateComponent>
    {

        public FamilyTemplateComponentViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection) : base(dataSet, sQLiteConnection)
        {
            InternalDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].DefaultView;
            RefreshCollection();
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
            FamilyTemplateComponent comp = null;
            if (parent == null)
            {
                comp = FamilyTemplateComponent.NewTemplateComponent(SQLiteConnection, InternalDataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].DefaultView, ActiveUser, null);
            }
            else
            {
                comp = FamilyTemplateComponent.NewTemplateComponent(SQLiteConnection, InternalDataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].DefaultView, ActiveUser, ((FamilyTemplate)parent));
            }
            comp.Name = "New Component Reference Pair";
            comp.Description = "A Pair of reference Planes to alighn and lock to.";
            AddElement(comp);
            comp.EndEdit();
            return true;
        }

        public override void SaveElement(FamilyTemplateComponent element)
        {
            FamFactoryDataSet.SaveTableChangesToDatbase(SQLiteConnection, InternalDataView.Table);
        }

        public override void SetActiveUser(User user)
        {
            ActiveUser = user;
        }

        public override void RefreshCollection()
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataView)
                {
                    this.AddElement(new FamilyTemplateComponent(item, SQLiteConnection), true);
                }
            }
        }

        public override void RefreshCollection(string sortColumn, string filter)
        {
            if (InternalCollection != null)
            {
                InternalDataView.Sort = sortColumn;
                InternalDataView.RowFilter = filter;
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataView)
                {
                    this.AddElement(new FamilyTemplateComponent(item, SQLiteConnection), true);
                }
            }
        }
    }
}
