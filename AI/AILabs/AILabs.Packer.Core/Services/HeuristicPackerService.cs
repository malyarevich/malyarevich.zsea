using System;
using System.Collections.Generic;
using System.Linq;
using AILabs.Packer.Core.Interfaces;
using AILabs.Packer.Core.Models;

namespace AILabs.Packer.Core.Services
{
    public class HeuristicPackerService : IPackerService
    {
        public PackerResult Run(IList<Box> boxes, Position startPosition)
        {
            var massCenter = CalculateMassCenter(boxes);
            var centerBox = GetCenterBox(boxes, massCenter);
            var startBox = GetFarthestBox(boxes, massCenter);
            var distance = boxes.Sum(box => box.DistanceTo(centerBox)) * 2 - startBox.DistanceTo(centerBox) + startBox.DistanceTo(startPosition);
            var weight = boxes.Where(box => box != centerBox).Sum(box => box.Weight);
            var job = distance * weight * PhysicConstants.Gravity * PhysicConstants.Friction;
            return new PackerResult(startBox, centerBox, job);
        }

        private static Position CalculateMassCenter(IEnumerable<Box> boxes)
        {
            var sx = 0d;
            var sy = 0d;
            var sm = 0d;
            foreach (var box in boxes)
            {
                sx += box.Weight * box.Position.X;
                sy += box.Weight * box.Position.Y;
                sm += box.Weight;
            }
            return new Position((int)Math.Round(sx / sm), (int)Math.Round(sy / sm));
        }

        private static Box GetCenterBox(IEnumerable<Box> boxes, Position center)
        {
            return boxes.OrderBy(box => box.DistanceTo(center)).First();
        }

        private static Box GetFarthestBox(IEnumerable<Box> boxes, Position center)
        {
            return boxes.OrderByDescending(box => box.DistanceTo(center)).First();
        }
    }
}