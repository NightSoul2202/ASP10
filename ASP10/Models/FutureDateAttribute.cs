using ASP10.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date)
        {
            if (date <= DateTime.Today)
            {
                return new ValidationResult("Дата консультації має бути в майбутньому.");
            }

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("Дата консультації не може потрапляти на вихідні.");
            }

            var instance = (FormInfo)validationContext.ObjectInstance;
            if (instance.Product == "Основи" && date.DayOfWeek == DayOfWeek.Monday)
            {
                return new ValidationResult("Консультація щодо продукту 'Основи' не може проходити по понеділках.");
            }

            return ValidationResult.Success;
        }

        return new ValidationResult("Невірний формат дати.");
    }
}
