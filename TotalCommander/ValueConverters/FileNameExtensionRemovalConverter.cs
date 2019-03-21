using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TotalCommander.ValueConverters
{
    class FileNameExtensionRemovalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fileName = value as string;
            int extensionDotIndex = fileName.LastIndexOf('.');
            return fileName.Substring(0, extensionDotIndex);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value}.{parameter}";
        }
    }
}
