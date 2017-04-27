using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AILabs.BarleyBreak.Core.Models
{
    public class State : IEquatable<State>
    {
        #region Properties, Indexers

        public List<int> Cells { get; set; }

        public State PreviousState { get; set; }

        public int Depth { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        public State() : this(new List<int>())
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        public State([NotNull] List<int> cells, int depth = 0, State previousState = null)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));
            Cells = cells;
            Depth = depth;
            PreviousState = previousState;
        }

        #endregion

        #region Methods

        public Field ApplyTo(Field field)
        {
            for (var i = 0; i < field.Cells.Count; ++i)
            {
                field.Cells[i].IsEmpty = Cells[i] < 0;
                field.Cells[i].CurrentValue = Cells[i];
            }
            return field;
        }

        public Field ApplyRequiredTo(Field field)
        {
            for (var i = 0; i < field.Cells.Count; ++i)
            {
                field.Cells[i].IsEmpty = Cells[i] < 0;
                field.Cells[i].RequiredValue = Cells[i];
            }
            return field;
        }

        public static State FromField(Field field, State state)
        {
            return new State(field.Cells.Select(cell => cell.CurrentValue).ToList(), state.Depth, state.PreviousState);
        }

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
            if (obj.GetType() != GetType())
                return false;
            return Equals((State) obj);
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return Cells?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return $"Points: {string.Join(", ", Cells)}";
        }

        #endregion

        #region IEquatable<State> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(State other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Cells.SequenceEqual(other.Cells);
        }

        #endregion
    }
}