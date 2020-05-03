using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Data
{
    public abstract class FamFactoryDataCollectionBase<T> : INotifyCollectionChanged//, IList<T>
    {
        internal DataTable dataTableSource;

        //    public T this[int index]
        //    {
        //        get { return (T)dataTableSource.Rows[index] as T; }
        //    }

        //    public int Count => throw new NotImplementedException();

        //    public bool IsReadOnly => throw new NotImplementedException();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        //    public void Add(T item)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Clear()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public bool Contains(T item)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void CopyTo(T[] array, int arrayIndex)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IEnumerator<T> GetEnumerator()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public int IndexOf(T item)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Insert(int index, T item)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public bool Remove(T item)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void RemoveAt(int index)
        //    {
        //        throw new NotImplementedException();
        //    }

        internal void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            var handler = CollectionChanged;
            if (handler != null)
                handler(this, args);
        }

        //    IEnumerator IEnumerable.GetEnumerator()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
