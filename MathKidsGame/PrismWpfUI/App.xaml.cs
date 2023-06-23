using MathKidsCore;
using MathKidsCore.Model;
using Prism.Ioc;
using PrismWpfUI.Core;
using PrismWpfUI.ViewModels;
using PrismWpfUI.Views;
using System.Windows;

namespace PrismWpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(MainMenu), typeof(MainMenuViewModel));
            containerRegistry.Register(typeof(GameUC), typeof(GameUCViewModel));
            containerRegistry.Register(typeof(GameController));
            containerRegistry.RegisterSingleton(typeof(GameSettingsModel));

            containerRegistry.RegisterSingleton(typeof(IApplicationCommands), typeof(ApplicationCommands));

            containerRegistry.RegisterForNavigation(typeof(MainMenu), typeof(MainMenu).Name);
            containerRegistry.RegisterForNavigation(typeof(GameUC), typeof(GameUC).Name);
            containerRegistry.RegisterForNavigation(typeof(GameSettingsUC), typeof(GameSettingsUC).Name);
        }
    }
}
