using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Caliburn.Micro;
using GraphingAlgorithms.Helpers;
using GraphingAlgorithmsUI.Services;
using GraphingAlgorithmsUI.ViewModels;

namespace GraphingAlgorithmsUI.Bootstrapper
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.PerRequest<MainWindowViewModel>();

            container.Singleton<IWindowManager, WindowManager>();           

            container.Singleton<IFileReader, FileReader>();
            container.Singleton<IViewModelProvider, ViewModelProvider>();
            container.Singleton<IDataInterfaceProvider, DataInterfaceProvider>();
            container.Singleton<IModelProvider, ModelProvider>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
        
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {

        }

        protected override void OnExit(object sender, EventArgs e)
        {

        }
    }
}
