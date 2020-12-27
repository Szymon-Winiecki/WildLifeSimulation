using System;
using System.Collections.Generic;

namespace WildLifeSimulation.World
{
    class MotionVector
    {
        public static readonly MotionVector Zero = new MotionVector(0, 0);
        public static readonly MotionVector West = new MotionVector(-1, 0);
        public static readonly MotionVector East = new MotionVector(1, 0);
        public static readonly MotionVector North = new MotionVector(0, -1);
        public static readonly MotionVector South = new MotionVector(0, 1);

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

        public static MotionVector RandomMoveFrom(List<MotionVector> vectors)
        {
            if(vectors.Count == 0)
            {
                return MotionVector.Zero;
            }

            int randomNumber = random.Next(vectors.Count);

            return (vectors[randomNumber]);
        }

        public static MotionVector RandomWithLimitations(Position position, Map map)
        {
            List<MotionVector> possibleMoves = new List<MotionVector>();
            if(position.X > 0)
            {
                possibleMoves.Add(MotionVector.West);
            }
            if (position.X < map.Width - 1)
            {
                possibleMoves.Add(MotionVector.East);
            }
            if(position.Y > 0)
            {
                possibleMoves.Add(MotionVector.North);
            }
            if(position.Y < map.Height - 1)
            {
                possibleMoves.Add(MotionVector.South);
            }

            return RandomMoveFrom(possibleMoves);
        }

        public override string ToString() => "[" + X + ", " + Y + "]";
    }
}
