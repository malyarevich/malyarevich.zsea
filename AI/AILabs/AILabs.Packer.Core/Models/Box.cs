namespace AILabs.Packer.Core.Models
{
    public class Box
    {
        #region Properties, Indexers

        public Position Position { get; }

        public double Weight { get; }

        #endregion

        #region Constructors

        public Box(Position position, double weight)
        {
            Position = position;
            Weight = weight;
        }

        #endregion

        #region Methods

        public double DistanceTo(Box other) => Position.DistanceTo(other.Position);

        public double DistanceTo(Position position) => Position.DistanceTo(position);

        #endregion
    }
}