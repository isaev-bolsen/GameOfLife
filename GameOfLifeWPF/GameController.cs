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
            for (int i = 0; i < frameRepresentation[0].Length; ++i)
                for (int j = 0; j < frameRepresentation.Length; ++j)
                    frame[i, j] = frameRepresentation[j][i];

            return frame;
        }

        public override void SetNewFrame(GameOfLifeFrame frame)
        {
            this.frame = frame;
            frameRepresentation = frame.Select(r => r.ToArray()).ToArray();

            if (renderer.Columns.Count != frame.U)
            {
                renderer.Columns.Clear();
                for (int i = 0; i < frame.U; ++i)
                    renderer.Columns.Add(new DataGridCheckBoxColumn()
                    {
                        Binding = new Binding(String.Format("[{0}]", i))
                    });
            }

            renderer.ItemsSource = frameRepresentation;
        }

        public void Reset()
        {
            SetNewFrame(CreateNewFrame());
        }
    }
}
