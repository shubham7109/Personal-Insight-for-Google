using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Personal_Insight.Models
{
    class HelpfulMethods
    {
        public HelpfulMethods()
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

        }

        public static double DirSize(DirectoryInfo d)
        {
            double size = 0;
            try
            {
                // Add file sizes.
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
                return size;
            }
            catch(Exception e)
            {
                //Console.WriteLine("ERROR: {0} Exception caught.", e);
                return size;
            }
        }

        public static Tuple<double, string> ByteToString(double len)
        {
            string[] sizes = { "Bytes", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            //string result = String.Format("{0:0.##} {1}", len, sizes[order]);



            return Tuple.Create(len,sizes[order]);
        }
    }
}
