﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class EmailProfileViewModel : ViewModelBase<EmailProfile>
    {
        public EmailProfileViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user) : base(dataSet, sQLiteConnection, user)
        {

        }

        public EmailProfileViewModel(DataSet dataSet, SQLiteConnection sQLiteConnection, User user, object application) : base(dataSet, sQLiteConnection, user, application)
        {
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

        public override void DeleteElement(EmailProfile element)
        {
            throw new NotImplementedException();
        }

        public override void EditElement(EmailProfile element)
        {
            throw new NotImplementedException();
        }

        public override object NewElement(object parent)
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

        public override void SaveElement(EmailProfile element)
        {

        }
    }
}
