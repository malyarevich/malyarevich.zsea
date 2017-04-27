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
using AILabs.TicTacToe.Core.Implementations;
using AILabs.TicTacToe.Core.Interfaces;
using AILabs.TicTacToe.Core.Models;

namespace AI_Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ITicTacToeService ticTacToeService;
        private IHeuristicService heuristicService;

        private Field currentField = new Field();

        private CellType player;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RestartButton_OnClick(object sender, RoutedEventArgs e)
        {
            var winCount = Convert.ToInt32(WinCountTextBox.Text);
            var size = Convert.ToInt32(SizeTextBox.Text);
            var depth = Convert.ToInt32(DepthTextBox.Text);

            player = PlayerComboBox.SelectedIndex == 0 ? CellType.Cross : CellType.Nought;
            heuristicService = new SmartHeuristicService(winCount, CellType.Cross);
            ticTacToeService = new TicTacToeService(heuristicService, winCount, depth);

            CreateField();
            currentField = new Field(size);
            if (player == CellType.Nought)
            {
                currentField = ticTacToeService.AlphaBeta(currentField, int.MinValue + 1, int.MaxValue - 1, depth, player);
                UpdateField();
            }
        }

        private void CreateField()
        {
            var depth = Convert.ToInt32(DepthTextBox.Text);
            TicTacToeStackPanel.Children.Clear();
            var size = Convert.ToInt32(SizeTextBox.Text);
            for (var i = 0; i < size; ++i)
            {
                var stackPanel = new StackPanel() {Orientation = Orientation.Horizontal};
                TicTacToeStackPanel.Children.Add(stackPanel);
                for (var j = 0; j < size; ++j)
                {
                    var button = new Button() {Width = 50, Height = 50, Margin = new Thickness(5), BorderThickness = new Thickness(2)};
                    var row = i;
                    var column = j;
                    button.Click += (sender, args) =>
                                    {
                                        var clickedButton = sender as Button;
                                        if (clickedButton == null || !string.IsNullOrWhiteSpace(clickedButton.Content?.ToString()) || currentField.Winner != CellType.Empty)
                                            return;
                                        clickedButton.Content = player == CellType.Cross ? "X" : "0";
                                        currentField = currentField.ChangeCell(row, column, player);
                                        currentField = ticTacToeService.AlphaBeta(currentField, int.MinValue, int.MaxValue, depth, player);
                                        UpdateField();
                                    };
                    stackPanel.Children.Add(button);
                }
            }
        }

        private void UpdateField()
        {
            for (var i = 0; i < currentField.Size; ++i)
            {
                for (var j = 0; j < currentField.Size; ++j)
                {
                    var button = (TicTacToeStackPanel.Children[i] as StackPanel)?.Children[j] as Button;
                    if (button == null)
                        continue;
                    switch (currentField.Cells[i, j])
                    {
                        case CellType.Cross:
                            button.Content = "X";
                            break;
                        case CellType.Nought:
                            button.Content = "0";
                            break;
                        case CellType.Empty:
                            button.Content = "";
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    if (currentField.Winner != CellType.Empty)
                    {
                        if (currentField.WinLine.Any(pair => pair.Key == i && pair.Value == j))
                            button.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                }
            }
            if (currentField.Winner != CellType.Empty)
                ResultTextBlock.Text = currentField.Winner == player ? "You won :)" : "You lost :(";
            else if (currentField.IsFullField())
                ResultTextBlock.Text = "Draw :|";
        }
    }
}
