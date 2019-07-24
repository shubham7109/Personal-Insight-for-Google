using Personal_Insight.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

namespace Personal_Insight.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private List<GoogleProductModel> googleProductList;
        private long loggedFiles = 0;
        private double takeoutSize = 0;
        private String takeoutSizeType;

        public Dashboard(List<GoogleProductModel> googleProductList)
        {
            InitializeComponent();

            this.googleProductList = googleProductList;

            initData();
        }

        private void initData()
        {
            listBox.ItemsSource = googleProductList;
        }

        private void Window_ContentRendered(object sender, RoutedEventArgs e)
        {
            foreach(GoogleProductModel googleProduct in googleProductList)
            {
                loggedFiles += googleProduct.NumItems;
                takeoutSize += googleProduct.DirSize;
            }
            Console.WriteLine("Logged files: " + loggedFiles);
            Console.WriteLine("Takeout bytes: " + takeoutSize);

            var tuple = HelpfulMethods.ByteToString(takeoutSize);
            takeoutSizeType = tuple.Item2;
            takeoutSize = tuple.Item1;            

            new Thread(CountUpText).Start();
        }
        public void CountUpText()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var elapsedMs = watch.ElapsedMilliseconds;

            while (elapsedMs < 1000)
            {
                this.Dispatcher.Invoke(() => {
                    loggedText.Text = ((int) (loggedFiles*(elapsedMs/1000.0))).ToString();
                    takeoutSizeText.Text = ((int)(takeoutSize * (elapsedMs / 1000.0)))  + " " + takeoutSizeType;
                });

                elapsedMs = watch.ElapsedMilliseconds;
            }

            watch.Stop();

            this.Dispatcher.Invoke(() => {
                loggedText.Text = loggedFiles.ToString();
                //string result = String.Format("{0:0.##} {1}", len, sizes[order]);
                takeoutSizeText.Text = (String.Format("{0:0.##} ", takeoutSize)) + takeoutSizeType;
            });

        }

        private void listView_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                GoogleProductsList.NavigateNextPage((GoogleProductModel)item, this);
            }
        }

        private void openFolderClick(object sender, RoutedEventArgs e)
        {
            var path = googleProductList.ElementAt(0).ProductFolderPath;
            path = path.Remove(path.LastIndexOf('\\'));
            
            Process.Start(path);
        }
    }
}
