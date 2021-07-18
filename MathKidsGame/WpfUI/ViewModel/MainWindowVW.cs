using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfUI.View;

namespace WpfUI
{
    public class MainWindowVW : BindableBase
    {
        public DelegateCommand GameMaxInARow { get; }
        public DelegateCommand EditSettings { get; }

        public MainWindowVW()
        {
            GameMaxInARow = new DelegateCommand(() => new GameWindow().ShowDialog());
            EditSettings = new DelegateCommand(() => new GameSettings().ShowDialog());
        }
    }
}