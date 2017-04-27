using AILabs.TicTacToe.Core.Models;

namespace AILabs.TicTacToe.Core.Interfaces
{
    public interface ITicTacToeService
    {
        Field AlphaBeta(Field field, int alpha, int beta, int depth, CellType player);
    }
}