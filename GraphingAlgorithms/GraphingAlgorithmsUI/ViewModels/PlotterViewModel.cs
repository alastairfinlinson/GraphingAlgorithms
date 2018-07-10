using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using GraphingAlgorithmsUI.Services;

namespace GraphingAlgorithmsUI.ViewModels
{
    public interface IPlotterViewModel
    {
        ObservableCollection<INodeViewModel> Nodes { get; set; }

        void OnCanvasClick(object e);
    }

    public class PlotterViewModel : PropertyChangedBase, IPlotterViewModel
    {
        private ObservableCollection<INodeViewModel> _nodes;
        private readonly IViewModelProvider _viewModelProvider;
        private readonly IModelProvider _modelProvider;

        public PlotterViewModel(IViewModelProvider viewModelProvider, IModelProvider modelProvider)
        {
            _viewModelProvider = viewModelProvider;
            _modelProvider = modelProvider;
            Nodes = new ObservableCollection<INodeViewModel>
            {
                _viewModelProvider.GetNodeViewModel(_modelProvider.GetNode(0, 0))
            };
        }

        public void OnCanvasClick(object e)
        {
            var eventArgs = e as RoutedEventArgs;
            var button = eventArgs.OriginalSource as Button;

            Point a = Mouse.GetPosition(button);


            if (a!=null)
            {
                Point relPoint = button.TranslatePoint(a, button);
                INodeViewModel newNode = _viewModelProvider.GetNodeViewModel(_modelProvider.GetNode(a.X - button.ActualWidth ,a.Y - button.ActualHeight));
                Nodes.Add(newNode);
            }
        }

        public ObservableCollection<INodeViewModel> Nodes
        {
            get => _nodes;

            set
            {
                _nodes = value;
                NotifyOfPropertyChange(() => Nodes);
            }
        }
    }
}