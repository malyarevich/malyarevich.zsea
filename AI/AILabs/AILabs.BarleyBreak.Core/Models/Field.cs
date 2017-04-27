using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace AILabs.BarleyBreak.Core.Models
{
    public class Field
    {
        #region Properties, Indexers

        public List<Cell> Cells { get; set; }


        public Cell EmptyCell
        {
            get { return Cells.Find(cell => cell.IsEmpty); }
        }

        #endregion

        #region Constructors

        public Field() : this(new List<Cell>())
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        public Field(List<Cell> cells)
        {
            Cells = cells;
        }

        #endregion

        #region Methods

        public static Field CreateEmptyField(int cellsCount)
        {
            var field = new Field();
            var linesCount = Math.Round(Math.Sqrt(cellsCount));
            for (var i = 0; i < linesCount; ++i)
            {
                for (var j = 0; j < linesCount; j++)
                {
                    field.Cells.Add(new Cell(j, i));
                }
            }
            for (var i = 0; i < linesCount; ++i)
            {
                for (var j = 0; j < linesCount; j++)
                {
                    var left = field.Cells.Find(cell => cell.Position.X == i - 1 && cell.Position.Y == j);
                    var top = field.Cells.Find(cell => cell.Position.X == i && cell.Position.Y == j - 1);
                    var right = field.Cells.Find(cell => cell.Position.X == i + 1 && cell.Position.Y == j);
                    var bottom = field.Cells.Find(cell => cell.Position.X == i && cell.Position.Y == j + 1);
                    var currentCell = field.Cells.Find(cell => cell.Position.X == i && cell.Position.Y == j);

                    currentCell.Left = left;
                    currentCell.Top = top;
                    currentCell.Right = right;
                    currentCell.Bottom = bottom;
                }
            }
            return field;
        }

        public Field MoveTo([NotNull] Cell cell)
        {
            if (cell == null)
                throw new ArgumentNullException(nameof(cell));
            EmptyCell.MoveTo(cell);
            return this;
        }

        #endregion
    }
}