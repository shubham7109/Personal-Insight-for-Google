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

    }

    
}
