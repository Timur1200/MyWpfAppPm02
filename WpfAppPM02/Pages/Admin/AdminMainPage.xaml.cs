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
using WpfAppPM02.Pages.Admin;

namespace WpfAppPM02.Pages
{
   
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
            Nav.f2 = Frame2;
            Nav.f2.Navigate(new General.GeneralPage());
        }

        private void Go(Page a)
        {
            Nav.f2.Navigate(a);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Nav.Back(Frame2);
        }

        private void UsersPageClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new UsersPage());
            
            
        }

        private void SpecPageClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new SpecPage());
        }

        private void ReqPageClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new ReqPage());
        }

        private void PersonalDataPageClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new User.PersonalDataPage());
        }

        private void StoragePageClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new StoragePage());
        }

        private void StoragePageClick1(object sender, RoutedEventArgs e)
        {
            Go(new MaterialPageList());
        }

        private void ReqPageClick1(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new ReqPage1());
        }
    }
}
