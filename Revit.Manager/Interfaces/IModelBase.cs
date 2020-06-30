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
    public interface IModelBase<T> : INotifyPropertyChanged
    {
        User ActiveUser { get; }
        DataView InternalDataView { get ; } 
        DataRow Row { get ;  }
        bool IsEdit { get ; }
        bool IsNew { get ; }
        DataRowVersion RowVersion { get; } 
        bool ValuesChanged { get; }
        void BeginEdit();
        void EndEdit();
        void CancelEdit();
        void Delete();
        DataView CreateChildView(DataRelation relation);
        DataView CreateChildView(string dataRelation);
        DataView CreateChildView(DataRelation dataRelation, bool followParent);
        DataView CreateChildView(string dataRelation, bool followParent);
        void RefreshCollections();
        void RefreshCollections(string sortColumn, string filter);
        void NotifyValueChanged();
    }
}
