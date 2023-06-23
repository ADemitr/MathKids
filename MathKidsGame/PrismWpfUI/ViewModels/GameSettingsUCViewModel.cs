using MathKidsCore;
using MathKidsCore.Model;
using Prism.Commands;
using Prism.Mvvm;
using PrismWpfUI.Core;
using PrismWpfUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismWpfUI.ViewModels
{
    public class GameSettingsUCViewModel : BindableBase
    {
        public GameSettingsUCViewModel(GameSettingsModel gameSettings, IApplicationCommands applicationCommands)
        {
            _gameSettings = gameSettings;
            _applicationCommands = applicationCommands;

            if (_gameSettings.Operations != null)
            {
                _operationAddChecked = _gameSettings.Operations.Contains(MathOperations.Add);
                _operationDifChecked = _gameSettings.Operations.Contains(MathOperations.Diff);
                _operationMultiplyChecked = _gameSettings.Operations.Contains(MathOperations.Multiply);
            }
        }

        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand =>
            _backCommand ?? (_backCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand() =>_applicationCommands.Naviagte.Execute(typeof(MainMenu).Name);
        

        private GameSettingsModel _gameSettings;
        private IApplicationCommands _applicationCommands;
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
