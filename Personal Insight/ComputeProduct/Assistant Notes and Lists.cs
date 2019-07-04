using Personal_Insight.Models;
using Personal_Insight.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Personal_Insight.ComputeProduct
{
    class Assistant_Notes_and_Lists
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        public List<ShoppingList> shoppingList_list;

        public Assistant_Notes_and_Lists()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Assistant_Notes_and_Lists");

            calculate_numFiles();
            gatherData();

        }

        private void gatherData()
        {
            shoppingList_list = new List<ShoppingList>();
            string[] files = Directory.GetFiles(googleProduct.ProductFolderPath);
            foreach (String file in files)
            {
                string[] lines = File.ReadAllLines(file);
                int listItems = 0;
                foreach (string line in lines)
                    listItems++;
                listItems -= 3; //Removing the first 3 lines as they are not needed


                String fileText = File.ReadAllText(file);
                int checkedItems = new Regex(Regex.Escape("Checked")).Matches(fileText).Count;
                int uncheckedItems = new Regex(Regex.Escape("Unchecked")).Matches(fileText).Count;

                shoppingList_list.Add(new ShoppingList(listItems, checkedItems, uncheckedItems));
                //page.enterLog(listItems + "," + checkedItems + "," + uncheckedItems);
            }
        }

        private void calculate_numFiles()
        {
            string[] files = Directory.GetFiles(googleProduct.ProductFolderPath);
            googleProduct.NumItems = files.Length;
            page.enterLog("Num of files: " + googleProduct.NumItems);
        }

        public class ShoppingList
        {
            public int ListItems { get; set; }
            public int CheckedItems { get; set; }
            public int UncheckedItems { get; set; }

            public ShoppingList(int listItems, int checkedItems, int uncheckedItems)
            {
                ListItems = listItems;
                CheckedItems = checkedItems;
                UncheckedItems = uncheckedItems;
            }
        }

    }
}
