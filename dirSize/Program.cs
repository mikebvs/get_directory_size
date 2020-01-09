
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace dirSize
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\" + Environment.UserName + @"\.nuget\packages");
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            dirs = dir.GetDirectories().ToList<DirectoryInfo>();
            foreach(DirectoryInfo item in dirs)
            {
            long size = 0;
                foreach (FileInfo fi in item.GetFiles("*", SearchOption.AllDirectories))
                {
                    size += fi.Length;
                }
                string namePrint = item.Name + " ";
                for(int i = 0; namePrint.Length <= 100; ++i)
                {
                    namePrint += "-";
                }
                Console.WriteLine(String.Format("{0,-100}|{1,-5} KB", namePrint, size/1024/1024));
            }
        }
    }
}
