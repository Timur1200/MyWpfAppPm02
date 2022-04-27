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

namespace WpfAppPM02.Pages.General
{
    
    public partial class GeneralPage : Page
    {
        public GeneralPage()
        {
            InitializeComponent();
            HelloTextBlock.Text = $"Добро пожаловать, {Session.Fio} \n Ваша должность: {Session.NameRol} ";
        }
    }
}
