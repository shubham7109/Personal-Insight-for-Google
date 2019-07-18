using Personal_Insight.ComputeProduct;
using Personal_Insight.Models;
using System;
using System.Collections.Generic;
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
using static Personal_Insight.ComputeProduct.Calendar;
using Calendar = Personal_Insight.ComputeProduct.Calendar;

namespace Personal_Insight.Pages.ModelPages
{
    /// <summary>
    /// Interaction logic for Page_Calendar.xaml
    /// </summary>
    public partial class Page_Calendar : Page
    {
        private GoogleProductModel googleProduct;
        private double takeoutSize = 0;
        private String takeoutSizeType;
        private Calendar productObject;

        public Page_Calendar(GoogleProductModel googleProduct)
        {
            this.googleProduct = googleProduct;
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, RoutedEventArgs e)
        {
            productObject = (Calendar)googleProduct.ProductObject;
            var collection = new List<CalendarEvent_>();

            for (int i = 0; i < 50; i++)
            {
                collection.Add(productObject.calendarEvents.ElementAt(i));
            }

            dataGrid.ItemsSource = collection;

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
