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
using WpfAppPM02.MyClass;
using WpfAppPM02.DataBase;

namespace WpfAppPM02.Pages.Admin
{

    public partial class StoragePage : Page
    {
        public StoragePage()
        {
            InitializeComponent();
        }
        private List<Storage> LStorage = Data.SelectStorage();

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new AddMaterialPage());
        }

        private void DataGridReq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LStorage = Data.SelectStorage();
            DataGridMaterial.ItemsSource = LStorage;

        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            object SelectItem = DataGridMaterial.SelectedItem;
            if (SelectItem == null)
            {
                MessageBox.Show("Сначало нужно выделить запись");
                return;
            }

            Nav.f2.Navigate(new AddMaterialPage((Storage)SelectItem));
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            object SelectItem = DataGridMaterial.SelectedItem;
            if (SelectItem is Storage)
            {
                try
                {
                    using (MyModel db = new MyModel())
                    {
                        var a = (Storage)SelectItem;
                        db.Storage.Attach(a);

                        db.Storage.Remove(a);
                        db.SaveChanges();

                    }
                    MessageBox.Show("Удалено!");
                    Page_Loaded(null, null);
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка, данная запись уже используется, поэтому не может быть удалена");
                }
            }
            else MessageBox.Show("Сначало нужно выделить запись");

        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            var b = LStorage.Where(q => q.MaterialName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            DataGridMaterial.ItemsSource = b;
        }
    }
}
