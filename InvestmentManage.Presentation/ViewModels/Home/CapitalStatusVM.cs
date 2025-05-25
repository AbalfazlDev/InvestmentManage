using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using LiveCharts;
using InvestmentManage.Presentation.Helpers;
using System.Windows.Media;
using System.Windows;
using PropertyChanged;

namespace InvestmentManage.Presentation.ViewModels.Home
{
    [AddINotifyPropertyChangedInterface]
    class CapitalStatusVM:NotifyPropertyChanged
    {
        //private SeriesCollection _seriesCollection;

        //public SeriesCollection SeriesCollection
        //{
        //    get { return _seriesCollection; }
        //    set
        //    {
        //        _seriesCollection = value;
        //        OnPropertyChanged(nameof(SeriesCollection));
        //    }
        //}

        public SeriesCollection SeriesCollection { get; set; }

        public void LoadChartSeries()
        {
            // لود رنگ‌ها از Resource
            var lineColor = Application.Current.Resources["CommonLblFG"] as Brush;
            var fillColor = Application.Current.Resources["PrimeColor"] as Brush;

            // ساختن نمودار
            SeriesCollection = new SeriesCollection
        {
            new LineSeries
            {
                Title = "نمودار",
                Values = new ChartValues<double> { 3, 5, 2, 7, 6 },
                Stroke = lineColor,       // رنگ خط
                Fill = fillColor,         // رنگ پر شدن زیر نمودار
                PointForeground = Brushes.White,
                LineSmoothness = 0.3
            }
        };
        }

        public CapitalStatusVM()
        {
            LoadChartSeries();
            // Sample data for the chart
            //var values = new List<ChartData>
            //{
            //    new ChartData { Category = "A", Value = 50 },
            //    new ChartData { Category = "B", Value = 80 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 600 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "C", Value = 120 },
            //    new ChartData { Category = "D", Value = 160 }
            //};

            // Create the series for the bar chart
            //SeriesCollection = new SeriesCollection
            //{
            //    new ColumnSeries
            //    {
            //        Title = "Values",
            //        Values = new ChartValues<double>(values.ConvertAll(v => v.Value))
            //    }
            //};
        }

        public void ResetColor()
        {
            LoadChartSeries();
        }

    }

    // Class to represent the data
    public class ChartData
    {
        public string Category { get; set; }
        public double Value { get; set; }

    }


}
