using MathKidsCore.Model;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace WpfUI.ViewModel
{
    public class SettingsVW : BindableBase
    {
        private GameSettingsModel _gameSettings;

        public SettingsVW(GameSettingsModel gameSettings)
        {
            _gameSettings = gameSettings;

            if (_gameSettings.Operations != null)
            {
                _operationAddChecked = _gameSettings.Operations.Contains(MathOperations.Add);
                _operationDifChecked = _gameSettings.Operations.Contains(MathOperations.Diff);
                _operationMultiplyChecked = _gameSettings.Operations.Contains(MathOperations.Multiply);
            }
        }

        private bool _operationAddChecked;

        public bool OperationAddChecked
        {
            get { return _operationAddChecked; }
            set 
            { 
                _operationAddChecked = value;
                UpdateOperations();
            }
        }

        private bool _operationDifChecked;

        public bool OperationDifChecked
        {
            get { return _operationDifChecked; }
            set 
            { 
                _operationDifChecked = value;
                UpdateOperations();
            }
        }

        private bool _operationMultiplyChecked;

        public bool OperationMultiplyChecked
        {
            get { return _operationMultiplyChecked; }
            set 
            {
                _operationMultiplyChecked = value;
                UpdateOperations();
            }
        }

        public int SelectedDificulty
        {
            get { return (int)_gameSettings.Dificulty; }
            set 
            {
                _gameSettings.Dificulty = (GameDificulty)value;
                GameSettingsModel.Save(_gameSettings);
            }
        }

        private void UpdateOperations()
        {
            List<MathOperations> operations = new List<MathOperations>();
            if (_operationAddChecked) operations.Add(MathOperations.Add);
            if (_operationDifChecked) operations.Add(MathOperations.Diff);
            if (_operationMultiplyChecked) operations.Add(MathOperations.Multiply);

            _gameSettings.Operations = operations;
            GameSettingsModel.Save(_gameSettings);
        }
    }
}
