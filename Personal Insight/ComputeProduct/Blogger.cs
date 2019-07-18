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
    class Blogger
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        private List<Blog> autoList;
        public List<BlogCustom> blogList;

        public Blogger()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Blogger");

            calculate_numFiles();
            gatherData();
            setStatInfo();
        }

        private void setStatInfo()
        {
            googleProduct.NumItems = blogList.Count;
            if (blogList.Count > 0)
            {
                GoogleProduct.isProcessed = true;
            }
        }

        private void gatherData()
        {
            autoList = new List<Blog>();
            blogList = new List<BlogCustom>();
            string[] dirs = Directory.GetDirectories(googleProduct.ProductFolderPath+ "\\Blogs");
            foreach (String dir in dirs)
            {
                string[] files = Directory.GetFiles(dir);   

                foreach(String file in files)
                {
                    if (file.Contains("settings.csv"))
                    {
                        using (var reader = new StreamReader(file))
                        using (var csv = new CsvReader(reader))
                        {
                            csv.Configuration.RegisterClassMap<BlogClassMap>();
                            var records = csv.GetRecords<Blog>();
                            autoList = records.ToList();
                            blogList.Add(new BlogCustom(autoList.ElementAt(0).blog_subdomain, autoList.ElementAt(0).blog_name, autoList.ElementAt(0).blog_admin_permission, ++count));

                        }
                        //page.enterLog("Name: "+blogName+", URL: "+blogURL+", Admin: " + blogAdmin);
                    }
                }

            }

            page.enterLog("Logged " + blogList.Count + " Blog Sites!");
        }

        private int count = 0;

        private void calculate_numFiles()
        {
            /*string[] dirs = Directory.GetDirectories(googleProduct.ProductFolderPath + "\\Blogs");
            googleProduct.NumItems = dirs.Length;
            page.enterLog("Num of blogs: " + googleProduct.NumItems);*/
        }

        public class BlogCustom
        {
            public String blogURL { get; set; }
            public String blogName { get; set; }
            public String blogAdmin { get; set; }
            public int blogNumber { get; set; }

            public BlogCustom(string blogURL, string blogName, string blogAdmin, int count)
            {
                this.blogURL = "https://" + blogURL + ".blogspot.com";
                this.blogName = blogName;
                this.blogAdmin = blogAdmin;
                blogNumber = count;
            }
        }


        public class Blog
        {
            public string blog_publishing_mode { get; set; }
            public string blog_admin_permission { get; set; }
            public bool blog_adult_content { get; set; }
            public bool blog_alternate_jsrender_allowed { get; set; }
            public string blog_analytics_account_number { get; set; }
            public string blog_archive_date_format { get; set; }
            public string blog_archive_frequency { get; set; }
            public string blog_author_permission { get; set; }
            public bool blog_by_post_archiving { get; set; }
            public string blog_comment_access { get; set; }
            public bool blog_comment_captcha { get; set; }
            public string blog_comment_email { get; set; }
            public string blog_comment_feed { get; set; }
            public string blog_comment_form_location { get; set; }
            public string blog_comment_message { get; set; }
            public string blog_comment_moderation { get; set; }
            public int blog_comment_moderation_delay { get; set; }
            public string blog_comment_moderation_email { get; set; }
            public bool blog_comment_profile_images { get; set; }
            public bool blog_comments_allowed { get; set; }
            public int blog_comments_time_stamp_format { get; set; }
            public bool blog_convert_line_breaks { get; set; }
            public string blog_custom_ads_txt { get; set; }
            public bool blog_custom_ads_txt_enabled { get; set; }
            public string blog_custom_page_not_found { get; set; }
            public string blog_custom_robots_txt { get; set; }
            public bool blog_custom_robots_txt_enabled { get; set; }
            public int blog_date_format { get; set; }
            public string blog_default_comments_mode { get; set; }
            public string blog_description { get; set; }
            public bool blog_email_post_links { get; set; }
            public string blog_feed_redirect_url { get; set; }
            public bool blog_float_alignment { get; set; }
            public string blog_locale { get; set; }
            public int blog_max_num { get; set; }
            public string blog_max_unit { get; set; }
            public string blog_meta_description { get; set; }
            public bool blog_meta_description_enabled { get; set; }
            public string blog_name { get; set; }
            public string blog_per_post_feed { get; set; }
            public string blog_post_feed { get; set; }
            public string blog_post_feed_footer { get; set; }
            public string blog_post_template { get; set; }
            public bool blog_promoted { get; set; }
            public bool blog_quick_editing { get; set; }
            public string blog_read_access_mode { get; set; }
            public string blog_reader_permission { get; set; }
            public bool blog_searchable { get; set; }
            public string blog_send_email { get; set; }
            public bool blog_show_url { get; set; }
            public string blog_subdomain { get; set; }
            public int blog_time_stamp_format { get; set; }
            public string blog_time_zone { get; set; }
            public bool blog_use_lightbox { get; set; }
        }

        public class BlogClassMap : ClassMap<Blog>
        {
            public BlogClassMap()
            {
                Map(m => m.blog_publishing_mode).Name("blog_publishing_mode");
                Map(m => m.blog_admin_permission).Name("blog_admin_permission");
                Map(m => m.blog_adult_content).Name("blog_adult_content");
                Map(m => m.blog_alternate_jsrender_allowed).Name("blog_alternate_jsrender_allowed");
                Map(m => m.blog_analytics_account_number).Name("blog_analytics_account_number");
                Map(m => m.blog_archive_date_format).Name("blog_archive_date_format");
                Map(m => m.blog_archive_frequency).Name("blog_archive_frequency");
                Map(m => m.blog_author_permission).Name("blog_author_permission");
                Map(m => m.blog_by_post_archiving).Name("blog_by_post_archiving");
                Map(m => m.blog_comment_access).Name("blog_comment_access");
                Map(m => m.blog_comment_captcha).Name("blog_comment_captcha");
                Map(m => m.blog_comment_email).Name("blog_comment_email");
                Map(m => m.blog_comment_feed).Name("blog_comment_feed");
                Map(m => m.blog_comment_form_location).Name("blog_comment_form_location");
                Map(m => m.blog_comment_message).Name("blog_comment_message");
                Map(m => m.blog_comment_moderation).Name("blog_comment_moderation");
                Map(m => m.blog_comment_moderation_delay).Name("blog_comment_moderation_delay");
                Map(m => m.blog_comment_moderation_email).Name("blog_comment_moderation_email");
                Map(m => m.blog_comment_profile_images).Name("blog_comment_profile_images");
                Map(m => m.blog_comments_allowed).Name("blog_comments_allowed");
                Map(m => m.blog_comments_time_stamp_format).Name("blog_comments_time_stamp_format");
                Map(m => m.blog_convert_line_breaks).Name("blog_convert_line_breaks");
                Map(m => m.blog_custom_ads_txt).Name("blog_custom_ads_txt");
                Map(m => m.blog_custom_ads_txt_enabled).Name("blog_custom_ads_txt_enabled");
                Map(m => m.blog_custom_page_not_found).Name("blog_custom_page_not_found");
                Map(m => m.blog_custom_robots_txt).Name("blog_custom_robots_txt");
                Map(m => m.blog_custom_robots_txt_enabled).Name("blog_custom_robots_txt_enabled");
                Map(m => m.blog_date_format).Name("blog_date_format");
                Map(m => m.blog_default_comments_mode).Name("blog_default_comments_mode");
                Map(m => m.blog_description).Name("blog_description");
                Map(m => m.blog_email_post_links).Name("blog_email_post_links");
                Map(m => m.blog_feed_redirect_url).Name("blog_feed_redirect_url");
                Map(m => m.blog_float_alignment).Name("blog_float_alignment");
                Map(m => m.blog_locale).Name("blog_locale");
                Map(m => m.blog_max_num).Name("blog_max_num");
                Map(m => m.blog_max_unit).Name("blog_max_unit");
                Map(m => m.blog_meta_description).Name("blog_meta_description");
                Map(m => m.blog_meta_description_enabled).Name("blog_meta_description_enabled");
                Map(m => m.blog_name).Name("blog_name");
                Map(m => m.blog_per_post_feed).Name("blog_per_post_feed");
                Map(m => m.blog_post_feed).Name("blog_post_feed");
                Map(m => m.blog_post_feed_footer).Name("blog_post_feed_footer");
                Map(m => m.blog_post_template).Name("blog_post_template");
                Map(m => m.blog_promoted).Name("blog_promoted");
                Map(m => m.blog_quick_editing).Name("blog_quick_editing");
                Map(m => m.blog_read_access_mode).Name("blog_read_access_mode");
                Map(m => m.blog_reader_permission).Name("blog_reader_permission");
                Map(m => m.blog_searchable).Name("blog_searchable");
                Map(m => m.blog_send_email).Name("blog_send_email");
                Map(m => m.blog_show_url).Name("blog_show_url");
                Map(m => m.blog_subdomain).Name("blog_subdomain");
                Map(m => m.blog_time_stamp_format).Name("blog_time_stamp_format");
                Map(m => m.blog_time_zone).Name("blog_time_zone");
                Map(m => m.blog_use_lightbox).Name("blog_use_lightbox");
            }
        }

    }
}
