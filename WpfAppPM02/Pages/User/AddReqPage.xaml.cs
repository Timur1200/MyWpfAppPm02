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
   
    public partial class AddReqPage : Page
    {
        public AddReqPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (TextBoxTheme.Text == "" || TextBoxDesc.Text == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения!!!"); return;
            }

            Data.InsertReq(TextBoxTheme.Text,TextBoxDesc.Text,(Users)Session.User);
            MessageBox.Show("Запрос был отправлен");
            Nav.Back2();

        }
    }
}
