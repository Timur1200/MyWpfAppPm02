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
   
    public partial class AnswerPage : Page
    {
         private  Quire quire { get; set; }
        public AnswerPage(Quire Mquire)
        {
            InitializeComponent();
            quire = Mquire;
           
            string QuireStatus;
            TextBlockTheme.Text = $"Тема: {quire.Theme} №{quire.IdQuire}";
            TextBoxDesc.Text = quire.Desc;
            if (quire.Status == 0) QuireStatus = "Отправлен";
            else if (quire.Status == 1) QuireStatus = "На рассмотрение";
            else QuireStatus = "Завершен";
            TextBlockStatus.Text += $" {QuireStatus}";
            

           if (quire.Status==2)
            {
                LBox.Visibility = Visibility.Hidden;
                Btn.Visibility = Visibility.Hidden;
                Btn1.Visibility = Visibility.Hidden;
                Btn2.Visibility = Visibility.Hidden;
                TBoxAns.Text = quire.Answer;
                TBoxAns.IsReadOnly = true;
                TextBlockDate.Text = "Дан ответ: " + quire.Date2;
                return;
            }
            TextBlockDate.Text += quire.Date1D;
            if (Session.Access == 0)
            {
                LBox.Visibility = Visibility.Hidden;
                Btn.Visibility = Visibility.Hidden;
                Btn1.Visibility = Visibility.Hidden;
                Btn2.Visibility = Visibility.Hidden;
                
                if (TBoxAns.Text.Length == 0)
                {
                    TBoxAns.Visibility = Visibility.Hidden;
                }
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LBox.ItemsSource = Data.SelectMaterialList(quire);

        }
        private void BtnClick(object sender, RoutedEventArgs e)
        {
            using (MyModel db = new MyModel())
            {
                db.Quire.Attach(quire);
                quire.Date2 = DateTime.Now;
                quire.Answer = TBoxAns.Text;
                quire.Status += 1;
                db.SaveChanges();
                Nav.Back2();
                MessageBox.Show("Отправлено!");

            }
        }

       

        private void BtnClick1(object sender, RoutedEventArgs e)
        {
            Nav.f1.Navigate(new SelectMaterialPage(quire));
        }

        private void BtnClick2(object sender, RoutedEventArgs e)
        {
            if (LBox.SelectedItem == null) return;

            var Item = (MaterialList)LBox.SelectedItem;

            using (MyModel db = new MyModel())
            {
                db.MaterialList.Attach(Item);
                var storage = Item.Storage;
                db.Storage.Attach(storage);
                storage.Amount += Item.AmountInList;

                db.MaterialList.Remove(Item);
                db.SaveChanges();
                Page_Loaded(null, null);
            }
        }
    }
}
