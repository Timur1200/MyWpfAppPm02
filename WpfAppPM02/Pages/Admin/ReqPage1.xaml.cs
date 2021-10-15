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
    
    public partial class ReqPage1 : Page
    {
        public ReqPage1()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridReq.ItemsSource = Data.SelectQuire01();
        }

        private void DataGridReq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridReq.SelectedItem == null) return;

            Quire c = (Quire)DataGridReq.SelectedItem;
            Nav.f2.Navigate(new ThisReqPage(c));
        }
    }
}
