using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using AILabs.TicTacToe.Core.Implementations;

namespace AILabs.TicTacToe.Core.Models
{
    public class Field
    {
        #region Fields

        public CellType Winner { get; private set; } = CellType.Empty;

        public List<KeyValuePair<int, int>> WinLine { get; set; } = new List<KeyValuePair<int, int>>();

        #endregion

        #region Properties, Indexers

        public CellType[,] Cells { get; }

        public int Score { get; set; }

        public int Size { get; }

        #endregion

        #region Constructors

        public Field(int size = 3, int score = int.MinValue)
        {
            Size = size;
            Score = score;
            Cells = new CellType[size, size];
            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    Cells[i, j] = CellType.Empty;
                }
            }
        }

        #endregion

        #region Methods

        public Field ChangeCell(int i, int j, CellType newCell)
        {
            var field = DeepCopy();
            field.Cells[i, j] = newCell;
            field.LastMoveI = i;
            field.LastMoveJ = j;
            return field;
        }

        public int LastMoveJ { get; private set; } = -1;

        public int LastMoveI { get; private set; } = -1;

        public Field ChangeScore(int score)
        {
            var field = DeepCopy();
            field.Score = score;
            return field;
        }

        public Field DeepCopy()
        {
            var field = new Field(Size, Score);
            for (var k = 0; k < field.Size; ++k)
            {
                for (var l = 0; l < field.Size; ++l)
                {
                    field.Cells[k, l] = Cells[k, l];
                }
            }
            return field;
        }

        public bool IsDiagonalWin(int winCount)
        {
            for (var j = winCount - 1; j < Size; ++j)
            {
                if (IsDiagonalWin(0, j, j, 0, 1, -1, winCount))
                    return true;
            }
            for (var i = winCount - 1; i < Size; ++i)
            {
                if (IsDiagonalWin(i, Size - 1, 0, Size - 1 - i, -1, -1, winCount))
                    return true;
            }
            for (var j = Size - winCount; j >= 0; --j)
            {
                if (IsDiagonalWin(Size - 1, j, j, Size - 1, -1, 1, winCount))
                    return true;
            }
            for (var i = Size - winCount; i >= 0; --i)
            {
                if (IsDiagonalWin(i, 0, Size - 1, Size - 1 - i, 1, 1, winCount))
                    return true;
            }

            return false;
        }

        public bool IsFullField()
        {
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (Cells[i, j] == CellType.Empty)
                        return false;
                }
            }
            return true;
        }

        public bool IsStraightLineWin(int winCount)
        {
            var horCrosses = new List<KeyValuePair<int, int>>();
            var horNoughtes = new List<KeyValuePair<int, int>>();
            var verCrosses = new List<KeyValuePair<int, int>>();
            var verNoughtes = new List<KeyValuePair<int, int>>();
            for (var i = 0; i < Size; ++i)
            {
                var horCrossSum = 0;
                var horNoughtSum = 0;

                var verCrossSum = 0;
                var verNoughtSum = 0;
                for (var j = 0; j < Size; ++j)
                {
                    switch (Cells[i, j])
                    {
                        case CellType.Cross:
                            UpdateCrossNoughtSum(ref horCrossSum, out horNoughtSum);
                            UpdateWinLine(horCrosses, i, j, horNoughtes);
                            break;
                        case CellType.Nought:
                            UpdateCrossNoughtSum(ref horNoughtSum, out horCrossSum);
                            UpdateWinLine(horNoughtes, i, j, horCrosses);
                            break;
                        case CellType.Empty:
                            ResetCrossNoughtSum(out horCrossSum, out horNoughtSum);
                            UpdateWinLine(horCrosses, horNoughtes);
                            break;
                    }

                    switch (Cells[j, i])
                    {
                        case CellType.Cross:
                            UpdateCrossNoughtSum(ref verCrossSum, out verNoughtSum);
                            UpdateWinLine(verCrosses, j, i, verNoughtes);
                            break;
                        case CellType.Nought:
                            UpdateCrossNoughtSum(ref verNoughtSum, out verCrossSum);
                            UpdateWinLine(verNoughtes, j, i, verCrosses);
                            break;
                        case CellType.Empty:
                            ResetCrossNoughtSum(out verCrossSum, out verNoughtSum);
                            UpdateWinLine(verCrosses, verNoughtes);
                            break;
                    }
                    if (verCrossSum >= winCount || horCrossSum >= winCount)
                    {
                        Winner = CellType.Cross;
                        WinLine = verCrossSum >= winCount ? verCrosses : horCrosses;
                        return true;
                    }
                    if (verNoughtSum >= winCount || horNoughtSum >= winCount)
                    {
                        Winner = CellType.Nought;
                        WinLine = verNoughtSum >= winCount ? verNoughtes : horNoughtes;
                        return true;
                    }
                }
            }
            return false;
        }

        private static void UpdateWinLine(ICollection<KeyValuePair<int, int>> toSave, int i, int j, IList toClear)
        {
            toSave.Add(new KeyValuePair<int, int>(i, j));
            toClear.Clear();
        }

        private static void UpdateWinLine(IList firstToClear, IList secondToClear)
        {
            firstToClear.Clear();
            secondToClear.Clear();
        }

        private static void ResetCrossNoughtSum(out int firstValue, out int secondValue)
        {
            firstValue = 0;
            secondValue = 0;
        }

        private static void UpdateCrossNoughtSum(ref int incValue, out int resetValue)
        {
            ++incValue;
            resetValue = 0;
        }

        private bool IsDiagonalWin(int startRow, int startColumn, int endRow, int endColumn, int rowChange, int columnChange, int winCount)
        {
            var crosses = new List<KeyValuePair<int, int>>();
            var noughtes = new List<KeyValuePair<int, int>>();
            var crossSum = 0;
            var noughtSum = 0;
            var i = startRow;
            var j = startColumn;
            while (i != endRow + rowChange || j != endColumn + columnChange)
            {
                switch (Cells[i, j])
                {
                    case CellType.Cross:
                        UpdateCrossNoughtSum(ref crossSum, out noughtSum);
                        UpdateWinLine(crosses, i, j, noughtes);
                        break;
                    case CellType.Nought:
                        UpdateCrossNoughtSum(ref noughtSum, out crossSum);
                        UpdateWinLine(noughtes, i, j, crosses);
                        break;
                    case CellType.Empty:
                        ResetCrossNoughtSum(out crossSum, out noughtSum);
                        UpdateWinLine(noughtes, crosses);
                        break;
                }
                if (crossSum >= winCount)
                {
                    Winner = CellType.Cross;
                    WinLine = crosses;
                    return true;
                }
                if (noughtSum >= winCount)
                {
                    Winner = CellType.Nought;
                    WinLine = noughtes;
                    return true;
                }
                i += rowChange;
                j += columnChange;
            }

            return false;
        }

        #endregion
    }
}