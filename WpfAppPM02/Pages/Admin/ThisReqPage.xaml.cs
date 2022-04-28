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




namespace WpfAppPM02.Pages.Admin
{
   
    public partial class ThisReqPage : Page
    {
       private Quire GetQuire;
        public ThisReqPage(Quire quire)
        {
            InitializeComponent();
            GetQuire = quire;
            string QuireStatus;
            TBlockUser.Text += $" {quire.Users.Fio}";
            TextBlockTheme.Text = $"Тема: {GetQuire.Theme} №{GetQuire.IdQuire}";
            TextBoxDesc.Text = GetQuire.Desc;
            if (GetQuire.Status == 0) QuireStatus = "Отправлен";
            else if (GetQuire.Status == 1) QuireStatus = "На рассмотрение";
            else QuireStatus = "Завершен";
            TextBlockStatus.Text += $" {QuireStatus}";
       
            TextBlockDate.Text += GetQuire.Date1D;

            if (GetQuire.Status==1 || GetQuire.Status==2)
            {

                SearchTextBox.Visibility = Visibility.Hidden;
                    ComboBoxSelectSpec.Visibility = Visibility.Hidden;
                    Btn.Visibility = Visibility.Hidden;
                TextBlockSpec.Text = "Специалист: " +GetQuire.Spec.FIo+ $" {GetQuire.Spec.Roli.NameRol}";
                if (GetQuire.Status == 2)
                {
                    TextBoxAns.Visibility = Visibility.Visible;
                    TextBoxAns.Text = GetQuire.Answer;
                    LBoxItems.Visibility = Visibility.Visible;
                    LBoxItems.ItemsSource = Data.SelectMaterialList(GetQuire);
                    TBlockTe.Visibility = Visibility.Visible;
                }


            }

           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var a = Data.SelectOnlySpec();
            ComboBoxSelectSpec.ItemsSource = a;
            _ListSpec = a;
        }
        List<Spec> _ListSpec { get; set; } 
        private void BtnClick(object sender, RoutedEventArgs e)
        {
          Spec getSpec = (Spec)ComboBoxSelectSpec.SelectedItem;
            Data.UpdatqQuireTo1(GetQuire,getSpec);
            Nav.Back2();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (SearchTextBox.Text == "")
            {

                ComboBoxSelectSpec.ItemsSource = _ListSpec;
                ComboBoxSelectSpec.SelectedItem = null;
                return;
            }
            ComboBoxSelectSpec.IsDropDownOpen = true;
            string Text = SearchTextBox.Text;


            ComboBoxSelectSpec.ItemsSource = MyModel.GetContext().Spec.Where(q => q.FIo.Contains(Text)).ToList();
        }
    }
}
