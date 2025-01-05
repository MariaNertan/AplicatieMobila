using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using AplicatieMobila.Models;

namespace AplicatieMobila.Converters
{
    public class CartItemAndQuantityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CartItem cartItem && int.TryParse(parameter?.ToString(), out int quantityChange))
            {
                return Tuple.Create(cartItem, quantityChange);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
