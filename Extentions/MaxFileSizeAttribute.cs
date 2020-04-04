using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ForumEngine.Extentions
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            this.maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if(file != null)
            {
                if(file.Length > maxFileSize)
                {
                    return new ValidationResult($"Maximum allowed file size is {maxFileSize / (1024 * 1024)} MB");
                }
            }

            return ValidationResult.Success;
        }
    }
}
