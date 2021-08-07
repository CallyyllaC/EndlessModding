using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GenerateXSD
{
    static class Program
    {
        private static string dir = @"D:\Steam Library\steamapps\common\Endless Space 2\Public\Schemas\";
        private static string xsd = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe";
        static void Main(string[] args)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = dir,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false
            };

            string[] files = System.IO.Directory.GetFiles(dir, "*.xsd");

            //File.Copy(xsd, dir);

            Parallel.ForEach(files, i =>
            {
                var item = Path.GetFileName(i);
                Console.WriteLine($"Started converting {item}...");

                var process = new System.Diagnostics.Process();
                process.StartInfo = startInfo;

                process.Start();
                process.StandardInput.WriteLine($"xsd /c {item}");
                process.WaitForExit();

                Console.WriteLine($"Completed converting {item.Replace(".xsd",".cs")}");
            });

            Console.WriteLine($"Completed, press any key to exit");
            Console.ReadKey();
        }
    }
}
