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
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Personal_Insight
{
    /// <summary>
    /// Interaction logic for IntroPage_3.xaml
    /// </summary>
    /// 
    public partial class IntroPage_3 : Page
    {
        public IntroPage_3()
        {
            InitializeComponent();
            ShowsNavigationUI = false;

            /*List<User> items = new List<User>();
            items.Add(new User() { Name = "John Doe", Age = 42, Mail = "john@doe-family.com" });
            items.Add(new User() { Name = "Jane Doe", Age = 39, Mail = "jane@doe-family.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });*/
            //listview.ItemsSource = items;
            var lol = listview.ActualHeight;
        }

        private void P3BtnClick_next(object sender, RoutedEventArgs e)
        {

        }

        private void P3BtnClick_back(object sender, RoutedEventArgs e)
        {
            IntroPage_2 page2 = new IntroPage_2();
            NavigationService.Navigate(page2);
        }

        private void btnClick_openFile(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;
            dialog.EnsureFileExists = true;

            CommonFileDialogResult res = dialog.ShowDialog();
            if (res == CommonFileDialogResult.Ok)
            {
                String path = dialog.FileName;
                int start = path.Length - 7;
                String takeoutCheck = path.Substring(start);

                if (takeoutCheck.Equals("Takeout"))
                {
                    populateListBox(path);
                }
                else
                {
                    MessageBox.Show("The selected folder is not a '/Takeout' folder", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if( res  == CommonFileDialogResult.None)
            {
                MessageBox.Show("Error opening dialog. Contact developer for a solution.", "Error: 0x01", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
