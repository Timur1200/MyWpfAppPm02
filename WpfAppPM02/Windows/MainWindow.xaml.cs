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
using System.Windows.Shapes;
using WpfAppPM02.MyClass;

using WpfAppPM02.Pages.Admin;
using WpfAppPM02.Pages.General;
using WpfAppPM02.Pages.SpecPages;
using WpfAppPM02.Pages.Storages;
using WpfAppPM02.Pages.User;

namespace WpfAppPM02.Windows
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            AdminPanel.Visibility = Visibility.Collapsed;
            SpecPanel.Visibility = Visibility.Collapsed;
            UserPanel.Visibility = Visibility.Collapsed;
            

            Nav.f2 = MainFrame;
            MainFrame.Navigate(new GeneralPage());
            if (Session.Access == 2) AdminPanel.Visibility = Visibility.Visible;
            else if (Session.Access==1) SpecPanel.Visibility = Visibility.Visible;
            else UserPanel.Visibility = Visibility.Visible;


        }

        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ReAuthClick(object sender, RoutedEventArgs e)
        {
            Session.Out(this);
            
        }

        private void ChangePasswordClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new ChangePasswordPage());

            //  Process.Start(System.IO.Path.GetFullPath(@"help.chm"));
        }

        private void GoToGeneralPageClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new GeneralPage());
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Go(Page a)
        {
            Nav.f2.Navigate(a);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Nav.Back(MainFrame);
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
            Nav.f2.Navigate(new Pages.User.PersonalDataPage());
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

        private void StorageManagerPageClick(object sender, RoutedEventArgs e)
        {
            Go(new StorageManagerPage());
        }

        private void QueryPageClick(object sender, RoutedEventArgs e)
        {
            Go(new ActualReqPage());
        }

        private void QueryPageUserClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new QueryPage());
        }
    }
}
