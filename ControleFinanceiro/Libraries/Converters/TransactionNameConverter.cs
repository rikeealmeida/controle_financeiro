using System;
using System.Globalization;

namespace ControleFinanceiro.Libraries.Converters
{
    public class TransactionNameConverter : IValueConverter
    {
        public TransactionNameConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String transactionName = (String)value;

            return transactionName.ToUpper()[0];

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

