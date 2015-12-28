using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Abstracts;
using GameOfLife.Frames;

namespace GameOfLifeWPF
{
    class GameController : GameOfLifeUI
    {
        public int U { get; set; }
        public int V { get; set; }

        private GameOfLifeFrame frame = new LimitedFrame(5, 5);

        public override GameOfLifeFrame GetCurrentFrame()
        {
            if (U <= 0 || V <= 0) return frame;
            if (frame.U == U && frame.V == V) return frame;
            else return new LimitedFrame(U, V);
        }

        public override void SetNewFrame(GameOfLifeFrame frame)
        {
            this.frame = frame;
        }
    }
}
