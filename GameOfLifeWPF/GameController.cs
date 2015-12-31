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
        { get; private set; }

        public int U { get; set; }
        public int V { get; set; }
        public string FrameType { get; set; }
        public IEnumerable<string> FrameTypes
        {
            get { return FramesFactory.AvailableTypes; }
        }

        public GameController()
        {
            FrameType = FrameTypes.First();
            U = 50;
            V = 50;
            frame = CreateNewFrame();
        }

        public override GameOfLifeFrame GetCurrentFrame()
        {
            if (U <= 0 || V <= 0) return frame;
            if (frame.U == U && frame.V == V) return frame;
            else return CreateNewFrame();
        }

        private GameOfLifeFrame CreateNewFrame()
        {
            return FramesFactory.GetFarame(FrameType, U, V);
        }

        public override void SetNewFrame(GameOfLifeFrame frame)
        {
            this.frame = frame;
        }
    }
}
