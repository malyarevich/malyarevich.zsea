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
using AILabs.BarleyBreak.Core.Interfaces;
using AILabs.BarleyBreak.Core.Models;
using AILabs.BarleyBreak.Core.Services;

namespace AI_Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private State currentState;
        private State requiredState;
        private readonly Field field = Field.CreateEmptyField(9);
        private IHeuristicService heuristicService;
        private ResolvedPath resolvedPath;
        private int currentStepIndex = 1;

        public MainWindow()
        {
            InitializeComponent();
            InitializeStartupState();
        }

        private void InitializeStartupState()
        {
            currentState = new State(new List<int>(9) {1, 2, 3, 4, 5, 6, 7, 8, -1});
            requiredState = new State(new List<int>(9) {1, 2, 3, 4, 5, 6, 7, 8, -1});
            ApplyCurrentState();
            currentState.ApplyTo(field);
            requiredState.ApplyRequiredTo(field);
            SelectHeuristic();
            NextStepButton.IsEnabled = false;
            currentStepIndex = 1;
        }

        private void Cell_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var textBlock = (sender as Border)?.Child as TextBlock;
            if (textBlock != null)
            {
                var selectedCell = currentState.ApplyTo(field).Cells.Find(cell => cell.CurrentValue == Convert.ToInt32(textBlock.Text));
                MoveCell(selectedCell);
            }
        }

        private void MoveCell(Cell selectedCell)
        {
            if (ReferenceEquals(selectedCell, field.EmptyCell.Left) || ReferenceEquals(selectedCell, field.EmptyCell.Top)
                || ReferenceEquals(selectedCell, field.EmptyCell.Right) || ReferenceEquals(selectedCell, field.EmptyCell.Bottom))
            {
                currentState = State.FromField(currentState.ApplyTo(field).MoveTo(selectedCell), currentState);
                ApplyCurrentState();
            }
        }

        private void ApplyCurrentState()
        {
            for (var i = 0; i < BarleyBreakCanvas.Children.Count; i++)
            {
                var child = BarleyBreakCanvas.Children[i];
                var border = child as Border;
                var textBlock = border?.Child as TextBlock;
                if (textBlock != null)
                {
                    textBlock.Text = currentState.Cells[i].ToString();
                    border.Visibility = currentState.Cells[i] < 0 ? Visibility.Hidden : Visibility.Visible;
                }
            }
        }

        private void SelectHeuristic()
        {
            switch (HeuristicComboBox.SelectedIndex)
            {
                case 0: heuristicService = new AbsoluteHeuristicService();
                    break;
                case 1: heuristicService = new ManhattanHeuristicService();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(@"Heuristic with selected index are not exits", nameof(HeuristicComboBox.SelectedIndex));
            }
        }

        private void ResolveButton_OnClick(object sender, RoutedEventArgs e)
        {
            SelectHeuristic();
            currentStepIndex = 1;
            resolvedPath = AStarService.Run(currentState, requiredState, heuristicService, field);
            OpenedStatesTextBlock.Text = $"Opened states: {resolvedPath.OpenedCount}";
            StepsTextBlock.Text = $"Step: 0/{resolvedPath.Path.Count() - 1}";
            NextStepButton.IsEnabled = true;
        }

        private void NextStepButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (currentStepIndex < resolvedPath.Path.Count())
            {
                currentState = resolvedPath.Path.ElementAt(currentStepIndex);
                ApplyCurrentState();
                StepsTextBlock.Text = $"Step: {currentStepIndex}/{resolvedPath.Path.Count() - 1}";
                ++currentStepIndex;
            }
            else
            {
                NextStepButton.IsEnabled = false;
                currentStepIndex = 1;
            }
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            InitializeStartupState();
        }
    }
}
