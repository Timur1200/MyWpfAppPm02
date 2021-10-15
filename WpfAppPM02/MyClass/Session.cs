using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WpfAppPM02.DataBase;
using System.Windows;

namespace WpfAppPM02.MyClass
{
    static class Session
    {
        public static object User { get; set; }
        public static int? Id { get; set; }
        public static string Fio { get; set; }
        public static string Pass { get; set; }
        public static string Login { get; set; }
        public static bool? Status { get; set; }
        public static string NameRol { get; set; }
        public static int? Access { get; set; }
        
        public static void Out(Window w)
        {
            Windows.LoginWindow mw = new Windows.LoginWindow(); mw.Show();
            w.Close();
            Id = null;Fio = null; Pass = null; Login = null;Status = null;NameRol = null;Access = null;User = null;
        }

        public static void Auth(Spec s)
        {
            Id = s.IdSpec;Fio = s.FIo;Pass = s.Pass;Login = s.Login;Status = s.Status;//
            Access= s.Roli.Access; NameRol = s.Roli.NameRol;User = s;
        }

         new  public static string ToString()
        {
            string q = "==";
            return Id + q + Fio + q + Pass + q + Login + q + Status + q + NameRol + q + Access; 
        }

        public static void Auth(Users s)
        {
            Id = s.IdUser; Fio = s.Fio; Pass = s.Pass; Login = s.Login; 
            Access = s.Roli.Access; NameRol = s.Roli.NameRol;User = s;
        }


    }
}
