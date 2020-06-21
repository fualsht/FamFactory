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
        ICommand NextElementCommand { get; }
        ICommand PreviousElementCommand { get; }
        ICommand AddElementCommand { get; }
        ICommand DeleteElementCommand { get; }
        ICommand EditElementCommand { get; }
        ICommand SaveElementCommand { get; }
        ICommand CancelElementChangesCommand { get; }
        void NextElement();
        void PreviousElement();
        void GoToElement(int index);
        void GoToElement(T element);
        void AddElement(T T, bool setactive);
        bool CanAddElement();
        object NewElement(object parent);
        void CancelElementChanges();
        void DeleteElement(T element);
        void SaveElement(T element);
        void EditElement(T element);
        bool CanEditElement();
        bool CanCancelElementChanges();
        bool CanDeleteElement();
        bool CanSaveElement();
        bool CanGoToNext();
        bool CanGoBack(); 
        void RefreshCollections();
        void RefreshCollections(string sortColumn, string filter);
    }
}
