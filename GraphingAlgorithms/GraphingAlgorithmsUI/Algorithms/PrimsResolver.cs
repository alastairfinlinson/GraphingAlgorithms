using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphingAlgorithms.GraphObjects;

namespace GraphingAlgorithms
{
    public class PrimsResolver : IResolver
    {
        public List<IEdge> ConnectionEdges { get; set; } = new List<IEdge>();

        public Graph Resolve(List<INode> nodes, INode startNode)
        {
            List<INode> connectedNodes = new List<INode>();
            List<INode> unconnectedNodes = nodes;

            unconnectedNodes.Remove(startNode);
            connectedNodes.Add(startNode);

            while (unconnectedNodes.Count != 0)
            {
                INode newConnectionNode = FindConnection(connectedNodes, unconnectedNodes);
                unconnectedNodes.Remove(newConnectionNode);
                connectedNodes.Add(newConnectionNode);
            }
            return new Graph(connectedNodes);

        }

        private INode FindConnection(List<INode> connectedNodes, List<INode> unconnectedNodes)
        {
            INode nearestNode = null;
            INode sourceNode = null;
            double smallestWeight = double.MaxValue;
            foreach (INode connectedNode in connectedNodes)
            {
                foreach (IEdge edge in connectedNode.Edges)
                {
                    if (edge.Weight < smallestWeight)
                    {
                        if (!connectedNodes.Contains(edge.Destination))
                        {
                            smallestWeight = edge.Weight;
                            nearestNode = edge.Destination;
                            sourceNode = connectedNode;
                        }                        
                    }
                }
               
            }
            ConnectionEdges.Add(new Edge(sourceNode, nearestNode, smallestWeight));
            return nearestNode;
        }
    }
}
