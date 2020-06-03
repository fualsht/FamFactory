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
        internal DataRowView internalDataRowView;

        internal SQLiteConnection internalSQLConenction;

        public event PropertyChangedEventHandler PropertyChanged;

        public DataView InternalDataView { get { return internalDataRowView.DataView; } }

        public DataRow Row { get { return internalDataRowView.Row; } }

        public bool IsEdit { get { return internalDataRowView.IsEdit; } }

        public bool IsNew { get { return internalDataRowView.IsNew; } }

        public DataRowVersion RowVersion { get { return internalDataRowView.RowVersion; } }

        internal bool _ValuesChanged;
        public bool ValuesChanged { get { return _ValuesChanged; } }
        public ModelBase(DataRowView rowView, SQLiteConnection connection)
        {
            internalDataRowView = rowView;
            internalSQLConenction = connection;
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
    }
}
