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
    class Drive
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        public List<FileInfo> fileInfoList;

        public Drive()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Drive");

            gatherData(googleProduct.ProductFolderPath);
            page.enterLog("Logged " + fileInfoList.Count + " files in Google Drive");
        }

        private void gatherData(string productFolderPath)
        {
            fileInfoList = new List<FileInfo>();
            setUpList(new DirectoryInfo(productFolderPath));
        }

        public void setUpList(DirectoryInfo d)
        {
            try
            {
                // Add file sizes.
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    if (!fileInfoList.Contains(fi))
                    {
                        fileInfoList.Add(fi);
                    }
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    setUpList(di);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("ERROR: {0} Exception caught.", e);
            }
        }
    }
}
