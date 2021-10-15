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

namespace WpfAppPM02.Pages.SpecPages
{
   
    public partial class ActualReqPage : Page
    {
        public ActualReqPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           DGridReq.ItemsSource = Data.SelectQuireForSpec();
        }

        private void DGridReq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = DGridReq.SelectedItem;
            if (item == null) return;
            Nav.f2.Navigate(new AnswerPage((Quire)item));
        }
    }
}
