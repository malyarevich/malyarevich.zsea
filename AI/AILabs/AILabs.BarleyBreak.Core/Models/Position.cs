namespace AILabs.BarleyBreak.Core.Models
{
    public struct Position
    {
        #region Properties, Indexers

        public int X { get; }
        public int Y { get; }

        #endregion

        #region Constructors

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion
    }
}