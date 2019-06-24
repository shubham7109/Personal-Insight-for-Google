using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Insight.Models
{
    public class GoogleProductModel
    {
        private String productName;
        private String productFolderPath;
        private String imageResource;

        public GoogleProductModel(string productName, string productFolderPath, string imageResource)
        {
            this.productName = productName;
            this.productFolderPath = productFolderPath;
            this.imageResource = imageResource;
        }

        public string ProductName { get => productName; set => productName = value; }
        public string ProductFolderPath { get => productFolderPath; set => productFolderPath = value; }
        public string ImageResource { get => imageResource; set => imageResource = value; }
    }
}
