using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ForumEngine.Data.Images
{
    public class LocalImageStorage : IImageStorage
    {
        private IWebHostEnvironment webHostEnvironment;

        public LocalImageStorage(IWebHostEnvironment environment)
        {
            webHostEnvironment = environment;
        }

        public async Task<string> SaveAsync(IFormFile image)
        {
            var pathFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

            if(!Directory.Exists("images"))
            {
                Directory.CreateDirectory(pathFolder);
            }

            var imageName = Guid.NewGuid().ToString() + "." + Path.GetExtension(image.FileName);
            var imageFilePath = Path.Combine(pathFolder, imageName);
            await image.CopyToAsync(new FileStream(imageFilePath, FileMode.Create));

            return "\\" + Path.Combine("images", imageName);
        }
    }
}
