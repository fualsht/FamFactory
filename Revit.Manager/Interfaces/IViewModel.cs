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
        User ActiveUser { get; }
        ICommand NextElementCommand { get; }
        ICommand PreviousElementCommand { get; }
        ICommand AddElementCommand { get; }
        ICommand DeleteElementCommand { get; }
        ICommand SaveElementCommand { get; }
        ICommand CancelElementChangesCommand { get; }
        void NextElement();
        void PreviousElement();
        void GoToElement(int index);
        void GoToElement(T element);
        void AddElement(T T, bool setactive);
        bool CanAddElement();
        object NewElement(User user);
        void CancelElementChanges();
        void DeleteElement(T element);
        void SaveElement(T element);
        bool CanCancelElementChanges();
        bool CanCreateNewElement();
        bool CanDeleteElement();
        bool CanSaveElement();
        bool CanGoToNext();
        bool CanGoBack();
        void SetActiveUser(User user);
    }
}
