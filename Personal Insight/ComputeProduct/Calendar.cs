using Galactic.Calendar.iCalendar;
using Ical.Net;
using Ical.Net.Proxies;
using Personal_Insight.Models;
using Personal_Insight.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ical.Net.CalendarComponents;

namespace Personal_Insight.ComputeProduct
{
    class Calendar
    {
        private GoogleProductModel googleProduct;
        private IntroPage_5 page;
        public GoogleProductModel GoogleProduct { get => googleProduct; set => googleProduct = value; }
        public List<CalendarEvent_> calendarEvents;

        public Calendar()
        {
        }

        public void startWork(IntroPage_5 page)
        {
            this.page = page;
            page.enterLog("Starting work on Calendar");

            gatherData();
            setStatInfo();
        }

        private void setStatInfo()
        {
            googleProduct.NumItems = calendarEvents.Count;
            if (calendarEvents.Count > 0)
            {
                GoogleProduct.isProcessed = true;
            }
        }

        private void gatherData()
        {
            calendarEvents = new List<CalendarEvent_>();
            string[] files = Directory.GetFiles(googleProduct.ProductFolderPath);
            foreach (String file in files)
            {
                String fileText = File.ReadAllText(file);
                var calendar = Ical.Net.Calendar.Load(fileText);

                foreach(CalendarEvent calendarEvent in calendar.Events)
                {
                    calendarEvents.Add(new CalendarEvent_(++count, calendarEvent.Summary, calendarEvent.Description, calendarEvent.DtStart.AsSystemLocal.ToString("ddd, dd-MMM-yyy HH:mm:ss")));
                }
            }

            page.enterLog("Logged " + calendarEvents.Count + " calendar events!");
        }

        private int count = 0;

        public class CalendarEvent_
        {
            
            public String eventTitle { get; set; }
            public String description { get; set; }
            public String eventDate { get; set; }
            public int CalendarItem { get; set; }

            public CalendarEvent_(int count, String eventTitle, String description, String eventDate)
            {
                this.CalendarItem = count;
                this.eventTitle = eventTitle;
                this.description = description;
                this.eventDate = eventDate;
            }
        }
    }
}
