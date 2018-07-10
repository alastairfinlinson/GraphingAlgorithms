using System;
using System.Collections.Generic;
using System.Text;

namespace GraphingAlgorithms.GraphObjects
{
    public class Graph
    {
        public Graph(List<INode> mST)
        {
            MST = mST;
        }

        public List<INode> MST { get; set; } = new List<INode>();
    }
}
