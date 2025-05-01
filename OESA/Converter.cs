using System;
using System.Globalization;
using Microsoft.Maui.Controls;
namespace OESA;

// I absolutely hate this but if i dont have this SelectedAnswer will only be considered as Null instead of True/False

public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedAnswer = value as string;
            var option = parameter as string;

            if (string.IsNullOrEmpty(selectedAnswer))
            {
                return false;  // Ensure no option is selected if no answer is provided otherwise it will default to the first option, really annoying
            }

        return selectedAnswer == option;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }