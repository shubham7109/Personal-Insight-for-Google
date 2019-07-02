using Personal_Insight.Models;
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

namespace Personal_Insight.Pages
{
    /// <summary>
    /// Interaction logic for IntroPage_4.xaml
    /// </summary>
    public partial class IntroPage_4 : Page
    {
        private List<GoogleProductModel> googleProductList;
        public IntroPage_4()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
        }

        public IntroPage_4(List<GoogleProductModel> googleProductList)
        {
            InitializeComponent();
            ShowsNavigationUI = false;
            this.googleProductList = googleProductList;
        }

        private void P4BtnClick_back(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                IntroPage_3 page3 = new IntroPage_3();
                NavigationService.Navigate(page3);
            }

        }

        private void P4BtnClick_next(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                IntroPage_5 page5 = new IntroPage_5(googleProductList);
                NavigationService.Navigate(page5);
            }
        }
    }
}
