using System;

namespace WildLifeSimulation.World
{
    class Position
    {
        private int x;
        private int y;
        public int X 
        { get { return x; } }
        public int Y
        { get { return y; } }

        private static Random randomGenerator = new Random();

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Position(Position position) : this(position.X, position.Y) { }
        public Position() : this(0, 0) { }

        public Position ChangePosition(MotionVector motionVector)
        {
            this.x += motionVector.X;
            this.y += motionVector.Y;
            return this;
        }

        public static Position RandomPosition(Map map)
        {
            int randomX = randomGenerator.Next(map.Width);
            int randomY = randomGenerator.Next(map.Height);

            return new Position(randomX, randomY);
        }

        public override string ToString() => "(" + X + ", " + Y + ")";
    }
}
