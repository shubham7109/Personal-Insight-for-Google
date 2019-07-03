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
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case ANL:
                    fileName = "ANL";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Blogger:
                    fileName = "Blogger";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Bookmarks:
                    fileName = "Bookmarks";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Calendar:
                    fileName = "Calendar";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Chrome:
                    fileName = "Chrome";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPC:
                    fileName = "GPC";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Contacts:
                    fileName = "Contacts";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case CP:
                    fileName = "CP";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case CS:
                    fileName = "CS";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Drive:
                    fileName = "Drive";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Fit:
                    fileName = "Fit";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GC:
                    fileName = "GC";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GMB:
                    fileName = "GMB";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPay:
                    fileName = "GPay";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPB:
                    fileName = "GPB";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPGS:
                    fileName = "GPGS";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPhotos:
                    fileName = "GPhotos";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPlusS:
                    fileName = "GPlusS";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPM:
                    fileName = "GPM";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPMTV:
                    fileName = "GPMTV";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GPS:
                    fileName = "GPS";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GS:
                    fileName = "GS";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GSM:
                    fileName = "GSM";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case GW:
                    fileName = "GW";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case HA:
                    fileName = "HA";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Hangouts:
                    fileName = "Hangouts";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Keep:
                    fileName = "Keep";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case LH:
                    fileName = "LH";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case MA:
                    fileName = "MA";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Mail:
                    fileName = "Mail";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Maps:
                    fileName = "Maps";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case MapsYP:
                    fileName = "MapsYP";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case News:
                    fileName = "News";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case PR:
                    fileName = "PR";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Profile:
                    fileName = "Profile";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Reminders:
                    fileName = "Reminders";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Saved:
                    fileName = "Saved";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case SL:
                    fileName = "SL";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Tasks:
                    fileName = "Tasks";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Voice:
                    fileName = "Voice";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case YouTube:
                    fileName = "YouTube";
                    productObject = new Android_Device_Configuration_Service();
                    break;

                default:
                    fileName = "NotFound";
                    productObject = new Android_Device_Configuration_Service();
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
                    ((Android_Device_Configuration_Service) productObject ).GoogleProduct = googleProductModel;
                    ((Android_Device_Configuration_Service)productObject).startWork(page);

                    break;

                case ANL:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Blogger:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Bookmarks:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Calendar:
                    productObject = new Android_Device_Configuration_Service();
                    break;

                case Chrome:
                    productObject = new Android_Device_Configuration_Service();
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
