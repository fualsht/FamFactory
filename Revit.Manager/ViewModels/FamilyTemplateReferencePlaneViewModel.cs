﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyTemplateReferencePlaneViewModel : ViewModelBase<ReferencePlane>
    {
        public FamilyTemplateReferencePlaneViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user) : base(dataSet, sQLiteConnection, user)
        {
            InternalDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].DefaultView;
            RefreshCollections();
        }
        public FamilyTemplateReferencePlaneViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user, object application) : base(dataSet, sQLiteConnection, user, application)
        {
            InternalDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].DefaultView;
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

        public override object NewElement(object parent)
        {
            throw new NotImplementedException();
        }

        public override void RefreshCollections()
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataView)
                {
                    this.AddElement(new ReferencePlane(item, SQLiteConnection, ActiveUser), true);
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
                    this.AddElement(new ReferencePlane(item, SQLiteConnection, ActiveUser), true);
                }
            }
        }

        public override void SaveElement(ReferencePlane element)
        {
            throw new NotImplementedException();
        }

        public override void EditElement(ReferencePlane element)
        {
            throw new NotImplementedException();
        }

        public override bool CanEditElement()
        {
            throw new NotImplementedException();
        }

        public override void DeleteElement(ReferencePlane element)
        {
            throw new NotImplementedException();
        }
    }
}
