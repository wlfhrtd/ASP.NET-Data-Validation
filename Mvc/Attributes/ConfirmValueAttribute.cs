using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;


namespace Mvc.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfirmValueAttribute : ValidationAttribute, IClientModelValidator
    {
        private object expectedValue;


        public ConfirmValueAttribute(object expectedValue)
        {
            this.expectedValue = expectedValue;
        }


        public override bool IsValid(object value)
            => value == null ? throw new ArgumentNullException("value") : Equals(value, expectedValue);

        
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-confirmvalue", ErrorMessage);
            context.Attributes.Add("data-val-confirmvalue-expectedvalue", expectedValue.ToString());
        }
    }
}
