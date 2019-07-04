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
        public List<Device> devicesList;

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
            devicesList = new List<Device>();
            string[] files = Directory.GetFiles(googleProduct.ProductFolderPath);
            foreach(String file in files)
            {
                String fileText = File.ReadAllText(file);

                String model = fileText.Substring(fileText.IndexOf("Model: "));
                model = model.Substring(0, model.IndexOf("<br/>"));

                String manufacturer = fileText.Substring(fileText.IndexOf("Manufacturer: "));
                manufacturer = manufacturer.Substring(0, manufacturer.IndexOf("<br/>"));

                String iMEI = fileText.Substring(fileText.IndexOf("IMEI(s): "));
                iMEI = iMEI.Substring(0, iMEI.IndexOf("<br/>"));

                String lastConnection = fileText.Substring(fileText.IndexOf("Time of Last Data Connection: "));
                lastConnection = lastConnection.Substring(0, lastConnection.IndexOf("<br/>"));

                devicesList.Add(new Device(model, manufacturer, iMEI, lastConnection));
                page.enterLog("["+model+","+manufacturer+","+iMEI+","+lastConnection+"]");
            }

        }

        private void calculate_numFiles()
        {
            string[] files = Directory.GetFiles(googleProduct.ProductFolderPath);
            googleProduct.NumItems = files.Length;
            page.enterLog("Num of files: " + googleProduct.NumItems);
        }

        public class Device
        {
            public String Model { get; set; }
            public String Manufacturer { get; set; }
            public String IMEI { get; set; }
            public String LastConnection { get; set; }

            public Device(string model, string manufacturer, string iMEI, string lastConnection)
            {
                Model = model;
                Manufacturer = manufacturer;
                IMEI = iMEI;
                LastConnection = lastConnection;
            }
        }
    }
}