using CsvHelper;
using CsvHelper.Configuration;
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
    class Cloud_Print
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        public List<PrinterJobs> printerJobsList;
        public List<Printer> printerList;

        public Cloud_Print()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Cloud Print");

            gatherData(googleProduct.ProductFolderPath);
            setStatInfo();
        }

        private void setStatInfo()
        {
            googleProduct.NumItems = printerJobsList.Count + printerList.Count;
            if (printerJobsList.Count > 0 || printerList.Count > 0)
            {
                GoogleProduct.isProcessed = true;
            }
        }

        private void gatherData(string productFolderPath)
        {
            String[] files = Directory.GetFiles(productFolderPath);
            foreach(String file in files)
            {
                if(file.Contains("Jobs Metadata Takeout.csv"))
                {
                    using (var reader = new StreamReader(file))
                    using (var csv = new CsvReader(reader))
                    {
                        csv.Configuration.RegisterClassMap<PrinterJobsClassMap>();
                        var records = csv.GetRecords<PrinterJobs>();
                        printerJobsList = records.ToList();
                        page.enterLog("Logged " + printerJobsList.Count + " print jobs!");
                    }
                }
                else if(file.Contains("Printers Metadata Takeout.csv"))
                {
                    using (var reader = new StreamReader(file))
                    using (var csv = new CsvReader(reader))
                    {
                        csv.Configuration.RegisterClassMap<PrinterClassMap>();
                        var records = csv.GetRecords<Printer>();
                        printerList = records.ToList();
                        page.enterLog("Logged " + printerList.Count + " printers!");
                    }
                }
            }
        }

        public class Device
        {

        }

        public class PrinterJobs
        {
            public string documenttitle { get; set; }
            public string submissiondate { get; set; }
            public string printername { get; set; }
            public string printjobstatus { get; set; }
        }

        public class PrinterJobsClassMap : ClassMap<PrinterJobs>
        {
            public PrinterJobsClassMap()
            {
                Map(m => m.documenttitle).Name("document title");
                Map(m => m.submissiondate).Name("submission date");
                Map(m => m.printername).Name("printer name");
                Map(m => m.printjobstatus).Name("print job status");
            }
        }

        public class Printer
        {
            public string printername { get; set; }
            public string ownername { get; set; }
            public string owneremail { get; set; }
        }

        public class PrinterClassMap : ClassMap<Printer>
        {
            public PrinterClassMap()
            {
                Map(m => m.printername).Name("printer name");
                Map(m => m.ownername).Name("owner name");
                Map(m => m.owneremail).Name("owner email");
            }
        }



    }
}
