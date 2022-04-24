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
using WpfAppPM02.Pages.Admin;

namespace WpfAppPM02.Pages.Storages
{
   
    public partial class StorageManagerPage : Page
    {
        public StorageManagerPage()
        {
            InitializeComponent();
            TabItemFrame1.Navigate(new StoragePage());
            TabItemFrame2.Navigate(new MaterialPageList());
        }
    }
}
