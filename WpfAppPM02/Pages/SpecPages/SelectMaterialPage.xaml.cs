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
using WpfAppPM02.DataBase;
using WpfAppPM02.MyClass;

namespace WpfAppPM02.Pages.SpecPages
{
   
    public partial class SelectMaterialPage : Page
    {
        Quire quire;
        public SelectMaterialPage(Quire mQuire)
        {

            InitializeComponent();
            quire = mQuire;
            FrameInWindow.Navigate(new Pages.Admin.MaterialPageList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var b = Pages.Admin.MaterialPageList.GetStorage;

            if (b == null) {
                MessageBox.Show("Выберите материал!");
                return; }
            using (MyModel db = new MyModel())
            {
                MaterialList ml = new MaterialList();
                ml.ReqId = quire.IdQuire;
                try
                { ml.AmountInList = Convert.ToInt32(TBoxAmount.Text); }
                catch { ml.AmountInList = 1; }
                ml.MaterId = b.IdMaterial;
                db.MaterialList.Add(ml);

               
        //       b.Amount -= ml.AmountInList;
                if (b.Amount< ml.AmountInList)
                {
              //      b.Amount += ml.AmountInList;
                    MessageBox.Show("Количество использованных материалов не может превышать количество на складе!");
                    return;
                }
                db.Storage.Attach(b);
                b.Amount -= ml.AmountInList;
                db.SaveChanges();
                Nav.Back2();
                MessageBox.Show("Добавлено!");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Nav.Back2();
        }
    }
}
