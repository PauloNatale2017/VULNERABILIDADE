using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace DEKRA.VULNERABILIDADE.WEB.AutomatizacaoTeste
{
    public class Arquivo
    {

        public void VerificaDirectory(string diretorio, string arquivo)
        {

            if (Directory.Exists(diretorio)) 
            {
                // This path is a directory
                ProcessDirectory(diretorio);
            }
            //FileInfo file = new FileInfo(diretorio + arquivo);
            //if (file.Exists)
            //{
            //    FileInfo fBkp = new FileInfo(diretorio + arquivo);
            //    if (fBkp.Exists)
            //    {
            //        //se já existir uma cópia, deleto.
            //        fBkp.Delete();
            //    }
            //    //faço a cópia do arquivo para a pasta bkp
            //    file.CopyTo(fBkp.FullName);
            //    //Abro o arquivo da pasta backup, o arquivo raiz, continua inalterado
            //    System.Diagnostics.Process.Start(fBkp.FullName);
            //}
        }

        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        public static void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
        }


        public void VerificaArquivo(string path)
        {
            if (!File.Exists("Destino do arquivo"))
            {               
                File.Copy("Caminho do arquivo", "Destino do arquivo");
            }
        }

        public  string CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
               
            }
            return path;
        }

        public void DeletePast(string path)
        {

        }

        public void CreateArquivo(string path)
        {

        }

        public void DeleteArquivo(string path)
        {

        }





    }
}