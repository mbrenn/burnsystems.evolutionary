using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph
{
    public struct Vector2d
    {
        public double X;
        public double Y;

        public Vector2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector2d Zero()
        {
            return new Vector2d(0.0, 0.0);
        }

        public static double GetDistance(Vector2d point1, Vector2d point2)
        {
            var dX = point1.X - point2.X;
            var dY = point1.Y - point2.Y;

            return Math.Sqrt(dX * dX + dY * dY);
        }

        internal Vector2d Negate()
        {
            return new Vector2d(-X, -Y);
        }

        public void AddTo(Vector2d force)
        {
            X += force.X;
            Y += force.Y;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }
    }
}
