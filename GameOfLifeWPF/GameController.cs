using GameOfLife.Abstracts;
using System;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;

namespace GameOfLifeWPF
{
    class GameController : GameOfLifeUI
    {
        private GameOfLifeFrame frame { get; set; }

        private bool[][] frameRepresentation;

        private DataGrid renderer;

        public GameController(DataGrid renderer)
        {
            this.renderer = renderer;
            renderer.AutoGenerateColumns = false;
            Reset();
        }

        public override GameOfLifeFrame GetCurrentFrame()
        {
            return frame;
        }

        public override void SetNewFrame(GameOfLifeFrame frame)
        {
            this.frame = frame;
            frameRepresentation = frame.Select(r => r.ToArray()).ToArray();

            renderer.Columns.Clear();
            for (int i = 0; i < frame.U; ++i)
                renderer.Columns.Add(new DataGridCheckBoxColumn()
                {
                    Binding = new Binding(String.Format("[{0}]", i))
                });

            renderer.ItemsSource = frameRepresentation;
        }

        public void Reset()
        {
            SetNewFrame(CreateNewFrame());
        }
    }
}
