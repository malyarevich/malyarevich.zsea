using AILabs.TicTacToe.Core.Interfaces;
using AILabs.TicTacToe.Core.Models;

namespace AILabs.TicTacToe.Core.Implementations
{
    public class WinLoseHeuristicService : IHeuristicService
    {
        private readonly int winCount;

        private const int WinValue = 5;
        private const int LoseValue = -5;
        private const int DrawValue = 2;
        private const int NoneValue = 0;

        public int GetHeuristic(Field field, CellType player)
        {
            if (field.IsStraightLineWin(winCount) || field.IsDiagonalWin(winCount))
                return field.Winner == player ? WinValue : LoseValue;
            return field.IsFullField() ? DrawValue : NoneValue;
        }

        public WinLoseHeuristicService(int winCount)
        {
            this.winCount = winCount;
        }
    }
}