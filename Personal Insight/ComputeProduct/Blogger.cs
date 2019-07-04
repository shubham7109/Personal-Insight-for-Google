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
    class Blogger
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        public List<Blog> blogList;

        public Blogger()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Blogger");

            calculate_numFiles();
            gatherData();


        }

        private void gatherData()
        {
            blogList = new List<Blog>();
            string[] dirs = Directory.GetDirectories(googleProduct.ProductFolderPath+ "\\Blogs");
            foreach (String dir in dirs)
            {
                string[] files = Directory.GetFiles(dir);   

                foreach(String file in files)
                {
                    if (file.Contains("settings.csv"))
                    {
                        String[] lines = File.ReadAllLines(file);

                        //Get the second line of the CSV
                        String blogAdmin = lines[1];
                        String blogName = lines[1];
                        String blogURL = lines[1];


                        //ADMIN
                        int index = blogAdmin.IndexOf(",");
                        blogAdmin = blogAdmin.Substring(index + 1);
                        blogAdmin = blogAdmin.Remove(blogAdmin.IndexOf(","));

                        //NAME
                        for(int i=0; i<38; i++)
                        {
                            index = blogName.IndexOf(",");
                            blogName = blogName.Substring(index + 1);
                        }
                        blogName = blogName.Remove(blogName.IndexOf(","));

                        //URL
                        for (int i = 0; i < 50; i++)
                        {
                            index = blogURL.IndexOf(",");
                            blogURL = blogURL.Substring(index + 1);
                        }
                        blogURL = blogURL.Remove(blogURL.IndexOf(","));
                        blogURL = blogName + ".blogspot.com";

                        blogList.Add(new Blog(blogURL, blogName, blogAdmin));
                        page.enterLog("Name: "+blogName+", URL: "+blogURL+", Admin: " + blogAdmin);
                    }
                }

            }
        }

        private void calculate_numFiles()
        {
            string[] dirs = Directory.GetDirectories(googleProduct.ProductFolderPath + "\\Blogs");
            googleProduct.NumItems = dirs.Length;
            page.enterLog("Num of blogs: " + googleProduct.NumItems);
        }

        public class Blog
        {
            public String blogURL { get; set; }
            public String blogName { get; set; }
            public String blogAdmin { get; set; }

            public Blog(string blogURL, string blogName, string blogAdmin)
            {
                this.blogURL = blogURL;
                this.blogName = blogName;
                this.blogAdmin = blogAdmin;
            }
        }
    }
}
