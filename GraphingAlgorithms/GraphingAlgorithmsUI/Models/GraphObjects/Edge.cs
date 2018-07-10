using System;
using System.Collections.Generic;
using System.Text;

namespace GraphingAlgorithms.GraphObjects
{
    public interface IEdge
    {
        INode Destination { get; set; }
        INode Srouce { get; set; }
        double Weight { get; set; }
        int CompareTo(IEdge edge);
    }

    public class Edge : IEdge
    {
        public double Weight { get; set; }
        public INode Srouce { get; set; }
        public INode Destination { get; set; }

        public Edge(INode srouce, INode destination, double weight)
        {
            Weight = weight;
            Srouce = srouce;
            Destination = destination;
        }

        public int CompareTo(IEdge edge)
        {
            if (Weight == edge.Weight)
            {
                return 0;
            }
            if (Weight < edge.Weight)
            {
                return -1;
            }
            return 1;
        } 
    }
}