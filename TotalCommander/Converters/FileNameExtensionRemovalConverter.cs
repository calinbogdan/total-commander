using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TotalCommander.Converters
{
    class FileNameExtensionRemovalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fileName = value as string;
            int extensionDotIndex = fileName.LastIndexOf('.');
            return (extensionDotIndex > 0) ? fileName.Substring(0, extensionDotIndex) : fileName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value}.{parameter}";
        }
    }
}
