using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyComponentTypeViewModel : ViewModelBase<FamilyComponentType>
    {
        public FamilyComponentTypeViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user) : base(dataSet, sQLiteConnection, user)
        {
            InternalDataView = InternalDataSet.Tables[TableNames.FF_FamilyComponentTypes].DefaultView;
            RefreshCollections();
        }
        public FamilyComponentTypeViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user, object application) : base(dataSet, sQLiteConnection, user, application)
        {
            InternalDataView = InternalDataSet.Tables[TableNames.FF_FamilyComponentTypes].DefaultView;
            RefreshCollections();
        }

        public override bool CanAddElement()
        {
            throw new NotImplementedException();
        }

        public override bool CanCancelElementChanges()
        {
            throw new NotImplementedException();
        }

        public override void CancelElementChanges()
        {
            throw new NotImplementedException();
        }

        public override bool CanDeleteElement()
        {
            throw new NotImplementedException();
        }

        public override bool CanEditElement()
        {
            throw new NotImplementedException();
        }

        public override bool CanGoBack()
        {
            throw new NotImplementedException();
        }

        public override bool CanGoToNext()
        {
            throw new NotImplementedException();
        }

        public override bool CanSaveElement()
        {
            throw new NotImplementedException();
        }

        public override void DeleteElement(FamilyComponentType element)
        {
            throw new NotImplementedException();
        }

        public override void EditElement(FamilyComponentType element)
        {
            throw new NotImplementedException();
        }

        public override object NewElement(object parent)
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollections()
        {
            InternalCollection.Clear();
            foreach (DataRowView item in InternalDataView)
            {
                InternalCollection.Add(new FamilyComponentType(item, SQLiteConnection, ActiveUser));
            }
        }

        public override void RefreshCollections(string sortColumn, string filter)
        {
            throw new NotImplementedException();
        }

        public override void SaveElement(FamilyComponentType element)
        {
            throw new NotImplementedException();
        }
    }
}
