using System;
using System.Diagnostics;

namespace StreamBox.Helpers {
    public static class ShellHelper
    {
        public static string Bash(this string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");
            
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }

        public static string GetServerIPV4()
        {
            return "ifconfig | grep 'inet ' | grep -v 127.0.0.1|awk 'match($0, /([0-9]+\\.[0-9]+\\.[0-9]+\\.[0-9]+)/) {print substr($0,RSTART,RLENGTH)}'".Bash().Trim();
        }
    }   
}