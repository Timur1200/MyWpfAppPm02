using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPM02.DataBase
{
    partial class MyModel
    {
        private static MyModel _Context {get;set;}
        public static MyModel GetContext()
        {
            if (_Context == null)  _Context = new MyModel();
            return _Context;
        }
    }
}
