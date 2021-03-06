﻿using Personal_Insight.Models;
using Personal_Insight.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Insight.ComputeProduct
{
    class Bookmarks
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        public List<BookMark> bookmarks;

        public Bookmarks()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Bookmarks");

            gatherData();
            setStatInfo();
        }

        private void setStatInfo()
        {
            googleProduct.NumItems = bookmarks.Count;
            if (bookmarks.Count > 0)
            {
                GoogleProduct.isProcessed = true;
            }
        }

        private void gatherData()
        {
            bookmarks = new List<BookMark>();
            string[] files = Directory.GetFiles(googleProduct.ProductFolderPath);
            foreach (String file in files)
            {
                if (file.Contains("Bookmarks.html"))
                {
                    String[] lines = File.ReadAllLines(file);
                    foreach(String line in lines)
                    {
                        if (line.Contains("<DT><A HREF=\""))
                        {
                            String link = line.Remove(0, 13);
                            link = link.Substring(0,link.IndexOf("\""));

                            String name = line.Remove(0, line.IndexOf(">") + 1);
                            name = name.Remove(0, name.IndexOf(">")+ 1);
                            name = name.Substring(0, name.IndexOf("<"));

                            bookmarks.Add(new BookMark(name, link, ++count));
                            //page.enterLog("Name: "+ name + ", Link: " + link);
                        }
                    }

                    //page.enterLog("Number of Bookmarks: "+ bookmarks.Count());
                }
            }

            page.enterLog("Logged " + bookmarks.Count + " Bookmarks!");
        }

        private int count = 0;

        public class BookMark
        {
            public String name { get; set; }
            public String link { get; set; }
            public int Count { get; set; }

            public BookMark(string name, string link, int count)
            {
                this.name = name;
                this.link = link;
                Count = count;
            }
        }
    }
}
