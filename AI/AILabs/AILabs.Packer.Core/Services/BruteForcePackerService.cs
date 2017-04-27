using System;
using System.Collections.Generic;
using System.Linq;
using AILabs.Packer.Core.Interfaces;
using AILabs.Packer.Core.Models;

namespace AILabs.Packer.Core.Services
{
    public class BruteForcePackerService : IPackerService
    {
        #region IPackerService Members

        public PackerResult Run(IList<Box> boxes, Position startPosition)
        {
            PackerResult result = null;

            foreach (var startBox in boxes)
            {
                var initialDistance = startBox.DistanceTo(startPosition);
                foreach (var centerBox in boxes)
                {
                    var distance = boxes.Sum(box => box.DistanceTo(centerBox)) * 2 - startBox.DistanceTo(centerBox) + initialDistance;
                    var weight = boxes.Where(box => box != centerBox).Sum(box => box.Weight);
                    var currentJob = distance * weight * PhysicConstants.Gravity * PhysicConstants.Friction;
                    if (result == null || currentJob < result.Job)
                    {
                        result = new PackerResult(startBox, centerBox, currentJob);
                    }
                }
            }
            return result;
        }

        #endregion
    }
}