using GameOfLife.Abstracts;
using System.Windows.Controls;

namespace GameOfLifeWPF
{
    class GameController : GameOfLifeUI
    {
        public GameOfLifeFrame frame
        { get; set; }

        private ItemsControl renderer;

        public GameController(ItemsControl renderer)
        {
            this.renderer = renderer;
            Reset();
        }

        public override GameOfLifeFrame GetCurrentFrame()
        {
            return frame;
        }

        public override void SetNewFrame(GameOfLifeFrame frame)
        {
            this.frame = frame;
            renderer.ItemsSource = frame;
        }

        public void Reset()
        {
            SetNewFrame(CreateNewFrame());
        }
    }
}
