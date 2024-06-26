﻿using FTech.Infrastructure.Services.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FTech.Infrastructure.Services.Files
{
    public class FileService : IFileService
    {
        private readonly string MEDIA = "media";
        private readonly string IMAGES = "images";
        private readonly string AVATARS = "avatars";
        private readonly string ROOTPATH;

        public FileService(IWebHostEnvironment env)
        {
            this.ROOTPATH = env.WebRootPath;
        }
        public async Task<bool> DeleteAvatarAsync(string file)
        {
            string path = Path.Combine(ROOTPATH, file);

            if (File.Exists(path))
            {
                await Task.Run(() =>
                {
                    File.Delete(path);
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteImageAsync(string imagePath)
        {
            string path = Path.Combine(ROOTPATH, imagePath);

            if (File.Exists(path))
            {
                await Task.Run(() =>
                {
                    File.Delete(path);
                });
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<string> UploadAvatarAsync(IFormFile file)
        {
            string newImageName = MediaHelper.MakeImageName(file.FileName);
            string subPath = Path.Combine(MEDIA, AVATARS, newImageName);

            string path = Path.Combine(ROOTPATH, subPath);

            FileStream fileStream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fileStream);
            fileStream.Close();

            return subPath;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            string newImageName = MediaHelper.MakeImageName(file.FileName);
            string subPath = Path.Combine(MEDIA, IMAGES, newImageName);

            string path = Path.Combine(ROOTPATH, subPath);

            FileStream fileStream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fileStream);
            fileStream.Close();

            return subPath;
        }
    }
}
