
using System.Windows.Controls;

namespace WpfAppPM02.MyClass
{
    class Nav
    {
        public static Frame f1 { get; set; }

        public static Frame f2 { get; set; }

        public static void Back(Frame f)
        {
            if (f.NavigationService.CanGoBack == true) f.NavigationService.GoBack();
        }

        public static void Back1()
        {
            if (f1.NavigationService.CanGoBack == true) f1.NavigationService.GoBack();
        }

        public static void Back2()
        {
            if (f2.NavigationService.CanGoBack == true) f2.NavigationService.GoBack();
        }

    }
}
