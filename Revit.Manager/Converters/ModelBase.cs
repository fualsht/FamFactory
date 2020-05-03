using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public abstract class ModelBase<T> : IModelBase<T>
    {
        internal DataRowView InternalDataRowView;
        public event PropertyChangedEventHandler PropertyChanged;        
        public DataView DataView { get { return InternalDataRowView.DataView; } }
        public DataRow Row { get { return InternalDataRowView.Row; } }
        public bool IsEdit { get { return InternalDataRowView.IsEdit; } }
        public bool IsNew { get { return InternalDataRowView.IsNew; } }
        public DataRowVersion RowVersion { get { return InternalDataRowView.RowVersion; } }
        internal bool _ValuesChanged;
        public bool ValuesChanged { get { return _ValuesChanged; } }
        public ModelBase(DataRowView rowView)
        {
            InternalDataRowView = rowView;
        }

        public void BeginEdit()
        {
            InternalDataRowView.BeginEdit();
        }
        public void EndEdit()
        {
            InternalDataRowView.EndEdit();
        }
        public void CancelEdit()
        {
            InternalDataRowView.CancelEdit();
        }
        public void Delete()
        {
            InternalDataRowView.Delete();
        }

        public  DataView CreateChildView(DataRelation relation)
        {
            return InternalDataRowView.CreateChildView(relation);
        }

        public  DataView CreateChildView(string dataRelation)
        {
            return InternalDataRowView.CreateChildView(dataRelation);
        }
        
        public  DataView CreateChildView(DataRelation dataRelation, bool followParent)
        {
            return InternalDataRowView.CreateChildView(dataRelation, followParent);
        }

        public DataView CreateChildView(string dataRelation, bool followParent)
        {
            return InternalDataRowView.CreateChildView(dataRelation, followParent);
        }

        internal protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override int GetHashCode()
        {
            return InternalDataRowView.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public new Type GetType()
        {
            return InternalDataRowView.GetType(); 
        }
        public override string ToString()
        {
            return InternalDataRowView.ToString();
        }
    }
}
