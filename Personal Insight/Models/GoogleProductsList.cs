using Personal_Insight.ComputeProduct;
using Personal_Insight.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Personal_Insight.Models
{
    public class GoogleProductsList
    {
        public const String ADCS = "Android Device Configuration Service";
        public const String ANL = "Assistant Notes and Lists";
        public const String Blogger = "Blogger";
        public const String Bookmarks = "Bookmarks";
        public const String Calendar = "Calendar";
        public const String Chrome = "Chrome";
        public const String CS = "Classic Sites";
        public const String CP = "Cloud Print";
        public const String Contacts = "Contacts";
        public const String Drive = "Drive";
        public const String Fit = "Fit";
        public const String GSM = "G Suite Marketplace";
        public const String GMB = "Google My Business";
        public const String GPay = "Google Pay";
        public const String GPhotos = "Google Photos";
        public const String GPB = "Google Play Books";
        public const String GPC = "Google Play Console";
        public const String GPGS = "Google Play Games Services";
        public const String GPMTV = "Google Play Movies _ TV";
        public const String GPM = "Google Play Music";
        public const String GPS = "Google Play Store";
        public const String GS = "Google Shopping";
        public const String GW = "Google+ +1s on websites";
        public const String GC = "Google+ Circles";
        public const String GPlusS = "Google+ Stream";
        public const String Hangouts = "Hangouts";
        public const String HA = "Home App";
        public const String Keep = "Keep";
        public const String LH = "Location History";
        public const String Maps = "Maps";
        public const String MapsYP = "Maps (your places)";
        public const String MA = "My Activity";
        public const String News = "News";
        public const String Profile = "Profile";
        public const String PR = "Purchases _ Reservations";
        public const String Reminders = "Reminders";
        public const String Saved = "Saved";
        public const String SL = "Shopping Lists";
        public const String Tasks = "Tasks";
        public const String Voice = "Voice";
        public const String YouTube = "YouTube";
        public const String Mail = "Mail";

        private static Object productObject;
        public static Object ProductObject { get => productObject; set => productObject = value; }

        // for this code image needs to be a project resource
        public static BitmapImage LoadImage(string productName)
        {
            string fileName;
            switch (productName)
            {
                case ADCS:
                    fileName = "ADCS";
                    break;

                case ANL:
                    fileName = "ANL";
                    break;

                case Blogger:
                    fileName = "Blogger";
                    break;

                case Bookmarks:
                    fileName = "Bookmarks";
                    break;

                case Calendar:
                    fileName = "Calendar";
                    break;

                case Chrome:
                    fileName = "Chrome";
                    break;

                case GPC:
                    fileName = "GPC";
                    break;

                case Contacts:
                    fileName = "Contacts";
                    break;

                case CP:
                    fileName = "CP";
                    break;

                case CS:
                    fileName = "CS";
                    break;

                case Drive:
                    fileName = "Drive";
                    break;

                case Fit:
                    fileName = "Fit";
                    break;

                case GC:
                    fileName = "GC";
                    break;

                case GMB:
                    fileName = "GMB";
                    break;

                case GPay:
                    fileName = "GPay";
                    break;

                case GPB:
                    fileName = "GPB";
                    break;

                case GPGS:
                    fileName = "GPGS";
                    break;

                case GPhotos:
                    fileName = "GPhotos";
                    break;

                case GPlusS:
                    fileName = "GPlusS";
                    break;

                case GPM:
                    fileName = "GPM";
                    break;

                case GPMTV:
                    fileName = "GPMTV";
                    break;

                case GPS:
                    fileName = "GPS";
                    break;

                case GS:
                    fileName = "GS";
                    break;

                case GSM:
                    fileName = "GSM";
                    break;

                case GW:
                    fileName = "GW";
                    break;

                case HA:
                    fileName = "HA";
                    break;

                case Hangouts:
                    fileName = "Hangouts";
                    break;

                case Keep:
                    fileName = "Keep";
                    break;

                case LH:
                    fileName = "LH";
                    break;

                case MA:
                    fileName = "MA";
                    break;

                case Mail:
                    fileName = "Mail";
                    break;

                case Maps:
                    fileName = "Maps";
                    break;

                case MapsYP:
                    fileName = "MapsYP";
                    break;

                case News:
                    fileName = "News";
                    break;

                case PR:
                    fileName = "PR";
                    break;

                case Profile:
                    fileName = "Profile";
                    break;

                case Reminders:
                    fileName = "Reminders";
                    break;

                case Saved:
                    fileName = "Saved";
                    break;

                case SL:
                    fileName = "SL";
                    break;

                case Tasks:
                    fileName = "Tasks";
                    break;

                case Voice:
                    fileName = "Voice";
                    break;

                case YouTube:
                    fileName = "YouTube";
                    break;

                default:
                    fileName = "NotFound";
                    break;
            }
            
            return new BitmapImage(new Uri("pack://application:,,,/Personal Insight;component/assets/google_products/"+fileName+".png"));
        }


        public static void StartWork(GoogleProductModel googleProductModel, IntroPage_5 page)
        {
            //TODO Maybe check is as an instance of 
            // rather than strings
            string productName = googleProductModel.ProductName;
            switch (productName)
            {
                case ADCS:
                    productObject = new Android_Device_Configuration_Service();
                    ((Android_Device_Configuration_Service) productObject ).GoogleProduct = googleProductModel;
                    ((Android_Device_Configuration_Service) productObject).startWork(page);

                    break;

                case ANL:
                    productObject = new Assistant_Notes_and_Lists();
                    ((Assistant_Notes_and_Lists) productObject).GoogleProduct = googleProductModel;
                    ((Assistant_Notes_and_Lists) productObject).startWork(page);
                    break;

                case Blogger:
                    productObject = new Blogger();
                    ((Blogger)productObject).GoogleProduct = googleProductModel;
                    ((Blogger)productObject).startWork(page);
                    break;

                case Bookmarks:
                    productObject = new Bookmarks();
                    ((Bookmarks)productObject).GoogleProduct = googleProductModel;
                    ((Bookmarks)productObject).startWork(page);
                    break;

                case Calendar:
                    productObject = new Calendar();
                    ((Calendar)productObject).GoogleProduct = googleProductModel;
                    ((Calendar)productObject).startWork(page);
                    break;

                case Chrome:
                    productObject = new Chrome();
                    ((Chrome)productObject).GoogleProduct = googleProductModel;
                    ((Chrome)productObject).startWork(page);
                    break;

                case GPC:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Contacts:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case CP:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case CS:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Drive:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Fit:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GC:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GMB:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPay:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPB:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPGS:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPhotos:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPlusS:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPM:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPMTV:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPS:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GS:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GSM:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GW:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case HA:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Hangouts:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Keep:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case LH:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case MA:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Mail:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Maps:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case MapsYP:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case News:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case PR:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Profile:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Reminders:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Saved:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case SL:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Tasks:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Voice:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case YouTube:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                default:
                    productObject = new Android_Device_Configuration_Service();
                    break;
            }
        }
    }

    
}
