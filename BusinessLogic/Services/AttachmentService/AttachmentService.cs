﻿using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        private List<string> allowedExtensions = [".png", ".jpg", ".jpeg"];
        private const int maxSize = 2097152; //1024*1024*2 2MB
        public string? Upload(IFormFile file, string folderName)
        {
            if (file == null || string.IsNullOrEmpty(folderName))
                return null;
            // 1. Check Extension
            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension))
                return null;
            // 2. Check Size 
            if (file.Length == 0 || file.Length > maxSize)
                return null;
            // 3. Get Located Folder Path
            //var folderPath =$"{Directory.GetCurrentDirectory()}\\wwwroot\\Files\\{folderName}";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            // 4. Make Attachment Name Unique -- GUID
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            // 5. Get File Path
            var filePath = Path.Combine(folderPath, fileName);
            // 6. Create File Stream To Copy File[Unmanaged]
            using var fs = new FileStream(filePath, FileMode.Create);
            // 7. Use Stream To Copy File 
            //File.Create(filePath);
            file.CopyTo(fs);
            // 8. Return FileName To Store In Database 
            return fileName;
        }
        public bool Delete(string filePath)
        {
            // 1.Get File Path
            // 2.Check if File Exists Or Not If Exists Remove It
            if (!File.Exists(filePath))
                return false;
            else
            {
                File.Delete(filePath);
                return true;
            }
        }
    }
}
