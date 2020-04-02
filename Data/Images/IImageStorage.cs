﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ForumEngine.Data.Images
{
    public interface IImageStorage
    {
        Task<string> Save(IFormFile image);
    }
}
