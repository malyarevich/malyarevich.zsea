using System.Collections;
using System.Collections.Generic;
using AILabs.Packer.Core.Models;

namespace AILabs.Packer.Core.Interfaces
{
    public interface IPackerService
    {
        PackerResult Run(IList<Box> boxes, Position startPosition);
    }
}