using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Flights.Validations
{
    public class DateTimeCheck:ValidationAttribute
    {
        public static ValidationResult TimeValidation(object value, ValidationContext validationContext)
        {
            DateTime dt;
            if (DateTime.TryParseExact((string)value, new[] { "hh:mm tt", "h:mm tt" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                return ValidationResult.Success;
            else
                return new ValidationResult("Correct time formats: 01:00 AM or 1:00 AM");
        }
    }
}