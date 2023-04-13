using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace backend.DTOs
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxNumberOfFilesAttribute : ValidationAttribute
    {
        private readonly int _maxNumberOfFiles;

        public MaxNumberOfFilesAttribute(int maxNumberOfFiles)
        {
            _maxNumberOfFiles = maxNumberOfFiles;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var files = value as IEnumerable<IFormFile>;
            if (files == null)
            {
                return ValidationResult.Success;
            }

            if (files.Count() > _maxNumberOfFiles)
            {
                return new ValidationResult($"You can upload a maximum of {_maxNumberOfFiles} files.");
            }

            return ValidationResult.Success;
        }
    }
}
