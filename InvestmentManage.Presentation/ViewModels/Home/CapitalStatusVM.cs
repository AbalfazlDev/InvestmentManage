using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using LiveCharts;

namespace InvestmentManage.Presentation.ViewModels.Home
{
    class CapitalStatusVM
    {
        private SeriesCollection _seriesCollection;

        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
                OnPropertyChanged(nameof(SeriesCollection));
            }
        }

        public CapitalStatusVM()
        {
            // Sample data for the chart
            var values = new List<ChartData>
            {
                new ChartData { Category = "A", Value = 50 },
                new ChartData { Category = "B", Value = 80 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 600 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },new ChartData { Category = "B", Value = 80 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "C", Value = 120 },
                new ChartData { Category = "D", Value = 160 }
            };

            // Create the series for the bar chart
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Values",
                    Values = new ChartValues<double>(values.ConvertAll(v => v.Value))
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Class to represent the data
    public class ChartData
    {
        public string Category { get; set; }
        public double Value { get; set; }

    }


}
