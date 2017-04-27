using AILabs.TicTacToe.Core.Models;

namespace AILabs.TicTacToe.Core.Interfaces
{
    public interface IHeuristicService
    {
        int GetHeuristic(Field field, CellType player);
    }
}