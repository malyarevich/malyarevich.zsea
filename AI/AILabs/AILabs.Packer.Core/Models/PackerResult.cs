namespace AILabs.Packer.Core.Models
{
    public class PackerResult
    {
        #region Properties, Indexers

        public Box CenterBox { get; }
        public Box FirstBox { get; }

        public double Job { get; }

        #endregion

        #region Constructors

        public PackerResult(Box firstBox, Box centerBox, double job)
        {
            FirstBox = firstBox;
            CenterBox = centerBox;
            Job = job;
        }

        #endregion
    }
}