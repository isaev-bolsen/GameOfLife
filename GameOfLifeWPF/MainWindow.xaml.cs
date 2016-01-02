using System.Windows;
using System.Windows.Controls;

namespace GameOfLifeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameController GameController;
        private GameOfLife.Abstracts.GameOfLife Game;

        public MainWindow()
        {
            InitializeComponent();
            GameController = new GameController(FrameRenderer);
            Game = new GameOfLife.Abstracts.GameOfLife(GameController);
            SettingsToolBar.DataContext = GameController;
        }

        private void StepButton_Click(object sender, RoutedEventArgs e)
        {
            Game.Next();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            GameController.Reset();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Game.StartStop();
            if (button.Content.ToString() == "Start") button.Content = "Stop";
            else button.Content = "Start";
        }
    }
}
