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
using System.Windows.Shapes;
using SnekLib;

namespace Snek {
    /// <summary>
    /// Interaction logic for DifficultyWindow.xaml
    /// </summary>
    public partial class DifficultyWindow : Window {
        public DifficultyWindow() {
            InitializeComponent();
        }

        private void StartGame(double d) {
            SnekType.Difficulty = d;
            MainWindow Main = new MainWindow();
            Main.Show();
            this.Close();
        }

        private void ButtonEasy_Click(object sender, RoutedEventArgs e) {
            StartGame(0.15);
        }

        private void ButtonMedium_Click(object sender, RoutedEventArgs e) {
            StartGame(0.1);
        }

        private void ButtonHard_Click(object sender, RoutedEventArgs e) {
            StartGame(0.05);
        }
    }
}
