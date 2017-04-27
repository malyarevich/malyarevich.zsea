using System;

namespace AILabs.Utils.Models.Graph.Services
{
    public static class DistanceService
    {
        public static double CalculateSpeed(Vertex begin, Vertex end, double len, double basicSpeed)
        {
            return basicSpeed / Math.Sqrt(1 + 15 * Math.Pow(Math.Abs(begin.Position.Z - end.Position.Z) / len, 2));
        }

        public static double CalculateLength(Vertex begin, Vertex end)
        {
            return Math.Sqrt(Math.Pow(begin.Position.X - end.Position.X, 2)
                             + Math.Pow(begin.Position.Y - end.Position.Y, 2)
                             + Math.Pow(begin.Position.Z - end.Position.Z, 2));
        }
    }
}