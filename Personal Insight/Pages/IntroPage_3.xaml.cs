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
using Personal_Insight.Models;

namespace Personal_Insight
{
    /// <summary>
    /// Interaction logic for IntroPage_3.xaml
    /// </summary>
    /// 
    public partial class IntroPage_3 : Page
    {
        private List<GoogleProductModel> googleProductList;
        public IntroPage_3()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
            
            //Init the arraylist
            googleProductList = new List<GoogleProductModel>();
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
                    populateArrayList(path);
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

        private void populateArrayList(String folderName)
        {

            //listView.Items.Clear();
            string[] files = Directory.GetFiles(folderName);
            string[] dirs = Directory.GetDirectories(folderName);

            foreach (string dir in dirs)
            {
                googleProductList.Add(new GoogleProductModel(
                    /*Product name*/ getProductName(dir),
                    /*Product path*/ dir,
                    /*Product imgr*/ GoogleProductsList.LoadImage(getProductName(dir))));
            }

            listView.ItemsSource = googleProductList;
        }

        private void populateListBox(String path)
        {

        }

        /*
         * This method converts the path to a product name
         */
        public static String getProductName(String pathName)
        {
            //TODO 
            // Add a try catch here
            while (pathName.Contains("\\"))
            {
                int index = pathName.IndexOf("\\");
                pathName = pathName.Substring(index + 1);
            }
            return pathName;
        }
    }
}
