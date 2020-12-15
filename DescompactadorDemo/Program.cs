using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace DescompactadorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Compactador
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            Console.WriteLine("Compactando....");
            string zipPath = @"C:\Users\WellingtonKarl\Desktop\Super.rar";
            string startPath = @"C:\Users\WellingtonKarl\Pictures\Imagens";

            string pathExtract = @"C:\Users\WellingtonKarl\Desktop\imagens";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            stopwatch.Stop();

            Console.WriteLine($"Tempo decorrido Compactando: {stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();

            //Descompactador
            stopwatch.Start();
            Console.WriteLine("Descompactando....");
            if (!pathExtract.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            {
                using (ZipArchive arquive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in arquive.Entries)
                    {
                        if (entry.FullName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                        {
                            if (!Directory.Exists(pathExtract)) Directory.CreateDirectory(pathExtract);
                            entry.ExtractToFile(Path.Combine(pathExtract, entry.FullName));
                        }
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Tempo decorrido Descompatando: {stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
