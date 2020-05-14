using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModBox.FamFactory.Revit.Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FamFactoryDataSet dSet = new FamFactoryDataSet("FamFactoryDatabase");
        public MainWindow()
        {
            InitializeComponent();
            FamFactoryViewModel famFactoryViewModel = new FamFactoryViewModel(dSet.FFDataSet);
            this.DataContext = famFactoryViewModel;
        }
        public MainWindow(FamFactoryViewModel dataContext)
        {
            InitializeComponent();
            this.DataContext = dataContext;
        }
    }
}
