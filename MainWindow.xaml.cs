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
            SnekType.CoordList.Add(new Coord(14, 10));
            SnekType.RandGoal();                        
            Dispatcher.Invoke(TimerSnek);

        }

        private void CheckCollide() {
            List<Coord> SnekCells = new List<Coord>(SnekType.CoordList);
            Coord LeadCell = SnekCells[0];
            SnekCells.RemoveAt(0);
            foreach (Coord c in SnekCells) {
                if (LeadCell.Row == c.Row && LeadCell.Col == c.Col) {
                    MessageBox.Show("You lose, Dingus!");
                    this.Close();
                }
            }
        }

        private void TimerSnek() {
            DispatcherTimer SnekTimer = new DispatcherTimer();

            SnekTimer.Interval = TimeSpan.FromSeconds(SnekType.Difficulty);

            SnekTimer.Tick += DrawSnek;
            SnekTimer.Start();
        }

        public void DrawSnek(Object sender, EventArgs e) {

            SnekType.MoveSnek();
            List<Coord> CellList = new List<Coord>(SnekType.CoordList);
            

            if (CellList[0].Row == -1 || CellList[0].Row == 21 || CellList[0].Col == -1 || CellList[0].Col == 29) {
                MessageBox.Show("You lose, dingus!");
                this.Close();
                return;
            }

            if (CellList[0].Row == SnekType.GoalCell.Row && CellList[0].Col == SnekType.GoalCell.Col) {
                SnekType.AddCells += 3;
                SnekType.RandGoal();
            }

            MainGrid.Children.Clear();
            CheckCollide();

            foreach (Coord c in CellList) {
                Rectangle x = new Rectangle();
                x.SetValue(Grid.RowProperty, c.Row);
                x.SetValue(Grid.ColumnProperty, c.Col);
                x.Fill = new SolidColorBrush(Colors.Red);
                MainGrid.Children.Add(x);
            }

            Rectangle Goal = new Rectangle();
            Goal.SetValue(Grid.RowProperty, SnekType.GoalCell.Row);
            Goal.SetValue(Grid.ColumnProperty, SnekType.GoalCell.Col);
            Goal.Fill = new SolidColorBrush(Colors.Blue);
            MainGrid.Children.Add(Goal);
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