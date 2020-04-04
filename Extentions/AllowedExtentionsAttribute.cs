using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace ForumEngine.Extentions
{
    public class AllowedExtentionsAttribute : ValidationAttribute
    {
        private readonly string[] extentions;

        public AllowedExtentionsAttribute(string[] extentions)
        {
            this.extentions = extentions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var file = value as IFormFile;

            if(file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                if (!extentions.Contains(extention.ToLower()))
                {
                    return new ValidationResult($"This photo extention is not allowed");
                }
            }

            return ValidationResult.Success;
        }
    }
}
