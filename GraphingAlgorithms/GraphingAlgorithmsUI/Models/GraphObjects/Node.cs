using System;
using System.Collections.Generic;
using System.Text;

namespace GraphingAlgorithms.GraphObjects
{
    public interface INode
    {
        List<IEdge> Edges { get; set; }
        string Name { get; set; }
        ICartesianPoint Point { get; set; }
    }

    public class Node : INode
    {
        public ICartesianPoint Point { get; set; }
        public string Name { get; set; }
        public List<IEdge> Edges { get; set; } = new List<IEdge>();

        public Node(ICartesianPoint point)
        {
            Point = point;
        }

        public Node(ICartesianPoint point, string name)
        {
            Point = point;
            Name = name;
        }
    }
}