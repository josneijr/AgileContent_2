using System;
using System.IO;
using System.Net;
using AgileContent2.Domains.DataInterpreters;
using AgileContent2.Domains.DataWriters;
using AgileContent2.Interfaces;

namespace AgileContent2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }

        public static void ConvertFile(string sourceUrl, string targetPath)
        {
            IDataInterpreter dataInterpreter = new MinhaCDN();
            IDataReformat dataReformat = new Agora();

            DownloadFile(sourceUrl, targetPath);
        }

        public static void DownloadFile(string sourceUrl, string outputPath)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(sourceUrl, Path.ChangeExtension(outputPath, "tmp"));
            }
        } 
    }
}
