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
using AILabs.Packer.Core.Interfaces;
using AILabs.Packer.Core.Models;
using AILabs.Packer.Core.Services;

namespace AILabs_Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Box> Boxes { get; set; } = new List<Box>();

        public Position CarPosition = new Position(0,0);

        private IPackerService packerService;

        public MainWindow()
        {
            InitializeComponent();
            packerService = SelectPackerService(MethodComboBox.SelectedIndex);
        }

        private IPackerService SelectPackerService(int index)
        {
            switch (index)
            {
                case 0:
                    return new BruteForcePackerService();
                case 1:
                    return new HeuristicPackerService();
                default:
                    return new BruteForcePackerService();
            }
        }

        private void RebuildButton_OnClick(object sender, RoutedEventArgs e)
        {
            Boxes = GenerateBoxes(Convert.ToInt32(BoxesCountTextBox.Text), (int) DrawingCanvas.Width, (int) DrawingCanvas.Height, 10);
            CarPosition = new Position(Convert.ToInt32(CarXPositionTextBox.Text), Convert.ToInt32(CarYPositionTextBox.Text));
            DrawingCanvas.Children.Clear();
            foreach (var box in Boxes)
            {
                DrawingCanvas.Children.Add(CreateBoxEllipse(box.Position.X, box.Position.Y, new SolidColorBrush(Colors.Green)));
            }
            DrawingCanvas.Children.Add(CreateCarRectangle(CarPosition.X, CarPosition.Y, new SolidColorBrush(Colors.Brown)));
        }

        private Ellipse CreateBoxEllipse(int x, int y, Brush brush)
        {
            var ellipse = new Ellipse() {Width = 10, Height = 10, Fill = brush};
            Canvas.SetTop(ellipse, y);
            Canvas.SetLeft(ellipse, x);
            return ellipse;
        }

        private Rectangle CreateCarRectangle(int x, int y, Brush brush)
        {
            var rectangle = new Rectangle() { Width = 10, Height = 10, Fill = brush };
            Canvas.SetTop(rectangle, y);
            Canvas.SetLeft(rectangle, x);
            return rectangle;
        }

        private static List<Box> GenerateBoxes(int count, int width, int height, int maxWeight)
        {
            var list = new List<Box>(count);
            var random = new Random();
            for (var i = 0; i < count; ++i)
            {
                list.Add(new Box(new Position(random.Next(width - 10), random.Next(height - 10)), random.Next(maxWeight)));
            }
            return list;
        }

        private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var line in DrawingCanvas.Children.OfType<Line>().ToArray())
            {
                DrawingCanvas.Children.Remove(line);
            }

            packerService = SelectPackerService(MethodComboBox.SelectedIndex);

            var result = packerService.Run(Boxes, CarPosition);

            JobTextBlock.Text = $"Spent work: {result.Job.ToString("F")}";

            foreach (var box in Boxes.Where(item => item != result.CenterBox))
            {
                DrawingCanvas.Children.Add(CreateLine(box.Position, result.CenterBox.Position, new SolidColorBrush(Colors.Aqua)));
            }
            DrawingCanvas.Children.Add(CreateLine(result.FirstBox.Position, CarPosition, new SolidColorBrush(Colors.Aqua)));
        }

        private static Line CreateLine(Position boxPosition, Position centerBoxPosition, Brush brush)
        {
            return new Line()
                   {
                       X1 = boxPosition.X + 5, Y1 = boxPosition.Y + 5, X2 = centerBoxPosition.X + 5,
                       Y2 = centerBoxPosition.Y + 5, Stroke = brush, Fill = brush, StrokeThickness = 1, Visibility = Visibility.Visible, Opacity = 0.5
                   };
        }
    }
}
