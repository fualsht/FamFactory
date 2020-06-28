using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace ModBox.FamFactory.Revit.Manager
{
    public interface IViewModel<T> : INotifyPropertyChanged
    {
        DataSet InternalDataSet { get; }
        ObservableCollection<T> InternalCollection { get; }
        ObservableCollection<T> SelectionHistory { get; }
        ObservableCollection<T> SelectedItems { get; }
        ICommand NextElementCommand { get; }
        ICommand PreviousElementCommand { get; }
        ICommand AddElementCommand { get; }
        ICommand DeleteElementCommand { get; }
        ICommand DeleteElementCommands { get; }
        ICommand EditElementCommand { get; }
        ICommand SaveElementCommand { get; }
        ICommand CancelElementChangesCommand { get; }
        void RefreshCollections();
        void RefreshCollections(string sortColumn, string filter);
        void NextElement();
        void PreviousElement();
        void GoToElement(int index);
        void GoToElement(T element);
        void AddElement(T element, bool setactive);
        void AddElements(T[] elements);
        bool CanAddElement();
        T NewElement(object parent);
        T NewElements(object[] parents);
        void CancelElementChanges();
        bool DeleteElement(T element);
        int DeleteElements(T[] element);
        bool SaveElement(T element);
        int SaveElements(T[] element);
        bool EditElement(T element);
        int EditElements(T[] element);
        bool CanEditElement();
        bool CanEditElements();
        bool CanCancelElementChanges();
        bool CanCancelElementsChanges();
        bool CanDeleteElement();
        bool CanDeleteElements();
        bool CanSaveElement();
        bool CanSaveElements();
        bool CanGoToNext();
        bool CanGoBack();
    }
}
