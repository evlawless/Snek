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

            Dispatcher.Invoke(SnekTime);
        }


        public char SnekDirection = 's';
        int CurrentRow;
        int CurrentCol;

        public void SnekTime() {
            DispatcherTimer SnekTimer = new DispatcherTimer();

            SnekTimer.Interval = TimeSpan.FromSeconds(.1);

            SnekTimer.Tick += MoveSnek;
            SnekTimer.Start();
        }

        public void MoveSnek(Object source, EventArgs e) {

            CurrentRow = (int)Pixel.GetValue(Grid.RowProperty);
            CurrentCol = (int)Pixel.GetValue(Grid.ColumnProperty);

            switch (SnekDirection) {

                case 's':
                    break;
                case 'u':
                    if (CurrentRow != 0) {
                        Pixel.SetValue(Grid.RowProperty, (CurrentRow - 1));
                    }
                    break;
                case 'd':
                    if (CurrentRow != 20) {
                        Pixel.SetValue(Grid.RowProperty, (CurrentRow + 1));
                    }
                    break;
                case 'l':
                    if (CurrentCol != 0) {
                        Pixel.SetValue(Grid.ColumnProperty, (CurrentCol - 1));
                    }
                    break;
                case 'r':
                    if (CurrentRow != 20) {
                        Pixel.SetValue(Grid.ColumnProperty, (CurrentCol + 1));
                    }
                    break;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {

            switch (e.Key) {

                case Key.Left:
                    SnekDirection = 'l';
                    break;
                case Key.Right:
                    SnekDirection = 'r';
                    break;
                case Key.Up:
                    SnekDirection = 'u';
                    break;
                case Key.Down:
                    SnekDirection = 'd';
                    break;
                case Key.F5:
                    MainWindow M = new MainWindow();
                    M.Show();
                    this.Close();
                    break;
                default:
                    break;


            }


        }


    }
}
