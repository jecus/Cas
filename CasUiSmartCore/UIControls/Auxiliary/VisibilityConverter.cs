using System;
using System.Windows;
using System.Windows.Data;

namespace CAS.UI.UIControls.Auxiliary
{
    public class AddButtonVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values == null) return false;
            if (values[0] == null || values[1] == null || values[2] == null) return false;
            if (values[0].Equals(double.NaN) || values[1].Equals(double.NaN) || values[2].Equals(double.NaN)) return false;

            double dblHorizontalOffset = 0;
            double dblViewportWidth = 0;
            double dblExtentWidth = 0;

            double.TryParse(values[0].ToString(), out dblHorizontalOffset);
            double.TryParse(values[1].ToString(), out dblViewportWidth);
            double.TryParse(values[2].ToString(), out dblExtentWidth);

            bool fOnFarRight = Math.Round((dblHorizontalOffset + dblViewportWidth), 2) < Math.Round(dblExtentWidth, 2);
            return fOnFarRight ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
