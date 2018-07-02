using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace RozetkaResearch.Security
{
    public class SecurityLoader
    {
        private const string AppName = "RozetkaResearch.exe";

        private const string BatName = "RozetkaResearch.bat";

        public static void RemoveCurrentApp()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentFiles = Directory.GetFiles(currentDirectory);

            var batTemplate = $@"@echo off\n
                :loop\n
                {string.Join("\n", currentFiles.Select(fname => $"del \"{fname}\""))}\n
                del %0";

            StreamWriter file = new StreamWriter(BatName);
            file.Write(batTemplate);
            file.Close();

            Process batCall = new Process();
            batCall.StartInfo.FileName = BatName;
            batCall.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            batCall.StartInfo.UseShellExecute = true;
            batCall.Start();
        }

        public static bool IsExpiredDate(DateTime expirationDate)
        {
            return DateTime.Now >= expirationDate;
        }
    }
}
