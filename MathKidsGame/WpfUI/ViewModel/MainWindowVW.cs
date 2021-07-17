using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfUI
{
    public class MainWindowVW : BindableBase
    {
        public DelegateCommand GameMaxInARow { get;  }

        public MainWindowVW()
        {
            GameMaxInARow = new DelegateCommand(() => RunGame());
        }

        private void RunGame()
        {
            var gameWinodw = new GameWindow();
            gameWinodw.Show();
        }
    }
}