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
using WpfAppPM02.DataBase;
using Microsoft.Win32;
using System.IO;


namespace WpfAppPM02.Pages.Admin
{
    
    public partial class AddMaterialPage : Page
    {
        public AddMaterialPage()
        {
            InitializeComponent();
            GetStorage = null;
        }
        public AddMaterialPage(Storage mStorage)
        {
            InitializeComponent();
            GetStorage = mStorage;
            TextBoxAmount.Text = mStorage.Amount.ToString();
            TextBoxNameMaterial.Text = mStorage.MaterialName;
            TextBoxPrice.Text = mStorage.Price.ToString();
           

        }
        private static string FileName { get; set; }
        private static Storage GetStorage { get; set; }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            
            if (GetStorage == null) 
            { 
            using (MyModel db = new MyModel())
            {
                Storage storage = new Storage
                {
                    MaterialName = TextBoxNameMaterial.Text,
                    Amount = Convert.ToInt32(TextBoxAmount.Text),
                    Price = Convert.ToInt32(TextBoxPrice.Text),
                };
                
                if (FileName != null)
                {
                    byte[] bData = File.ReadAllBytes(FileName);
                    storage.Img = bData;
                }
                db.Storage.Add(storage);
                db.SaveChanges();
                MessageBox.Show("Запись добавлена!");
                Nav.Back2();
            }
            }
            else
            {
                using (MyModel db =new MyModel())
                {
                    db.Storage.Attach(GetStorage);
                    GetStorage.Price = Convert.ToInt32( TextBoxPrice.Text);
                    GetStorage.Amount = Convert.ToInt32(TextBoxAmount.Text);
                    GetStorage.MaterialName = TextBoxNameMaterial.Text;

                    if (FileName != null)
                    {
                        byte[] bData = File.ReadAllBytes(FileName);
                        GetStorage.Img = bData;
                    }
                    db.SaveChanges();
                    MessageBox.Show("Запись обновлена!");
                    Nav.Back2();
                }
            }
        }

        private void AddImgClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileName = openFileDialog.FileName;
                MessageBox.Show("Изображение получено!");
            }
        }

        private void TextBoxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
