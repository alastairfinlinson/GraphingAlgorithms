using System;
using System.Collections.Generic;
using System.Text;
using GraphingAlgorithms.GraphObjects;

namespace GraphingAlgorithms
{
    public interface IResolver
    {
        Graph Resolve(List<INode> node, INode startNode);
    }
}
