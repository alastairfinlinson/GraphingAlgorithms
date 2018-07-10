using System.Collections.ObjectModel;
using Caliburn.Micro;
using GraphingAlgorithmsUI.Services;

namespace GraphingAlgorithmsUI.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private readonly IDataInterfaceProvider _dataInterfaceProvider;
        private readonly IViewModelProvider _viewModelProvider;
        private readonly IModelProvider _modelProvider;

        public IGraphDisplayViewModel PrimsGraphViewModel { get; private set; }
        public IGraphDisplayViewModel KurskalsGraphViewModel { get; private set; }
        public IGraphDisplayViewModel DijkstrasGraphViewModel { get; private set; }

        public IPlotterViewModel PlotterViewModel { get; set; }

        public MainWindowViewModel(IDataInterfaceProvider dataInterfaceProvider, IViewModelProvider viewModelProvider, IModelProvider modelProvider)
        {
            _dataInterfaceProvider = dataInterfaceProvider;
            _viewModelProvider = viewModelProvider;
            _modelProvider = modelProvider;
            var a = _dataInterfaceProvider.GenerateNodeScatter(20);
            var b = _viewModelProvider.GetNodeViewModels(a);

            PrimsGraphViewModel = _viewModelProvider.GetPrimsGraph(b);
            KurskalsGraphViewModel = _viewModelProvider.GetKurskalsGraph(b);
            DijkstrasGraphViewModel = _viewModelProvider.GetDijkstrasGraph(b);
            PlotterViewModel = _viewModelProvider.GetPlotterViewModel(_viewModelProvider, _modelProvider);
        }
    }
}