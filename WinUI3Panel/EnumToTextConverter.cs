using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI3Panel;

public class EnumToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
        => value.ToString();

    public object ConvertBack(object value, Type targetType, object parameter, string language)
        => throw new NotImplementedException();

}
