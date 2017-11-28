using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactivePlayground.ViewModels
{
    public class PageOneViewModel : INotifyPropertyChanged
    {
        public object Value { get; set; }

        public PageOneViewModel()
        {
        }

        public PageOneViewModel(object param)
        {
            Value = param;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
