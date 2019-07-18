using Personal_Insight.ComputeProduct;
using Personal_Insight.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Page_Android_Device_Configuration_Service.xaml
    /// </summary>
    public partial class Page_Android_Device_Configuration_Service : Page
    {
        private GoogleProductModel googleProduct;
        private double takeoutSize = 0;
        private String takeoutSizeType;
        private Android_Device_Configuration_Service productObject;

        public Page_Android_Device_Configuration_Service(GoogleProductModel googleProduct)
        {
            this.googleProduct = googleProduct;
            InitializeComponent();
            productObject = (Android_Device_Configuration_Service)googleProduct.ProductObject;
            dataGrid.ItemsSource = productObject.devicesList;
        }

        private void Window_ContentRendered(object sender, RoutedEventArgs e)
        {
            takeoutSize = googleProduct.DirSize;
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
