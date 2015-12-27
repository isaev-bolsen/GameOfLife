namespace GameOfLife.Frames
{
    public class LimitedFrame : GameOfLife.Abstracts.GameOfLifeFrame
    {
        public LimitedFrame(int U, int V) : base(U, V) { }

        public override bool this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= U || j < 0 || j >= V) return false;
                else return frame[i, j];
            }
            set
            {
                if (i < 0 || i >= U || j < 0 || j >= V) return;
                frame[i, j] = value;
            }
        }

        public override Abstracts.GameOfLifeFrame New()
        {
            return new LimitedFrame(U, V);
        }
    }
}
