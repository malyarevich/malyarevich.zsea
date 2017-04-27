using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using AILabs.TicTacToe.Core.Interfaces;
using AILabs.TicTacToe.Core.Models;

namespace AILabs.TicTacToe.Core.Implementations
{
    public class TicTacToeService : ITicTacToeService
    {
        private readonly IHeuristicService heuristicService;
        private readonly int winCount;
        private readonly int initialDepth;

        public TicTacToeService(IHeuristicService heuristicService, int winCount, int initialDepth)
        {
            this.heuristicService = heuristicService;
            this.winCount = winCount;
            this.initialDepth = initialDepth;
        }

        public Field AlphaBeta(Field field, int alpha, int beta, int depth, CellType player)
        {
            if (IsTerminal(field, depth))
            {
                field.Score = heuristicService.GetHeuristic(field, player);
                return field;
                return field.ChangeScore(heuristicService.GetHeuristic(field, player));
            }
            var oppositePlayer = player == CellType.Cross ? CellType.Nought : CellType.Cross;
            var resultField = field;
            if (depth == initialDepth)
            {
                Parallel.ForEach(GetChildFields(field, oppositePlayer), (child, state) =>
                                                                        {
                                                                            var score = AlphaBeta(child, alpha, beta, depth - 1, oppositePlayer);
                                                                            if (player == CellType.Cross)
                                                                            {
                                                                                if (beta > score.Score)
                                                                                {
                                                                                    beta = score.Score;
                                                                                    resultField = child;
                                                                                    if (alpha >= beta)
                                                                                        state.Break();
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (alpha < score.Score)
                                                                                {
                                                                                    alpha = score.Score;
                                                                                    resultField = child;
                                                                                    if (alpha >= beta)
                                                                                        state.Break();
                                                                                }
                                                                            }
                                                                        });
            }
            else
            {
                foreach (var child in GetChildFields(field, oppositePlayer))
                {
                    var score = AlphaBeta(child, alpha, beta, depth - 1, oppositePlayer);
                    if (player == CellType.Cross)
                    {
                        if (beta > score.Score)
                        {
                            beta = score.Score;
                            resultField = child;
                            if (alpha >= beta)
                                break;
                        }
                    }
                    else
                    {
                        if (alpha < score.Score)
                        {
                            alpha = score.Score;
                            resultField = child;
                            if (alpha >= beta)
                                break;
                        }
                    }
                }
            }
            
            resultField.Score = player == CellType.Nought ? alpha : beta;
            return resultField;
            return resultField.ChangeScore(player == CellType.Nought ? alpha : beta);
        }

        private static IEnumerable<Field> GetChildFields(Field field, CellType player)
        {
            for (var i = 0; i < field.Size; ++i)
            {
                for (var j = 0; j < field.Size; ++j)
                {
                    if (field.Cells[i, j] == CellType.Empty)
                    {
                        yield return field.ChangeCell(i, j, player);
                    }
                }
            }
        }

        private bool IsTerminal(Field field, int depth)
        {
            if (depth == 0)
                return true;
            if (field.IsFullField())
                return true;
            if (field.IsStraightLineWin(winCount))
                return true;
            if (field.IsDiagonalWin(winCount))
                return true;

            return false;

        }
    }
}