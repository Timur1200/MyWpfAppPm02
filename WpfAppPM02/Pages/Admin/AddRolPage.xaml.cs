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

namespace WpfAppPM02.Pages.Admin
{
   
    public partial class AddRolPage : Page
    {
        public AddRolPage()
        {
            InitializeComponent();
            AccessComboBox.Items.Add("Пользователь");
            AccessComboBox.Items.Add("Специалист");
            AccessComboBox.Items.Add("Администратор");

            
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Nav.Back(Nav.f2);
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            int indexAccess =  AccessComboBox.SelectedIndex;
            using (MyModel db= new MyModel())
            {
                Roli r = new Roli();
                r.Access = indexAccess;
                r.NameRol = NameTextBox.Text;
                db.Roli.Add(r);
                db.SaveChanges();
                Nav.Back2();

            }
        }
    }
}
