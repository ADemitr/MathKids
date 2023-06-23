using PrismWpfUI.Core;
using PrismWpfUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PrismWpfUI.Converters
{
    public class MathTaskResultToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MathTaskResult? result = value as MathTaskResult?;
            if (result == null)
            {
                throw new ArgumentNullException("Value must be of type MathTaskResult");
            }

            string output = "";
            switch (result.Value) 
            {
                case MathTaskResult.Undefined:
                    output = string.Empty;
                    break;
                case MathTaskResult.Correct:
                    output = "Правильно!";
                    break;
                case MathTaskResult.Incorrect:
                    output = "Ошибка!";
                    break;
                case MathTaskResult.TimeIsUp:
                    output = "Время вышло!";
                    break;
                default:
                    throw new ArgumentNullException("Unsupported value of MathTaskResult enum");
            }

            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
