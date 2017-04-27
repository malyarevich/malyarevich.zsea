using System.Collections.Generic;
using System.Linq;
using AILabs.Utils.Models.Base;

namespace AILabs.Utils.Models.Graph
{
    public class Vertex
    {
        #region Properties, Indexers

        public Point3D Position { get; set; }

        public List<Vertex> Connections { get; set; }

        public double S { get; set; }
        public double T { get; set; }

        #endregion

        #region Constructors

        public Vertex() : this(new Point3D())
        {}

        public Vertex(Point3D position)
        {
            Position = position;
            Connections = new List<Vertex>();
        }

        public Vertex(double x, double y, double z) : this(new Point3D(x, y, z))
        { }

        #endregion

        public void AddConnection(Vertex other)
        {
            if (!Connections.Contains(other))
            {
                Connections.Add(other);
            }
        }

        public override string ToString()
        {
            return $"Position: {Position}, S: {S}, T: {T}";
        }

        public Vertex DeepCopy()
        {
            return new Vertex(Position) {S = S, T = T, Connections = Connections.Select(vertex => vertex.DeepCopy()).ToList()};
        }
    }
}