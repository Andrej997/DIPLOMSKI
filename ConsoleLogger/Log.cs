using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleLogger
{
    public class Log
    {
        private static readonly string filename = @"C:\Users\andre\Desktop\DIPLOMSKI\ConsoleLogger\log.txt";

        public static void Append(string ms, string fromClass)
        {
            if (!File.Exists(filename))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filename));
            }
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine($"[{DateTime.Now}] : \tmicroservice: {ms}\t\t class: {fromClass}");
            }
        }
    }
}
