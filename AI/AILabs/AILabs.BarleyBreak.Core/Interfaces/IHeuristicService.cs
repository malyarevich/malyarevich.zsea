using System.Data;
using AILabs.BarleyBreak.Core.Models;

namespace AILabs.BarleyBreak.Core.Interfaces
{
    public interface IHeuristicService
    {
        int CalculateHeuristic(Field field, int depth);
    }
}