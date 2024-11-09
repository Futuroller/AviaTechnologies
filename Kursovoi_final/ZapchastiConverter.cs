using Kursovoi_final.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Kursovoi_final
{
    public class ZapchastiConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var zapchastiDlaObslygivania = value as IEnumerable<b_Zapchasti_dla_obslygivania>;
            if (zapchastiDlaObslygivania != null && zapchastiDlaObslygivania.Any())
            {
                return $"Деталь: {zapchastiDlaObslygivania.First().b_Zapchasti.Nazvanie}";
            }
            return "Деталь не указана";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}