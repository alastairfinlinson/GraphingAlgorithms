using System.Collections.Generic;
using GraphingAlgorithms;
using GraphingAlgorithms.GraphObjects;
using GraphingAlgorithmsUI.ViewModels;

namespace GraphingAlgorithmsUI.Services
{
    public interface IViewModelProvider
    {
        INodeViewModel GetNodeViewModel(INode nodeViewModel);
        INodeViewModel GetNodeViewModel(ICartesianPoint point, string name);
        IEnumerable<INodeViewModel> GetNodeViewModels(IEnumerable<INode> nodeModels);
        IGraphDisplayViewModel GetPrimsGraph(IEnumerable<INodeViewModel> nodes);
        IGraphDisplayViewModel GetKurskalsGraph(IEnumerable<INodeViewModel> nodes);
        IGraphDisplayViewModel GetDijkstrasGraph(IEnumerable<INodeViewModel> nodes);
        IPlotterViewModel GetPlotterViewModel(IViewModelProvider viewModelProvider, IModelProvider modelProvider);
    }   

    public class ViewModelProvider : IViewModelProvider
    {
        private readonly IModelProvider _modelProvider;

        public ViewModelProvider(IModelProvider modelProvider)
        {
            _modelProvider = modelProvider;
        }

        public INodeViewModel GetNodeViewModel(INode nodeViewModel)
        {
            return new NodeViewModel(nodeViewModel);
        }

        public INodeViewModel GetNodeViewModel(ICartesianPoint point, string name)
        {
            INode node = _modelProvider.GetNode(point, name);
            return new NodeViewModel(node);
        }

        public IEnumerable<INodeViewModel> GetNodeViewModels(IEnumerable<INode> nodeModels)
        {
            foreach (INode node in nodeModels)
            {
                yield return new NodeViewModel(node);
            }
        }

        public IGraphDisplayViewModel GetPrimsGraph(IEnumerable<INodeViewModel> nodes)
        {
            return new GraphDisplayViewModel(nodes, new PrimsResolver(), "Prim's Algorithm");
        }

        public IGraphDisplayViewModel GetKurskalsGraph(IEnumerable<INodeViewModel> nodes)
        {
            return new GraphDisplayViewModel(nodes, new KurskalsResolver(), "Kurskal's Algorithm");
        }

        public IGraphDisplayViewModel GetDijkstrasGraph(IEnumerable<INodeViewModel> nodes)
        {
            return new GraphDisplayViewModel(nodes, new DijkstrasResolver(), "Dijkstra's Algorithm");
        }

        public IPlotterViewModel GetPlotterViewModel(IViewModelProvider viewModelProvider, IModelProvider modelProvider)
        {
            return new PlotterViewModel(viewModelProvider, modelProvider);
        }
    }
}