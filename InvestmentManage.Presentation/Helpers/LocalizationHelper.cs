using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManage.Presentation.Helpers
{
    public class LocalizationHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string this[string key] => _resourceManager.GetString(key, CultureInfo.CurrentUICulture);

        private ResourceManager _resourceManager;

        public LocalizationHelper(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void Refresh()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }

}
