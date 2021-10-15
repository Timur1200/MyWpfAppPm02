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

namespace WpfAppPM02.Pages.General
{

    public partial class ChangePasswordPage : Page
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private void BtnChangePassClick(object sender, RoutedEventArgs e)
        {
            if (OldPassBox.Password != Session.Pass)
            {
                MessageBox.Show("Пароль введен неверно!");
                return;
            }

            if (PassBox.Password != PassBox1.Password)
            {
                MessageBox.Show("Введенные пароли не совпадают!");
                return;       
            }
            if (Session.Access == 0) Data.ChangePass((Users)Session.User,PassBox.Password);
            else Data.ChangePass((Spec)Session.User, PassBox.Password);
            MessageBox.Show("Пароль был успешно изменен!");
            Session.Pass = PassBox.Password;

        }
    }
}
