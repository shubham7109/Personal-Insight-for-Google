using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Personal_Insight.Models
{
    public class GoogleProductModel
    {
        private String productName;
        private String productFolderPath;
        private BitmapImage imageData;

        public GoogleProductModel(string productName, string productFolderPath, BitmapImage imageResource)
        {
            this.productName = productName;
            this.productFolderPath = productFolderPath;
            this.imageData = imageResource;
        }

        public string ProductName { get => productName; set => productName = value; }
        public string ProductFolderPath { get => productFolderPath; set => productFolderPath = value; }
        public BitmapImage ImageResource { get => imageData; set => imageData = value; }
    }
}
