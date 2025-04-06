using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Ecom.core.Services;
using System;

namespace Ecom.infrastructure.Repositries.Service
{
    public class ImageManagementService : IImagemanagementService
    {
        private readonly IFileProvider _fileProvider;
        public ImageManagementService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            var saveImageSrc = new List<string>();
            var imageDirectory = Path.Combine("wwwroot", "Images", src);

            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            foreach (var item in files)
            {
                if (item.Length > 0)


                {
                   
                    var imageName = $"{Guid.NewGuid()}{Path.GetExtension(item.FileName)}";
                    var imageSrc = $"/Images/{src}/{imageName}";
                    var root = Path.Combine(imageDirectory, imageName);








                    try
                    {
                        using (var stream = new FileStream(root, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                        }
                        saveImageSrc.Add(imageSrc);
                    }
                    catch (Exception ex)
                    {
                       
                        Console.WriteLine($"Error saving image: {ex.Message}");
                    }
                }
            }

            return saveImageSrc;
        }

        public Task DeleteImageAsync(string src)
        {
            if (File.Exists(src))
            {
                File.Delete(src);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
