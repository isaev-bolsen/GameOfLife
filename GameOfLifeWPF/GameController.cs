using GameOfLife.Abstracts;
using System;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;

namespace GameOfLifeWPF
{
    class GameController : GameOfLifeUI
    {
        public GameOfLifeFrame frame { get; set; }

        private DataGrid renderer;

        public GameController(DataGrid renderer)
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

            if (renderer.Columns.Count != frame.U)
            {
                renderer.Columns.Clear();
                for (int i = 0; i < frame.U; ++i)
                    renderer.Columns.Add(new DataGridCheckBoxColumn()
                    {
                        Binding = new Binding(String.Format("[{0}]", i))
                    });
            }

            var t = new DataTable();
            for (var c = 0; c < frame.U; c++) t.Columns.Add(new DataColumn(c.ToString()));
            for (var r = 0; r < frame.V; r++)
            {
                var newRow = t.NewRow();
                for (var c = 0; c < frame.U; c++) newRow[c] = frame[r, c];
                t.Rows.Add(newRow);
            }

            renderer.ItemsSource = t.DefaultView;

        }

        public void Reset()
        {
            SetNewFrame(CreateNewFrame());
        }
    }
}
