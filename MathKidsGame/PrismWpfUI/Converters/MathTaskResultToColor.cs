using PrismWpfUI.Core;
using System;
using System.Globalization;
using System.Windows.Data;

namespace PrismWpfUI.Converters
{
    internal class MathTaskResultToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MathTaskResult? correct = value as MathTaskResult?;
            if (correct == null)
            {
                throw new ArgumentNullException("Value must be of type MathTaskResult");
            }

            return correct.Value == MathTaskResult.Correct ? "Green" : "Red";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
