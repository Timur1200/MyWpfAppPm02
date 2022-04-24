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

namespace WpfAppPM02.Pages.Admin
{
    
    public partial class MaterialPageList : Page
    {
        public static Storage GetStorage { get; set; }
        public MaterialPageList()
        {
            InitializeComponent();     
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            using (MyModel db = new MyModel())
            {
                listStorage = db.Storage.ToList();
                LViewMat.ItemsSource = listStorage;
            }
        }
        private List<Storage> listStorage { get; set; }

        private void LViewMat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetStorage = (Storage)LViewMat.SelectedItem;
        }

        private void search()
        { 
            if (TBoxSearch.Text.Length == 0)
            {
                LViewMat.ItemsSource = listStorage;
                return;
            }

            using (MyModel db = new MyModel())
            {
              LViewMat.ItemsSource = db.Storage.Where(q => q.MaterialName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            search();
        }

        private void CboxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
