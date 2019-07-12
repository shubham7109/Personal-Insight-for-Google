using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Personal_Insight.Models;
using Personal_Insight.Models.JSON_Models.BrowserHistory;
using Personal_Insight.Models.JSON_Models.ChromeAutofill;
using Personal_Insight.Models.JSON_Models.Extensions;
using Personal_Insight.Models.JSON_Models.SearchEngines;
using Personal_Insight.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Personal_Insight.ComputeProduct
{
    class Chrome
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        public List<BookMark> bookMarks;
        public List<DictionaryWord> dictionaryWords;
        public ChromeAutofillModel autofillContent;
        public BrowserHistoryModel browserHistoryModel;
        public ExtensionsModel extensionsModel;
        public SearchEnginesModel searchEnginesModel;

        public Chrome()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Chrome");

            string[] files = Directory.GetFiles(googleProduct.ProductFolderPath);
            foreach (String file in files)
            {
                if (file.Contains("Autofill.json"))
                {
                    gather_AutoFills(File.ReadAllText(file));
                    if (autofillContent.Autofill.Count >= 1)
                    {
                        page.enterLog("Logged autofill content!");
                    }
                }
                else if (file.Contains("Bookmarks.html"))
                {
                    gather_Bookmarks(file);
                    page.enterLog("Logged " + bookMarks.Count + " Chrome bookmarks!");
                }
                else if (file.Contains("BrowserHistory.json"))
                {
                    gather_BrowserEvents(File.ReadAllText(file));
                    page.enterLog("Logged " + browserHistoryModel.BrowserHistory.Count + " items of browser history!");
                }
                else if (file.Contains("Dictionary.csv"))
                {
                    gather_DictionaryWords(file);
                    page.enterLog("Logged " + dictionaryWords.Count + " dictionary words!");
                }
                else if (file.Contains("Extensions.json"))
                {
                    gather_Extensions(File.ReadAllText(file));
                    page.enterLog("Logged " + extensionsModel.Extensions.Count + " Chrome Extensions!");
                }
                else if (file.Contains("SearchEngines.json"))
                {
                    gather_SearchEngines(File.ReadAllText(file));
                    page.enterLog("Logged " + searchEnginesModel.SearchEngines.Count + " Search Engines!");
                }
            }

            setStatInfo();
        }

        private void setStatInfo()
        {
            googleProduct.NumItems =    bookMarks.Count + 
                                        searchEnginesModel.SearchEngines.Count +
                                        extensionsModel.Extensions.Count +
                                        dictionaryWords.Count +
                                        browserHistoryModel.BrowserHistory.Count +
                                        autofillContent.Autofill.Count;
            if (bookMarks.Count > 0 || 
                searchEnginesModel.SearchEngines.Count > 0 ||
                extensionsModel.Extensions.Count > 0 ||
                dictionaryWords.Count > 0 || 
                browserHistoryModel.BrowserHistory.Count > 0 || 
                autofillContent.Autofill.Count > 0)
            {
                GoogleProduct.isProcessed = true;
            }
        }

        private void gather_AutoFills(String jsonText)
        {
            autofillContent = ChromeAutofillModel.FromJson(jsonText);
        }

        private void gather_SearchEngines(string jsonText)
        {
            //jsonText = jsonText.Replace(@"\", @"\\");
            searchEnginesModel = SearchEnginesModel.FromJson(jsonText);
        }

        private void gather_Extensions(string jsonText)
        {
            //jsonText = jsonText.Replace(@"\", @"\\");
            extensionsModel = ExtensionsModel.FromJson(jsonText);
        }

        private void gather_DictionaryWords(string filePath)
        {
            dictionaryWords = new List<DictionaryWord>();
            String[] lines = File.ReadAllLines(filePath);
            foreach(String line in lines)
            {
                dictionaryWords.Add(new DictionaryWord(line));
            }
        }

        private void gather_BrowserEvents(String jsonText)
        {
            browserHistoryModel = BrowserHistoryModel.FromJson(jsonText);
        }

        private void gather_Bookmarks(String filePath)
        {
            bookMarks = new List<BookMark>();
            String[] lines = File.ReadAllLines(filePath);
            foreach (String line in lines)
            {
                if (line.Contains("<DT><A HREF=\""))
                {
                    String link = line.Substring(line.IndexOf("\"")+1);
                    link = link.Substring(0, link.IndexOf("\""));

                    String name = line.Remove(0, line.IndexOf(">") + 1);
                    name = name.Remove(0, name.IndexOf(">") + 1);
                    name = name.Substring(0, name.IndexOf("<"));

                    bookMarks.Add(new BookMark(name, link));
                    //page.enterLog("Name: "+ name + ", Link: " + link);
                }
            }
        }

        public class BookMark
        {
            public String name { get; set; }
            public String link { get; set; }

            public BookMark(string name, string link)
            {
                this.name = name;
                this.link = link;
            }
        }

        public class DictionaryWord
        {
            public String word { get; set; }

            public DictionaryWord(string word)
            {
                this.word = word;
            }
        }

      
    }
}
