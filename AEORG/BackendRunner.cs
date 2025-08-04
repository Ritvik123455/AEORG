using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEORG
{
    public class BackendRunner
    { 
        public static string RunTool(string exePath, string inputFilePath)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = $"\"{inputFilePath}\"",
                UseShellExecute = false ,
                RedirectStandardOutput = true ,
                RedirectStandardError = true ,
                CreateNoWindow = true 
            };

            using var process = Process.Start(startInfo);
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            return string.IsNullOrEmpty(error) ?  output : error;
        }
    }
}
