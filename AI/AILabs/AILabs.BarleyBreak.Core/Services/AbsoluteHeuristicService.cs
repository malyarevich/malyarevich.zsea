using System;
using AILabs.BarleyBreak.Core.Interfaces;
using AILabs.BarleyBreak.Core.Models;

namespace AILabs.BarleyBreak.Core.Services
{
    public class AbsoluteHeuristicService : IHeuristicService
    {
        #region IHeuristicService Members

        public int CalculateHeuristic(Field field, int depth)
        {
            var heuristic = depth;
            for (var i = 0; i < field.Cells.Count; ++i)
            {
                if (field.Cells[i].CurrentValue != field.Cells[i].RequiredValue)
                    ++heuristic;
            }
            return heuristic;
        }

        #endregion
    }
}