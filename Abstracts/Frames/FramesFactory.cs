using GameOfLife.Abstracts;
using System;
using System.Collections.Generic;

namespace GameOfLife.Frames
{
    public static class FramesFactory
    {
        public static readonly IEnumerable<string> AvailableTypes = new HashSet<string>
        { "Flat","Cylinder","Toroid"};

        public static GameOfLifeFrame GetFarame(string type, int U, int V)
        {
            switch (type)
            {
                case "Flat": return new LimitedFrame(U, V);
                case "Cylinder": return new CylinderFrame(U, V);
                case "Toroid": return new ToroidFrame(U, V);
                default: throw new NotSupportedException("No Such frame type: " + type);
            }
        }
    }
}
