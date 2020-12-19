using System;
using System.Collections.Generic;
using System.Text;

namespace WildLifeSimulation.World
{
    class Position
    {
        public int X 
        { get; set; }
        public int Y
        { get; set; }

        public Position ChangePosition(MotionVector motionVector)
        {
            return this;
        }

        public override string ToString() => "(" + X + ", " + Y + ")";
    }
}
