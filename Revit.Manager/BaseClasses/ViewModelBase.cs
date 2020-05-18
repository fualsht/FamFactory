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

        User _ActiveUser;
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



        public ViewModelBase(DataSet dataSet, System.Data.SQLite.SQLiteConnection sQLiteConnection)
        {
            _InternalCollection = new ObservableCollection<T>();
            NotifyPropertyChanged("InternalCollection");
            _SelectionHistory = new ObservableCollection<T>();
            NotifyPropertyChanged("SelectionHistory");
            _InternalDataContext = dataSet;
            NotifyPropertyChanged("InternalDataContext");
            _SQLiteConnection = sQLiteConnection;
            NotifyPropertyChanged("sQLiteConnection");
        }

        public ViewModelBase(DataSet dataSet, System.Data.SQLite.SQLiteConnection sQLiteConnection, object application)
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
        }

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
            get => _AddElementCommand ?? (_AddElementCommand = new RelayCommand(param => this.NewElement(ActiveUser), param => this.CanCreateNewElement()));
        }

        RelayCommand _DeleteElementCommand;
        public ICommand DeleteElementCommand
        {
            get => _DeleteElementCommand ?? (_DeleteElementCommand = new RelayCommand(param => this.DeleteElement(SelectedElement), param => this.CanDeleteElement()));
        }

        RelayCommand _SaveElementCommand;
        public ICommand SaveElementCommand
        {
            get => _SaveElementCommand ?? (_SaveElementCommand = new RelayCommand(param => this.SaveElement(SelectedElement), param => this.CanSaveElement()));
        }

        RelayCommand _CancelElementChangesCommand;
        public ICommand CancelElementChangesCommand
        {
            get => _CancelElementChangesCommand ?? (_CancelElementChangesCommand = new RelayCommand(param => this.CancelElementChanges(), param => this.CanCancelElementChanges()));
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

        public void DeleteElement(T element)
        {
            T tempStorage = SelectedElement;
            int index = InternalCollection.IndexOf(tempStorage);

            if (index > 0)
                SelectedElement = InternalCollection[index - 1];

            if (index == 0 && InternalCollection.Count > 1)
                SelectedElement = InternalCollection[index + 1];

            if (index == 0 && InternalCollection.Count == 1)
                SelectedElement = default(T);

            InternalCollection.Remove(element);
            ((IModelBase<T>)element).Delete();
        }

        public abstract object NewElement(User user);

        public abstract void SaveElement(T element);

        public abstract void CancelElementChanges();

        public abstract bool CanCancelElementChanges();

        public abstract bool CanAddElement();

        public abstract bool CanCreateNewElement();

        public abstract bool CanDeleteElement();

        public abstract bool CanSaveElement();

        public abstract bool CanGoToNext();

        public abstract bool CanGoBack();

        public void SetActiveUser(User user)
        {
            _ActiveUser = user;
            NotifyPropertyChanged("ActiveUser");
        }

        internal protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
