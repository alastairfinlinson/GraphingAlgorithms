using System;
using GraphingAlgorithms.GraphObjects;

namespace GraphingAlgorithms.Helpers
{
    public class PolarCalculator
    {
        public double CalculateMagnitude(Node sourceNode, Node destinationNode)
        {
            double deltaX = destinationNode.Point.X - sourceNode.Point.X;
            double deltaY = destinationNode.Point.Y - sourceNode.Point.Y;
            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }
    }
}