﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Peasy.Attributes
{
    /// <summary>
    /// Validates that non-zero values are supplied for numeric types (int, long, decimal, etc.) and non-default values for dates and guids.
    /// </summary>
    /// <remarks>The base <see cref="RequiredAttribute"/> validation takes priority and is invoked first, followed by the non-zero and non-default validation.</remarks>
    public class PeasyRequiredAttribute : RequiredAttribute
    {
        /// <inheritdoc cref="ValidationAttribute.IsValid"/>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var baseResult = base.IsValid(value, validationContext);
            if (baseResult != null)
            {
                return baseResult;
            }

            var errorMessage = $"The {validationContext.DisplayName} field is required.";
            var validationResult = new ValidationResult(errorMessage, new string[] { validationContext.DisplayName });

            switch (value)
            {
                case null:
                    return validationResult;
                case Guid _ when Guid.Parse(value.ToString()) == Guid.Empty:
                    return validationResult;
            }

            var incoming = value.ToString();

            if (decimal.TryParse(incoming, out var val) && val == 0)
            {
                return validationResult;
            }

            if (DateTime.TryParse(incoming, out var date) && date == DateTime.MinValue)
            {
                return validationResult;
            }

            return ValidationResult.Success;
        }
    }
}
