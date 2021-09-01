using Autofac;
using MathKidsCore.Model;
using System.Windows;
using System.Windows.Input;

namespace WpfUI.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILifetimeScope _container;
        private GameSettingsModel _settings;

        public MainWindow(ILifetimeScope container, GameSettingsModel gameSettings)
        {
            InitializeComponent();

            _container = container;
            _settings = gameSettings;

            GameSettingsModel.Load(_settings);
            userName.Text = _settings.CurrentUserName;
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

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Kill logical focus
            FocusManager.SetFocusedElement(FocusManager.GetFocusScope(userName), null);
            // Kill keyboard focus
            Keyboard.ClearFocus();

            _settings.CurrentUserName = userName.Text;
            GameSettingsModel.Save(_settings);
        }
    }
}
