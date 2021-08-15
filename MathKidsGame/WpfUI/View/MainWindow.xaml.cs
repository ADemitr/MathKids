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

        private void PlayGame(object sender, RoutedEventArgs e) => ShowScreen(GameScreen);

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e) => ShowScreen(MainMenu);

        private void ShowScreen(UIElement screenToShow)
        {
            // Hide all screens and buttons
            MainMenu.Visibility = Visibility.Collapsed;
            GameSettingsScreen.Visibility = Visibility.Collapsed;
            BackToMainMenu.Visibility = Visibility.Collapsed;
            GameScreen.Visibility = Visibility.Collapsed;

            // Show needed
            screenToShow.Visibility = Visibility.Visible;
            if(screenToShow != MainMenu)
            {
                BackToMainMenu.Visibility = Visibility.Visible;
            }
        }
    }
}
