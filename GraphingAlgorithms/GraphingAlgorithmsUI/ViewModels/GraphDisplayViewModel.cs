using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using GraphingAlgorithms;
using GraphingAlgorithms.GraphObjects;

namespace GraphingAlgorithmsUI.ViewModels
{
    public interface IGraphDisplayViewModel
    {
        ObservableCollection<INodeViewModel> Points { get; set; }
        string AlgorithmName { get; }
    }

    public class GraphDisplayViewModel : PropertyChangedBase, IGraphDisplayViewModel
    {
        private readonly IResolver _resolver;
        private string _algorithmName;
        ObservableCollection<INodeViewModel> _points = new ObservableCollection<INodeViewModel>();        

        public GraphDisplayViewModel(IEnumerable<INodeViewModel> points, IResolver resolver, string name)
        {
            _points = new ObservableCollection<INodeViewModel>(points);
            _resolver = resolver;
            _algorithmName = name;
        }

        public ObservableCollection<INodeViewModel> Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
                NotifyOfPropertyChange(() => Points);
            }
        }

        public string AlgorithmName
        {
            get => _algorithmName;
            set
            {
                _algorithmName = value;
                NotifyOfPropertyChange(() => AlgorithmName);
            }
        }

        public void Resolve()
        {
            IEnumerable<INode> nodes = Points.Select(p => new Node(p.Point, p.Name));
        }
    }
}
