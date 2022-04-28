using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppPM02.DataBase;

namespace WpfAppPM02.Pages.Admin
{
  
    public partial class ChartsPage : Page
    {
        public ChartsPage()
        {
            InitializeComponent();
            MyChart.ChartAreas.Add(new ChartArea("Main"));


            var currentSeries = new Series("Test2")
            {
                IsValueShownAsLabel = true
            };
            MyChart.Series.Add(currentSeries);
            
            ChartTypesComboBox.ItemsSource = Enum.GetValues(typeof(SeriesChartType));

        }

        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            if (ChartTypesComboBox.SelectedItem 
                is SeriesChartType SelectedType)
            {
                Series currentSeries = MyChart.Series.FirstOrDefault();
                currentSeries.ChartType = SelectedType;
                currentSeries.Points.Clear();

               var specList = MyModel.GetContext().Spec.Where(q=>q.Roli.Access==1).ToList();
                foreach (var item in specList)
                {
                   int i = MyModel.GetContext().Quire.Where(q => q.SpecId == item.IdSpec
                    && q.Status == 2).Count();
                    currentSeries.Points.AddXY(item.FIo, i);
                    
                }

            }
        }
    }
}
