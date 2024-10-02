using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace C42_G01_MVC01_Demo.PL.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string FolderName) 
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\", FolderName);
            string FileName = $"{Guid.NewGuid()}{file.FileName}";
            string FilePath = Path.Combine(FolderPath, FileName);
            using var FS = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(FS);
            return FileName;
        }
        public static void RemoveFile(string FileName, string FolderName) 
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\", FolderName);
            string FilePath = Path.Combine(FolderPath, FileName);
            if (File.Exists(FilePath))
            { 
                File.Delete(FilePath);
            }
        }
    }
}
