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
    
    
    public partial class UsersPageAdd : Page
    {
        static bool IsUpdate;
        static bool IsSpecPage;

        private readonly Users userForUpdate;
        private readonly Spec specForUpdate;
        // создание пользователей
        public UsersPageAdd(bool IsSpec)
        {
            InitializeComponent();
            IsUpdate = false;
            IsSpecPage = IsSpec;
            
        }

       // Для редактирования пользователей
        public UsersPageAdd(Users mUser)
        {
            IsSpecPage = false;
            IsUpdate = true;
            InitializeComponent();
             userForUpdate = mUser;
            
            FioTextBox.Text = mUser.Fio;
            LoginTextBox.Text = mUser.Login;
            List<Roli> b = MyModel.GetContext().Roli.ToList();
            int i = 0;
           
            Roli r = mUser.Roli;
            foreach (Roli a in b)
            {
                if (a.NameRol == r.NameRol)
                {
                    RolComboBox.SelectedIndex = i;
                    return;
                }
                i++;
            }  
        }
        public UsersPageAdd(Spec mSpec)
        {
            IsSpecPage = true;
            IsUpdate = true;
            InitializeComponent();
            specForUpdate = mSpec;

            FioTextBox.Text = mSpec.FIo;
            LoginTextBox.Text = mSpec.Login;
            List<Roli> b = MyModel.GetContext().Roli.ToList();
            int i = 0;

            Roli r = mSpec.Roli;
            foreach (Roli a in b)
            {
                if (a.NameRol == r.NameRol)
                {
                    RolComboBox.SelectedIndex = i;
                    return;
                }
                i++;
            }
        }


        private void SaveClick(object sender, RoutedEventArgs e)
        {
            
            
            if (RolComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль");
                return;
            }
            if (PassBox.Password != PassBox1.Password)
            {
                MessageBox.Show("Введенные пароли не совпадают");
                return;
            }
            if (IsSpecPage == false)
            {

                if (IsUpdate == false)
                {
                    var Message = Data.InsertUser(FioTextBox.Text, LoginTextBox.Text, PassBox.Password, (Roli)RolComboBox.SelectedItem);
                    MessageBox.Show(Message);
                    Nav.Back2();
                }
                else
                {
                    

                    var msg = Data.UpdateUser(FioTextBox.Text, LoginTextBox.Text, PassBox.Password, (Roli)RolComboBox.SelectedItem, userForUpdate);
                    Nav.Back2();
                    MessageBox.Show(msg);
                }

            }
            else
            {
                if (IsUpdate == false)
                {
                    var Message = Data.InsertSpec(FioTextBox.Text, LoginTextBox.Text, PassBox.Password, (Roli)RolComboBox.SelectedItem);
                    MessageBox.Show(Message);
                    Nav.Back2();
                }
                else
                {
                    var msg = Data.UpdateSpec(FioTextBox.Text, LoginTextBox.Text, PassBox.Password, (Roli)RolComboBox.SelectedItem, specForUpdate);
                    Nav.Back2();
                    MessageBox.Show(msg);
                }
            }


        }

        private void NewRolPageClick(object sender, RoutedEventArgs e)
        {
            Nav.f2.Navigate(new AddRolPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RolComboBox.ItemsSource = MyModel.GetContext().Roli.ToList();
          // if (IsSpecPage == true) RolComboBox.ItemsSource = Data.SelectRoli1();
          // else RolComboBox.ItemsSource = Data.SelectRoli0();
           
        }
    }
}
