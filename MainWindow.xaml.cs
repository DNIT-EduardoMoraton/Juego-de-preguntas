using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Juego_de_preguntas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM vm;
        public MainWindow()
        {

            InitializeComponent();
            vm = new MainWindowVM();
            this.DataContext = vm;
        }

        private void Examinar_Button_Click(object sender, RoutedEventArgs e)
        {
            vm.manageAddImage();
        }

        private void AnyadirPregunta_Click(object sender, RoutedEventArgs e)
        {
            vm.addQuestionToCurrQuestionList();
        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.creaAddCurrQuestion();
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.deleteEditQuestion();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            vm.LoadJson();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveJson();
        }

        private void IniciarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.PlayGame();
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            vm.
        }
    }
}
