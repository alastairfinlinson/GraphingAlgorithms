using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GraphingAlgorithms.GraphObjects;

namespace GraphingAlgorithmsUI.Services
{
    public interface IModelProvider
    {
        IEnumerable<INode> GetNodes(SampleSize sampleSize);
        INode GetNode(ICartesianPoint point, string name);
        INode GetNode(Point point);
        INode GetNode(double x, double y);
    }

    public class ModelProvider : IModelProvider
    {
        private readonly IDataInterfaceProvider _dataInterfaceProvider;

        public ModelProvider(IDataInterfaceProvider dataInterfaceProvider)
        {
            _dataInterfaceProvider = dataInterfaceProvider;
        }

        public IEnumerable<INode> GetNodes(SampleSize sampleSize)
        {
            return _dataInterfaceProvider.ReadNodeCollectionFile(sampleSize);
        }

        public INode GetNode(ICartesianPoint point, string name)
        {
            return new Node(point, name);
        }

        public INode GetNode(double x, double y)
        {
            return new Node(new CartesianPoint(x, y));
        }

        public INode GetNode(Point point)
        {
            return new Node(new CartesianPoint(point.X, point.Y));
        }
    }
}