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
    public partial class IntroPage_5 : Page, INotifyPropertyChanged
    {
        private List<GoogleProductModel> googleProductList;

        public IntroPage_5(List<GoogleProductModel> googleProductList)
        {
            DataContext = this;
            this.googleProductList = googleProductList;
            InitializeComponent();
        }


        private String _consoleLogText;
        public String ConsoleLogText
        {
            get { return _consoleLogText; }
            set
            {
                if (_consoleLogText != value)
                {
                    _consoleLogText = value;
                    OnPropertyChanged();
                }
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            ConsoleLogText = "Starting takeout scan...\n\n";

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < googleProductList.Count; i++)
            {
                product_worker(googleProductList.ElementAt(i));
                decimal send =  ( ((i + 1) / (decimal)googleProductList.Count) * 100);
                (sender as BackgroundWorker).ReportProgress((int)send); // TODO Add a check if count==0
            }
        }


        private void product_worker(GoogleProductModel product)
        {
            
            enterLog("Working on module: " + product.ProductName + " in path, " + product.ProductFolderPath);
            enterLog("The size is " + HelpfulMethods.DirSize(new DirectoryInfo(product.ProductFolderPath)) + "bytes");

            //Starting worker
            GoogleProductsList.StartWork(product,this);
            enterLog("\n");
            //DONE Worker


        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Console.WriteLine("Progress %:" + e.ProgressPercentage);
            progressBar.Value = e.ProgressPercentage;

            //Once the progress is completed.
            if (e.ProgressPercentage >= 100)
            {
                progressBar.IsIndeterminate = false;
                progressBar.Foreground = Brushes.Green;
                progressBar.Background = Brushes.Green;
                enterLog("Scan complete. Click 'Next' to continue.\n");
            }

        }

        /// <summary>
        /// Enters, maintains and prints a new log to the Textbox
        /// </summary>
        /// <param name="log">The log used</param>  
        public void enterLog(String log)
        {
            if (log.Equals("\n"))
            {
                ConsoleLogText = ConsoleLogText + log + Environment.NewLine;
            }
            else
            {
                //ConsoleLogText = "[" + DateTime.Now.ToString("HH:mm:ss tt") + "] " + log + Environment.NewLine + ConsoleLogText;
                ConsoleLogText = ConsoleLogText + "[" + DateTime.Now.ToString("HH:mm:ss tt") + "] " + log + Environment.NewLine;
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
