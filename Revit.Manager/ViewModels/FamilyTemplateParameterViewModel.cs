using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyTemplateParameterViewModel : ViewModelBase<Parameter>
    {
        public FamilyTemplateParameterViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection) : base(dataSet, sQLiteConnection)
        {
            InternalDataView = dataSet.Tables[TableNames.FF_FamilyTemplateParameters.ToString()].DefaultView;
            RefreshCollections();
        }

        public FamilyTemplateParameterViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, object application) : base(dataSet, sQLiteConnection, application)
        {
            InternalDataView = dataSet.Tables[TableNames.FF_FamilyTemplateParameters.ToString()].DefaultView;
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

        public override bool CanEditElement()
        {
            throw new NotImplementedException();
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

        public override void EditElement(Parameter element)
        {
            throw new NotImplementedException();
        }

        public override object NewElement(object parent)
        {
            return true;
        }

        public override void RefreshCollections()
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataView)
                {
                    this.AddElement(new Parameter(item, SQLiteConnection), true);
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
                    this.AddElement(new Parameter(item, SQLiteConnection), true);
                }
            }
        }

        public override void SaveElement(Parameter element)
        {

        }

        public override void SetActiveUser(User user)
        {

        }
    }
}
