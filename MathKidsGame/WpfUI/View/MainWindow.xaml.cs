using WpfUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowSettings(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Collapsed;
            GameSettingsScreen.Visibility = Visibility.Visible;
            BackToMainMenu.Visibility = Visibility.Visible;
        }

        private void PlayGame(object sender, RoutedEventArgs e)
        {

        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Visible;
            GameSettingsScreen.Visibility = Visibility.Collapsed;
            BackToMainMenu.Visibility = Visibility.Collapsed;
        }
    }
}
