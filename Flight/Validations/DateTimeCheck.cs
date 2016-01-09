using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flights.Validations
{
    public class DateTimeCheck
    {
        public static IEnumerable<ValidationResult> dateValidation(DateTime dateTime, ValidationContext validationContext)
        {       
            DateTime minDate = DateTime.Parse("01/01/2000");
            DateTime maxDate = DateTime.Parse("01/01/2020");


            if (dateTime>=minDate && dateTime <= maxDate)
                yield return new ValidationResult("Data musi być z zakresu 01/01/2000 - 01/01/2020", new[] { "Date1" });

            else yield return ValidationResult.Success;


        }

    }
}