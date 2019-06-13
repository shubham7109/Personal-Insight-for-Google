﻿using System;
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
    public partial class IntroPage_3 : Page
    {
        public IntroPage_3()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
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

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                listbox.Items.Clear();
                string[] files = Directory.GetFiles(dialog.FileName);
                string[] dirs = Directory.GetDirectories(dialog.FileName);

                listbox.Items.Add(string.Join(Environment.NewLine, files));
                listbox.Items.Add(string.Join(Environment.NewLine, dirs));

            }
        }
    }
}
