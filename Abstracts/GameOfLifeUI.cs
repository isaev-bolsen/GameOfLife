using GameOfLife.Frames;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Abstracts
{
    public abstract class GameOfLifeUI
    {
        public abstract GameOfLifeFrame GetCurrentFrame();
        public abstract void SetNewFrame(GameOfLifeFrame frame);

        private int u = 50;
        private int v = 50;
        private string type;

        public int U
        {
            get { return u; }
            set { u = value; }
        }

        public int V
        {
            get { return v; }
            set { v = value; }
        }

        public string FrameType
        {
            get { return type; }
            set { type = value; }
        }

        public IEnumerable<string> FrameTypes
        {
            get { return FramesFactory.AvailableTypes; }
        }

        public GameOfLifeUI()
        {
            FrameType = FrameTypes.First();
        }

        public GameOfLifeFrame CreateNewFrame()
        {
            return FramesFactory.GetFarame(FrameType, U, V);
        }
    }
}
