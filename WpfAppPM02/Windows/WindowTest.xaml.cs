﻿using System;
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
using System.Windows.Shapes;
using System.Data.Entity;
using WpfAppPM02.DataBase;
using WpfAppPM02.Windows;
using WpfAppPM02.MyClass;
using WpfAppPM02.Pages.Admin;

namespace WpfAppPM02.Windows
{
   
    public partial class WindowTest : Window
    {
        public WindowTest()
        {
            InitializeComponent();
            MainFrame.Navigate(new ChartsPage());

        }
    }
}
