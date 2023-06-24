using PrismWpfUI.Core;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
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

            ResourceManager rm = new ResourceManager("PrismWpfUI.Resources.Strings",
                Assembly.GetExecutingAssembly());

            string output = "";
            switch (result.Value)
            {
                case MathTaskResult.Undefined:
                    output = string.Empty;
                    break;
                case MathTaskResult.Correct:
                    output = rm.GetString("Correct");
                    break;
                case MathTaskResult.Incorrect:
                    output = rm.GetString("Wrong");
                    break;
                case MathTaskResult.TimeIsUp:
                    output = rm.GetString("TimesUp");
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
