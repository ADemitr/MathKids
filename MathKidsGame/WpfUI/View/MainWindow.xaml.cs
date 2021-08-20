using Autofac;
using System.Windows;

namespace WpfUI.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILifetimeScope _container;

        public MainWindow(ILifetimeScope container)
        {
            InitializeComponent();

            _container = container;
        }

        private void ShowSettings(object sender, RoutedEventArgs e)
        {
            HideAllScreens();
            ActiveScreen.Children.Add(_container.Resolve<GameSettingsUC>());
            BackToMainMenu.Visibility = Visibility.Visible;
        }

        private void PlayGame(object sender, RoutedEventArgs e)
        {
            HideAllScreens();
            ActiveScreen.Children.Add(_container.Resolve<GameUC>());
            BackToMainMenu.Visibility = Visibility.Visible;
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            HideAllScreens();
            MainMenu.Visibility = Visibility.Visible;
        }

        private void HideAllScreens()
        {
            MainMenu.Visibility = Visibility.Collapsed;
            BackToMainMenu.Visibility = Visibility.Collapsed;
            ActiveScreen.Children.Clear();
        }
    }
}
