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
using WpfAppPM02.Pages.General;

namespace WpfAppPM02.Windows
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Nav.f1 = AdminWindowFrame;
            if (Session.Access == 2) _ = Nav.f1.Navigate(new Pages.AdminMainPage());
            else if (Session.Access==1) _ = Nav.f1.Navigate(new Pages.SpecPages.MainSpecPage());
            else _ = Nav.f1.Navigate(new Pages.User.UserMainPage());


        }

        public  string TextInfo 
        { 
            get
            {
                return TBlock1.Text;
            }
            set
            {
                TBlock1.Text = value;
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
    }
}
