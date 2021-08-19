using Autofac;
using MathKidsCore.Model;
using System.Windows;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILifetimeScope _container;

        private GameSettingsModel _settings = new GameSettingsModel
        {
            Dificulty = GameDificulty.Normal
        };

        public MainWindow(ILifetimeScope container)
        {
            InitializeComponent();

            _container = container;
        }

        private void ShowSettings(object sender, RoutedEventArgs e)
        {
            HideAllScreens();
            SettingsGrid.Children.Add(_container.Resolve<GameSettingsUC>());
            BackToMainMenu.Visibility = Visibility.Visible;
        }

        private void PlayGame(object sender, RoutedEventArgs e)
        {
            HideAllScreens();
            SettingsGrid.Children.Add(_container.Resolve<GameUC>());
            BackToMainMenu.Visibility = Visibility.Visible;
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e) => ShowScreen(MainMenu);

        private void ShowScreen(UIElement screenToShow)
        {
            HideAllScreens();

            if (screenToShow != MainMenu)
            {
                BackToMainMenu.Visibility = Visibility.Visible;
            }

            screenToShow.Visibility = Visibility.Visible;
        }

        private void HideAllScreens()
        {
            MainMenu.Visibility = Visibility.Collapsed;
            BackToMainMenu.Visibility = Visibility.Collapsed;
            SettingsGrid.Children.Clear();
            GameGrid.Children.Clear();
        }
    }
}
