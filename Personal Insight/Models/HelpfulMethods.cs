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

        public static long DirSize(DirectoryInfo d)
        {
            try

            {
                long size = 0;
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
                return 0;
            }
        }
    }
}
