﻿using Personal_Insight.ComputeProduct;
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

namespace Personal_Insight.Pages.ModelPages
{
    /// <summary>
    /// Interaction logic for Page_Blogger.xaml
    /// </summary>
    public partial class Page_Blogger : Page
    {
        private GoogleProductModel googleProduct;
        private double takeoutSize = 0;
        private String takeoutSizeType;
        private Blogger productObject;

        public Page_Blogger(GoogleProductModel googleProduct)
        {
            this.googleProduct = googleProduct;
            InitializeComponent();
            productObject = (Blogger)googleProduct.ProductObject;
            dataGrid.ItemsSource = productObject.blogList;
        }

        private void onClickHyperLink(object sender, RoutedEventArgs e)
        {
            var URL = ( (Blogger.BlogCustom) ((Hyperlink) e.Source).DataContext).blogURL;
            System.Diagnostics.Process.Start(URL);
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

        private void openFolderClick(object sender, RoutedEventArgs e)
        {
            Process.Start(googleProduct.ProductFolderPath);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
