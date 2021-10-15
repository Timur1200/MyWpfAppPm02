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
using WpfAppPM02.MyClass;
using System.Data.Entity;

namespace WpfAppPM02.Pages.Admin
{
    
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();           
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridUsers.ItemsSource = Data.SelectUsers();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            _ = Nav.f2.Navigate(new UsersPageAdd(false));
        }
        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выделить строку!");
                return;
            }

            Data.DeleteUser((Users)DataGridUsers.SelectedItem);
            
            Page_Loaded(null,null);
        }
        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выделить строку!");
                return;
            }

            var b = (Users)DataGridUsers.SelectedItem;

            Nav.f2.Navigate(new UsersPageAdd(b));
        }

        private void VisibleClick(object sender, RoutedEventArgs e)
        {
            if (DGColumnPass.Visibility == Visibility.Visible)
            {
                DGColumnPass.Visibility = Visibility.Hidden;
                BtnVisiblePass.Content = "Показать пароль";
            }
            else
            {
                DGColumnPass.Visibility = Visibility.Visible;
                BtnVisiblePass.Content = "Скрыть пароль";
            }
        }
    }
}
