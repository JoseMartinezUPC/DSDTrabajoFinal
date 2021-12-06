using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Helper
{
    public class NumericAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                decimal val;
                var isNumeric = decimal.TryParse(value.ToString(), out val);

                if (!isNumeric)
                {
                    return new ValidationResult("Debe ingresar un valor numérico");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class RequiredNotEmptyAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string) return string.IsNullOrEmpty((string)value);

            return base.IsValid(value);
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowExtensionsAttribute : ValidationAttribute
    {
        public string Extensions { get; set; } = "xlsx";
        public override bool IsValid(object value)
        {
            IFormFile file = value as IFormFile;
            bool isValid = true;

            List<string> allowedExtensions = this.Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();


            if (file != null)
            {
                var fileName = file.FileName;

                isValid = allowedExtensions.Any(y => fileName.EndsWith(y));
            }

            return isValid;
        }
    }
}
