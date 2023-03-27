using System;
using System.Globalization;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Libraries.Converters
{
    public class TransactionValueColorConverter : IValueConverter
    {
        public TransactionValueColorConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Transaction transaction = (Transaction)value;
            if (transaction == null)
            {
                return Colors.Black;
            }
            if (transaction.TransactionType == TransactionType.Income)
            {
                return Color.FromArgb("#FF939e5a");
            }
            else
            {
                return Colors.Red;
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

