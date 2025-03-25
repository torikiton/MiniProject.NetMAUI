using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace MiniProject.Converters
{
    public class CountToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count)
                return count > 0 ? 200 : 50; // ถ้ามีวิชา ให้สูง 200 ถ้าไม่มีให้เหลือ 50

            return 50; // ค่าพื้นฐาน
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}