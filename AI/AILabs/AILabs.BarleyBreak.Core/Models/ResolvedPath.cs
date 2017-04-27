using System.Collections.Generic;

namespace AILabs.BarleyBreak.Core.Models
{
    public class ResolvedPath
    {
        #region Properties, Indexers

        public IEnumerable<State> Path { get; set; }

        public int OpenedCount { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ResolvedPath"/> class.
        /// </summary>
        public ResolvedPath(IEnumerable<State> path, int openedCount)
        {
            Path = path;
            OpenedCount = openedCount;
        }

        #endregion
    }
}