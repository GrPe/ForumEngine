using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ForumEngine.Data.Images
{
    public class AzureImageStorage : IImageStorage
    {
        IConfiguration configuration;

        public AzureImageStorage(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> Save(IFormFile image)
        {
            BlobServiceClient client = new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage"));
            BlobContainerClient containerClient = client.GetBlobContainerClient("images");
            var id = Guid.NewGuid().ToString();

            BlobClient blobClient = containerClient.GetBlobClient(id + "." + image.FileName.Split('.')[^1]);

            await blobClient.UploadAsync(image.OpenReadStream());

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
