using System;

namespace AILabs.Packer.Core.Models
{
    public struct Position : IEquatable<Position>
    {
        #region Properties, Indexers

        public int X { get; }

        public int Y { get; }

        #endregion

        #region Constructors

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Methods

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is Position && Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public double DistanceTo(Position other) => Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));

        #endregion

        #region IEquatable<Position> Members

        public bool Equals(Position other) => X == other.X && Y == other.Y;

        #endregion
    }
}