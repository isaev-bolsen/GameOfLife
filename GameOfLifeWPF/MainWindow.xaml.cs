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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameOfLife.Abstracts;

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
            Game = new GameOfLife.Abstracts.GameOfLife(GameController);
            GameController = new GameController(FrameRenderer);
            SettingsToolBar.DataContext = GameController;
        }

        private void StepButton_Click(object sender, RoutedEventArgs e)
        {
            Game.Next();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            var res = FrameRenderer.ItemsSource;

            GameController.Reset();
        }
    }
}
