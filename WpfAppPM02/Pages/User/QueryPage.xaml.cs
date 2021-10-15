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

namespace WpfAppPM02.Pages.User
{
    
    public partial class QueryPage : Page
    {
        public QueryPage()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new AddReqPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridReq.ItemsSource = Data.SelectQuire0();
        }

        

        private void DataGridReq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridReq.SelectedItem == null) return;
            Quire c = (Quire)DataGridReq.SelectedItem;
           Nav.f2.Navigate(new SpecPages.AnswerPage(c));
        }
    }
}
