using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models.Validations
{
    public class NegativeValuesNotAllowed: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Ref. https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation

            switch (validationContext.ObjectInstance.GetType().Name.ToLower())
            {
                case "course":
                    Course course = (Course)validationContext.ObjectInstance;

                    if (course.TotalHours < 0)
                    {
                        return new ValidationResult("Negative hours not allowed");
                    }

                    break;

                case "enrollment":
                    Enrollment enrollment = (Enrollment)validationContext.ObjectInstance;

                    if (enrollment.Grade < 0)
                    {
                        return new ValidationResult("Negative grade not allowed");
                    }
                    break;

                default:
                    break;
            }
            

            return ValidationResult.Success;
        }
    }
}