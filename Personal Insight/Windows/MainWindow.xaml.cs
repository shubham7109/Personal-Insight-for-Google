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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Personal_Insight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainFrame_OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            try
            {
                /*var ta = new ThicknessAnimation();
                ta.Duration = TimeSpan.FromSeconds(0.5);
                ta.DecelerationRatio = 0.7;
                ta.To = new Thickness(0, 0, 0, 0);
                if (e.NavigationMode == NavigationMode.New || e.NavigationMode == NavigationMode.Forward)
                {
                    ta.From = new Thickness(1000, 0, 0, 0);
                }
                else if (e.NavigationMode == NavigationMode.Back)
                {
                    ta.From = new Thickness(0, 0, 1000, 0);
                }*/

                //(e.Content as Page).BeginAnimation(MarginProperty, ta);

                

            }
            catch (Exception _e)
            {
                Console.WriteLine(_e.Message);
            }
        }
    }
}
