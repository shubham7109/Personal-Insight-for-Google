using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Personal_Insight.Models
{
    public class GoogleProductModel
    {
        private String productName;
        private String productFolderPath;
        private BitmapImage imageData;
        private BitmapImage verifyModuleImage;
        private String verifyModuleText;
        private Object productObject;

        private string isModuleDisabledText;
        private double dirSize  = 0;
        private long numItems = 0;


        public GoogleProductModel(string productName, string productFolderPath, BitmapImage imageResource, Object productObject)
        {
            this.productName = productName;
            this.productFolderPath = productFolderPath;
            this.imageData = imageResource;
            this.productObject = productObject;
            if (imageData.UriSource.ToString().Contains("NotFound"))
            {
                verifyModuleImage = new BitmapImage(new Uri("pack://application:,,,/Personal Insight;component/assets/icons/" + "icons8-close-window-filled-48.png"));
                verifyModuleText = "Not compatible yet.";
            }
            else
            {
                verifyModuleImage =  new BitmapImage(new Uri("pack://application:,,,/Personal Insight;component/assets/icons/" + "icons8-tick-box-48.png"));
                verifyModuleText = "Imported Sucessfully";
            }
        }

        public string ProductName { get => productName; set => productName = value; }
        public string ProductFolderPath { get => productFolderPath; set => productFolderPath = value; }
        public BitmapImage ImageResource { get => imageData; set => imageData = value; }
        public BitmapImage VerifyModuleImage { get => verifyModuleImage; set => verifyModuleImage = value; }
        public String VerifyModuleText { get => verifyModuleText; set => verifyModuleText = value; }
        public Object ProductObject { get => productObject; set => productObject = value; }
        public long NumItems { get => numItems; set => numItems = value; }
        public double DirSize { get => dirSize; set => dirSize = value; }
        public bool isProcessed { get; set; }
        public string IsModuleDisabledText {
            get
            {
                if (numItems != 0)
                    return "";
                else return "This module is disabled";
            }
        }

    }
}
