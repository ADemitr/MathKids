using Prism.Events;
using Prism.Regions;
using PrismWpfUI.Core;
using PrismWpfUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Unity.Injection;

namespace PrismWpfUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IApplicationCommands _applicationCommands;

        public MainWindow(IApplicationCommands applicationCommands)
        {
            InitializeComponent();

            _applicationCommands = applicationCommands;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            _applicationCommands.Naviagte.Execute(typeof(MainMenu).Name);
        }
    }
}
