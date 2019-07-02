using Personal_Insight.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Personal_Insight.Pages
{
    /// <summary>
    /// Interaction logic for IntroPage_5.xaml
    /// </summary>
    public partial class IntroPage_5 : Page, INotifyPropertyChanged
    {
        private int percentageProgress;
        private List<GoogleProductModel> googleProductList;
        private String _consoleLogText;
        public String ConsoleLogText {
            get { return _consoleLogText; }
            set
            {
                if (value != _consoleLogText)
                {
                    _consoleLogText = value;
                    OnPropertyChanged("Name2");
                }
            }
        }

        public IntroPage_5(List<GoogleProductModel> googleProductList)
        {
            InitializeComponent();
            percentageProgress = 0;
            this.googleProductList = googleProductList;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            ConsoleLogText = "Starting takeout scan...";

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            /*for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(100);
            }*/
            

            for(int i=0; i< googleProductList.Count; i++)
            {
                product_worker(googleProductList.ElementAt(i));
                (sender as BackgroundWorker).ReportProgress((i/googleProductList.Count)*100); // TODO Add a check if count==0
            }
        }


        private void product_worker(GoogleProductModel product)
        {
            Console.WriteLine("The size is {0} bytes.", HelpfulMethods.DirSize(new DirectoryInfo(product.ProductFolderPath)));
            enterLog(product.ProductFolderPath);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;

        }

        private void enterLog(String log)
        {
            //ConsoleLogText += Environment.NewLine + log;
            Console.WriteLine(log);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
