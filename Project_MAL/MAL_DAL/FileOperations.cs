using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAL_DAL
{
    class FileOperations
    {
        /*
         Voor alle fouten te loggen en deze in een bestand te zetten.
         */

        public static void Foutloggen(Exception fout)
        {
            using (StreamWriter writer = new StreamWriter("foutenbestand.txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                writer.WriteLine(fout.Message);
                writer.WriteLine(fout.StackTrace);
                writer.WriteLine(new string('-', 80));
                writer.WriteLine();
            }
        }
    }
}
