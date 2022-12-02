using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Juego_de_preguntas.services
{
    class DialogService
    {
        public static string GetImagePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.png; *.jpg)| *.bmp; *.png; *.jpg";
            if ((bool)openFileDialog.ShowDialog())
            {
                return openFileDialog.FileName;
            }
            return null;

        }

        public static void Error(string msg)
        {
            MessageBox.Show(msg, "Error en la aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}
