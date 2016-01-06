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
        private GameOfLifeFrame frame { get;  set; }
        private Image renderer;
        private Dispatcher Dispatcher;
        private readonly BitmapPalette palette = new BitmapPalette(new List<Color> { Colors.Black, Colors.Green });

        public GameController(Image renderer)
        {
            this.renderer = renderer;
            Dispatcher = Dispatcher.CurrentDispatcher;
            Reset();
        }

        private void SetPixel(int x,int y)
        {
            frame[x, y] = !frame[x, y];
            RedrawFrame();
        }

        public void SetPixel(double x, double y)
        {
            double HalfOfCell = renderer.ActualWidth / frame.U / 2;
            SetPixel(
                Convert.ToInt32((y - HalfOfCell) / renderer.ActualWidth * frame.U),
                Convert.ToInt32((x - HalfOfCell) / renderer.ActualHeight * frame.V)
                );
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
            RedrawFrame();
        }

        private void RedrawFrame()
        {
            renderer.Source = null;
            renderer.Source = BitmapSource.Create(frame.U, frame.V, 8, 8, PixelFormats.Indexed8, palette, GetBytes(), frame.U);
        }

        private Array GetBytes()
        {
            return frame.SelectMany(r => r.Select(p => Convert.ToByte(p))).ToArray();
        }

        public void Reset()
        {
            SetNewFrame(CreateNewFrame());
        }
    }
}
