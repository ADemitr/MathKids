using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismWpfUI.Core;
using PrismWpfUI.Views;
using System.Windows.Input;

namespace PrismWpfUI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IApplicationCommands _applicationCommands;

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands)
        {
            _regionManager = regionManager;
            _applicationCommands = applicationCommands;
            _applicationCommands.Naviagte.RegisterCommand(NavigateCommand);
        }

        private DelegateCommand<string> _naviagteCommand;
        public DelegateCommand<string> NavigateCommand =>
            _naviagteCommand ?? (_naviagteCommand = new DelegateCommand<string>(ExecuteNaviagteCommand));

        void ExecuteNaviagteCommand(string viewName)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, viewName);
        }
    }
}
