namespace BillsPaymentSystem.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string targetProperty;
        public XorAttribute(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            Object targetPropValue = validationContext
                .ObjectType
                .GetProperty(this.targetProperty)
                .GetValue(validationContext.ObjectInstance);

            if ((value == null && targetProperty == null) ||
                (value != null && targetProperty != null)
                )
            {
                return new ValidationResult("ERROR!!!");
            }

            return ValidationResult.Success;
        }
    }
}
