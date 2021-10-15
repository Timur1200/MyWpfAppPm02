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
    
    public partial class SpecPage : Page
    {
        public SpecPage()
        {
            InitializeComponent();
            Go = true;
            DPicker1.SelectedDate = DateTime.Now.AddDays(1);
            DPicker2.SelectedDate = DateTime.Now.AddDays(1);
            Go = false;
        }
        List<Spec> Specs { get; set; }
        bool Go { get; set; }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {   
            Specs = Data.SelectAllSpec();
            DataGridUsers.ItemsSource = Specs;
            
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new UsersPageAdd(true));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedItem == null) return;

            Spec spec;
            spec = (Spec)DataGridUsers.SelectedItem;

            Data.DeleteSpec(spec);
            MessageBox.Show("Удалено!");
            Page_Loaded(null, null);
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedItem == null) return ;

            Spec spec;
            spec = (Spec)DataGridUsers.SelectedItem;

            Nav.f2.Navigate(new UsersPageAdd(spec));
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

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Go) return;
            if (DPicker1.SelectedDate == null && DPicker2.SelectedDate == null) return;
            using (MyModel db = new MyModel())
            {

                DateTime dt1 = DPicker1.SelectedDate.Value;
                DateTime dt2 = DPicker2.SelectedDate.Value;


                foreach (var a in Specs)
                {
                    a.Select = db.Quire.Include(q => q.Spec).Where(q=>q.SpecId==a.IdSpec && q.Status==2 && dt1 < q.Date2 && q.Date2 < dt2).Count();   
                }
                DataGridUsers.Items.Refresh();

            }
        }
    }
}
