using System.Windows;

namespace WpfUI.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private void ShowSettings(object sender, RoutedEventArgs e) => ShowScreen(GameSettingsScreen);

        private void PlayGame(object sender, RoutedEventArgs e)
        {
            HideAllScreens();
            GameGrid.Children.Add(new GameUC());
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
            GameSettingsScreen.Visibility = Visibility.Collapsed;
            GameGrid.Children.Clear();
        }
    }
}
