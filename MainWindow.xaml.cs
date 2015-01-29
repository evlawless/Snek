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
using System.Windows.Threading;
using SnekLib;

namespace Snek {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            SnekType.Direction = 's';

            Dispatcher.Invoke(TimerSnek);

        }

        private void TimerSnek() {
            DispatcherTimer SnekTimer = new DispatcherTimer();

            SnekTimer.Interval = TimeSpan.FromSeconds(SnekType.Difficulty);

            SnekTimer.Tick += MoveSnek;
            SnekTimer.Start();
        }

        private void MoveSnek(Object source, EventArgs e) {
            int CurrentRow = (int)Pixel.GetValue(Grid.RowProperty);
            int CurrentCol = (int)Pixel.GetValue(Grid.ColumnProperty);

            switch (SnekType.Direction) {

                case 's':
                    break;
                case 'u':
                    if (CurrentRow != 0) {
                        Pixel.SetValue(Grid.RowProperty, (CurrentRow - 1));
                    }
                    else {
                        MessageBox.Show("You failed!", "Great Job Idiot", MessageBoxButton.OK);
                        this.Close();
                    }
                    break;
                case 'd':
                    if (CurrentRow != 21) {
                        Pixel.SetValue(Grid.RowProperty, (CurrentRow + 1));
                    }
                    else {
                        MessageBox.Show("You failed!", "Great Job Idiot", MessageBoxButton.OK);
                        this.Close();
                    }
                    break;
                case 'l':
                    if (CurrentCol != 0) {
                        Pixel.SetValue(Grid.ColumnProperty, (CurrentCol - 1));
                    }
                    else {
                        MessageBox.Show("You failed!", "Great Job Idiot", MessageBoxButton.OK);
                        this.Close();
                    }
                    break;
                case 'r':
                    if (CurrentCol != 29) {
                        Pixel.SetValue(Grid.ColumnProperty, (CurrentCol + 1));
                    }
                    else {
                        MessageBox.Show("You failed!","Great Job Idiot",MessageBoxButton.OK);
                        this.Close();
                    }
                    break;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            switch (e.Key) {

                case Key.Left:
                    if (SnekType.Direction != 'r') {
                        SnekType.Direction = 'l';
                    }
                    break;
                case Key.Right:
                    if (SnekType.Direction != 'l') {
                        SnekType.Direction = 'r';
                    }
                    break;
                case Key.Up:
                    if (SnekType.Direction != 'd') {
                        SnekType.Direction = 'u';
                    }
                    break;
                case Key.Down:
                    if (SnekType.Direction != 'u') {
                        SnekType.Direction = 'd';
                    }
                    break;
                default:
                    break;


            }
        }
    }
}