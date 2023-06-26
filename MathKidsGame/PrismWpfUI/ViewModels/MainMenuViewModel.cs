using MathKidsCore.Model;
using Prism.Commands;
using Prism.Mvvm;
using PrismWpfUI.Core;

namespace PrismWpfUI.ViewModels
{
    public class MainMenuViewModel : BindableBase
    {
        private IApplicationCommands _applicationCommands;
        private GameSettingsModel _gameSettingsModel;

        public MainMenuViewModel(IApplicationCommands applicationCommands, GameSettingsModel gameSettingsModel)
        {
            _applicationCommands = applicationCommands;

            GameSettingsModel.Load(gameSettingsModel);
            _gameSettingsModel = gameSettingsModel;

            UserName = gameSettingsModel.CurrentUserName;
        }

        private DelegateCommand<string> _naviagteCommand;
        public DelegateCommand<string> NaviagteCommand =>
            _naviagteCommand ?? (_naviagteCommand = new DelegateCommand<string>(ExecuteNaviagteCommand));

        void ExecuteNaviagteCommand(string viewName)
        {
            _applicationCommands.Naviagte.Execute(viewName);
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set 
            {
                _gameSettingsModel.CurrentUserName = value;
                GameSettingsModel.Save(_gameSettingsModel);
                SetProperty(ref _userName, value); 
            }
        }

    }
}
