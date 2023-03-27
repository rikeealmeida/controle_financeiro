using System;
using System.Globalization;

namespace ControleFinanceiro.Libraries.Converters
{
    public class TransactionNameColorConverter : IValueConverter
    {
        public TransactionNameColorConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var random = new Random();
            var color = String.Format("#FF{0:X6}", random.Next(0x1000000));
            return Color.FromArgb(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

