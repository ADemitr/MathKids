﻿using MathKidsCore;
using Prism.Commands;
using Prism.Mvvm;

namespace WpfUI
{
    public class MainWindowVM : BindableBase
    {
        private GameController _gameController;
        public string Description { get; private set; }
        public DelegateCommand SayYes { get; }
        public DelegateCommand SayNo { get; }

        public MainWindowVM()
        {
            _gameController = new GameController();
            NextRound();
            SayYes = new DelegateCommand(() =>
                {
                    Description = "Yes";
                    RaisePropertyChanged(nameof(Description));
                });
            SayNo = new DelegateCommand(() =>
            {
                Description = "No";
                RaisePropertyChanged(nameof(Description));
            });
        }

        private void NextRound()
        {
            Description = _gameController.GenerateMathTaskAndGetDescription();
            RaisePropertyChanged(nameof(Description));
        }

        private string _record = "Рекорд : 0";
        public string Record
        {
            get { return _record; }
            set { _record =  value; }
        }
    }
}
