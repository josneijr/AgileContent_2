using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using AgileContent2.Domains.DataInterpreters;
using AgileContent2.Domains.DataWriters;
using AgileContent2.Entities;
using AgileContent2.Interfaces;

namespace AgileContent2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Número incorreto de parâmetros");
                Console.Read();
            }
            else
            {
                ConvertFile(args[0], args[1]);
            }
        }

        public static void ConvertFile(string sourceUrl, string targetPath)
        {
            IDataInterpreter dataInterpreter = new MinhaCDN();
            IDataReformat dataReformat = new Agora();

            string downloadPath = Path.ChangeExtension(targetPath, "tmp");

            try
            {
                //Primeiro, pegamos o arquivo da origem (download)
                DownloadFile(sourceUrl, downloadPath);

                //Vamos agora abrir o arquivo e deixá-lo em memória
                string fileContent = OpenFileContent(downloadPath);

                //Vamos interpretar o arquivo, pegando todos os eventos que encontrarmos
                List<DataEvent> dataEvents = dataInterpreter.InterpretData(fileContent);

                //E com os eventos, geramos a saída no formato que queremos
                string output = dataReformat.ReformatData(dataEvents);

                //Por último, flush nos dados
                SaveBufferToFile(output, targetPath);
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao converter dados: " + e.Message);
            }
        }

        private static void SaveBufferToFile(string outputContent, string outputPath)
        {
            File.WriteAllText(outputPath, outputContent);
        }

        public static void DownloadFile(string sourceUrl, string outputPath)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(sourceUrl, outputPath);
            }
        } 

        public static string OpenFileContent(string filePath)
        {
            return File.ReadAllText(filePath); ;
        }
    }
}
