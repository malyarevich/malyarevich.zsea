using System;
using System.Collections.Generic;
using System.Media;
using System.Threading.Tasks;
using AILabs.TicTacToe.Core.Interfaces;
using AILabs.TicTacToe.Core.Models;

namespace AILabs.TicTacToe.Core.Implementations
{
    public class SmartHeuristicService : IHeuristicService
    {
        #region Fields

        private readonly int winCount;
        private readonly CellType mainPlayer;

        private Tuple<int, int>[] directions = {new Tuple<int, int>(-1, 0), new Tuple<int, int>(-1, -1), new Tuple<int, int>(0, -1), new Tuple<int, int>(-1, 1) };
        #endregion

        #region Constructors

        public SmartHeuristicService(int winCount, CellType mainPlayer)
        {
            this.winCount = winCount;
            this.mainPlayer = mainPlayer;
        }

        #endregion

        #region Methods

        private int Factorial(int k)
        {
            if (k < 0)
            {
                throw new ArgumentException();
            }
            if (k == 1)
                return k;
            return k * Factorial(k - 1);
        }

        private int CalculatePositiveValue(int k)
        {
            return Factorial(k + 2);
        }

        private int CalculateNegativeValue(int k)
        {
            return Factorial(k + 2);
        }

        private Score ScoreMove(Field field, CellType player, int rowOffset, int columnOffset)
        {
            var i = field.LastMoveI;
            var j = field.LastMoveJ;
            var rowCount = 0;
            var totalCount = 0;
            var openedCount = 0;
            var inRow = true;
            while (openedCount < winCount && i < field.Size && i >=0 && j < field.Size && j >= 0 && rowCount < winCount)
            {
                if (field.Cells[i, j] == player)
                {
                    if (inRow)
                        ++rowCount;
                    ++totalCount;
                }
                else
                    inRow = false;

                ++openedCount;
                i += rowOffset;
                j += columnOffset;
            }
            return new Score(totalCount, rowCount, openedCount);
        }

        #endregion

        #region IHeuristicService Members

        public int GetHeuristic(Field field, CellType player)
        {
            var playerResult = 0;
            var oppositePlayerResult = 0;
            var oppositePlayer = player == CellType.Cross ? CellType.Nought : CellType.Cross;
            foreach (var direction in directions)
            {
                var playerScore =
                    ScoreMove(field, player, direction.Item1, direction.Item2)
                        .MakeLineScore(ScoreMove(field, player, -direction.Item1, -direction.Item2));
                if (playerScore.OpenedCount < winCount)
                    continue;
                if (playerScore.RowCount >= winCount)
                {
                    playerResult = int.MaxValue - 1;
                    return player == mainPlayer ? playerResult : -playerResult;
                }
                playerResult += CalculatePositiveValue(playerScore.RowCount) + playerScore.TotalCount;

                var oppositePlayerScore =
                    ScoreMove(field, oppositePlayer, direction.Item1, direction.Item2)
                        .MakeLineScore(ScoreMove(field, oppositePlayer, -direction.Item1, -direction.Item2));
                if (oppositePlayerScore.RowCount >= winCount)
                {
                    oppositePlayerResult = int.MaxValue - 1;
                    return player == mainPlayer ? oppositePlayerResult : -oppositePlayerResult;
                }
                if (oppositePlayerScore.OpenedCount >= winCount)
                {
                    oppositePlayerResult += CalculateNegativeValue(oppositePlayerScore.RowCount) + oppositePlayerScore.TotalCount;
                }

            }
            return player == mainPlayer ? playerResult + oppositePlayerResult : -(playerResult + oppositePlayerResult);
        }

        #endregion

        #region Nested Types

        private class Score
        {
            #region Properties, Indexers

            public int RowCount { get; set; }
            public int TotalCount { get; set; }

            public int OpenedCount { get; set; }

            #endregion

            #region Constructors

            public Score(int totalCount, int rowCount, int openedCount)
            {
                TotalCount = totalCount;
                RowCount = rowCount;
                OpenedCount = openedCount;
            }

            #endregion

            public Score MakeLineScore(Score other)
            {
                TotalCount += other.TotalCount - 1;
                RowCount += other.RowCount - 1;
                OpenedCount += other.OpenedCount - 1;
                return this;
            }
        }

        #endregion
    }
}