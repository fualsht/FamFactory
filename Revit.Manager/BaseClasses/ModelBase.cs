using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public abstract class ModelBase<T> : IModelBase<T>
    {
        User _ActiveUser;
        public User ActiveUser { get { return _ActiveUser; } }

        internal DataRowView internalDataRowView;

        internal SQLiteConnection internalSQLConenction;

        public event PropertyChangedEventHandler PropertyChanged;

        public DataView InternalDataView { get { return internalDataRowView.DataView; } }

        public DataRow Row { get { return internalDataRowView.Row; } }

        public bool IsEdit { get { return internalDataRowView.IsEdit; } }

        public bool IsNew { get { return internalDataRowView.IsNew; } }

        public DataRowVersion RowVersion { get { return internalDataRowView.RowVersion; } }

        internal bool _valuesChanged;
        public bool ValuesChanged { get { return _valuesChanged; } }

        public object DateCreated
        {
            get { return internalDataRowView["DateCreated"]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView["DateCreated"] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public object DateModified
        {
            get { return internalDataRowView["DateModified"]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView["DateModified"] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public string CreatedById
        {
            get { return internalDataRowView["CreatedById"].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView["CreatedById"] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        User _CreatedBy;
        public User CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; NotifyPropertyChanged(); _valuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string ModifiedById
        {
            get { return internalDataRowView["ModifiedById"].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView["ModifiedById"] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        User _ModifiedBy;
        public User ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; NotifyPropertyChanged(); _valuesChanged = true; NotifyPropertyChanged("ValuesChanged"); NotifyValueChanged(); }
        }

        public ModelBase(DataRowView rowView, SQLiteConnection connection, User user)
        {
            internalDataRowView = rowView;
            internalSQLConenction = connection;
            _ActiveUser = user;
            NotifyPropertyChanged("ActiveUser");
        }

        public void BeginEdit()
        {
            internalDataRowView.BeginEdit();
        }
        public void EndEdit()
        {
            internalDataRowView.EndEdit();
        }
        public void CancelEdit()
        {
            internalDataRowView.CancelEdit();
        }
        public void Delete()
        {
            internalDataRowView.Delete();
        }

        public  DataView CreateChildView(DataRelation relation)
        {
            return internalDataRowView.CreateChildView(relation);
        }

        public  DataView CreateChildView(string dataRelation)
        {
            return internalDataRowView.CreateChildView(dataRelation);
        }
        
        public  DataView CreateChildView(DataRelation dataRelation, bool followParent)
        {
            return internalDataRowView.CreateChildView(dataRelation, followParent);
        }

        public DataView CreateChildView(string dataRelation, bool followParent)
        {
            return internalDataRowView.CreateChildView(dataRelation, followParent);
        }

        internal protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override int GetHashCode()
        {
            return internalDataRowView.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public new Type GetType()
        {
            return internalDataRowView.GetType(); 
        }
        public override string ToString()
        {
            return internalDataRowView.ToString();
        }

        public abstract void RefreshCollections();

        public abstract void RefreshCollections(string sortColumn, string filter);

        public void NotifyValueChanged()
        {
            _valuesChanged = true; NotifyPropertyChanged("valuesChanged");
        }
    }
}
