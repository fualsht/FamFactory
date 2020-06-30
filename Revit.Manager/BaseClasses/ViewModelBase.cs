using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ModBox.FamFactory.Revit.Manager
{
    public abstract class ViewModelBase<T> : IViewModel<T>
    {
        static object _adskApplciation;
        internal static object ADSKApplciation { get { return _adskApplciation; } }

        DataView _internalDataView;
        internal DataView InternalDataView { get { return _internalDataView; } set { _internalDataView = value; } }

        private User _ActiveUser;
        public User ActiveUser { get { return _ActiveUser; } }

        DataSet _InternalDataContext;
        public DataSet InternalDataSet { get { return _InternalDataContext; } }

        ObservableCollection<T> _InternalCollection;
        public ObservableCollection<T> InternalCollection { get { return _InternalCollection; } }

        ObservableCollection<T> _SelectionHistory;
        public ObservableCollection<T> SelectionHistory { get { return _SelectionHistory; } }

        System.Data.SQLite.SQLiteConnection _SQLiteConnection;
        public System.Data.SQLite.SQLiteConnection SQLiteConnection { get { return _SQLiteConnection; } }

        public event EventHandler OnSelectionChagned = new EventHandler((e, a) => { });
        public event PropertyChangedEventHandler PropertyChanged;

        private T _SelectedElement;
        public T SelectedElement
        {
            get
            {
                return _SelectedElement;
            }
            set
            {
                if (_SelectedElement != null)
                    SelectionHistory.Add(_SelectedElement);

                _SelectedElement = value;
                NotifyPropertyChanged();
                _SelectedElementIndex = InternalCollection.IndexOf(value);
                NotifyPropertyChanged("SelectedElementIndex");
                OnSelectionChagned(this, new EventArgs());
            }
        }

        int _SelectedElementIndex;
        public int SelectedElementIndex { get { return _SelectedElementIndex; } }

        RelayCommand _NextElementCommand;
        public ICommand NextElementCommand
        {
            get => _NextElementCommand ?? (_NextElementCommand = new RelayCommand(param => this.NextElement(), param => this.CanGoToNext()));
        }

        RelayCommand _PreviousElementCommand;
        public ICommand PreviousElementCommand
        {
            get => _PreviousElementCommand ?? (_PreviousElementCommand = new RelayCommand(param => this.PreviousElement(), param => this.CanGoBack()));
        }

        RelayCommand _AddElementCommand;
        public ICommand AddElementCommand
        {
            get => _AddElementCommand ?? (_AddElementCommand = new RelayCommand(param => this.NewElement(param), param => this.CanAddElement()));
        }

        RelayCommand _DeleteElementCommand;
        public ICommand DeleteElementCommand
        {
            get => _DeleteElementCommand ?? (_DeleteElementCommand = new RelayCommand(param => this.DeleteElement(SelectedElement), param => this.CanDeleteElement()));
        }

        RelayCommand _DeleteElementCommands;
        public ICommand DeleteElementCommands
        {
            get => _DeleteElementCommands ?? (_DeleteElementCommands = new RelayCommand(param => this.DeleteElements(SelectedItems.ToArray()), param => this.CanDeleteElements()));
        }

        RelayCommand _SaveElementCommand;
        public ICommand SaveElementCommand
        {
            get => _SaveElementCommand ?? (_SaveElementCommand = new RelayCommand(param => this.SaveElement(SelectedElement), param => this.CanSaveElement()));
        }

        RelayCommand _EditElementCommand;
        public ICommand EditElementCommand
        {
            get => _EditElementCommand ?? (_EditElementCommand = new RelayCommand(param => this.EditElement(SelectedElement), param => this.CanEditElement()));
        }

        RelayCommand _CancelElementChangesCommand;
        public ICommand CancelElementChangesCommand
        {
            get => _CancelElementChangesCommand ?? (_CancelElementChangesCommand = new RelayCommand(param => this.CancelElementChanges(), param => this.CanCancelElementChanges()));
        }

        public ObservableCollection<T> SelectedItems => throw new NotImplementedException();

        public ViewModelBase(DataSet dataSet, System.Data.SQLite.SQLiteConnection sQLiteConnection, User user)
        {
            _InternalCollection = new ObservableCollection<T>();
            NotifyPropertyChanged("InternalCollection");
            _SelectionHistory = new ObservableCollection<T>();
            NotifyPropertyChanged("SelectionHistory");
            _InternalDataContext = dataSet;
            NotifyPropertyChanged("InternalDataContext");
            _SQLiteConnection = sQLiteConnection;
            NotifyPropertyChanged("sQLiteConnection");
            SetActiveUser(user);
        }

        public ViewModelBase(DataSet dataSet, System.Data.SQLite.SQLiteConnection sQLiteConnection, User user, object application)
        {
            _InternalCollection = new ObservableCollection<T>();
            NotifyPropertyChanged("InternalCollection");
            _SelectionHistory = new ObservableCollection<T>();
            NotifyPropertyChanged("SelectionHistory");
            _InternalDataContext = dataSet;
            NotifyPropertyChanged("InternalDataContext");
            _adskApplciation = application;
            NotifyPropertyChanged("ADSKApplciation");
            _SQLiteConnection = sQLiteConnection;
            NotifyPropertyChanged("sQLiteConnection");
            SetActiveUser(user);
        }

        public void AddElement(T element, bool setactive = false)
        {
            InternalCollection.Add(element);

            if (setactive)
            {
                GoToElement(element);
            }
        }

        public void GoToElement(int index)
        {
            SelectedElement = InternalCollection[index];
            _SelectedElementIndex = index;
            NotifyPropertyChanged("SelectedElementIndex");
        }

        public void GoToElement(T element)
        {
            SelectedElement = InternalCollection.Where(x => x.GetHashCode() == element.GetHashCode()).FirstOrDefault();
        }

        public void NextElement()
        {
            if (SelectedElementIndex + 1 >= InternalCollection.Count)
            {
                GoToElement(InternalCollection[0]);
            }
            else
            {
                GoToElement(InternalCollection[SelectedElementIndex + 1]);
            }
        }

        public void PreviousElement()
        {
            if (SelectedElementIndex - 1 < 0)
            {
                GoToElement(InternalCollection[InternalCollection.Count - 1]);
            }
            else
            {
                GoToElement(InternalCollection[SelectedElementIndex - 1]);
            }
        }

        public abstract void DeleteElement(T element);

        public abstract object NewElement(object parent);

        public abstract void EditElement(T element);

        public abstract void SaveElement(T element);

        public abstract void CancelElementChanges();

        public abstract bool CanCancelElementChanges();

        public abstract bool CanEditElement();

        public abstract bool CanAddElement();

        public abstract bool CanDeleteElement();

        public abstract bool CanSaveElement();

        public abstract bool CanGoToNext();

        public abstract bool CanGoBack();

        public abstract void RefreshCollections();

        public abstract void RefreshCollections(string sortColumn, string filter);

        private void SetActiveUser(User user)
        {
            _ActiveUser = user; 
            NotifyPropertyChanged("ActiveUser");
        }

        internal protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddElements(T[] elements)
        {
            throw new NotImplementedException();
        }

        T IViewModel<T>.NewElement(object parent)
        {
            throw new NotImplementedException();
        }

        public T NewElements(object[] parents)
        {
            throw new NotImplementedException();
        }

        bool IViewModel<T>.DeleteElement(T element)
        {
            throw new NotImplementedException();
        }

        public int DeleteElements(T[] element)
        {
            throw new NotImplementedException();
        }

        bool IViewModel<T>.SaveElement(T element)
        {
            throw new NotImplementedException();
        }

        public int SaveElements(T[] element)
        {
            throw new NotImplementedException();
        }

        bool IViewModel<T>.EditElement(T element)
        {
            throw new NotImplementedException();
        }

        public int EditElements(T[] element)
        {
            throw new NotImplementedException();
        }

        public bool CanEditElements()
        {
            throw new NotImplementedException();
        }

        public bool CanCancelElementsChanges()
        {
            throw new NotImplementedException();
        }

        public bool CanDeleteElements()
        {
            throw new NotImplementedException();
        }

        public bool CanSaveElements()
        {
            throw new NotImplementedException();
        }
    }
}
