using Prism.Commands;
using Prism.Mvvm;
using PrismWpfUI.Core;

namespace PrismWpfUI.ViewModels
{
    public class MainMenuViewModel : BindableBase
    {
        private IApplicationCommands _applicationCommands;

        public MainMenuViewModel(IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;
        }

        private DelegateCommand<string> _naviagteCommand;
        public DelegateCommand<string> NaviagteCommand =>
            _naviagteCommand ?? (_naviagteCommand = new DelegateCommand<string>(ExecuteNaviagteCommand));

        void ExecuteNaviagteCommand(string viewName)
        {
            _applicationCommands.Naviagte.Execute(viewName);
        }

    }
}
