using System;

namespace AILabs.BarleyBreak.Core.Models
{
    public class Cell : IEquatable<Cell>
    {
        #region Properties, Indexers

        public Cell Left { get; set; }
        public Cell Top { get; set; }
        public Cell Right { get; set; }
        public Cell Bottom { get; set; }

        public int CurrentValue { get; set; }
        public int RequiredValue { get; set; }

        public bool IsEmpty { get; set; }

        public Position Position { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        public Cell(int x, int y, Cell left, Cell top, Cell right, Cell bottom, int requiredValue, bool isEmpty)
        {
            Position = new Position(x, y);
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            RequiredValue = requiredValue;
            IsEmpty = isEmpty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        public Cell(int x, int y, Cell left, Cell top, Cell right, Cell bottom, int currentValue, int requiredValue, bool isEmpty)
        {
            Position = new Position(x, y);
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            CurrentValue = currentValue;
            RequiredValue = requiredValue;
            IsEmpty = isEmpty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        public Cell(int x, int y, Cell left = null, Cell top = null, Cell right = null, Cell bottom = null, bool isEmpty = false)
        {
            Position = new Position(x, y);
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            IsEmpty = isEmpty;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Cell) obj);
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Position.X * 397) ^ Position.Y;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return $"X: {Position.X}, Y: {Position.Y}, CurrentValue:{CurrentValue}";
        }

        public void MoveTo(Cell cell)
        {
            var tempValue = CurrentValue;
            CurrentValue = cell.CurrentValue;
            cell.CurrentValue = tempValue;

            var tempEmptiness = IsEmpty;
            IsEmpty = cell.IsEmpty;
            cell.IsEmpty = tempEmptiness;
        }

        #endregion

        #region IEquatable<Cell> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Cell other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Position.X == other.Position.X && Position.Y == other.Position.Y;
        }

        #endregion
    }
}