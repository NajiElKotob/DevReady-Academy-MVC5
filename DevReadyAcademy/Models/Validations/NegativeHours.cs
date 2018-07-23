using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models.Validations
{
    public class NegativeHoursNotAllowed : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Ref. https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation

            Course course = (Course)validationContext.ObjectInstance;

            if (course.TotalHours < 0)
            {
                return new ValidationResult("Negative hours not allowed");
            }

            return ValidationResult.Success;
        }
    }
}