using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace BlazorApp.Validation
{
  public class DynamicContactValidationAttribute : ValidationAttribute
  {
    private readonly string _parentFieldName;
    private readonly string _fieldType;
    private readonly string[] _validationTypes;

    public DynamicContactValidationAttribute(string parentFieldName, string fieldType, string[] validationTypes)
    {
      _parentFieldName = parentFieldName;
      _fieldType = fieldType;
      _validationTypes = validationTypes;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (validationContext.ObjectInstance != null)
      {
        var parentFieldValueObject = validationContext.ObjectInstance.GetType()
            .GetProperty(_parentFieldName)?.GetValue(validationContext.ObjectInstance, null);
        string parentFieldValue = parentFieldValueObject != null ? parentFieldValueObject.ToString() : string.Empty;

        string currentFieldValue = value != null ? value.ToString() : string.Empty;

        if (!string.IsNullOrEmpty(parentFieldValue) && parentFieldValue.ToLower() == _fieldType.ToLower())
        {
          if (string.IsNullOrEmpty(currentFieldValue) &&
              _validationTypes.Any(_ => _.ToLower() == "required"))
          {
            return new ValidationResult($"{validationContext.DisplayName} is required", new[] { validationContext.MemberName });
          }
          else if (_validationTypes.Any(_ => _.ToLower() == "email"))
          {
            bool isEmail = Regex.IsMatch(currentFieldValue, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
              return new ValidationResult($"{validationContext.DisplayName} is not a valid email", new[] { validationContext.MemberName });
            }
          }

          else if (_validationTypes.Any(_ => _.ToLower() == "password"))
          {
            if (string.IsNullOrEmpty(currentFieldValue) &&
                _validationTypes.Any(_ => _.ToLower() == "required"))
            {
              return new ValidationResult($"{validationContext.DisplayName} is required", new[] { validationContext.MemberName });
            }
            else
            {
              if (!string.IsNullOrEmpty(currentFieldValue))
              {
                // Validate password rules
                if (currentFieldValue.Length < 6 || currentFieldValue.Length > 10)
                {
                  return new ValidationResult($"Password must be between 6 and 10 characters long", new[] { validationContext.MemberName });
                }

                bool hasDigit = currentFieldValue.Any(char.IsDigit);
                bool hasLower = currentFieldValue.Any(char.IsLower);
                bool hasUpper = currentFieldValue.Any(char.IsUpper);

                if (!hasDigit || !hasLower || !hasUpper)
                {
                  return new ValidationResult($"Password must contain at least one digit, one lowercase letter, and one uppercase letter", new[] { validationContext.MemberName });
                }
              }
            }
          }
        }
      }

      return ValidationResult.Success;
    }
  }
}
