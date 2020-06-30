using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Input;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyTemplateComponentViewModel : ViewModelBase<FamilyTemplateComponent>
    {
        public FamilyTemplateComponentViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user) : base(dataSet, sQLiteConnection, user)
        {
            InternalDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].DefaultView;
            RefreshCollections();
        }

        public FamilyTemplateComponentViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user, object application) : base(dataSet, sQLiteConnection, user, application)
        {
            InternalDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplateComponents.ToString()].DefaultView;
            RefreshCollections();
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

            SelectedElement = comp;
            if (Utils.EditElement("test", new Pages.TemplateComponentEditorView(), SelectedElement))
            {
                comp.EndEdit();
                AddElement(comp);
                SaveElement(SelectedElement);
                return true;
            }
            else
            {
                SelectedElement = SelectionHistory[SelectionHistory.Count - 1];
                return false;
            }
        }

        public override void SaveElement(FamilyTemplateComponent element)
        {
            FamFactoryDataSet.SaveTableChangesToDatbase(SQLiteConnection, InternalDataView.Table);
            RefreshCollections();
        }

        public override void RefreshCollections()
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataView)
                {
                    this.AddElement(new FamilyTemplateComponent(item, SQLiteConnection, ActiveUser), true);
                }
            }
        }

        public override void RefreshCollections(string sortColumn, string filter)
        {
            if (InternalCollection != null)
            {
                InternalDataView.Sort = sortColumn;
                InternalDataView.RowFilter = filter;
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataView)
                {
                    this.AddElement(new FamilyTemplateComponent(item, SQLiteConnection, ActiveUser), true);
                }
            }
        }

        public override void EditElement(FamilyTemplateComponent element)
        {
            if (Utils.EditElement("Edit Template Comonent.", new Pages.TemplateComponentEditorView(), element))
            {
                element.EndEdit();
                SaveElement(element);
                
            }
            else
            {

            }
        }

        public override bool CanEditElement()
        {
            if (SelectedElement == null)
                return false;
            else
                return true;
        }

        public override void DeleteElement(FamilyTemplateComponent element)
        {
            throw new NotImplementedException();
        }
    }
}
