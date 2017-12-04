using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ReactiveUI;
using WpfReactivePlayground.Pages;

namespace WpfReactivePlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BackgroundWorker BackgroundWorker { get; set; }
        public List<Page> Pages = new List<Page>();
        public int Limit { get; set; } = 100;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubscribeToBgWorker()
        {
            BackgroundWorker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };  
            
            BackgroundWorker.DoWork += BackgroundWorkerOnDoWork;
            BackgroundWorker.ProgressChanged += BackgroundWorkerOnProgressChanged;
            BackgroundWorker.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
        }

        private void NavigateToPage<T>(object param = null) where T : Page, new()
        {
            var page = Pages.FirstOrDefault(p => p.GetType() == typeof(T));
            if (page == null)
            {
                T instance = param == null ? new T() : (T)Activator.CreateInstance(typeof(T), param);

                Pages.Add(instance);
            }
            
            MainFrame.Navigate(Pages.First(p => p.GetType() == typeof(T)));
        }

        #region events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SubscribeToBgWorker();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)

        {
            BackgroundWorker.RunWorkerAsync();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker.CancelAsync();
        }

        private void BtnPageOne_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage<PageOne>();
        }

        private void BtnPageTwo_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage<PageTwo>();
        }
        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            throw new NotImplementedException();
        }

        private void BackgroundWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            throw new NotImplementedException();
        }

        private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
