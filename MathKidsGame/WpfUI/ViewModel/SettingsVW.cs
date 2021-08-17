using MathKidsCore.Model;
using Prism.Mvvm;

namespace WpfUI.ViewModel
{
    public class SettingsVW : BindableBase
    {
        private GameSettingsModel _gameSettings;

        public SettingsVW(GameSettingsModel gameSettings)
        {
            _gameSettings = gameSettings;
        }

        private bool _operationAddChecked = true;

        public bool OperationAddChecked
        {
            get { return _operationAddChecked; }
            set { _operationAddChecked = value; }
        }

        private bool _operationDifChecked = true;

        public bool OperationDifChecked
        {
            get { return _operationDifChecked; }
            set { _operationDifChecked = value; }
        }

        private bool _operationMultiplyChecked = true;

        public bool OperationMultiplyChecked
        {
            get { return _operationMultiplyChecked; }
            set { _operationMultiplyChecked = value; }
        }

        public int SelectedDificulty
        {
            get { return (int)_gameSettings.Dificulty; }
            set { _gameSettings.Dificulty = (GameDificulty) value; }
        }

    }
}
