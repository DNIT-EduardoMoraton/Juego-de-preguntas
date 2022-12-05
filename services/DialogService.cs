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
        public DialogService()
        {
        }

        public string SaveJsonPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json Files(*.json)| *.json;";
            if ((bool)saveFileDialog.ShowDialog())
                return saveFileDialog.FileName;
            return null;
        }

        public string GetImagePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.png; *.jpg)| *.bmp; *.png; *.jpg";
            return GetPath(openFileDialog);
        }

        public string GetJsonPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json Files(*.json)| *.json;";
            return GetPath(openFileDialog);
        }

        public string GetPath(OpenFileDialog pfd)
        {
            if ((bool)pfd.ShowDialog())
            {
                return pfd.FileName;
            }
            return null;
        }

        public void Error(string msg)
        {
            MessageBox.Show(msg, "Error en la aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}
