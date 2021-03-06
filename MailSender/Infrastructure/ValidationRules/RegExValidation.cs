using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailSender.Infrastructure.ValidationRules
{
    public class RegExValidation : ValidationRule
    {
        private Regex _Regex;

        // ^[^@\s]+@[^@\s]+\.[^@\s]+$

        public string Pattern
        {
            get => _Regex.ToString();
            set => _Regex = string.IsNullOrEmpty(value) ? null : new(value);
        }

        public bool AllowNull { get; set; }

        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo culture)
        {
            //return ValidationResult.ValidResult;
            //return new ValidationResult(true, "");
            //return new ValidationResult(false, "Текст ошибки");

            if (value is null)
                return AllowNull
                    ? ValidationResult.ValidResult
                    : new(false, ErrorMessage ?? "Пустая ссылка");

            if(_Regex is null) return ValidationResult.ValidResult;

            if (value is not string str)
                str = value.ToString();

            return _Regex.IsMatch(str ?? "")
                ? ValidationResult.ValidResult
                : new(false, ErrorMessage ?? $"Строка {str} не удовлетворяет регулярному выражению {Pattern}");
        }
    }
}
