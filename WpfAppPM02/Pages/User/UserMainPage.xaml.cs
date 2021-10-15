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

namespace WpfAppPM02.Pages.User
{
   
    public partial class UserMainPage : Page
    {
        public UserMainPage()
        {
            InitializeComponent();
            Nav.f2 = Frame2;
            Nav.f2.Navigate(new General.GeneralPage());
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Nav.Back(Frame2);
        }

        

        private void QueryPageClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new QueryPage());
        }

        private void PersonalDataPageClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new PersonalDataPage());
        }
    }
}
