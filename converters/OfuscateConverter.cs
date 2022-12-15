using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Juego_de_preguntas.converters
{
    class OfuscateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string inWord = (string)value;
            string ofuscatedWord = "";
            Random rnd = new Random();

            for (int i = 0; i < inWord.Length; i++)
            {
                if (rnd.Next(0, 10) >= 4)
                    ofuscatedWord += inWord[i];
                else
                    ofuscatedWord += "*";
            }

            return ofuscatedWord;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
