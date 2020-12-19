using System;
using System.Collections.Generic;
using System.Text;

namespace WildLifeSimulation.World
{
    class MotionVector
    {
        public static readonly MotionVector Zero = new MotionVector(0, 0);
        public static readonly MotionVector Left = new MotionVector(-1, 0);
        public static readonly MotionVector Right = new MotionVector(1, 0);
        public static readonly MotionVector Forward = new MotionVector(0, 1);
        public static readonly MotionVector Backward = new MotionVector(0, -1);

        private static Random random = new Random();


        private int x, y;
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }

        public MotionVector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static MotionVector Random()
        {
            int randomNumber = random.Next(3);

            switch (randomNumber)
            {
                case 0:
                    return MotionVector.Left;
                    break;
                case 1:
                    return MotionVector.Right;
                    break;
                case 2:
                    return MotionVector.Forward;
                    break;
                case 3:
                    return MotionVector.Backward;
                    break;
            }
            return MotionVector.Zero;
        }

        public static MotionVector RandomWithLimitations(Position position, Map map) { return Zero};

        public override string ToString() => "[" + X + ", " + Y + "]";
    }
}
