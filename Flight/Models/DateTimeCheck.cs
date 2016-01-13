using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Flights.Validations
{
    public class DateTimeCheck:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();

                if (Regex.IsMatch(email, @"(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]", RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Proszę wprowadzić datę w formacie hh:mm");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " jest wymagana");
            }
        }
    }
}