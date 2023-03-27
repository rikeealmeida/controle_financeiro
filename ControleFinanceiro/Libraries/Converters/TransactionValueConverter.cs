using System;
using System.Globalization;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Libraries.Converters
{
    public class TransactionValueConverter : IValueConverter
    {
        public TransactionValueConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Transaction transaction = (Transaction)value;
            if (transaction == null)
            {
                return "";
            }
            if (transaction.TransactionType == TransactionType.Income)
            {
                return transaction.Value.ToString("C");
            }
            else
            {
                return $"- {transaction.Value.ToString("C")}";
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

