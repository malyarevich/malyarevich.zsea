using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AILabs.Utils.Models.Graph.Services;
using C5;

namespace AILabs.Utils.Models.Graph
{
    public class Graph
    {
        #region Properties, Indexers

        public List<Vertex> Vertices { get; set; }

        #endregion

        #region Constructors

        public Graph()
        {
            Vertices = new List<Vertex>();
        }

        #endregion

        #region Methods

        public void AddConnection(Vertex begin, Vertex end)
        {
            begin.AddConnection(end);
        }

        public void AddVertex(Vertex vertex)
        {
            if (!Vertices.Contains(vertex))
                Vertices.Add(vertex);
        }

        public void AddVertices(IEnumerable<Vertex> vertices)
        {
            foreach (var vertex in vertices.Where(vertex => !Vertices.Contains(vertex)))
            {
                AddVertex(vertex);
            }
        }

        public IEnumerable<Vertex> BfsSearch(Vertex begin, Vertex end, Func<IEnumerable<Vertex>, Vertex, bool> handler, double basicSpeed = 1)
        {
            var open = new Queue<System.Collections.Generic.KeyValuePair<Vertex, object>>();
            var path = new Stack<Vertex>();
            open.Enqueue(new System.Collections.Generic.KeyValuePair<Vertex, object>(begin, null));
            while (open.Count > 0)
            {
                var vertex = open.Dequeue();
                if (vertex.Key.Position.Equals(end.Position) && handler(path, vertex.Key))
                {
                    path.Clear();
                    var tmp = vertex;
                    do
                    {
                        path.Push(tmp.Key);
                        tmp = (System.Collections.Generic.KeyValuePair<Vertex, object>)tmp.Value;
                    } while (tmp.Value != null);
                    path.Push(tmp.Key);
                }
                else
                {
                    foreach (var connection in vertex.Key.Connections)
                    {
                        var len = DistanceService.CalculateLength(connection, vertex.Key);
                        var speed = DistanceService.CalculateSpeed(connection, vertex.Key, len, basicSpeed);

                        var nv = connection.DeepCopy();
                        nv.S = vertex.Key.S + len;
                        if (!double.IsNaN(speed))
                            nv.T = vertex.Key.T + len / speed;
                        else
                            nv.T = vertex.Key.T;
                        open.Enqueue(new System.Collections.Generic.KeyValuePair<Vertex, object>(nv, vertex));
                    }
                }
            }
            return path;
        }

        public IEnumerable<Vertex> DfsSearch(Vertex begin, Vertex end, Func<IEnumerable<Vertex>, Vertex, bool> handler, double basicSpeed = 1)
        {
            var open = new Stack<System.Collections.Generic.KeyValuePair<Vertex, object>>();
            var path = new Stack<Vertex>();
            open.Push(new System.Collections.Generic.KeyValuePair<Vertex, object>(begin, null));
            while (open.Count > 0)
            {
                var vertex = open.Pop();
                if (vertex.Key.Position.Equals(end.Position) && handler(path, vertex.Key))
                {
                    path.Clear();
                    var tmp = vertex;
                    do
                    {
                        path.Push(tmp.Key);
                        tmp = (System.Collections.Generic.KeyValuePair<Vertex, object>)tmp.Value;
                    } while (tmp.Value != null);
                    path.Push(tmp.Key);
                }
                else
                {
                    foreach (var connection in vertex.Key.Connections)
                    {
                        var len = DistanceService.CalculateLength(connection, vertex.Key);
                        var speed = DistanceService.CalculateSpeed(connection, vertex.Key, len, basicSpeed);
                        var nv = connection.DeepCopy();
                        nv.S = vertex.Key.S + len;
                        if (!double.IsNaN(speed))
                            nv.T = vertex.Key.T + len / speed;
                        else
                            nv.T = vertex.Key.T;
                        open.Push(new System.Collections.Generic.KeyValuePair<Vertex, object>(nv, vertex));
                    }
                }
            }
            return path;
        }

        public IEnumerable<Vertex> AStarSearch(Vertex begin, Vertex end, Func<Vertex, Vertex, Vertex, double> heuristic,
                                               Func<IEnumerable<Vertex>, Vertex, bool> handler, double basicSpeed = 1)
        {
            var open =
                new IntervalHeap<HeuristicNode>(
                    Comparer<HeuristicNode>.Create(
                        (first, second) => first.Heuristic > second.Heuristic ? 1 : first.Heuristic < second.Heuristic ? -1 : 0));
            var path = new Stack<Vertex>();
            open.Add(new HeuristicNode(begin, null, heuristic(begin, null, end)));
            while (open.Count > 0)
            {
                var node = open.DeleteMin();
                if (node.Vertex.Position.Equals(end.Position) && handler(path, node.Vertex))
                {
                    path.Clear();
                    var tmp = node;
                    do
                    {
                        path.Push(tmp.Vertex);
                        tmp = tmp.PreviousNode;
                    } while (tmp.PreviousNode != null);
                    path.Push(tmp.Vertex);
                    //return path;
                }
                else
                {
                    foreach (var connection in node.Vertex.Connections)
                    {
                        var len = DistanceService.CalculateLength(node.Vertex, connection);
                        var speed = DistanceService.CalculateSpeed(node.Vertex, connection, len, basicSpeed);

                        var nv = connection.DeepCopy();
                        nv.S = node.Vertex.S + len;
                        if (!double.IsNaN(speed))
                            nv.T = node.Vertex.T + len / speed;
                        else
                            nv.T = node.Vertex.T;
                        var eg = new HeuristicNode(nv, node, heuristic(connection, node.Vertex, end));
                        open.Add(eg);
                    }
                }
            }
            return path;
        }

        #endregion

        #region Nested Types

        private class HeuristicNode
        {
            #region Properties, Indexers

            public Vertex Vertex { get; set; }
            public HeuristicNode PreviousNode { get; set; }
            public double Heuristic { get; set; }

            #endregion

            #region Constructors

            public HeuristicNode(Vertex vertex, HeuristicNode previousNode, double heuristicFunc)
            {
                Vertex = vertex;
                PreviousNode = previousNode;
                Heuristic = heuristicFunc;
            }

            #endregion
        }

        #endregion
    }
}