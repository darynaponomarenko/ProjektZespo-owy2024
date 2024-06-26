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
    internal class PeselValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new("^(?!00000000000)(?!11111111111)" +
                                    "(?!22222222222)(?!33333333333)" +
                                    "(?!44444444444)(?!55555555555)" +
                                    "(?!66666666666)(?!77777777777)" +
                                    "(?!88888888888)(?!99999999999)" +
                                    "(?:(?!00000000000)(?!11111111111)" +
                                    "(?!22222222222)(?!33333333333)" +
                                    "(?!44444444444)(?!55555555555)" +
                                    "(?!66666666666)(?!77777777777)" +
                                    "(?!88888888888)(?!99999999999)\\d{11})$");
            if (!regex.IsMatch(value.ToString()))
            {
                return new ValidationResult(false, "Podaj poprawny PESEL!");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
