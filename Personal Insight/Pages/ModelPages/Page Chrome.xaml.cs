using Personal_Insight.ComputeProduct;
using Personal_Insight.Models;
using Personal_Insight.Models.JSON_Models.BrowserHistory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Personal_Insight.Pages.ModelPages
{
    /// <summary>
    /// Interaction logic for Page_Chrome.xaml
    /// </summary>
    public partial class Page_Chrome : Page
    {
        private GoogleProductModel googleProduct;
        private double takeoutSize = 0;
        private String takeoutSizeType;
        private Chrome productObject;

        public Page_Chrome(GoogleProductModel googleProduct)
        {
            this.googleProduct = googleProduct;
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, RoutedEventArgs e)
        {
            productObject = (Chrome)googleProduct.ProductObject;

            var collection = new List<BrowserHistory>();

            for(int i=0; i < 50; i++)
            {
                collection.Add(productObject.browserHistoryModel.BrowserHistory.ElementAt(i));
            }

            dataGrid.ItemsSource = collection;


            takeoutSize = googleProduct.DirSize;
            var tuple = HelpfulMethods.ByteToString(takeoutSize);
            takeoutSizeType = tuple.Item2;
            takeoutSize = tuple.Item1;

            new Thread(CountUpText).Start();
        }

        private void onClickHyperLink(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(((BrowserHistory)((Hyperlink)e.Source).DataContext).URI_text);
        }

        public void CountUpText()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var elapsedMs = watch.ElapsedMilliseconds;

            while (elapsedMs < 1000)
            {
                this.Dispatcher.Invoke(() => {
                    loggedText.Text = ((int)(googleProduct.NumItems * (elapsedMs / 1000.0))).ToString();
                    takeoutSizeText.Text = ((int)(takeoutSize * (elapsedMs / 1000.0))) + " " + takeoutSizeType;
                });

                elapsedMs = watch.ElapsedMilliseconds;
            }

            watch.Stop();

            this.Dispatcher.Invoke(() => {
                loggedText.Text = googleProduct.NumItems.ToString();
                //string result = String.Format("{0:0.##} {1}", len, sizes[order]);
                takeoutSizeText.Text = (String.Format("{0:0.##} ", takeoutSize)) + takeoutSizeType;
            });

        }
    }
}
