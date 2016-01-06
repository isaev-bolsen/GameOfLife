using GameOfLife.Abstracts;
using System;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Collections.Generic;

namespace GameOfLifeWPF
{
    class GameController : GameOfLifeUI
    {
        public GameOfLifeFrame frame { get; private set; }
        private Image renderer;
        private Dispatcher Dispatcher;
        private readonly BitmapPalette palette = new BitmapPalette(new List<Color> { Colors.Black, Colors.Green });


        public GameController(Image renderer)
        {
            this.renderer = renderer;
            Dispatcher = Dispatcher.CurrentDispatcher;
            Reset();
        }

        public override GameOfLifeFrame GetCurrentFrame()
        {
            return frame;
        }

        public override void SetNewFrame(GameOfLifeFrame frame)
        {
            Dispatcher.Invoke(() => SetFrame(frame));
        }

        private void SetFrame(GameOfLifeFrame frame)
        {
            this.frame = frame;
            renderer.Source = null;
            renderer.Source = BitmapSource.Create(frame.U, frame.V, 8, 8, PixelFormats.Indexed8, palette, GetBytes(frame), frame.U);
        }

        private Array GetBytes(GameOfLifeFrame frame)
        {
            return frame.SelectMany(r => r.Select(p => Convert.ToByte(p))).ToArray();
        }

        public void Reset()
        {
            SetNewFrame(CreateNewFrame());
        }
    }
}
