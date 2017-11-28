using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WpfReactivePlayground.ViewModels;

namespace WpfReactivePlayground.Pages
{
    /// <summary>
    /// Interaction logic for PageOne.xaml
    /// </summary>
    public partial class PageOne : Page
    {
        public PageOneViewModel PageOneViewModel { get; set; }
        public PageOne()
        {
            InitializeComponent();
        }

        public PageOne(object param)
        {
            InitializeComponent();
            PageOneViewModel = new PageOneViewModel(param);
            this.DataContext = PageOneViewModel;
        }
    }
}
