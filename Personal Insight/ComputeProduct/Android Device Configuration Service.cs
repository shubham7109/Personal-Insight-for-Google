using Personal_Insight.Models;
using Personal_Insight.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Insight.ComputeProduct
{
    class Android_Device_Configuration_Service
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        public List<Devices> devicesList;

        public Android_Device_Configuration_Service()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Android_Device_Configuration_Service");

            calculate_numFiles();
            gatherDevices();
        }

        private void gatherDevices()
        {
            devicesList = new List<Devices>();
            string[] files = Directory.GetFiles(googleProduct.ProductFolderPath);
            foreach(String file in files)
            {
                page.enterLog(file);
            }

        }

        private void calculate_numFiles()
        {
            string[] files = Directory.GetFiles(googleProduct.ProductFolderPath);
            googleProduct.NumItems = files.Length;
            page.enterLog("Num of files: " + googleProduct.NumItems);
        }

        public class Devices
        {
            public String Model { get; set; }
            public String Brand { get; set; }
            public String IMEI { get; set; }

            public Devices(string model, string brand, string iMEI)
            {
                Model = model;
                Brand = brand;
                IMEI = iMEI;
            }
        }
    }
}