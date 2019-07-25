using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Personal_Insight
{
    /// <summary>
    /// Interaction logic for IntroPage_1.xaml
    /// </summary>
    public partial class IntroPage_1 : Page
    {
        public IntroPage_1()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //begin_btn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }


        private void P1BtnClick_begin(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                IntroPage_2 page2 = new IntroPage_2();
                NavigationService.Navigate(page2);
            }

        }
    }
}
