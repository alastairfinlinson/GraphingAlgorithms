using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using GraphingAlgorithms.GraphObjects;

namespace GraphingAlgorithmsUI.ViewModels
{
    public interface INodeViewModel
    {
        string Name { get; set; }
        ICartesianPoint Point { get; set; }
        ObservableCollection<IEdge> Edges { get; set; }
    }

    public class NodeViewModel : PropertyChangedBase, INodeViewModel
    {
        private readonly INode _node;
        private string _name;
        private ICartesianPoint _point;
        private ObservableCollection<IEdge> _edges;

        public NodeViewModel(INode node)
        {
            _node = node;
            Point = node.Point;
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public ICartesianPoint Point
        {
            get => _point;
            set
            {
                _point = value;
                NotifyOfPropertyChange(() => Point);
            }
        }

        public ObservableCollection<IEdge> Edges
        {
            get => _edges;
            set
            {
                _edges = value;
                NotifyOfPropertyChange(() => Edges);
            }
        }
    }
}