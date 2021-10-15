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
using System.Data.Entity;
using Word = Microsoft.Office.Interop.Word;

namespace WpfAppPM02.Pages.Admin
{

    public partial class ReqPage : Page
    {
        public ReqPage()
        {
            InitializeComponent();
            Go = true;
            DPicker1.SelectedDate = DateTime.Now.AddDays(1);
            DPicker2.SelectedDate = DateTime.Now.AddDays(1);
            Go = false;
        }
        bool Go { get; set; }
        List<Quire> listQuires { get; set; }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listQuires = Data.SelectQuire02();
            DataGridReq.ItemsSource = listQuires;
        }





        private readonly string TemplateFileName = System.IO.Path.GetFullPath(@"Word/WordFile.docx");
        void ReplaceWordStub(String stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        private void WordClick(object sender, RoutedEventArgs e)
        {
            if (DataGridReq.SelectedItem == null)
            {
                return;
            }
            Quire q = (Quire)DataGridReq.SelectedItem;
            string mater = ""; int j = 0;
            using (MyModel db = new MyModel())
            {
                int i = 0;
                var b = db.MaterialList.Include(w => w.Storage).Where(w => w.ReqId == q.IdQuire).ToList();
                foreach (var a in b)
                {
                    i++; j += a.Storage.Price.Value * a.AmountInList.Value;
                    mater += $"{i}) {a.Storage.MaterialName}({a.Storage.Price} руб) X {a.AmountInList} ШТ. = {a.Storage.Price * a.AmountInList} руб; ";
                }
            }


            var wordApp = new Word.Application();

            wordApp.Visible = false;
            var wordDocument = wordApp.Documents.Open(TemplateFileName);
            ReplaceWordStub("{Id}", Convert.ToString(q.IdQuire), wordDocument);
            ReplaceWordStub("{fio}", q.Spec.FIo, wordDocument);
            ReplaceWordStub("{date1}", q.Date1D, wordDocument);
            ReplaceWordStub("{date2}", q.Date2D, wordDocument);
            ReplaceWordStub("{desc}", q.Desc, wordDocument);
            ReplaceWordStub("{ans}", q.Answer, wordDocument);
            ReplaceWordStub("{mater}", mater, wordDocument);
            ReplaceWordStub("{sum}", j.ToString(), wordDocument);
            wordDocument.SaveAs2(System.IO.Path.GetFullPath($@"Word/{Guid.NewGuid()}.docx"));

            wordApp.Visible = true;


        }

        private void BtnInGrid(object sender, RoutedEventArgs e)
        {
            Quire q = (Quire)DataGridReq.SelectedItem;
            Nav.f2.Navigate(new ThisReqPage(q));
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Go) return;
            if (DPicker1.SelectedDate == null && DPicker2.SelectedDate == null) return;
            using (MyModel db = new MyModel())
            {
                
                DateTime dt1 = DPicker1.SelectedDate.Value;
                DateTime dt2 = DPicker2.SelectedDate.Value;
                List<Quire> newList;

               
                   newList = db.Quire.Include(q => q.Spec).Where(q => q.Status == 2 && dt1 < q.Date2 && q.Date2 < dt2).ToList();
                DataGridReq.ItemsSource = newList;
                DataGridReq.Items.Refresh();

            }
        }


    }
        }
    
