using System;
using System.Collections.Generic;
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
using System.Diagnostics;
using System.Windows.Controls.Primitives;

namespace Personal_Insight
{
    /// <summary>
    /// Interaction logic for IntroPage_2.xaml
    /// </summary>
    public partial class IntroPage_2 : Page
    {
        public IntroPage_2()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //next_btn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void onClickHyperLink(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://takeout.google.com");
        }

        private void P2BtnClick_back(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                IntroPage_1 page1 = new IntroPage_1();
                NavigationService.Navigate(page1);
            }

        }

        private void P2BtnClick_next(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                IntroPage_3 page3 = new IntroPage_3();
                NavigationService.Navigate(page3);
            }
        }
    }


}
