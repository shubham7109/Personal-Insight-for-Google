﻿using Personal_Insight.Models;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private List<GoogleProductModel> googleProductList;

        public Dashboard(List<GoogleProductModel> googleProductList)
        {
            InitializeComponent();

            this.googleProductList = googleProductList;

            initData();
        }

        private void initData()
        {
            listBox.ItemsSource = googleProductList;
        }
    }
}
