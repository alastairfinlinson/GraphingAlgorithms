using System;
using System.Collections.Generic;
using System.Text;

namespace GraphingAlgorithms.GraphObjects
{
    public interface ICartesianPoint
    {
        double X { get; set; }
        double Y { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }

    public class CartesianPoint : ICartesianPoint
    {
        public CartesianPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override bool Equals(object obj)
        {
            CartesianPoint point = obj as CartesianPoint;
            if (point.X == X)
            {
                if (point.Y == Y)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
