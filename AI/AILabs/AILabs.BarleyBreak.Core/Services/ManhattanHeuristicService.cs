using System;
using AILabs.BarleyBreak.Core.Interfaces;
using AILabs.BarleyBreak.Core.Models;

namespace AILabs.BarleyBreak.Core.Services
{
    public class ManhattanHeuristicService : IHeuristicService
    {
        #region IHeuristicService Members

        public int CalculateHeuristic(Field field, int depth)
        {
            var heuristic = depth;
            for (var i = 0; i < field.Cells.Count; ++i)
            {
                if (field.Cells[i].CurrentValue != field.Cells[i].RequiredValue)
                {
                    var requiredCell = field.Cells.Find(cell => cell.RequiredValue == field.Cells[i].CurrentValue);
                    heuristic += Math.Abs(field.Cells[i].Position.X - requiredCell.Position.X)
                                 + Math.Abs(field.Cells[i].Position.Y - requiredCell.Position.Y);
                }
            }
            return heuristic;
        }

        #endregion
    }
}