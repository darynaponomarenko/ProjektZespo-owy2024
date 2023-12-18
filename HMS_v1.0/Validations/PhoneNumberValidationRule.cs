using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HMS_v1._0.Validations
{
    public class PhoneNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new("^\\+48[1-9]\\d{8}");
            if (!regex.IsMatch(value.ToString()))
            {
                return new ValidationResult(false, "Podaj poprawny numer telefonu!");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
