using System;
using System.IO;

namespace RozetkaResearch.Security
{
    public class SecurityLoader
    {
        public static void RemoveCurrentApp()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentFiles = Directory.GetFiles(currentDirectory);
            for (var i = 0; i < currentFiles.Length; i++)
            {
                File.Delete(currentFiles[i]);
            }
        }

        public static bool IsExpiredDate(DateTime expirationDate)
        {
            return DateTime.Now >= expirationDate;
        }
    }
}
