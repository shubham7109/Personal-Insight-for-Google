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
    class Classic_Sites
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        public List<Site> siteList;

        public Classic_Sites()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Classic Sites");

            gatherData(googleProduct.ProductFolderPath);
            setStatInfo();

        }

        private void setStatInfo()
        {
            googleProduct.NumItems = siteList.Count;
            if (siteList.Count > 0)
            {
                GoogleProduct.isProcessed = true;
            }
        }

        private void gatherData(string productFolderPath)
        {
            siteList = new List<Site>();
            string[] folders = Directory.GetDirectories(productFolderPath);
            foreach(String folder in folders)
            {
                siteList.Add(new Site(getSiteName(folder))); 
            }

            page.enterLog("Logged " + siteList.Count + " Classic Sites!");
        }

        public static String getSiteName(String pathName)
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

        public class Site
        {
            public String siteName { get; set; }
            public String siteURL { get; set; }

            public Site(string siteName)
            {
                this.siteName = siteName;
                this.siteURL = "https://sites.google.com/site/" + siteName;
            }
        }
    }
}
