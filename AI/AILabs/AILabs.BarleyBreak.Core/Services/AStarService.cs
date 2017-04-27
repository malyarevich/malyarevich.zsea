using System;
using System.Collections.Generic;
using System.Linq;
using AILabs.BarleyBreak.Core.Interfaces;
using AILabs.BarleyBreak.Core.Models;

namespace AILabs.BarleyBreak.Core.Services
{
    public class AStarService
    {
        #region Methods

        public static ResolvedPath Run(State currentState, State requiredState, IHeuristicService heuristicService, Field field)
        {
            currentState.ApplyTo(field);
            requiredState.ApplyRequiredTo(field);
            var opened =
                new C5.IntervalHeap<State>(
                    Comparer<State>.Create(
                        (first, second) =>
                        heuristicService.CalculateHeuristic(first.ApplyTo(field), first.Depth)
                                        .CompareTo(heuristicService.CalculateHeuristic(second.ApplyTo(field), second.Depth))));
            var openedCount = 0;

            var closed = new HashSet<State>();

            currentState.PreviousState = null;
            opened.Add(currentState);
            while (opened.Count != 0)
            {
                var state = opened.DeleteMin();
                closed.Add(state);
                ++openedCount;

                if (state.Equals(requiredState))
                    return new ResolvedPath(RestorePath(state), openedCount);
                foreach (var availableState in GetAvailableStates(state, field))
                {
                    if (closed.Contains(availableState))
                        continue;
                    availableState.Depth = state.Depth + 1;
                    availableState.PreviousState = state;
                    if (!opened.Contains(availableState) || heuristicService.CalculateHeuristic(availableState.ApplyTo(field), availableState.Depth)
                        < heuristicService.CalculateHeuristic(state.ApplyTo(field), state.Depth))
                    {
                        opened.Add(availableState);
                    }
                }

            }
            throw new InvalidOperationException("Path was not found");
        }

        private static IEnumerable<State> GetAvailableStates(State state, Field field)
        {
            if (state.ApplyTo(field).EmptyCell.Left != null)
            {
                yield return State.FromField(field.MoveTo(field.EmptyCell.Left), state);
            }

            if (state.ApplyTo(field).EmptyCell.Top != null)
            {
                yield return State.FromField(field.MoveTo(field.EmptyCell.Top), state);
            }

            if (state.ApplyTo(field).EmptyCell.Right != null)
            {
                yield return State.FromField(field.MoveTo(field.EmptyCell.Right), state);
            }

            if (state.ApplyTo(field).EmptyCell.Bottom != null)
            {
                yield return State.FromField(field.MoveTo(field.EmptyCell.Bottom), state);
            }
        }

        private static IEnumerable<State> RestorePath(State state)
        {
            var path = new Stack<State>();
            var temp = state;
            while (temp.PreviousState != null)
            {
                path.Push(temp);
                temp = temp.PreviousState;
            }
            path.Push(temp);
            return path;
        }

        #endregion
    }
}