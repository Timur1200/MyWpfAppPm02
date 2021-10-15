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
namespace WpfAppPM02.Pages.User
{
    
    public partial class PersonalDataPage : Page
    {
        public PersonalDataPage()
        {
            InitializeComponent();
            LoginTextBlock.Text = $"Ваш логин: {Session.Login}";
            FioTextBlock.Text = $"Ваше ФИО: {Session.Fio}";
            AccessTextBlock.Text = $"Ваша должность: {Session.NameRol}";
        }
    }
}
