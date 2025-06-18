using System.Globalization;


namespace ListViewMAUI
{
    #region TextConverter
    public class TextConverter : IValueConverter
    {
        public object? Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
		{
			if (value == string.Empty)
			{
				return null;
			}
			return ((string)value!)[0].ToString();
		}

		public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region ColorConverter
    public class ColorConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            Random r = new Random();
            return Color.FromRgb(r.Next(40, 255), r.Next(40, 255), r.Next(40, 255));
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}