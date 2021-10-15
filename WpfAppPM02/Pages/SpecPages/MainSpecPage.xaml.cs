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


namespace WpfAppPM02.Pages.SpecPages
{
    
    public partial class MainSpecPage : Page
    {
        public MainSpecPage()
        {
            InitializeComponent();
            Nav.f2 = Frame2;
            Nav.f2.Navigate(new General.GeneralPage());
        }

        private void Go(Page p)
        {
            Nav.f2.Navigate(p);
        }

        private void PersonalDataPageClick(object sender, RoutedEventArgs e)
        {
            Go(new User.PersonalDataPage());
        }

        private void QueryPageClick(object sender, RoutedEventArgs e)
        {
            Go(new ActualReqPage());
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Nav.Back2();
        }

        private void StorageClick(object sender, RoutedEventArgs e)
        {
            Go(new Admin.StoragePage());
        }

        private void ListClick(object sender, RoutedEventArgs e)
        {
            Go(new Admin.MaterialPageList());
        }
    }
}
