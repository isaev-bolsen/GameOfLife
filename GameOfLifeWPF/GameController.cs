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
        public GameOfLifeFrame frame
        { get; set; }

        public override GameOfLifeFrame GetCurrentFrame()
        {
            return frame;
        }

        public override void SetNewFrame(GameOfLifeFrame frame)
        {
            this.frame = frame;
        }

        public void Reset()
        {
            frame = CreateNewFrame();
        }
    }
}
