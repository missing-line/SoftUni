namespace BillsPaymentSystem.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class ExpirationDateAttribute : ValidationAttribute
    {       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currDateTime = DateTime.Now;

            if (currDateTime > (DateTime)value)
            {
                return new ValidationResult("Card is expired");
            }

            return ValidationResult.Success;
        }
    }
}
