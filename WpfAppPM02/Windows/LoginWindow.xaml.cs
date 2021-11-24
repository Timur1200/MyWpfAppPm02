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
using System.Data.Entity;
using WpfAppPM02.DataBase;
using WpfAppPM02.Windows;
using WpfAppPM02.MyClass;
using System.Windows.Threading;

namespace WpfAppPM02.Windows
{
    public enum enumAccess
    {
        User,
        Spec,
        Admin
    }

    public partial class LoginWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public LoginWindow()
        {
            InitializeComponent();
            //WindowTest a = new WindowTest(); a.Show();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);

        }
        int Num = 3;//кол-во попыток
        int factor = 0;// коэффициент (множитель) блокирования
        int BlockTime = 0;// блокировка в секундах

        private void timerTick(object sender, EventArgs e)
        {
            BlockTime -= 1;
            BtnAuth.Content ="Попробуйте снова через " +Convert.ToString(BlockTime)+ " с";
            if (BlockTime == 0)
            {
                BtnAuth.Content = "Войти";
                timer.Stop();
                Num = 1;
                BtnAuth.IsEnabled = true;
              //  BtnAuth.Background = Brushes.Black;

            }
        }
        private void AuthClick(object sender, RoutedEventArgs e)
        {
            if (ChechBoxPass.IsChecked.Value) PassBox.Password = PassBox1.Text;

            try
            {
                MyModel ww = new MyModel();
                using (MyModel db = new MyModel())
                {


                    foreach (Spec a in db.Spec.Include(a => a.Roli))
                    {
                        if (LoginTextBox.Text == a.Login && PassBox.Password == a.Pass)
                        {


                            if (a.Roli.Access == 2)
                            {
                                Session.Auth(a);
                                MainWindow win = new MainWindow();
                                win.Show();
                                this.Close();
                            }
                            if (a.Roli.Access == 1)
                            {
                                Session.Auth(a);
                                MainWindow win = new MainWindow();
                                win.Show();
                                this.Close();
                            }

                            return;


                        }
                    }

                    foreach (Users a in db.Users.Include(a => a.Roli))
                    {
                        if (LoginTextBox.Text == a.Login && PassBox.Password == a.Pass)
                        {
                            Session.Auth(a);
                            MainWindow win = new MainWindow();
                            win.Show();
                            this.Close(); return;
                        }
                    }
                    MessageBox.Show("Пользователь не найден!");
                    Num--; if (Num == 0)// в случае если попыток не осталось происходит блокировка
                    {
                        BtnAuth.IsEnabled = false;
                        factor += 1;
                        timer.Start();
                        BlockTime += 5 * factor;
                        return;
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString(), ex.Message);
                    }
        }
        #region test
        private void adminClick(object sender, RoutedEventArgs e)
        {
           
               LoginTextBox.Text = "admin";
                PassBox.Password = "admin";
                AuthClick(null,null);
        }

        private void userClick(object sender, RoutedEventArgs e)
        {
            LoginTextBox.Text = "иван12";
            PassBox.Password = "123";
            AuthClick(null, null);
        }

        private void specClick(object sender, RoutedEventArgs e)
        {
            LoginTextBox.Text = "программер228";
            PassBox.Password = "йцу";
            AuthClick(null, null);
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        private int i = 0;
        private void LoginTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            i++;
            if (i == 3)
            {
                PanelAdmin.Visibility = Visibility.Visible;
            }
        }

        private void ChechBoxPass_Checked(object sender, RoutedEventArgs e)
        {
           
            if (ChechBoxPass.IsChecked.Value)
            {
                PassBox1.Visibility = Visibility.Visible;
                PassBox.Visibility = Visibility.Collapsed;
                PassBox1.Text = PassBox.Password;
            }
            else
            {
                PassBox1.Visibility = Visibility.Collapsed;
                PassBox.Visibility = Visibility.Visible;
                PassBox.Password = PassBox1.Text;
            }
        }
    }
}
