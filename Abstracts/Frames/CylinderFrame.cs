namespace GameOfLife.Frames
{
    class CylinderFrame : GameOfLife.Frames.LoopedFrame
    {
        public CylinderFrame(int U, int V) : base(U, V) { }

        public override bool this[int i, int j]
        {
            get
            {
                if (j < 0 || j >= V) return false;
                else return frame[CorrectIndex(i, U), j];
            }
            set
            {
                if (j < 0 || j >= V) return;
                frame[CorrectIndex(i, U), j] = value;
            }
        }

        public override Abstracts.GameOfLifeFrame New()
        {
            return new CylinderFrame(U, V);
        }
    }
}
