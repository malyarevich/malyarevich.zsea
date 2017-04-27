using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AILabs.Utils.Models.Graph;
using AILabs.Utils.Models.Graph.Services;
using HelixToolkit.Wpf;

namespace AI_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private Point3D pointA;
        private Point3D pointB;
        private Point3D pointC;
        private Point3D pointH;
        private Point3D startPoint;
        private Point3D endPoint;

        private Storyboard movingSphereStoryboard = new Storyboard();

        private Graph graph;

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            Rebuild3DModel();
        }

        #endregion

        #region Methods

        private static SphereVisual3D CreateSphereVisual3D(Vertex point)
        {
            return new SphereVisual3D()
                   {
                       Radius = 10,
                       Center = Point3DToWpfPoint3D(point.Position)
                   };
        }

        private static SphereVisual3D CreateSphereVisual3D(Vertex point, Brush brush)
        {
            return new SphereVisual3D()
            {
                Radius = 10,
                Center = Point3DToWpfPoint3D(point.Position),
                Material = new DiffuseMaterial(brush)
            };
        }

        private static Point3D Point3DToWpfPoint3D(AILabs.Utils.Models.Base.Point3D point)
    {
        return new Point3D(point.X, point.Y, point.Z);
    }

        private void RebuildButton_OnClick(object sender, RoutedEventArgs e)
        {
            Rebuild3DModel();
        }

        private void Rebuild3DModel()
        {
            BFSResult.Visibility = Visibility.Collapsed;
            DFSResult.Visibility = Visibility.Collapsed;
            AStarResult.Visibility = Visibility.Collapsed;
            BFSSpeedResult.Visibility = Visibility.Collapsed;
            DFSSpeedResult.Visibility = Visibility.Collapsed;
            AStarSpeedResult.Visibility = Visibility.Collapsed;

            pointA.X = VertexACoordX.Value.Value;
            pointB.Y = VertexBCoordY.Value.Value;
            pointC.Y = VertexCCoordY.Value.Value;
            pointH.Z = VertexHCoordZ.Value.Value;

            PathLinesVisual3D.Points = new List<Point3D>();

            LinesVisual3D.Points = new List<Point3D>(12)
                                   {
                                       pointB, pointA,
                                       pointB, pointC,
                                       pointC, pointA,
                                       pointA, pointH,
                                       pointB, pointH,
                                       pointC, pointH
                                   };


            VertexA.Center = pointA;
            VertexB.Center = pointB;
            VertexC.Center = pointC;
            VertexH.Center = pointH;


            startPoint.X = StartPointCoordX.Value.Value;
            startPoint.Y = StartPointCoordY.Value.Value;
            StartPoint.Center = startPoint;

            endPoint.X = EndPointCoordX.Value.Value;
            endPoint.Y = EndPointCoordY.Value.Value;
            EndPoint.Center = endPoint;


            MeshGeometry3D.Positions = new Point3DCollection(4)
                                       {
                                           pointA,
                                           pointB,
                                           pointC,
                                           pointH
                                       };


            var presetPoints = new List<SphereVisual3D> {VertexA, VertexB, VertexC, VertexH, StartPoint, EndPoint};
            var tempPoints =
                HelixViewport3D.Children.Where(visual => visual is SphereVisual3D && presetPoints.All(item => !ReferenceEquals(item, visual))).ToArray();
            foreach (var visual in tempPoints)
            {
                HelixViewport3D.Children.Remove(visual);
            }


            var pointsCount = (int) PointsCount.Value.Value;
            var stepBA = CalculateStep(pointB, pointA, pointsCount);
            var stepHA = CalculateStep(pointH, pointA, pointsCount);
            var stepCA = CalculateStep(pointC, pointA, pointsCount);

            var pointsBA = GetEdgePoints(pointB, stepBA, pointsCount);
            foreach (var point in pointsBA)
            {
                HelixViewport3D.Children.Add(CreateSphereVisual3D(point));
            }
            var pointsHA = GetEdgePoints(pointH, stepHA, pointsCount);
            foreach (var point in pointsHA)
            {
                HelixViewport3D.Children.Add(CreateSphereVisual3D(point));
            }
            var pointsCA = GetEdgePoints(pointC, stepCA, pointsCount);
            foreach (var point in pointsCA)
            {
                HelixViewport3D.Children.Add(CreateSphereVisual3D(point));
            }
            graph = BuildGraph(new Vertex(startPoint.X, startPoint.Y, startPoint.Z), new Vertex(endPoint.X, endPoint.Y, endPoint.Z), pointsBA,
                               pointsHA, pointsCA);
        }

        private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            List<Vertex> result;
            var basicSpeed = SpeedValue.Value.Value;
            switch (((TextBlock)AlgorithmComboBox.SelectedValue).Text)
            {
                case "BFS":
                    result = graph.BfsSearch(graph.Vertices.First(), graph.Vertices.Last(), DistanceHandler, basicSpeed).ToList();
                    BFSResult.Visibility = Visibility.Visible;
                    BFSResult.Text = string.Format("BFS S: {0}, T: {1}", result.Last().S, result.Last().T);
                    break;
                case "DFS":
                    result = graph.DfsSearch(graph.Vertices.First(), graph.Vertices.Last(), DistanceHandler, basicSpeed).ToList();
                    DFSResult.Visibility = Visibility.Visible;
                    DFSResult.Text = string.Format("DFS S: {0}, T: {1}", result.Last().S, result.Last().T);
                    break;
                case "A*":
                    result = graph.AStarSearch(graph.Vertices.First(), graph.Vertices.Last(), DistanceHeuristicFunction, DistanceHandler, basicSpeed).ToList();
                    AStarResult.Visibility = Visibility.Visible;
                    AStarResult.Text = string.Format("A Star S: {0}, T: {1}", result.Last().S, result.Last().T);
                    break;
                case "BFS + Speed":
                    result = graph.BfsSearch(graph.Vertices.First(), graph.Vertices.Last(),
                                                     SpeedHandler, basicSpeed).ToList();
                    BFSSpeedResult.Visibility = Visibility.Visible;
                    BFSSpeedResult.Text = string.Format("BFS+Speed S: {0}, T: {1}", result.Last().S, result.Last().T);
                    break;
                case "DFS + Speed":
                    result = graph.DfsSearch(graph.Vertices.First(), graph.Vertices.Last(),
                                                     SpeedHandler, basicSpeed).ToList();
                    DFSSpeedResult.Visibility = Visibility.Visible;
                    DFSSpeedResult.Text = string.Format("DFS+Speed S: {0}, T: {1}", result.Last().S, result.Last().T);
                    break;
                case "A* + Speed":
                    result = graph.AStarSearch(graph.Vertices.First(), graph.Vertices.Last(), SpeedHeuristicFunction, SpeedHandler, basicSpeed).ToList();
                    AStarSpeedResult.Visibility = Visibility.Visible;
                    AStarSpeedResult.Text = string.Format("AStar+Speed S: {0}, T: {1}", result.Last().S, result.Last().T);
                    break;
                default:
                    return;
            }
           
            var points = new List<Point3D>(PathLinesVisual3D.Points);
            //MovingSphere.Visible = true;
            var animationQueue = new Queue<object[]>();
            var movingSphere = new SphereVisual3D()
            {
                Material = new DiffuseMaterial(new SolidColorBrush(Colors.Purple)),
                Radius = 12,
                Visible = true
            };
            HelixViewport3D.Children.Add(movingSphere);
            for (var i = 1; i < result.Count; i++)
            {
                var currentStartPoint = Point3DToWpfPoint3D(result[i-1].Position);
                points.Add(currentStartPoint);
                var currentEndPoint = Point3DToWpfPoint3D(result[i].Position);
                points.Add(currentEndPoint);
                PathLinesVisual3D.Points = points;
                var distance = currentStartPoint.DistanceTo(currentEndPoint);
                var pointAnimation = new Point3DAnimation(currentStartPoint, currentEndPoint, new Duration(TimeSpan.FromSeconds(distance > 0 ? distance / 100 : 0.2)));

                SequentialAnimation(pointAnimation,
                                    movingSphere,
                                    SphereVisual3D.CenterProperty, animationQueue);
            }
        }

        void SequentialAnimation(AnimationTimeline da, IAnimatable a, DependencyProperty dp, Queue<object[]> animationQueue)
        {
            da.Completed += (sender, e) =>
                            {
                                lock (animationQueue)
                                {
                                    var completed = animationQueue.Dequeue();
                                    if (animationQueue.Count > 0)
                                    {
                                        var next = animationQueue.Peek();
                                        var da1 = (AnimationTimeline)next[0];
                                        var a1 = (IAnimatable)next[1];
                                        var dp1 = (DependencyProperty)next[2];
                                        a1.BeginAnimation(dp1, da1);
                                    }
                                }
                            };

            lock (animationQueue)
            {
                if (animationQueue.Count == 0) // no animation pending
                {
                    animationQueue.Enqueue(new object[] { da, a, dp });
                    a.BeginAnimation(dp, da);
                }
                else
                {
                    animationQueue.Enqueue(new object[] { da, a, dp });
                }
            }
        }

        private double SpeedHeuristicFunction(Vertex current, Vertex prev, Vertex end)
        {
            var g = prev != null ? DistanceService.CalculateLength(current, prev) : 0;
            var h = DistanceService.CalculateLength(current, end);
            var v = prev != null ? DistanceService.CalculateSpeed(current, prev, g, SpeedValue.Value.Value) : SpeedValue.Value.Value;
            return (prev?.T ?? 0) + (g + h) / v;
        }

        private double DistanceHeuristicFunction(Vertex current, Vertex prev, Vertex end)
        {
            var g = prev != null ? DistanceService.CalculateLength(current, prev) : 0;
            var h = DistanceService.CalculateLength(current, end);
            return (prev?.S ?? 0) + g + h;
        }

        private bool SpeedHandler(IEnumerable<Vertex> path, Vertex vertex)
        {
            return !path.Any() || vertex.T < path.Last().T;
        }

        private bool DistanceHandler(IEnumerable<Vertex> path, Vertex vertex)
        {
            return !path.Any() || vertex.S < path.Last().S;
        }

        private Graph BuildGraph(Vertex start, Vertex end, List<Vertex> pointsBA, List<Vertex> pointsHA, List<Vertex> pointsCA)
        {
            var graph = new Graph();
            graph.AddVertex(start);
            graph.AddVertices(pointsBA);
            graph.AddVertices(pointsHA);
            graph.AddVertices(pointsCA);
            graph.AddVertex(end);
            foreach (var ba in pointsBA)
            {
                graph.AddConnection(start, ba);
                foreach (var ha in pointsHA)
                {
                    graph.AddConnection(ba, ha);
                    foreach (var ca in pointsCA)
                    {
                        graph.AddConnection(ha, ca);
                        graph.AddConnection(ca, end);
                    }
                }
            }
            return graph;
        }

        private Point3D CalculateStep(Point3D first, Point3D second, double pointsCount)
        {
            return new Point3D((first.X - second.X) / (pointsCount - 1), (first.Y - second.Y) / (pointsCount - 1),
                               (first.Z - second.Z) / (pointsCount - 1));
        }

        private List<Vertex> GetEdgePoints(Point3D point, Point3D step, int pointsCount)
        {
            var list = new List<Vertex>();
            for (var i = 0; i < pointsCount; i++)
            {
                list.Add(new Vertex(point.X - step.X * i, point.Y - step.Y * i, point.Z - step.Z * i));
            }
            return list;
        }

        #endregion
    }
}
