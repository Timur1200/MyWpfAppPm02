using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppPM02.DataBase;

namespace WpfAppPM02.Pages.Storages
{
    /// <summary>
    /// Логика взаимодействия для StoryStoragePage.xaml
    /// </summary>
    public partial class StoryStoragePage : Page
    {
        public StoryStoragePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           StoryDataGrid.ItemsSource = MyModel.GetContext().MaterialList.ToList();
        }
    }
}
